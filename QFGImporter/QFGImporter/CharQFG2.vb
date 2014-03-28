Public Class CharQFG2
    Inherits CharV1
    Enum ByteNames
        CharacterClass = 0
        DinarHundreds
        Dinar
        PuzzlePoints
        UniqueInventory
        AbilityStrength = 5
        AbilityIntelligence
        AbilityVitality
        AbilityAgility
        AbilityLuck
        SkillWeaponUse = 10
        SkillParry
        SkillDodge
        SkillStealth
        SkillPickLocks
        SkillThrowing
        SkillClimbing
        SkillMagic
        SkillCommunication
        SkillHonor
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
        InventoryDaggers = 35
        InventoryHealingPills
        InventoryMagicPills
        InventoryVigorPills
        InventoryPoisonCurePills = 39
        Constant1
        Constant2
        Checksum1 = 42
        Checksum2
        Constant3 = 44
        Constant4
        Constant5
        Constant6

    End Enum

    Friend Overrides ReadOnly Property Constants1 As Integer()
        Get
            Return {&HA0, &H3E}
        End Get
    End Property

    Friend Overrides ReadOnly Property Constants2 As Integer()
        Get
            Return {&H2F, &H90, &H19, &HA3}
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetCharClass As Byte
        Get
            Return 0
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetSkills As Byte
        Get
            Return 5
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetExperience As Byte
        Get
            Return 20
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetSpells As Byte
        Get
            Return 24
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetInventory As Byte
        Get
            Return 35
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetConstants1 As Byte
        Get
            Return 40
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 42
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetConstants2 As Byte
        Get
            Return 44
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 48
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return &HDA
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillMaximum As Short
        Get
            Return 200
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As Short
        Get
            Return Byte.MaxValue
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillCount As Byte
        Get
            Return 15
        End Get
    End Property

    Friend Overrides ReadOnly Property MagicCount As Byte
        Get
            Return 11
        End Get
    End Property

    Friend Overrides ReadOnly Property InventoryCount As Byte
        Get
            Return 5
        End Get
    End Property

    Public Property PoisonCurePills As Integer
        Get
            Return Me.DecodedValues(CharQFG2.ByteNames.InventoryPoisonCurePills)
        End Get
        Set(value As Integer)
            Me.DecodedValues(CharQFG2.ByteNames.InventoryPoisonCurePills) = value
        End Set
    End Property

    Public Property HasFineSword As Boolean
        Get
            Return Me.Flag(0)
        End Get
        Set(value As Boolean)
            Me.Flag(0) = value
        End Set
    End Property

    Public Property HasSoulforge As Boolean
        Get
            Return Me.Flag(1)
        End Get
        Set(value As Boolean)
            Me.Flag(1) = value
        End Set
    End Property

    Public Property HasSaphirrePin As Boolean
        Get
            Return Me.Flag(2)
        End Get
        Set(value As Boolean)
            Me.Flag(2) = value
        End Set
    End Property

    Public Property HasBrassLamp As Boolean
        Get
            Return Me.Flag(3)
        End Get
        Set(value As Boolean)
            Me.Flag(3) = value
        End Set
    End Property

    Public Property HasEOFBadge As Boolean
        Get
            Return Me.Flag(4)
        End Get
        Set(value As Boolean)
            Me.Flag(4) = value
        End Set
    End Property

    Public Property HasXRayGlasses As Boolean
        Get
            Return Me.Flag(5)
        End Get
        Set(value As Boolean)
            Me.Flag(5) = value
        End Set
    End Property

    Public Property HasBroadsword As Boolean
        Get
            Return Me.Flag(6)
        End Get
        Set(value As Boolean)
            Me.Flag(6) = value
        End Set
    End Property

    Public Property HasChainmail As Boolean
        Get
            Return Me.Flag(7)
        End Get
        Set(value As Boolean)
            Me.Flag(7) = value
        End Set
    End Property

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG2
    End Sub

    Public Sub New()
        Call MyBase.New()
    End Sub

    Public Sub New(fileContents)
        Call Load(fileContents)
    End Sub
End Class
