Public MustInherit Class CharV2
    Inherits CharGeneric

    Friend Shadows Property EncodedData As Short()
    Friend Shadows Property DecodedValues As Short()

    Public Shadows Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Shadows Sub SetSkill(skill As Enums.Skills, value As Integer)
        Me.DecodedValues(Me.OffsetSkills + skill) = value
    End Sub

    Public Shadows Function GetSkill(skill As Enums.Skills) As Integer
        Return Me.DecodedValues(Me.OffsetSkills + skill)
    End Function

    Public Shadows Sub SetMagicSpell(spell As Enums.Magic, value As Integer)
        Me.DecodedValues(Me.OffsetSpells + spell) = value
    End Sub

    Public Shadows Function GetMagicSpell(spell As Enums.Magic) As Integer
        Return Me.DecodedValues(Me.OffsetSpells + spell)
    End Function

    Public Shadows Sub SetOtherSkill(skill As Enums.OtherSkills, value As Integer)
        Me.DecodedValues(Me.OffsetExperience + skill) = value
    End Sub

    Public Shadows Function GetOtherSkill(skill As Enums.OtherSkills) As Integer
        Return Me.DecodedValues(Me.OffsetExperience + skill)
    End Function

    Public Overridable Shadows Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSkills - 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSkills - 2) = value
        End Set
    End Property

    Public Overridable Shadows Property Daggers As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory) = value
        End Set
    End Property

    Public Overridable Shadows Property HealingPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 1)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 1) = value
        End Set
    End Property

    Public Overridable Shadows Property MagicPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 2) = value
        End Set
    End Property

    Public Overridable Shadows Property StaminaPotions As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + 3)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + 3) = value
        End Set
    End Property

    Public Overridable Shadows Property Currency As Integer
        Get
            Return Me.DecodedValues(Me.OffsetCharClass + 1)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetCharClass + 1) = value
        End Set
    End Property


    Friend Overrides Sub ConvertHexStringToBinary(hexString As String)
        Me.EncodedData = convertHexStringToShortArray(hexString)
    End Sub

    Public Overrides Sub DecodeValues()
        Me.DecodedValues = Me.GetDecodedBinary(Me.EncodedData)
    End Sub


    Public Shadows Function DecodedValuesToString() As String
        Return CharGeneric.BytesToString(Me.DecodedValues)
    End Function

    Private Shadows Function Checksums(values As Short()) As Short()
        Dim chk() As Short = {0, 0}

        'check even values
        For i As Integer = 0 To Me.OffsetOther - 1 Step 2
            chk(0) = (chk(0) + values(i)) Mod &H10000
        Next

        'check odd values
        For i As Integer = 1 To Me.OffsetOther - 1 Step 2
            chk(1) = (chk(1) + values(i)) Mod &H10000
        Next

        'add 0xD0 (208) to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) Mod &H10000

        ''the InitialLimiter is neccessary for QFG1,
        ''   where all the bytes are only 7 bits (i.e. 127 max)
        'chk(0) = chk(0) And Me.InitialLimiter
        'chk(1) = chk(1) And Me.InitialLimiter

        Return chk
    End Function

    Public Shadows Function ToByteString() As String
        Call EncodeValues()
        Return BinaryToString()
    End Function

    Friend Shadows Function BinaryToString() As String
        Dim str As String = String.Empty
        str = " glory" & Me.Game & ".sav " & vbLf
        str &= Me.Name & vbLf
        For Each b As Short In Me.EncodedData
            Dim upper As Byte = Math.Floor(b / 100)
            Dim lower As Byte = b Mod 100
            Dim test As Short = upper * 100 + lower
            Dim hexHi As String = " " & upper.ToString("X").ToLower
            hexHi = hexHi.Substring(hexHi.Length - 2)
            Dim hexLo As String = " " & lower.ToString("X").ToLower
            hexLo = hexLo.Substring(hexLo.Length - 2)

            str &= hexHi & hexLo
        Next
        str &= vbLf

        Return str
    End Function

    Private Shadows Sub SetChecksums()
        Dim chk() As Short = Me.Checksums(Me.DecodedValues)
        'replace checksum with calculated values
        For i As Integer = 0 To chk.Length - 1
            Me.DecodedValues(Me.OffsetChecksum + i) = chk(i)
        Next
    End Sub

    Friend Shadows Sub EncodeValues()
        Call SetChecksums()
        Me.EncodedData = Me.GetEncodedBinary(Me.DecodedValues)
    End Sub

End Class
