Public MustInherit Class CharGeneric
#Region "Constants"
    Public Const QFGFileFilter As String = "QFG Import Character (*.sav)|*.sav|All Files (*.*)|*.*"

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
    Public Property CharacterClass As Enums.CharacterClass
        Get
            If TypeOf Me Is CharV1 Then
                Return DirectCast(Me, CharV1).CharacterClass
            Else
                Return DirectCast(Me, CharV2).CharacterClass
            End If
        End Get
        Set(value As Enums.CharacterClass)
            If TypeOf Me Is CharV1 Then
                DirectCast(Me, CharV1).CharacterClass = value
            Else
                DirectCast(Me, CharV2).CharacterClass = value
            End If
        End Set
    End Property

    Public Property Strength As Integer
        Get
            Return GetSkill(Enums.Skills.Strength)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Strength, value)
        End Set
    End Property

    Public Property Intelligence As Integer
        Get
            Return GetSkill(Enums.Skills.Intelligence)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Intelligence, value)
        End Set
    End Property

    Public Property Agility As Integer
        Get
            Return GetSkill(Enums.Skills.Agility)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Agility, value)
        End Set
    End Property
    Public Property Vitality As Integer
        Get
            Return GetSkill(Enums.Skills.Vitality)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Vitality, value)
        End Set
    End Property
    Public Property Luck As Integer
        Get
            Return GetSkill(Enums.Skills.Luck)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Luck, value)
        End Set
    End Property

    Public Property WeaponUse As Integer
        Get
            Return GetSkill(Enums.Skills.WeaponUse)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.WeaponUse, value)
        End Set
    End Property
    Public Property Parry As Integer
        Get
            Return GetSkill(Enums.Skills.Parry)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Parry, value)
        End Set
    End Property
    Public Property Dodge As Integer
        Get
            Return GetSkill(Enums.Skills.Dodge)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Dodge, value)
        End Set
    End Property
    Public Property Stealth As Integer
        Get
            Return GetSkill(Enums.Skills.Stealth)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Stealth, value)
        End Set
    End Property
    Public Property PickLocks As Integer
        Get
            Return GetSkill(Enums.Skills.Picklocks)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Picklocks, value)
        End Set
    End Property
    Public Property Throwing As Integer
        Get
            Return GetSkill(Enums.Skills.Throwing)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Throwing, value)
        End Set
    End Property
    Public Property Climbing As Integer
        Get
            Return GetSkill(Enums.Skills.Climbing)
        End Get
        Set(value As Integer)
            Me.SetSkill(Enums.Skills.Climbing, value)
        End Set
    End Property
    Public Property Magic As Integer
        Get
            Return GetSkill(Enums.Skills.Magic)
        End Get
        Set(value As Integer)
            Me.SetSkill(Enums.Skills.Magic, value)
        End Set
    End Property

    Public Overridable Property Experience As Integer
        Get
            Return Me.GetOtherSkill(Enums.OtherSkills.Experience)
        End Get
        Set(value As Integer)
            Me.SetOtherSkill(Enums.OtherSkills.Experience, value)
        End Set
    End Property

    Public Overridable Property HealthPoints As Integer
        Get
            Return Me.GetOtherSkill(Enums.OtherSkills.HealthPoints)
        End Get
        Set(value As Integer)
            Me.SetOtherSkill(Enums.OtherSkills.HealthPoints, value)
        End Set
    End Property

    Public Overridable Property StaminaPoints As Integer
        Get
            Return Me.GetOtherSkill(Enums.OtherSkills.StaminaPoints)
        End Get
        Set(value As Integer)
            Me.SetOtherSkill(Enums.OtherSkills.StaminaPoints, value)
        End Set
    End Property

    Public Overridable Property MagicPoints As Integer
        Get
            Return Me.GetOtherSkill(Enums.OtherSkills.MagicPoints)
        End Get
        Set(value As Integer)
            Me.SetOtherSkill(Enums.OtherSkills.MagicPoints, value)
        End Set
    End Property

    Public Overridable Property PuzzlePoints As Integer
        Get
            If TypeOf Me Is CharV1 Then
                Return DirectCast(Me, CharV1).PuzzlePoints
            Else
                Return DirectCast(Me, CharV2).PuzzlePoints
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV1 Then
                DirectCast(Me, CharV1).PuzzlePoints = value
            Else
                DirectCast(Me, CharV2).PuzzlePoints = value
            End If
        End Set
    End Property

    Public Overridable Property Daggers As Integer
        Get
            If TypeOf Me Is CharV2 Then
                Return DirectCast(Me, CharV2).Daggers
            Else
                Return Me.DecodedValues(Me.OffsetInventory)
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV2 Then
                DirectCast(Me, CharV2).Daggers = value
            Else
                Me.DecodedValues(Me.OffsetInventory) = value
            End If
        End Set
    End Property

    Public Overridable Property HealingPotions As Integer
        Get
            If TypeOf Me Is CharV2 Then
                Return DirectCast(Me, CharV2).HealingPotions
            Else
                Return Me.DecodedValues(Me.OffsetInventory + 1)
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV2 Then
                DirectCast(Me, CharV2).HealingPotions = value
            Else
                Me.DecodedValues(Me.OffsetInventory + 1) = value
            End If
        End Set
    End Property

    Public Overridable Property MagicPotions As Integer
        Get
            If TypeOf Me Is CharV2 Then
                Return DirectCast(Me, CharV2).MagicPotions
            Else
                Return Me.DecodedValues(Me.OffsetInventory + 2)
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV2 Then
                DirectCast(Me, CharV2).MagicPotions = value
            Else
                Me.DecodedValues(Me.OffsetInventory + 2) = value
            End If
        End Set
    End Property

    Public Overridable Property StaminaPotions As Integer
        Get
            If TypeOf Me Is CharV2 Then
                Return DirectCast(Me, CharV2).StaminaPotions
            Else
                Return Me.DecodedValues(Me.OffsetInventory + 3)
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV2 Then
                DirectCast(Me, CharV2).StaminaPotions = value
            Else
                Me.DecodedValues(Me.OffsetInventory + 3) = value
            End If
        End Set
    End Property

    Public Overridable Property Currency As Integer
        Get
            If TypeOf Me Is CharV1 Then
                Return DirectCast(Me, CharV1).Currency
            Else
                Return DirectCast(Me, CharV2).Currency
            End If
        End Get
        Set(value As Integer)
            If TypeOf Me Is CharV1 Then
                DirectCast(Me, CharV1).Currency = value
            Else
                DirectCast(Me, CharV2).Currency = value
            End If
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

    Public Shared Function getBit(inputByte As Byte, bit As Byte) As Boolean
        If bit > 7 Then
            Return 0
        End If
        Dim mask As Byte = 1 << bit

        Return inputByte And mask
    End Function

    Public Shared Function toggleBit(inputByte As Byte, bit As Byte) As Byte
        If bit > 7 Then
            Return inputByte
        End If
        Dim mask As Byte = 1 << bit
        Return inputByte Xor mask
    End Function

    Public Shared Function setBit(inputByte As Byte, bit As Byte, value As Boolean) As Byte
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

    Public Sub SetSkill(skill As Enums.Skills, value As Integer)
        If TypeOf Me Is CharV2 Then
            DirectCast(Me, CharV2).SetSkill(skill, value)
        Else
            DirectCast(Me, CharV1).SetSkill(skill, value)
        End If
    End Sub
    Public Function GetSkill(skill As Enums.Skills) As Integer
        If TypeOf Me Is CharV2 Then
            Return DirectCast(Me, CharV2).GetSkill(skill)
        Else
            Return DirectCast(Me, CharV1).GetSkill(skill)
        End If
    End Function

    Public Sub SetMagicSpell(spell As Enums.Magic, value As Integer)
        If TypeOf Me Is CharV2 Then
            DirectCast(Me, CharV2).SetMagicSpell(spell, value)
        Else
            DirectCast(Me, CharV1).SetMagicSpell(spell, value)
        End If
    End Sub

    Public Function GetMagicSpell(spell As Enums.Magic) As Integer
        If TypeOf Me Is CharV2 Then
            Return DirectCast(Me, CharV2).GetMagicSpell(spell)
        Else
            Return DirectCast(Me, CharV1).GetMagicSpell(spell)
        End If
    End Function

    Public Sub SetOtherSkill(skill As Enums.OtherSkills, value As Integer)
        If TypeOf Me Is CharV2 Then
            DirectCast(Me, CharV2).SetOtherSkill(skill, value)
        Else
            DirectCast(Me, CharV1).SetOtherSkill(skill, value)
        End If
    End Sub

    Public Function GetOtherSkill(skill As Enums.OtherSkills) As Integer
        If TypeOf Me Is CharV2 Then
            Return DirectCast(Me, CharV2).GetOtherSkill(skill)
        Else
            Return DirectCast(Me, CharV1).GetOtherSkill(skill)
        End If
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
            Me.EncodedString = data

            If Me.Game = Enums.Games.QFG3 AndAlso Me.EncodedString.Length <> 208 Then
                'QFG3 data longer than 208 characters is victim to an overflow error... we cannot deal with that yet.
                MessageBox.Show("This saved character has " & Me.EncodedString.Length & " characters in the data portion of the file." & vbCrLf & "QFG3 files with data larger than 208 characters can an error, and this program cannot work around that yet.")
                Exit Sub
            End If

            'NOTE: we need to seperate this out, so QFG3 and QFG4 can call their own conversion functions
            Call ConvertHexStringToBinary(Me.EncodedString)
            Call Me.DecodeValues()
        End If
    End Sub

    Public Overridable Sub DecodeValues()
        Me.DecodedValues = Me.GetDecodedBinary(Me.EncodedData)
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

    Friend Overridable Sub ConvertHexStringToBinary(hexString As String)
        Me.EncodedData = convertHexStringToByteArray(hexString)
    End Sub

    ''' <summary>
    ''' This is used for QFG1 and QFG2
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertHexStringToByteArray(hexString As String) As Byte()
        Dim upperBound As Integer = Math.Ceiling(hexString.Length / 2)
        Dim buffer(upperBound - 1) As Byte

        For i As Integer = 0 To upperBound - 1
            Dim indexInString As Integer = i * 2
            Dim tempHex As String = String.Empty
            If indexInString < hexString.Length - 1 Then
                tempHex = hexString.Substring(indexInString, 2).Trim()
            Else
                'NOTE: In QFG3/4, overflow errors can cause the data string to be unexpectedly long.
                '   At some point, I will attempt to read this properly, but until then if we are 
                '   one character short for a full byte we add a 0 to the end of the last character.
                tempHex = hexString.Substring(indexInString, 1).Trim & "0"
            End If
            buffer(i) = Convert.ToByte(tempHex, 16)
        Next
        Return buffer
    End Function

    ''' <summary>
    ''' This is used for QFG3/4.
    ''' It is a custom two-byte word conversion, for QFG3/4.
    ''' AA BB = (AA*100)+BB
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks>Does not work if there are errors/overage in the SAV file</remarks>
    Public Shared Function convertHexStringToShortArray(hexString As String) As Short()
        'TODO: Some day, we need to account for data length overflow errors.
        Debug.Print(hexString)
        Dim tempByte() As Byte = convertHexStringToByteArray(hexString)

        Dim chkByte As String = String.Empty
        For Each x As Byte In tempByte
            chkByte &= x.ToString("X2") & " "
        Next
        Debug.Print(chkByte)

        Dim x2((tempByte.Length / 2) - 1) As Short
        For i As Integer = 0 To tempByte.Length - 1 Step 2
            Dim val As Short = tempByte(i) * 100 + tempByte(i + 1)
            x2(i / 2) = val
        Next

        Dim tmpstr As String = String.Empty
        For Each x As Short In x2
            tmpstr &= x.ToString("X4") & " "
        Next
        Debug.Print(tmpstr)


        Return x2
    End Function

    Public Function GetDecodedBinary(encodedData As Byte()) As Byte()
        Select Case Me.Game
            Case Enums.Games.QFG1, Enums.Games.QFG2
                Return CharGeneric.DecodeBytesXor(encodedData, Me.InitialCipher, Me.InitialLimiter)
            Case Else
                'for everything else, do not even try to decode the values
                Return encodedData
        End Select
    End Function

    Public Function GetDecodedBinary(encodedData As Short()) As Short()
        Return CharGeneric.DecodeBytesXor(encodedData, Me.InitialCipher)
    End Function

    Public Function GetEncodedBinary(decodedValues As Byte()) As Byte()
        Select Case Me.Game
            Case Enums.Games.QFG1, Enums.Games.QFG2
                Return CharGeneric.EncodeBytesXor(decodedValues, Me.InitialCipher, Me.InitialLimiter)
            Case Else
                'for everything else, do not even try to decode the values
                Return decodedValues
        End Select
    End Function

    Public Function GetEncodedBinary(decodedValues As Short()) As Short()
        Return CharGeneric.EncodeBytesXor(decodedValues, Me.InitialCipher)
    End Function

    ''' <summary>
    ''' The main method of encription that QFG1/2 saved characters use
    ''' </summary>
    ''' <param name="encodedData"></param>
    ''' <param name="initialCipher"></param>
    ''' <param name="Limiter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

        Dim chkDecodedShort As String = String.Empty
        For Each x As Short In decodedValues
            chkDecodedShort &= x.ToString("X4") & " "
        Next
        Debug.Print(chkDecodedShort)
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

    Public Shared Function EncodeBytesXor(decodedValues As Short(), initialCipher As Short, Optional Limiter As Short = Short.MaxValue) As Short()
        Dim encodedData(decodedValues.Length - 1) As Short

        For i As Integer = 0 To decodedValues.Length - 1
            Dim cipher As Short
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

    Public Shared Function BitShift(byteArray As Byte(), bits As SByte) As Byte()
        Dim result(byteArray.Length - 1) As Byte
        If bits = 0 Then
            Return byteArray
        ElseIf bits > 0 And bits < 8 Then
            For i As Integer = 0 To byteArray.Length - 2
                result(i) = (byteArray(i) << bits) Or (byteArray(i + 1) >> (8 - bits))
            Next
            result(byteArray.Length - 1) = (byteArray(byteArray.Length - 1) << bits)
        ElseIf bits = 8 Then
            For i As Integer = 0 To byteArray.Length - 2
                result(i) = byteArray(i + 1)
            Next
        ElseIf bits > 8 And bits < 16 Then
            bits = bits Mod 8
            For i As Integer = 0 To byteArray.Length - 3
                result(i) = (byteArray(i + 1) << bits) Or (byteArray(i + 2) >> (8 - bits))
            Next
            result(byteArray.Length - 2) = (byteArray(byteArray.Length - 2) << bits)
        ElseIf bits < 0 And bits > -8 Then

        ElseIf bits = -8 Then
            For i As Integer = 1 To byteArray.Length - 1
                result(i) = byteArray(i - 1)
            Next
        ElseIf bits < -8 And bits > -16 Then

        End If
        Return result
    End Function


    Private Function Checksums(values As Byte()) As Byte()
        Dim chk() As Byte = {0, 0}

        'check even values
        For i As Integer = 0 To Me.OffsetOther - 1 Step 2
            chk(0) = (CInt(chk(0)) + CInt(values(i))) Mod &H100
        Next

        'check odd values
        For i As Integer = 1 To Me.OffsetOther - 1 Step 2
            chk(1) = (CInt(chk(1)) + CInt(values(i))) Mod &H100
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

    Friend Sub EncodeValues()
        If TypeOf Me Is CharV2 Then
            Call DirectCast(Me, CharV2).EncodeValues()
        Else
            Call SetChecksums()
            Me.EncodedData = Me.GetEncodedBinary(Me.DecodedValues)
        End If
    End Sub

    Public Sub New()
        Call SetGame()
    End Sub

    Public MustOverride Function EncodedDataToString() As String
    Public MustOverride Function DecodedValuesToString(Optional hex As Boolean = True) As String

    Public Shared Function BytesToString(byteArray As Byte(), Optional hex As Boolean = True) As String
        Dim values As String = String.Empty
        For Each i As Integer In byteArray
            Dim tmpStr As String = String.Empty
            If hex Then
                tmpStr = i.ToString("X2")
            Else
                tmpStr = i.ToString
            End If

            values &= tmpStr & " "
        Next
        Return values.Trim
    End Function

    Public Shared Function BytesToString(shortArray As Short(), Optional hex As Boolean = True) As String
        Dim values As String = String.Empty
        If shortArray IsNot Nothing Then
            For Each i As Integer In shortArray
                Dim tmpStr As String = String.Empty
                If hex Then
                    tmpStr = i.ToString("X4")
                Else
                    tmpStr = i.ToString
                End If

                values &= tmpStr & " "
            Next
        End If
        Return values.Trim
    End Function

    Public Function ToByteString() As String
        Call EncodeValues()
        If TypeOf Me Is CharV2 Then
            Return DirectCast(Me, CharV2).BinaryToString()
        Else
            Return Me.BinaryToString
        End If
    End Function

    Friend Function BinaryToString() As String
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
