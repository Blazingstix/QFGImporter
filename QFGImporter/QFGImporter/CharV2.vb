Public MustInherit Class CharV2
    Inherits CharGeneric

    Friend Shadows Property EncodedData As Short()
    Friend Shadows Property DecodedValues As Short()

#Region "Generic Skill Functions"
    Public Overrides Property CharacterClass As Enums.CharacterClass
        Get
            Return Me.DecodedValues(Me.OffsetCharClass)
        End Get
        Set(value As Enums.CharacterClass)
            Me.DecodedValues(Me.OffsetCharClass) = value
        End Set
    End Property

    Public Overrides Property Skill(vSkill As Enums.Skills) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSkills + vSkill)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSkills + vSkill) = value
        End Set
    End Property

    Public Overrides Property MagicSpell(spell As Enums.Magic) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetSpells + spell)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetSpells + spell) = value
        End Set
    End Property

    Public Overrides Property OtherSkill(skill As Enums.OtherSkills) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetExperience + skill)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetExperience + skill) = value
        End Set
    End Property

    Public Overrides Property Inventory(item As Enums.Inventory) As Integer
        Get
            Return Me.DecodedValues(Me.OffsetInventory + item)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetInventory + item) = value
        End Set
    End Property

    Public Overrides Property PuzzlePoints As Integer
        Get
            Return Me.DecodedValues(Me.OffsetPuzzlePoints)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetPuzzlePoints) = value
        End Set
    End Property

    Public Overrides Property Currency As Integer
        Get
            Return Me.DecodedValues(Me.OffsetCurrency)
        End Get
        Set(value As Integer)
            Me.DecodedValues(Me.OffsetCurrency) = value
        End Set
    End Property

    Public Overrides Property Flag(position As Byte) As Boolean
        Get
            If position < 0 Or position > 7 Then
                Throw New IndexOutOfRangeException
            End If
            Return CharGeneric.getBit(Me.DecodedValues(Me.OffsetUniqueInventory), position)
        End Get
        Set(value As Boolean)
            If position < 0 Or position > 7 Then
                Throw New IndexOutOfRangeException
            End If
            Me.DecodedValues(Me.OffsetUniqueInventory) = CharGeneric.setBit(Me.DecodedValues(Me.OffsetUniqueInventory), position, value)
        End Set
    End Property
#End Region

    Friend Overrides Sub ParseHexString(hexString As String)
        Me.EncodedData = CharGeneric.convertHexStringToShortArray(hexString)
    End Sub

    Public Overrides Sub DecodeValues()
        Me.DecodedValues = Me.GetDecodedBinary(Me.EncodedData)
    End Sub

    Private Shadows Function Checksums(values As Short()) As Short()
        Dim chk() As Short = {0, 0}

        'check even values
        For i As Integer = 0 To Me.OffsetOther - 1 Step 2
            chk(0) = (CInt(chk(0)) + CInt(values(i))) Mod &H10000
        Next

        'check odd values
        For i As Integer = 1 To Me.OffsetOther - 1 Step 2
            chk(1) = (CInt(chk(1)) + CInt(values(i))) Mod &H10000
        Next

        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) Mod &H10000

        Return chk
    End Function

    Public Shadows Function ToByteString() As String
        Call EncodeValues()
        Return BinaryToString()
    End Function

    Friend Shadows Function BinaryToString() As String
        Dim str As String = String.Empty
        str = " glory" & Me.Game & ".sav " & vbLf
        str &= Me.Name & vbLf
        For Each b As Short In Me.EncodedData
            Dim upper As Byte = Math.Floor(b / 100)
            Dim lower As Byte = b Mod 100
            Dim test As Short = upper * 100 + lower
            Dim hexHi As String = " " & upper.ToString("X").ToLower
            hexHi = hexHi.Substring(hexHi.Length - 2)
            Dim hexLo As String = " " & lower.ToString("X").ToLower
            hexLo = hexLo.Substring(hexLo.Length - 2)

            str &= hexHi & hexLo
        Next
        str &= vbLf

        Return str
    End Function

    Private Shadows Sub SetChecksums()
        Dim chk() As Short = Me.Checksums(Me.DecodedValues)
        'replace checksum with calculated values
        For i As Integer = 0 To chk.Length - 1
            Me.DecodedValues(Me.OffsetChecksum + i) = chk(i)
        Next
    End Sub

    Friend Shadows Sub EncodeValues()
        Call SetChecksums()
        Me.EncodedData = Me.GetEncodedBinary(Me.DecodedValues)
    End Sub

    Public Overrides Function EncodedDataToString() As String
        Dim rtn As String = String.Empty
        For Each x As Short In Me.EncodedData
            rtn &= x.ToString("X4") & " "
        Next
        Return rtn.Trim
    End Function

    Public Overrides Function DecodedValuesToString(Optional hex As Boolean = True) As String
        Return CharGeneric.BytesToString(Me.DecodedValues, hex)
    End Function

End Class
