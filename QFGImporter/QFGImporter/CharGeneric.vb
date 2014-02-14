Public MustInherit Class CharGeneric
#Region "Constants"
    Public Const QFGFileFilter As String = "QFG Import Character (*.sav)|*.sav|All Files (*.*)|*.*"

    Friend MustOverride ReadOnly Property OffsetCharClass As Byte
    Friend MustOverride ReadOnly Property OffsetSkills As Byte
    Friend MustOverride ReadOnly Property OffsetExperience As Byte
    Friend MustOverride ReadOnly Property OffsetSpells As Byte
    Friend MustOverride ReadOnly Property OffsetInventory As Byte
    Friend MustOverride ReadOnly Property OffsetConstants1 As Byte
    Friend MustOverride ReadOnly Property OffsetChecksum As Byte
    Friend MustOverride ReadOnly Property OffsetConstants2 As Byte
    Friend MustOverride ReadOnly Property OffsetEOF As Byte
    Friend MustOverride ReadOnly Property DataSize As Byte

    Friend Overridable ReadOnly Property OffsetCurrency As Byte
        Get
            Return Me.OffsetCharClass + 1
        End Get
    End Property
    Friend Overridable ReadOnly Property OffsetPuzzlePoints As Byte
        Get
            Return Me.OffsetSkills - 2
        End Get
    End Property
    Friend Overridable ReadOnly Property OffsetUniqueInventory As Byte
        Get
            Return Me.OffsetSkills - 1
        End Get
    End Property
    Friend MustOverride ReadOnly Property SkillMaximum As UShort
    Friend MustOverride ReadOnly Property SkillTechnicalMaximum As UShort

    Friend Overridable ReadOnly Property InitialCipher As Byte
        Get
            Return &H53
        End Get
    End Property
    Friend MustOverride ReadOnly Property InitialChecksum As Byte
    Friend Overridable ReadOnly Property InitialLimiter As Byte
        Get
            Return Byte.MaxValue
        End Get
    End Property

    Friend MustOverride Sub SetGame()

#End Region


#Region "Basic Properties"

    Friend Property EncodedData As Byte()
    Friend Property DecodedValues As Byte()

    Public Property Game As Enums.Games
    Public Property Name As String = String.Empty
    Friend Property Extra As String
    Friend Property EncodedString As String

#End Region

#Region "Specific Properties"
    Public MustOverride Property CharacterClass As Enums.CharacterClass
    Public MustOverride Property Currency As Integer
    Public MustOverride Property PuzzlePoints As Integer
    Public MustOverride Property Flag(position As Byte) As Boolean

    Public MustOverride Property Skill(vSkill As Enums.Skills) As Integer
    Public MustOverride Property OtherSkill(skill As Enums.OtherSkills) As Integer
    Public MustOverride Property MagicSpell(spell As Enums.Magic) As Integer
    Public MustOverride Property Inventory(item As Enums.Inventory) As Integer

#End Region

    Public MustOverride Sub DecodeValues()
    Friend MustOverride Sub ParseHexString(hexString As String)
    Friend MustOverride Sub EncodeValues()
    Friend MustOverride Sub SetChecksums()

    Public Sub Load(fileContents As String)
        Dim lines As String() = Me.ParseCharacter(fileContents)
        If lines.Length > 1 Then
            Dim data As String = String.Empty
            If Me.Game = Enums.Games.QFG1 Or Me.Game = Enums.Games.QFG2 Then
                Me.Name = lines(0)
                data = lines(1)
                If lines.Length > 2 Then
                    Me.Extra = lines(2)
                End If
            Else
                Me.Name = lines(1)
                data = lines(2)
                If lines.Length > 3 Then
                    Me.Extra = lines(3)
                End If
            End If
            Me.EncodedString = data

            If Me.Game = Enums.Games.QFG3 AndAlso Me.EncodedString.Length <> 208 Then
                'QFG3 data longer than 208 characters is victim to an overflow error... we cannot deal with that yet.
                MessageBox.Show("This saved character has " & Me.EncodedString.Length & " characters in the data portion of the file." & vbCrLf & "QFG3 files with data larger than 208 characters can an error, and this program cannot work around that yet.")
                'Exit Sub
            End If

            'NOTE: we need to seperate this out, so QFG3 and QFG4 can call their own conversion functions
            Call ParseHexString(Me.EncodedString)
            Call Me.DecodeValues()
        End If
    End Sub

    Public Shared Function GetGame(FileContents As String) As Enums.Games
        Dim lines As String() = CharGeneric.SplitInputFile(FileContents)
        If lines IsNot Nothing AndAlso lines.Length > 1 Then
            If lines(0).Trim = "glory3.sav" Then
                Return Enums.Games.QFG3
            ElseIf lines(0).Trim = "glory4.sav" Then
                Return Enums.Games.QFG4
            ElseIf lines(1).Length = 86 Then
                Return Enums.Games.QFG1
            ElseIf lines(1).Length = 96 Then
                Return Enums.Games.QFG2
            Else

            End If
        End If
        'Throw New Exception("File not recognised")
        MessageBox.Show("Not Recognised")
        Return Nothing
    End Function

    Public Shared Function SplitInputFile(import As String) As String()
        If import.Contains(vbCrLf) Then
            import = import.Replace(vbCrLf, vbLf)
        End If
        Dim splitChars As Char() = {vbLf}
        'start off assuming it's QFG1 or QFG2, but if it's QFG3 or QFG4, 
        '   then we'll re-split it acordingly
        'NOTE: this is done in an effort to still support the files created by my
        '   original QFG Importer '95. In that program, I appended a text disclaimer 
        '   to the end of each created file.
        Dim lines() As String = import.Split(splitChars, 3)
        If lines(0).Trim.Equals("glory3.sav") Or lines(0).Trim.Equals("glory4.sav") Then
            lines = import.Split(splitChars, 4)
        End If
        Return lines
    End Function

    Public Function ParseCharacter(import As String) As String()
        Dim lines As String() = SplitInputFile(import)
        Dim name As String
        Dim data As String
        Dim extra As String = String.Empty
        If lines.Length > 1 Then
            If Me.Game = Enums.Games.QFG1 Or Me.Game = Enums.Games.QFG2 Then
                name = lines(0)
                data = lines(1)
                If lines.Length > 2 Then
                    extra = lines(2)
                End If
            Else
                name = lines(1)
                data = lines(2)
                If lines.Length > 3 Then
                    extra = lines(3)
                End If
            End If
        End If
        Return lines
    End Function

    ''' <summary>
    ''' QFG1/2 calls this function, while QFG3/4 calls a shadow function
    ''' </summary>
    ''' <param name="values"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overridable Function CalculateChecksums(values As Byte()) As Byte()
        Dim chk() As Byte = {0, 0}

        'all even values are summed, as are all odd values.
        For i As Integer = 0 To Me.OffsetConstants1 - 1
            chk(i Mod 2) = (CInt(chk(i Mod 2)) + CInt(values(i))) Mod &H100
        Next

        'add a constant value to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) Mod &H100

        'the InitialLimiter is neccessary for QFG1,
        '   where all the bytes are only 7 bits (i.e. 127 max)
        chk(0) = chk(0) And Me.InitialLimiter
        chk(1) = chk(1) And Me.InitialLimiter

        Return chk
    End Function

    Friend MustOverride Function VerifyChecksums() As Boolean

    Public Sub New()
        Call SetGame()
    End Sub

    Public MustOverride ReadOnly Property HeaderString As String
    Public MustOverride Function EncodedDataToString() As String

    ''' <summary>
    ''' FOR DEBUG ONLY
    ''' Outputs the Decoded Values to a space separated text string.
    ''' </summary>
    ''' <param name="hex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function DecodedValuesToString(Optional hex As Boolean = True) As String

    ''' <summary>
    ''' Updates the checksums, and the encoded values, then returns the string to be saved to a file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExportString() As String
        Call EncodeValues()

        Dim str As String = String.Empty
        str = Me.HeaderString
        str &= Me.Name & vbLf
        str &= Me.EncodedDataToString & vbLf
        Return str
    End Function



End Class
