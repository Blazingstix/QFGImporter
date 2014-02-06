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
        If Me.EncodedString.Length <> 208 Then
            MessageBox.Show("This saved character has " & Me.EncodedString.Length & " characters in the data portion of the file." & vbCrLf & "QFG3 files with data larger than 208 characters can an error, and this program cannot work around that yet.")
            Exit Sub
        End If
        Me.EncodedDataShort = ConvertByteToShortX(Me.EncodedData)
        Call RecalculateTestValues(0, 0, &H53)
    End Sub

    Public Sub RecalculateTestValues(bitEncoded As SByte, bitDecoded As SByte, cipher As Byte)
        'Me.DecodedValuesShort = Me.EncodedDataShort
        Me.DecodedValuesShort = CharGeneric.DecodeBytesXor(Me.EncodedDataShort, cipher)
        Me.EncodedData2 = CharGeneric.BitShift(Me.EncodedData, bitEncoded)
        Me.DecodedValues2 = CharGeneric.DecodeBytesXor(Me.EncodedData2, cipher)
        Me.DecodedValues2 = CharGeneric.BitShift(Me.DecodedValues2, bitDecoded)
    End Sub

    ''' <summary>
    ''' Converts a byte array into a Ushort array of half the length
    ''' Little Endian. (i.e. AA BB = AABB)
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ConvertByteToShort(bytes As Byte()) As UShort()
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

    ''' <summary>
    ''' Custom two-byte word conversion, for QFG3/4.
    ''' AA BB = (AA*100)+BB
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks>Does not work if there are errors/overage in the SAV file</remarks>
    Private Shared Function ConvertByteToShortX(bytes As Byte()) As UShort()

        'Dim y As New Collections.ArrayList
        Dim x2((bytes.Length / 2) - 1) As UShort
        For i As Integer = 0 To bytes.Length - 1 Step 2
            Dim val As UShort = bytes(i) * 100 + bytes(i + 1)
            'y.Add(val)
            x2(i / 2) = val
        Next
        '        Dim out() As UShort = CharGeneric.DecodeBytesXor(x2, &H53)
        Return x2
    End Function

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG3
    End Sub
End Class
