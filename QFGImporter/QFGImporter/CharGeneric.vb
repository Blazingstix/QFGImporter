Public MustInherit Class CharGeneric
#Region "Constants"
    Friend MustOverride ReadOnly Property OffsetCharClass As Byte
    Friend MustOverride ReadOnly Property OffsetSkills As Byte
    Friend MustOverride ReadOnly Property OffsetExperience As Byte
    Friend MustOverride ReadOnly Property OffsetSpells As Byte
    Friend MustOverride ReadOnly Property OffsetInventory As Byte
    Friend MustOverride ReadOnly Property OffsetOther As Byte
    Friend MustOverride ReadOnly Property OffsetChecksum As Byte
    Friend MustOverride ReadOnly Property OffsetOther2 As Byte
    Friend MustOverride ReadOnly Property OffsetEOF As Byte

    Friend MustOverride ReadOnly Property SkillMaximum As UShort
    Friend MustOverride ReadOnly Property SkillTechnicalMaximum As UShort

    Friend MustOverride ReadOnly Property InitialCipher As Byte
    Friend MustOverride ReadOnly Property InitialChecksum As Byte
    Friend Overridable ReadOnly Property InitialLimiter As Byte
        Get
            Return &HFF
        End Get
    End Property

#End Region


#Region "Basic Properties"

    Public Property Game As Enums.Games
    Public Property Name As String = String.Empty
    Friend Property EncodedData As Byte()
    Friend Property DecodedValues As Byte()
    Friend Property Extra As String

#End Region

#Region "Specific Properties"
    Public Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Property Strength As Integer
        Get
            Return GetSkills(Enums.Skills.Strength)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Strength, value)
        End Set
    End Property

    Public Property Intelligence As Integer
        Get
            Return GetSkills(Enums.Skills.Intelligence)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Intelligence, value)
        End Set
    End Property

    Public Property Agility As Integer
        Get
            Return GetSkills(Enums.Skills.Agility)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Agility, value)
        End Set
    End Property
    Public Property Vitality As Integer
        Get
            Return GetSkills(Enums.Skills.Vitality)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Vitality, value)
        End Set
    End Property
    Public Property Luck As Integer
        Get
            Return GetSkills(Enums.Skills.Luck)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Luck, value)
        End Set
    End Property

    Public Property WeaponUse As Integer
        Get
            Return GetSkills(Enums.Skills.WeaponUse)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.WeaponUse, value)
        End Set
    End Property
    Public Property Parry As Integer
        Get
            Return GetSkills(Enums.Skills.Parry)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Parry, value)
        End Set
    End Property
    Public Property Dodge As Integer
        Get
            Return GetSkills(Enums.Skills.Dodge)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Dodge, value)
        End Set
    End Property
    Public Property Stealth As Integer
        Get
            Return GetSkills(Enums.Skills.Stealth)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Stealth, value)
        End Set
    End Property
    Public Property PickLocks As Integer
        Get
            Return GetSkills(Enums.Skills.Picklocks)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Picklocks, value)
        End Set
    End Property
    Public Property Throwing As Integer
        Get
            Return GetSkills(Enums.Skills.Throwing)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Throwing, value)
        End Set
    End Property
    Public Property Climbing As Integer
        Get
            Return GetSkills(Enums.Skills.Climbing)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Climbing, value)
        End Set
    End Property
    Public Property Magic As Integer
        Get
            Return GetSkills(Enums.Skills.Magic)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Magic, value)
        End Set
    End Property

    Public Overridable Property Experience As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience) = value
        End Set
    End Property

    Public Overridable Property HealthPoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience + 1) / 2
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience + 1) = value * 2
        End Set
    End Property

    Public Overridable Property StaminaPoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience + 2) / 4
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience + 2) = value * 4
        End Set
    End Property

    Public Overridable Property MagicPoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience + 3)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience + 3) = value
        End Set
    End Property

    Public Overridable Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSkills - 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSkills - 2) = value And &HF7
        End Set
    End Property

    Public Overridable Property Daggers As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory) = value
        End Set
    End Property

    Public Overridable Property HealingPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 1)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 1) = value
        End Set
    End Property

    Public Overridable Property MagicPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 2) = value
        End Set
    End Property

    Public Overridable Property StaminaPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 3)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 3) = value
        End Set
    End Property

    Public Overridable Property Currency As Integer
        Get
            Dim hun As Integer = (Me.DecodedValues(Me.OffsetCharClass + 1) - 1) * 100
            Dim tens As Integer = Me.DecodedValues(Me.OffsetCharClass + 2)
            Return hun + tens
        End Get
        Set(value As Integer)
            Dim small As Byte = value Mod 100
            Dim large As Byte = ((value - small) / 100) + 1
            Me.DecodedValues(Me.OffsetCharClass + 1) = large
            Me.DecodedValues(Me.OffsetCharClass + 2) = small
        End Set
    End Property

    Public Overridable Property Flag1 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 0)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 0, value)
        End Set
    End Property

    Public Overridable Property Flag2 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 1)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 1, value)
        End Set
    End Property

    Public Overridable Property Flag3 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 2)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 2, value)
        End Set
    End Property

    Public Overridable Property Flag4 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 3)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 3, value)
        End Set
    End Property

    Public Overridable Property Flag5 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 4)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 4, value)
        End Set
    End Property

    Public Overridable Property Flag6 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 5)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 5, value)
        End Set
    End Property

    Public Overridable Property Flag7 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 6)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 6, value)
        End Set
    End Property

    Public Overridable Property Flag8 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 7)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 7, value)
        End Set
    End Property

#End Region

    Private Function getBit(inputByte As Byte, bit As Byte) As Boolean
        If bit > 7 Then
            Return 0
        End If
        Dim mask As Byte = 1 << bit

        Return inputByte And mask
    End Function

    Private Function toggleBit(inputByte As Byte, bit As Byte) As Byte
        If bit > 7 Then
            Return inputByte
        End If
        Dim mask As Byte = 1 << bit
        Return inputByte Xor mask
    End Function

    Private Function setBit(inputByte As Byte, bit As Byte, value As Boolean) As Byte
        If bit > 7 Then
            Return inputByte
        End If
        Dim mask As Byte = 1 << bit
        If value Then
            Return inputByte Or mask
        Else
            Return inputByte And (&HFF Xor mask)
        End If
    End Function

    Public Sub SetSkill(skills As Enums.Skills, value As Integer)
        Me.DecodedValues(Me.OffsetSkills + skills) = value
    End Sub
    Public Function GetSkills(skills As Enums.Skills) As Integer
        Return Me.DecodedValues(Me.OffsetSkills + skills)
    End Function

    Public Sub SetMagicSpell(spell As Enums.Magic, value As Integer)
        Me.DecodedValues(Me.OffsetSpells + spell) = value
    End Sub

    Public Function GetMagicSpell(spell As Enums.Magic) As Integer
        Return Me.DecodedValues(Me.OffsetSpells + spell)
    End Function


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
            Me.EncodedData = convertHexStringToByteArray(data)
            Call Me.DecodeValues()
        End If
    End Sub

    Public Sub DecodeValues()
        Me.DecodedValues = Me.GetDecodedBytes(Me.EncodedData)
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

    Friend MustOverride Sub SetGame()

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
            'Dim dataBytes As Byte() = convertHexStringToByteArray(data)
            'Dim values As Integer() = Me.DecodeBytes(dataBytes)
            'Dim chk As Byte() = Checksums(values)
        End If
        Return lines
    End Function

    Public Shared Function convertHexStringToByteArray(hexString As String) As Byte()
        Dim upperBound As Integer = Math.Ceiling(hexString.Length / 2)
        Dim buffer(upperBound - 1) As Byte

        For i As Integer = 0 To upperBound - 1
            Dim tempStr As String = hexString.Substring(i * 2, 2).Trim
            buffer(i) = Convert.ToByte(tempStr, 16)
        Next
        Return buffer
    End Function

    Public Function GetDecodedBytes(encodedData As Byte()) As Byte()
        Select Case Me.Game
            Case Enums.Games.QFG1, Enums.Games.QFG2
                Return CharGeneric.DecodeBytesXor(encodedData, Me.InitialCipher, Me.InitialLimiter)
            Case Enums.Games.QFG3
                Dim i(encodedData.Length - 1) As Byte
                For x As Integer = 0 To encodedData.Length - 1
                    i(x) = encodedData(x)
                Next
                Return i
            Case Else
                'for everything else, do not even try to decode the values
                Dim i(encodedData.Length - 1) As Byte
                For x As Integer = 0 To encodedData.Length - 1
                    i(x) = encodedData(x)
                Next
                Return i
        End Select
    End Function

    Public Function GetEncodedBytes(decodedValues As Byte()) As Byte()
        Select Case Me.Game
            Case Enums.Games.QFG1, Enums.Games.QFG2
                Return CharGeneric.EncodeBytesXor(decodedValues, Me.InitialCipher, Me.InitialLimiter)
            Case Enums.Games.QFG3
                'for everything else, do not even try to decode the values
                Dim b(decodedValues.Length - 1) As Byte
                For x As Integer = 0 To decodedValues.Length - 1
                    b(x) = EncodedData(x)
                Next
                Return b
            Case Else
                'for everything else, do not even try to decode the values
                Dim b(decodedValues.Length - 1) As Byte
                For x As Integer = 0 To decodedValues.Length - 1
                    b(x) = EncodedData(x)
                Next
                Return b
        End Select
    End Function

    Public Shared Function DecodeBytesXor(encodedData As Byte(), initialCipher As Byte, Optional Limiter As Byte = Byte.MaxValue) As Byte()
        Dim decodedValues(encodedData.Length - 1) As Byte

        For i As Integer = 0 To encodedData.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = initialCipher
            Else
                cipher = encodedData(i - 1) And Limiter
            End If

            decodedValues(i) = encodedData(i) Xor cipher
        Next

        Return decodedValues
    End Function

    Public Shared Function DecodeBytesXor(encodedData As Short(), initialCipher As Short, Optional Limiter As Short = Short.MaxValue) As Short()
        Dim decodedValues(encodedData.Length - 1) As Short

        For i As Integer = 0 To encodedData.Length - 1
            Dim cipher As Short
            If i = 0 Then
                cipher = initialCipher
            Else
                cipher = encodedData(i - 1) And Limiter
            End If

            decodedValues(i) = encodedData(i) Xor cipher
        Next

        Return decodedValues
    End Function


    Public Shared Function EncodeBytesXor(decodedValues As Byte(), initialCipher As Byte, Optional Limiter As Byte = Byte.MaxValue) As Byte()
        Dim encodedData(decodedValues.Length - 1) As Byte

        For i As Integer = 0 To decodedValues.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = initialCipher
            Else
                ' use the previously (just) encoded value as a cipher for the next value to encode
                cipher = encodedData(i - 1) And Limiter
            End If

            encodedData(i) = decodedValues(i) Xor cipher
        Next

        Return encodedData
    End Function

    Private Function Checksums(values As Byte()) As Byte()
        Dim chk() As Byte = {0, 0}

        'check even values
        For i As Integer = 0 To Me.OffsetOther - 1 Step 2
            chk(0) = (chk(0) + values(i)) Mod &H100
        Next

        'check odd values
        For i As Integer = 1 To Me.OffsetOther - 1 Step 2
            chk(1) = (chk(1) + values(i)) Mod &H100
        Next

        'add 0xCE (206) to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) Mod &H100

        'the InitialLimiter is neccessary for QFG1,
        '   where all the bytes are only 7 bits (i.e. 127 max)
        chk(0) = chk(0) And Me.InitialLimiter
        chk(1) = chk(1) And Me.InitialLimiter

        Return chk
    End Function

    Private Function VerifyChecksums() As Boolean
        Dim chk() As Byte = Checksums(Me.DecodedValues)
        Return (chk(0) = Me.DecodedValues(Me.OffsetChecksum) AndAlso chk(1) = Me.DecodedValues(Me.OffsetChecksum + 1))
    End Function

    Private Sub SetChecksums()
        Dim chk() As Byte = Me.Checksums(Me.DecodedValues)
        'replace checksum with calculated values
        For i As Integer = 0 To chk.Length - 1
            Me.DecodedValues(Me.OffsetChecksum + i) = chk(i)
        Next
    End Sub

    Private Sub EncodeValues()
        Call SetChecksums()
        Me.EncodedData = Me.GetEncodedBytes(Me.DecodedValues)
    End Sub

    Public Sub New()
        Call SetGame()
    End Sub

    Public Function DecodedValuesToString() As String
        Return CharGeneric.BytesToString(Me.DecodedValues)
    End Function

    Public Shared Function BytesToString(byteArray As Byte()) As String
        Dim values As String = String.Empty
        For Each i As Integer In byteArray
            values &= i.ToString("X2") & " "
        Next
        Return values.Trim
    End Function

    Public Shared Function BytesToString(shortArray As UShort()) As String
        Dim values As String = String.Empty
        For Each i As Integer In shortArray
            values &= i.ToString("X4") & " "
        Next
        Return values.Trim
    End Function

    Public Function ToByteString() As String
        Call EncodeValues()
        Dim str As String = String.Empty
        str = Me.Name & vbLf
        For Each b As Byte In Me.EncodedData
            Dim hex As String = " " & b.ToString("X").ToLower
            hex = hex.Substring(hex.Length - 2)
            str &= hex
        Next
        str &= vbLf
        Return str
    End Function
End Class
