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
        Unknown40
        Unknown41
        Checksum1 = 42
        Checksum2
        Unknown44 = 44
        Unknown45
        Unknown46
        Unknown47

    End Enum

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
    Friend Overrides ReadOnly Property OffsetOther As Byte
        Get
            Return 40
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 42
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetOther2 As Byte
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

    Friend Overrides ReadOnly Property SkillMaximum As UShort
        Get
            Return 200
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As UShort
        Get
            Return 255
        End Get
    End Property

    Public Property Communication As Integer
        Get
            Return GetSkill(Enums.Skills.Communication)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Communication, value)
        End Set
    End Property

    Public Property Honor As Integer
        Get
            Return GetSkill(Enums.Skills.Honor)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Honor, value)
        End Set
    End Property

    Public Overrides Property Currency As Integer
        Get
            Dim hun As Integer = (Me.DecodedValues(Me.OffsetCharClass + 1)) * 100
            Dim tens As Integer = Me.DecodedValues(Me.OffsetCharClass + 2)
            Return hun + tens
        End Get
        Set(value As Integer)
            Dim small As Byte = value Mod 100
            Dim large As Byte = ((value - small) / 100)
            Me.DecodedValues(Me.OffsetCharClass + 1) = large
            Me.DecodedValues(Me.OffsetCharClass + 2) = small
        End Set
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
            Return Me.Flag1
        End Get
        Set(value As Boolean)
            Me.Flag1 = value
        End Set
    End Property

    Public Property HasSoulforge As Boolean
        Get
            Return Me.Flag2
        End Get
        Set(value As Boolean)
            Me.Flag2 = value
        End Set
    End Property

    Public Property HasSaphirrePin As Boolean
        Get
            Return Me.Flag3
        End Get
        Set(value As Boolean)
            Me.Flag3 = value
        End Set
    End Property

    Public Property HasBrassLamp As Boolean
        Get
            Return Me.Flag4
        End Get
        Set(value As Boolean)
            Me.Flag4 = value
        End Set
    End Property

    Public Property HasEOFBadge As Boolean
        Get
            Return Me.Flag5
        End Get
        Set(value As Boolean)
            Me.Flag5 = value
        End Set
    End Property

    Public Property HasXRayGlasses As Boolean
        Get
            Return Me.Flag6
        End Get
        Set(value As Boolean)
            Me.Flag6 = value
        End Set
    End Property

    Public Property HasBroadsword As Boolean
        Get
            Return Me.Flag7
        End Get
        Set(value As Boolean)
            Me.Flag7 = value
        End Set
    End Property

    Public Property HasChainmail As Boolean
        Get
            Return Me.Flag8
        End Get
        Set(value As Boolean)
            Me.Flag8 = value
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
