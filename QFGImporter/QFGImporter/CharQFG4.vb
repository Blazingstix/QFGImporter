Public Class CharQFG4
    Inherits CharV2
    Enum ByteNames
        CharacterClass = 0
        CrownsHundreds
        CrownsRemainder
        UniqueInventory
        AbilityStrength = 4
        AbilityIntelligence
        AbilityVitality
        AbilityAgility
        AbilityLuck
        SkillWeaponUse = 9
        SkillParry
        SkillDodge
        SkillStealth
        SkillPickLocks
        SkillThrowing
        SkillClimbing
        SkillMagic
        SkillCommunication
        SkillHonor
        SkillAcrobatics
        Experience = 20
        HitPoints
        StaminaPoints
        MagicPoints
        MagicSpellOpen = 24
        MagicSpellDetect
        MagicSpellTrigger
        MagicSpellDazzle
        MagicSpellZap
        MagicSpellCalm
        MagicSpellFlame
        MagicSpellFetch
        MagicSpellForceBolt
        MagicSpellLevitation
        MagicSpellReversal
        MagicSpellJugglingLights
        MagicSpellSummonStaff
        MagicSpellLightningBall
        MagicSpellFrostBite
        MagicSpellGlide
        MagicSpellHide
        MagicSpellAura
        MagicSpellProtection
        MagicSpellResistance
        MagicSpellRitualOfRelease
        InventoryUnknown45 = 45
        InventoryUnknown46
        InventoryThrowingDaggers
        InventoryUnknown48 = 48
        InventoryHealingPills = 49
        InventoryManaPills
        InventoryPoisonCurePills
        Constant1 = 52
        Constant2
        Checksum1 = 54
        Checksum2
        Constant3 = 56
        Constant4
        Constant5
        Constant6 = 59

    End Enum

    Friend Overrides ReadOnly Property Constants1 As Integer()
        Get
            Return {&H19, &HBE}
        End Get
    End Property
    Friend Overrides ReadOnly Property Constants2 As Integer()
        Get
            Return {&H37, &H6D, &HC4, &HF2}
        End Get
    End Property

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return &HD0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetCharClass As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 54
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 60
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetExperience As Byte
        Get
            Return 20
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetInventory As Byte
        Get
            Return 45
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetConstants1 As Byte
        Get
            Return 52
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetConstants2 As Byte
        Get
            Return 56
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSkills As Byte
        Get
            Return 4
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSpells As Byte
        Get
            Return 24
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillMaximum As Short
        Get
            Return 400
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As Short
        Get
            Return 500
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillCount As Byte
        Get
            Return 16
        End Get
    End Property

    Friend Overrides ReadOnly Property MagicCount As Byte
        Get
            Return 21
        End Get
    End Property

    Friend Overrides ReadOnly Property InventoryCount As Byte
        Get
            Return 7
        End Get
    End Property

    Public Sub New(fileContents)
        Call Load(fileContents)
    End Sub

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG4
    End Sub

End Class
