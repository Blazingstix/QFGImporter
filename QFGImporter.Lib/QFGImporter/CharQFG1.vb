Public Class CharQFG1
    Inherits CharV1
    Enum Inventorys
        Daggers
        HealingPotions
        MagicPotions
        VigorPotions
        Gold
        Sword
        Shield
        ChainmailArmor
        LeatherArmor
        LockPick
        ToolKit
        ThiefLicense
    End Enum

    Enum ByteNames
        CharacterClass = 0
        GoldHundreds
        Gold
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
        Experience = 18
        HitPoints
        StaminaPoints
        MagicPoints
        MagicSpellOpen = 22
        MagicSpellDetect
        MagicSpellTrigger
        MagicSpellDazzle
        MagicSpellZap
        MagicSpellCalm
        MagicSpellFlame
        MagicSpellFetch
        InventoryDaggers = 30
        InventoryHealingPotions
        InventoryMagicPotions
        InventoryVigorPotions
        InventoryUndeadUnguent = 34
        Constant1
        Constant2
        Checksum1 = 37
        Checksum2
        Constant3 = 39
        Constant4
        Constant5
        Constant6

    End Enum
    Friend Overrides ReadOnly Property Constants1 As Integer()
        Get
            Return {&H79, &H6}
        End Get
    End Property
    Friend Overrides ReadOnly Property Constants2 As Integer()
        Get
            Return {&H43, &H8, &H2D, &H70}
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
            Return 18
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetSpells As Byte
        Get
            Return 22
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetInventory As Byte
        Get
            Return 30
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetConstants1 As Byte
        Get
            Return 35
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 37
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetConstants2 As Byte
        Get
            Return 39
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 43
        End Get
    End Property

    Public Overrides ReadOnly Property SkillTechnicalMaximum As Short
        Get
            Return SByte.MaxValue
        End Get
    End Property

    Public Overrides ReadOnly Property SkillMaximum As Short
        Get
            Return 100
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialLimiter As Short
        Get
            Return SByte.MaxValue
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return &HCE
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillCount As Byte
        Get
            Return 13
        End Get
    End Property

    Friend Overrides ReadOnly Property MagicCount As Byte
        Get
            Return 8
        End Get
    End Property

    Friend Overrides ReadOnly Property InventoryCount As Byte
        Get
            Return 5
        End Get
    End Property

    Public Property UndeadUnguent As Integer
        Get
            Return Me.DecodedValues(CharQFG1.ByteNames.InventoryUndeadUnguent)
        End Get
        Set(value As Integer)
            Me.DecodedValues(CharQFG1.ByteNames.InventoryUndeadUnguent) = value
        End Set
    End Property

    Public Property HasBroadsword As Boolean
        Get
            Return Me.Flag(0)
        End Get
        Set(value As Boolean)
            Me.Flag(0) = value
        End Set
    End Property

    Public Property HasChainmail As Boolean
        Get
            Return Me.Flag(1)
        End Get
        Set(value As Boolean)
            Me.Flag(1) = value
        End Set
    End Property

    Public Property HasLockpick As Boolean
        Get
            Return Me.Flag(2)
        End Get
        Set(value As Boolean)
            Me.Flag(2) = value
        End Set
    End Property

    Public Property HasToolkit As Boolean
        Get
            Return Me.Flag(3)
        End Get
        Set(value As Boolean)
            Me.Flag(3) = value
        End Set
    End Property

    Public Property HeroOfSpielburg As Boolean
        Get
            Return Me.Flag(4)
        End Get
        Set(value As Boolean)
            Me.Flag(4) = value
        End Set
    End Property

    Public Property DefeatedBabaYaga As Boolean
        Get
            Return Me.Flag(5)
        End Get
        Set(value As Boolean)
            Me.Flag(5) = value
        End Set
    End Property

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG1
    End Sub

    Public Sub New()
        Call MyBase.New()
    End Sub

    Public Sub New(fileContents)
        Call MyBase.New()
        Call Load(fileContents)
    End Sub
End Class
