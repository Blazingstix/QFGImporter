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
    Friend MustOverride ReadOnly Property InitialLimiter As Byte
    Friend MustOverride ReadOnly Property InitialChecksum As Byte

#End Region


#Region "Basic Properties"

    Public Property Game As Enums.Games
    Public Property Name As String = String.Empty
    Friend Property EncodedData As Byte()
    Friend Property DecodedValues As Integer()
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

    Public Overridable Property StaminaPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 2) = value
        End Set
    End Property

    Public Overridable Property MagicPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 3)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 3) = value
        End Set
    End Property

    Public Overridable Property Gold As Integer
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

    Public Overridable Property HasSword As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 0)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 0, value)
        End Set
    End Property

    Public Overridable Property HasChainmailArmor As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 1)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 1, value)
        End Set
    End Property

    Public Overridable Property HasLockPick As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 2)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 2, value)
        End Set
    End Property

    Public Overridable Property HasThievesToolkit As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 3)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 3, value)
        End Set
    End Property

    Public Overridable Property Unknown1 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 4)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 4, value)
        End Set
    End Property

    Public Overridable Property Unknown2 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 5)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 5, value)
        End Set
    End Property

    Public Overridable Property Unknown3 As Boolean
        Get
            Return getBit(Me.DecodedValues(Me.OffsetSkills - 1), 6)
        End Get
        Set(value As Boolean)
            Me.DecodedValues(Me.OffsetSkills - 1) = setBit(Me.DecodedValues(Me.OffsetSkills - 1), 6, value)
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
            Me.DecodedValues = DecodeBytes(Me.EncodedData)
        End If
    End Sub

    Public Shared Function GetGame(FileContents As String) As Enums.Games
        Dim lines As String() = CharGeneric.SplitInputFile(FileContents)
        If lines IsNot Nothing AndAlso lines.Length > 1 Then
            If lines(0) = " glory3.sav" Then
                Return Enums.Games.QFG3
            ElseIf lines(0) = " glory4.sav" Then
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

    Friend Overridable Sub SetGame()

    End Sub

    Public Shared Function SplitInputFile(import As String) As String()
        import = import.Replace(vbCrLf, vbLf)
        Dim splitChars As Char() = {vbLf}
        Dim lines() As String = import.Split(splitChars, 3)
        Return lines
    End Function

    Public Function ParseCharacter(import As String) As String()
        'MessageBox.Show(import)
        Dim lines As String() = SplitInputFile(import)
        If lines.Length > 1 Then
            Dim name As String = lines(0)
            Dim data As String = lines(1)
            If lines.Length > 2 Then
                Dim extra As String = lines(2)
            End If
            Dim dataBytes As Byte() = convertHexStringToByteArray(data)
            Dim values As Integer() = DecodeBytes(dataBytes)
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

    Public Function DecodeBytes(data As Byte()) As Integer()
        Dim values(data.Length - 1) As Integer

        For i As Integer = 0 To data.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = Me.InitialCipher
            Else
                cipher = data(i - 1) And Me.InitialLimiter
            End If

            values(i) = data(i) Xor cipher
        Next

        Return values
    End Function

    Public Function EncodeBytes(data As Integer()) As Byte()
        Dim values(data.Length - 1) As Byte
        For i As Integer = 0 To data.Length - 1
            Dim cipher As Byte
            If i = 0 Then
                cipher = Me.InitialCipher
            Else
                cipher = values(i - 1) And Me.InitialLimiter
            End If

            values(i) = data(i) Xor cipher
        Next

        Return values
    End Function

    Private Function Checksums(values As Integer()) As Byte()
        Dim chk() As Byte = {0, 0}

        'check even values
        For i As Integer = 0 To Me.OffsetOther Step 2
            chk(0) = (chk(0) + values(i)) Mod &H100
        Next

        'check odd values
        For i As Integer = 1 To Me.OffsetOther - 1 Step 2
            chk(1) = (chk(1) + values(i)) Mod &H100
        Next

        'add 0xCE (206) to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) Mod &H100

        'next, we limit it to the lower 7 bits
        '   not sure why.
        chk(0) = chk(0) And Me.InitialLimiter
        chk(1) = chk(1) And Me.InitialLimiter

        Return chk
    End Function

    Private Function VerifyChecksums() As Boolean

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
        'TODO: encode data
        Me.EncodedData = Me.EncodeBytes(Me.DecodedValues)

    End Sub

    Public Sub New()
        Call SetGame()
    End Sub

    Public Function DecodedValuesToString() As String
        Dim values As String = String.Empty
        For Each i As Integer In Me.DecodedValues
            values &= i.ToString("X2") & " "
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
