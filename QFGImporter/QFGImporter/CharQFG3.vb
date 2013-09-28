Public Class CharQFG3
    Inherits CharGeneric

#Region "Byte Breakdown"
    ' I don't know the layout of the QFG3/4 files yet, but I suspect they are similar to QFG1/2
    '   except that instead of being 8-bit bytes, it appears to use 16-bit unsigned shorts.
    '
    'UShort 0: Character Class
    '
    'UShort 1: (unknown)
    '
    'UShort 2: (unknown)
    '
    'UShort 3: (unknown)
    '
    'UShort 4 - 18: Abilities and Skills
    '   (4 - Strength, 5 - Intelligence, ... , 16 - Magic, 17 - Communication, 18 - Honor)
    '
    'UShort 19: (unknown)
    '
    'UShort 20: (unknown)
    '
    'UShort 21: (unknown)
    '
    '
#End Region

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return 0
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
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 255
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetExperience As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetInventory As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetOther As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetOther2 As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSkills As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetSpells As Byte
        Get
            Return 0
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillMaximum As UShort
        Get
            Return 300
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As UShort
        Get
            Return 300
        End Get
    End Property

    Public Property EncodedDataShort As UShort()
    Public Property DecodedValuesShort As UShort()
    Public Property EncodedData2 As Byte()
    Public Property DecodedValues2 As Byte()

    Public Sub New(fileContents)
        Call Load(fileContents)
        Me.EncodedDataShort = ConvertByteToShort(Me.EncodedData)
        Me.DecodedValuesShort = Me.EncodedDataShort
        Me.DecodedValuesShort = CharGeneric.DecodeBytesXor(Me.EncodedDataShort, &H53)
        Dim tmp(Me.EncodedData.Length - 1) As Byte
        For i As Integer = 0 To Me.EncodedData.Length - 2
            tmp(i) = Me.EncodedData(i + 1)
        Next
        Me.EncodedData2 = tmp
        Me.DecodedValues2 = CharGeneric.DecodeBytesXor(Me.EncodedData2, &H53)
    End Sub

    Private Function ConvertByteToShort(bytes As Byte()) As UShort()
        Dim shorts(Math.Ceiling(bytes.Length / 2) - 1) As UShort
        For i As Integer = 0 To shorts.Length - 1
            Dim byteA As Byte = bytes(2 * i)
            Dim byteB As Byte = 0
            If 2 * i + 1 < bytes.Length Then
                byteB = bytes(2 * i + 1)
            End If

            shorts(i) = (CUShort(byteA) << 8) Or byteB
        Next
        Return shorts
    End Function

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG3
    End Sub
End Class
