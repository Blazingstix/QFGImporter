Public Class CharQFG1
    Inherits CharGeneric
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

#Region "AdditionalBits"
    ' There is no record of Shields (must be class-based, or linked with Sword)
    ' There is no record of leather armor (Ego is issued at least leather armor)
    '
    'Byte 0: Character Class 
    '   (0 for Fighter, 1 for Magic User, 2 for Thief)
    '
    'Bytes 1 and 2: Gold
    '   (Byte1 - 1) * 100 = The hundreds column of gold.
    '   (Byte2) = The remainder of gold.
    '   (Note, silver coins are automatically converted to gold at the end of QFG1, rounded down.
    '   (i.e. 9909 silver coins == 990 gold coins.)
    '   i.e. if Ego has 75 gold coins, Byte1 = 1, Byte2 = 75
    '       if Ego has 150 gold coins, Byte1 = 2, Byte2 = 50
    '       if Ego has 1031 gold coins, Byte1 = 11, Byte2=31
    '
    'Byte 3: Puzzle Points
    '
    'Byte 4: Unique Inventory Items
    '   bit 0: Sword
    '   bit 1: Chainmail Armor
    '   bit 2: Lockpick
    '   bit 3: Thieves Toolkit
    '   bit 4: (unknown - possibly Became Hero of Spielburg?)
    '   bit 5: Defeated Baba Yaga
    '   bit 6: (unknown)
    '   bit 7: (unused)

    'Bytes 5 - 17: Abilities and Skills 
    '   (5 - Strength, 6 - Inelligence, ... , 17 - Magic)

    'Byte 18: Experience
    '   value is exp AND 0xF7
    '
    'Byte 19: Health Points 
    '   (health is divided by 2, i.e. 43HP = 86) 
    '   value is hp AND 0xF7 
    '
    'Byte 20: Stamina Points
    '   (stamina is divided by 4, i.e. 15SP = 60)
    '   value is sp AND 0xF7
    '
    'Byte 21: Magic Points
    '   value is mp AND 0xF7
    '
    'Bytes 22 - 29: Magic Spells
    '   (22 - Open, ... , 29 - Fetch)
    '
    'Byte 30: Daggers
    '
    'Byte 31: Healing Potions
    '
    'Byte 32: Vigor Potions
    '
    'Byte 33: Magic Potions
    '
    'Byte 34: Flasks of Undead Unguent
    '
    'Bytes 35 and 36: (constants - unknown)
    '   (Byte35 = 0x79)
    '   (Byte36 = 0x06)
    '
    'Bytes 37 and 38: Checksums
    '   (Byte37 is sum of all even bytes 0 - 34)
    '   (Byte38 is sum of all odd bytes 1 - 33)
    '
    'Bytes 39 - 42: (constants - unknown)
    '   (Byte39 = 0x43)
    '   (Byte40 = 0x08)
    '   (Byte41 = 0x2D)
    '   (Byte42 = 0x70)

#End Region


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

    Friend Overrides ReadOnly Property InitialCipher As Byte
        Get
            Return &H53
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

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG1
    End Sub

    Public Sub New()
        Call MyBase.New()
        Me.Name = String.Empty
        Dim newDeco(Me.OffsetEOF - 1) As Integer
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
