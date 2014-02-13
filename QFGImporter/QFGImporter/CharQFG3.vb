Public Class CharQFG3
    Inherits CharV2

    Friend Overrides ReadOnly Property InitialChecksum As Byte
        Get
            Return &HD0
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
            Return 46
        End Get
    End Property

    Friend Overrides ReadOnly Property OffsetEOF As Byte
        Get
            Return 51
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
            Return 300
        End Get
    End Property

    Friend Overrides ReadOnly Property SkillTechnicalMaximum As UShort
        Get
            Return 300
        End Get
    End Property

    'Public Property EncodedDataShort As Short()
    'Public Property DecodedValuesShort As Short()

    Public Sub New(fileContents)
        Call Load(fileContents)
        If Me.EncodedString.Length <> 208 Then
            MessageBox.Show("This saved character has " & Me.EncodedString.Length & " characters in the data portion of the file." & vbCrLf & "QFG3 files with data larger than 208 characters has an error, and this program cannot work around that yet.")
            Exit Sub
        End If
        'Me.EncodedDataShort = ConvertByteToShortX(Me.EncodedData)
    End Sub


    ' ''' <summary>
    ' ''' Custom two-byte word conversion, for QFG3/4.
    ' ''' AA BB = (AA*100)+BB
    ' ''' </summary>
    ' ''' <param name="bytes"></param>
    ' ''' <returns></returns>
    ' ''' <remarks>Does not work if there are errors/overage in the SAV file</remarks>
    'Private Shared Function ConvertByteToShortX(bytes As Byte()) As UShort()

    '    'Dim y As New Collections.ArrayList
    '    Dim x2((bytes.Length / 2) - 1) As UShort
    '    For i As Integer = 0 To bytes.Length - 1 Step 2
    '        Dim val As UShort = bytes(i) * 100 + bytes(i + 1)
    '        'y.Add(val)
    '        x2(i / 2) = val
    '    Next
    '    '        Dim out() As UShort = CharGeneric.DecodeBytesXor(x2, &H53)
    '    Return x2
    'End Function

    Friend Overrides Sub SetGame()
        Me.Game = Enums.Games.QFG3
    End Sub

End Class
