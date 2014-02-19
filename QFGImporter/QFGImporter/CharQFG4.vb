Public Class CharQFG4
    Inherits CharV2

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
            Return 400
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillCount As Byte
        Get
            Return 15
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
