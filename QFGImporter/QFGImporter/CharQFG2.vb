Public Class CharQFG2
    Inherits CharGeneric

    'Friend Shadows Const OffsetSkills As Byte = 5
    'Friend Shadows Const OffsetExperience As Byte = 20
    'Friend Shadows Const OffsetSpells As Byte = 24
    'Friend Shadows Const OffsetInventory As Byte = 35
    'Friend Shadows Const OffsetOther As Byte = 40
    'Friend Shadows Const OffsetChecksum As Short = 42
    'Friend Shadows Const OffsetOther2 As Byte = 44
    'Friend Shadows Const OffsetEOF As Byte = 48

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

    Friend Overrides ReadOnly Property InitialLimiter As Byte
        Get
            Return &HFF
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
