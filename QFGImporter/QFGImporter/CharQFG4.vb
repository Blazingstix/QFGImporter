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
            Return 46
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 60
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

    Friend Overrides ReadOnly Property SkillMaximum As UShort
        Get
            Return 400
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As UShort
        Get
            Return 400
        End Get
    End Property

    Public Sub New(fileContents)
        Call Load(fileContents)
        If (Me.EncodedString.Length Mod 4) <> 0 Then
            MessageBox.Show("This saved character has " & Me.EncodedString.Length & " characters in the data portion of the file." & vbCrLf & "QFG4 files with data not divisible by 4 has an error, and this program cannot work around that yet.")
            Exit Sub
        End If
        'Me.EncodedDataShort = ConvertByteToShortX(Me.EncodedData)
    End Sub

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG4
    End Sub

End Class
