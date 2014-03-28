Public Class CharQFG3
    Inherits CharV2

    Enum ByteNames
        CharacterClass = 0
        RoyalsHundreds
        RoyalsRemainder
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
        Experience = 19
        HitPoints
        StaminaPoints
        MagicPoints
        MagicSpellOpen = 23
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
        InventoryUnknown37 = 37
        InventoryUnknown38
        InventoryThrowingDaggers
        InventoryUnknown40 = 40
        InventoryHealingPills = 41
        InventoryManaPills = 42
        InventoryPoisonCurePills = 43
        Constant1 = 44
        Constant2
        Checksum1 = 46
        Checksum2
        Constant3 = 48
        Constant4
        Constant5
        Constant6 = 51

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

    Friend Overrides ReadOnly Property InitialCipher As Byte
        Get
            Return &H53
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetCharClass As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 46
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 52
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetExperience As Byte
        Get
            Return 19
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetInventory As Byte
        Get
            Return 37
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetConstants1 As Byte
        Get
            Return 44
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetConstants2 As Byte
        Get
            Return 48
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSkills As Byte
        Get
            Return 4
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSpells As Byte
        Get
            Return 23
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillMaximum As Short
        Get
            Return 300
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As Short
        Get
            Return 500
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillCount As Byte
        Get
            Return 15
        End Get
    End Property

    Friend Overrides ReadOnly Property MagicCount As Byte
        Get
            Return 14
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
        Me.Game = Enums.Games.QFG3
    End Sub

End Class
