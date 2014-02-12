Public MustInherit Class CharV1
    Inherits CharGeneric

#Region "Generic Skill Functions"

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
            Dim value As Integer = Me.DecodedValues(Me.OffsetExperience + skill)
            Select Case skill
                Case Enums.OtherSkills.HealthPoints
                    value = value / 2
                Case Enums.OtherSkills.StaminaPoints
                    value = value / 4
            End Select
            Return value
        End Get
        Set(value As Integer)
            Select Case skill
                Case Enums.OtherSkills.HealthPoints
                    value = value * 2
                Case Enums.OtherSkills.StaminaPoints
                    value = value * 4
            End Select
            Me.DecodedValues(Me.OffsetExperience + skill) = value And Me.InitialLimiter
        End Set
    End Property

    Public Overrides Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Overrides Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetPuzzlePoints)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetPuzzlePoints) = value And Me.InitialLimiter
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

    Public Overrides Property Currency As Integer
        Get
            'QFG1 adds 1 to the large value, but QFG2 does not.
            Dim valueOffset As Integer = 2 - Me.Game
            'QFG1/2 stores currency in two bytes. The high byte is the value / 100. The low byte is the remainder.
            Dim large As Integer = (Me.DecodedValues(Me.OffsetCurrency) - valueOffset) * 100
            Dim small As Integer = Me.DecodedValues(Me.OffsetCurrency + 1)
            Return large + small
        End Get
        Set(value As Integer)
            'QFG1 adds 1 to the large value, but QFG2 does not.
            Dim valueOffset As Integer = 2 - Me.Game
            'QFG1/2 stores currency in two bytes. The high byte is the value / 100. The low byte is the remainder.
            Dim small As Byte = value Mod 100
            Dim large As Byte = ((value - small) / 100) + valueOffset
            Me.DecodedValues(Me.OffsetCurrency) = large
            Me.DecodedValues(Me.OffsetCurrency + 1) = small
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

    Public Overrides Sub DecodeValues()
        Me.DecodedValues = Me.GetDecodedBinary(Me.EncodedData)
    End Sub

    Public Overrides Function EncodedDataToString() As String
        Dim rtn As String = String.Empty
        For Each x As Byte In Me.EncodedData
            rtn &= x.ToString("X2") & " "
        Next
        Return rtn.Trim
    End Function

    Public Overrides Function DecodedValuesToString(Optional hex As Boolean = True) As String
        Return CharGeneric.BytesToString(Me.DecodedValues, hex)
    End Function

    Friend Overrides Sub ParseHexString(hexString As String)
        Me.EncodedData = CharGeneric.convertHexStringToByteArray(hexString)
    End Sub
End Class
