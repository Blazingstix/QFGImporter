Public MustInherit Class CharV1
    Inherits CharGeneric

#Region "Generic Skill Functions"

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
        Select Case skill
            Case Enums.OtherSkills.HealthPoints
                value = value * 2
            Case Enums.OtherSkills.StaminaPoints
                value = value * 4
        End Select
        Me.DecodedValues(Me.OffsetExperience + skill) = value
    End Sub

    Public Shadows Function GetOtherSkill(skill As Enums.OtherSkills) As Integer
        Dim value As Integer = Me.DecodedValues(Me.OffsetExperience + skill)
        Select Case skill
            Case Enums.OtherSkills.HealthPoints
                value = value / 2
            Case Enums.OtherSkills.StaminaPoints
                value = value / 4
        End Select
        Return value
    End Function
#End Region

    Public Shadows Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Shadows Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSkills - 2)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSkills - 2) = value And &HF7
        End Set
    End Property

    Public Overridable Shadows Property Currency As Integer
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

End Class
