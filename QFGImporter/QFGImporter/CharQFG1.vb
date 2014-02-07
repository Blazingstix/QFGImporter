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
        Unknown35
        Unknown36
        Checksum1 = 37
        Checksum2
        Unknown39 = 39
        Unknown40
        Unknown41
        Unknown42

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
    Friend Overrides ReadOnly Property OffsetOther As Byte
        Get
            Return 34
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetChecksum As Byte
        Get
            Return 37
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetOther2 As Byte
        Get
            Return 39
        End Get
    End Property
    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 43
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As UShort
        Get
            Return 127
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillMaximum As UShort
        Get
            Return 100
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialLimiter As Byte
        Get
            Return &H7F
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return &HCE
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
            Return Me.Flag1()
        End Get
        Set(value As Boolean)
            Me.Flag1 = value
        End Set
    End Property

    Public Property HasChainmail As Boolean
        Get
            Return Me.Flag2
        End Get
        Set(value As Boolean)
            Me.Flag2 = value
        End Set
    End Property

    Public Property HasLockpick As Boolean
        Get
            Return Me.Flag3
        End Get
        Set(value As Boolean)
            Me.Flag3 = value
        End Set
    End Property

    Public Property HasToolkit As Boolean
        Get
            Return Me.Flag4
        End Get
        Set(value As Boolean)
            Me.Flag4 = value
        End Set
    End Property

    Public Property HeroOfSpielburg As Boolean
        Get
            Return Me.Flag5
        End Get
        Set(value As Boolean)
            Me.Flag5 = value
        End Set
    End Property

    Public Property DefeatedBabaYaga As Boolean
        Get
            Return Me.Flag6
        End Get
        Set(value As Boolean)
            Me.Flag6 = value
        End Set
    End Property

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG1
    End Sub

    Public Sub New()
        Call MyBase.New()
        Me.Name = String.Empty
        Dim newDeco(Me.OffsetEOF - 1) As Byte
        For i As Integer = 0 To newDeco.Length - 1
            newDeco(i) = 0
        Next
        newDeco.SetValue(&H79, 35)
        newDeco.SetValue(&H6, 36)
        newDeco.SetValue(&H43, 39)
        newDeco.SetValue(&H8, 40)
        newDeco.SetValue(&H2D, 41)
        newDeco.SetValue(&H70, 42)
        Me.DecodedValues = newDeco
    End Sub

    Public Sub New(fileContents)
        Call MyBase.New()
        Call Load(fileContents)
    End Sub
End Class
