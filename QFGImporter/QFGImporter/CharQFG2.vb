Public Class CharQFG2
    Inherits CharGeneric
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

#Region "Byte Breakdown"
    'Byte 0: Character Class 
    '   (0 for Fighter, 1 for Magic User, 2 for Thief, 3 for Paladin)
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
    '   bit 0: Fine Sword
    '   bit 1: Soulforge (Rakeesh's Paladin Sword)
    '   bit 2: Saphirre Pin (gift from the Kattas)
    '   bit 3: Brass Lamp
    '   bit 4: EOF Badge
    '   bit 5: X-Ray Glasses
    '   bit 6: Broadsword
    '   bit 7: Chainmail
    '   note: the lock pick, theif's toolkit, and thieves' guild license are not saved in the character file
    '   note2: having the Compass counts as both bits 0 and 1, so I do not know how to ultimately distinguish between having the fine sword or soulforge

    'Bytes 5 - 19: Abilities and Skills 
    '   (5 - Strength, 6 - Inelligence, ... , 17 - Magic, 18 - Communication, 19 - Honor)

    'Byte 20: Experience
    '   value is exp AND 0xFF
    '
    'Byte 21: Health Points 
    '   (health is divided by 2, i.e. 43HP = 86) 
    '   value is hp AND 0xFF
    '
    'Byte 22: Stamina Points
    '   (stamina is divided by 4, i.e. 15SP = 60)
    '   value is sp AND 0xFF
    '
    'Byte 23: Magic Points
    '   value is mp AND 0xFF
    '
    'Bytes 24 - 34: Magic Spells
    '   (24 - Open, ... , 31 - Fetch, 32 - ForceBolt, 33 - Levitate, 34 - Reversal)
    '
    'Byte 35: Daggers
    '   value is number of daggers AND 0xFF
    '
    'Byte 36: Healing Pills
    '
    'Byte 37: Magic Pills
    '
    'Byte 38: Vigor Pills
    '
    'Byte 39: Poison Cure Pills
    '
    'Bytes 40 and 41: (constants - unknown)
    '   (Byte40 = 0xA0)
    '   (Byte41 = 0x3E)
    '
    'Bytes 42 and 43: Checksums
    '   (Byte42 is sum of all even bytes 0 - 39)
    '   (Byte43 is sum of all odd bytes 1 - 38)
    '
    'Bytes 44 - 47: (constants - unknown)
    '   (Byte44 = 0x2F)
    '   (Byte45 = 0x90)
    '   (Byte46 = 0x19)
    '   (Byte47 = 0xA3)

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

    Friend Overrides ReadOnly Property InitialCipher As Byte
        Get
            Return &H53
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
            Return GetSkills(Enums.Skills.Communication)
        End Get
        Set(value As Integer)
            SetSkill(Enums.Skills.Communication, value)
        End Set
    End Property

    Public Property Honor As Integer
        Get
            Return GetSkills(Enums.Skills.Honor)
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
