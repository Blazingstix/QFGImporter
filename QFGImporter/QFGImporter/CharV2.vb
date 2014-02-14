Public MustInherit Class CharV2
    Inherits CharGeneric

    Friend Shadows Property EncodedData As Short()
    Friend Shadows Property DecodedValues As Short()

#Region "Generic Skill Functions"
    Friend Overrides ReadOnly Property DataSize As Byte
        Get
            Return (Me.OffsetEOF) * 4
        End Get
    End Property

    Public Overrides Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Overrides Property Skill(vSkill As Enums.Skills) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSkills + vSkill)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSkills + vSkill) = value
        End Set
    End Property

    Public Overrides Property MagicSpell(spell As Enums.Magic) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSpells + spell)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSpells + spell) = value
        End Set
    End Property

    Public Overrides Property OtherSkill(skill As Enums.OtherSkills) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience + skill)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience + skill) = value
        End Set
    End Property

    Public Overrides Property Inventory(item As Enums.Inventory) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + item)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + item) = value
        End Set
    End Property

    Public Overrides Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetPuzzlePoints)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetPuzzlePoints) = value
        End Set
    End Property

    Public Overrides Property Currency As Integer
        Get
            Return Me.DecodedValues(Me.OffsetCurrency)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetCurrency) = value
        End Set
    End Property

    Public Overrides Property Flag(position As Byte) As Boolean
        Get
            If position < 0 Or position > 7 Then
                Throw New IndexOutOfRangeException
            End If
            Return CharGeneric.getBit(Me.DecodedValues(Me.OffsetUniqueInventory), position)
        End Get
        Set(value As Boolean)
            If position < 0 Or position > 7 Then
                Throw New IndexOutOfRangeException
            End If
            Me.DecodedValues(Me.OffsetUniqueInventory) = CharGeneric.setBit(Me.DecodedValues(Me.OffsetUniqueInventory), position, value)
        End Set
    End Property
#End Region

    Friend Overrides Sub ParseHexString(hexString As String)
        Me.EncodedData = CharGeneric.importHexStringX(hexString, Me.DataSize)
    End Sub

    Public Overrides Sub DecodeValues()
        Me.DecodedValues = CharGeneric.DecodeBytesXor(Me.EncodedData, Me.InitialCipher)
    End Sub

    Friend Overrides Sub EncodeValues()
        Call SetChecksums()
        Me.EncodedData = CharGeneric.EncodeBytesXor(Me.DecodedValues, Me.InitialCipher)
    End Sub

    Friend Overrides Function VerifyChecksums() As Boolean
        Dim chk() As Short = Me.CalculateChecksums(Me.DecodedValues)
        Return (chk(0) = Me.DecodedValues(Me.OffsetChecksum) AndAlso chk(1) = Me.DecodedValues(Me.OffsetChecksum + 1))
    End Function

    Friend Overrides Sub SetChecksums()
        Dim chk() As Short = Me.CalculateChecksums(Me.DecodedValues)
        'replace checksum with calculated values
        For i As Integer = 0 To chk.Length - 1
            Me.DecodedValues(Me.OffsetChecksum + i) = chk(i)
        Next
    End Sub

    Private Shadows Function CalculateChecksums(values As Short()) As Short()
        Dim chk() As Short = {0, 0}

        'all even values are summed, as are all odd values.
        For i As Integer = 0 To Me.OffsetConstants1 - 1
            chk(i Mod 2) = (CInt(chk(i Mod 2)) + CInt(values(i))) And Short.MaxValue
        Next

        'add a constant value to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) And Short.MaxValue

        Return chk
    End Function

    Public Overrides ReadOnly Property HeaderString As String
        Get
            Return " glory" & Me.Game & ".sav " & vbLf
        End Get
    End Property

    Public Overrides Function EncodedDataToString() As String
        Dim str As String = String.Empty
        For Each b As Short In Me.EncodedData
            Dim upper As Short = Math.Floor(b / 100)
            Dim lower As Byte = b Mod 100
            Dim test As Short = upper * 100 + lower
            Dim hexHi As String = ReplaceLeadingZeros(upper.ToString("X2").ToLower)
            'TODO: possible overflow could allow for upper portions to be larger than 2 characters
            Dim hexLo As String = ReplaceLeadingZeros(lower.ToString("X2").ToLower)

            str &= hexHi & hexLo
        Next
        Return str
    End Function

    Public Overrides Function DecodedValuesToString(Optional hex As Boolean = True) As String
        Return CharGeneric.BytesToString(Me.DecodedValues, hex)
    End Function

End Class
