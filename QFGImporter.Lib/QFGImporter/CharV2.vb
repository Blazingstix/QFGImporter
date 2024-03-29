﻿Public MustInherit Class CharV2
    Inherits CharGeneric

    Friend Shadows Property EncodedData As Short()
    Friend Shadows Property DecodedValues As Short()

    Enum InventoryItems
        NotAnItem = -1
        PaladinHealingSpell = 0
        Rations
        ThrowingDaggers
        OilFlasks
        HealingPills
        ManaPills
        PoisonCurePills
    End Enum

#Region "Generic Skill Functions"
    Friend Overrides ReadOnly Property DataSize As Byte
        Get
            Return (Me.OffsetEOF) * 4
        End Get
    End Property

    Friend Overrides ReadOnly Property InitialLimiter As Short
        Get
            Return Short.MaxValue
        End Get
    End Property

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
            If vSkill >= 0 And vSkill < Me.SkillCount Then
                Return Me.DecodedValues(Me.OffsetSkills + vSkill)
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            If vSkill >= 0 And vSkill < Me.SkillCount Then
                Me.DecodedValues(Me.OffsetSkills + vSkill) = value
            End If
        End Set
    End Property

    Public Overrides Property MagicSpell(spell As Enums.Magic) As Integer
        Get
            If spell >= 0 And spell < Me.MagicCount Then
                Return Me.DecodedValues(Me.OffsetSpells + spell)
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            If spell >= 0 And spell < Me.MagicCount Then
                Me.DecodedValues(Me.OffsetSpells + spell) = value
            End If
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
            Dim v2Item As CharV2.InventoryItems = ConvertV1Inventory(item)
            If v2Item = InventoryItems.NotAnItem Then
                Return 0
            Else
                Return Me.DecodedValues(Me.OffsetInventory + v2Item)
            End If
        End Get
        Set(value As Integer)
            Dim v2Item As CharV2.InventoryItems = ConvertV1Inventory(item)
            If v2Item <> InventoryItems.NotAnItem Then
                Me.DecodedValues(Me.OffsetInventory + v2Item) = value
            End If
        End Set
    End Property

    Friend Function ConvertV1Inventory(item As Enums.Inventory) As CharV2.InventoryItems
        Select Case item
            Case Enums.Inventory.Daggers
                Return InventoryItems.ThrowingDaggers
            Case Enums.Inventory.HealingPotion
                Return InventoryItems.HealingPills
            Case Enums.Inventory.MagicPotion
                Return InventoryItems.ManaPills
            Case Enums.Inventory.PoisonCurePill
                Return InventoryItems.PoisonCurePills
            Case Enums.Inventory.PaladinHealingSpell
                Return InventoryItems.PaladinHealingSpell
            Case Enums.Inventory.Rations
                Return InventoryItems.Rations
            Case Enums.Inventory.OilFlasks
                Return InventoryItems.OilFlasks
            Case Else
                Return InventoryItems.NotAnItem
        End Select

    End Function

    Public Overrides Property PuzzlePoints As Integer
        Get
            Return 0
        End Get
        Set(value As Integer)

        End Set
    End Property

    Public Overrides Property Currency As Integer
        Get
            'QFG3/4 stores currency in two shorts. The high short is the value / 100. The low short is the remainder.
            Dim large As Integer = (Me.DecodedValues(Me.OffsetCurrency)) * 100
            Dim small As Integer = Me.DecodedValues(Me.OffsetCurrency + 1)
            Return large + small
        End Get
        Set(value As Integer)
            'QFG3/4 stores currency in two shorts. The high short is the value / 100. The low short is the remainder.
            Dim small As Byte = value Mod 100
            Dim large As Byte = ((value - small) / 100)
            Me.DecodedValues(Me.OffsetCurrency) = large
            Me.DecodedValues(Me.OffsetCurrency + 1) = small
        End Set
    End Property

    Public Overrides Property Flag(position As Byte) As Boolean
        Get
            If position < 0 Or position > 15 Then
                Throw New IndexOutOfRangeException
            End If
            Return CharGeneric.getBit(Me.DecodedValues(Me.OffsetUniqueInventory), position)
        End Get
        Set(value As Boolean)
            If position < 0 Or position > 15 Then
                Throw New IndexOutOfRangeException
            End If
            Me.DecodedValues(Me.OffsetUniqueInventory) = CharGeneric.setBit(Me.DecodedValues(Me.OffsetUniqueInventory), position, value)
        End Set
    End Property
#End Region

    Friend Overrides Sub ParseHexString(hexString As String)
        Me.EncodedData = CharGeneric.importHexStringX(hexString, Me.DataSize)
    End Sub

    Public Overrides Sub DecodeValues()
        Me.DecodedValues = CharGeneric.DecodeBytesXor(Me.EncodedData, Me.InitialCipher)
    End Sub

    Friend Overrides Sub EncodeValues()
        Call SetChecksums()
        Me.EncodedData = CharGeneric.EncodeBytesXor(Me.DecodedValues, Me.InitialCipher)
    End Sub

    Friend Overrides Function VerifyChecksums() As Boolean
        Dim chk() As Short = Me.CalculateChecksums(Me.DecodedValues)
        Return (chk(0) = Me.DecodedValues(Me.OffsetChecksum) AndAlso chk(1) = Me.DecodedValues(Me.OffsetChecksum + 1))
    End Function

    Friend Overrides Sub SetChecksums()
        Dim chk() As Short = Me.CalculateChecksums(Me.DecodedValues)
        'replace checksum with calculated values
        For i As Integer = 0 To chk.Length - 1
            Me.DecodedValues(Me.OffsetChecksum + i) = chk(i)
        Next
    End Sub

    Private Shadows Function CalculateChecksums(values As Short()) As Short()
        Dim chk() As Short = {0, 0}

        'all even values are summed, as are all odd values.
        For i As Integer = 0 To Me.OffsetConstants1 - 1
            chk(i Mod 2) = (CInt(chk(i Mod 2)) + CInt(values(i))) And Short.MaxValue
        Next

        'add a constant value to the 1st checksum
        chk(0) = (CInt(chk(0)) + CInt(Me.InitialChecksum)) And Short.MaxValue

        Return chk
    End Function

    Public Overrides ReadOnly Property HeaderString As String
        Get
            Return " glory" & Me.Game & ".sav " & vbLf
        End Get
    End Property

    Public Overrides Function EncodedDataToString() As String
        Dim str As String = String.Empty
        For Each b As Short In Me.EncodedData
            Dim upper As Short = Math.Floor(b / 100)
            Dim lower As Byte
            If b < 0 Then
                lower = (b Mod 100) + 100
            Else
                lower = b Mod 100
            End If
            Dim test As Short = upper * 100 + lower
            Dim hexHi As String = ReplaceLeadingZeros(upper.ToString("X2").ToLower)
            'TODO: possible overflow could allow for upper portions to be larger than 2 characters
            Dim hexLo As String = ReplaceLeadingZeros(lower.ToString("X2").ToLower)

            str &= hexHi & hexLo
        Next
        Return str
    End Function

    Public Overrides Function DecodedValuesToString(Optional hex As Boolean = True) As String
        Return CharGeneric.BytesToString(Me.DecodedValues, hex)
    End Function

    Public Sub New()
        Call MyBase.New()

        'create a blank valueset
        Dim blankVals(Me.OffsetEOF - 1) As Short
        For i As Integer = 0 To blankVals.Length - 1
            blankVals(i) = 0
        Next

        Me.DecodedValues = blankVals
        Call UpdateConstants()

    End Sub

    Public Overrides Sub UpdateConstants()
        If Me.DecodedValues IsNot Nothing Then
            'fill in the constant values
            For i As Integer = 0 To 1
                Me.DecodedValues(Me.OffsetConstants1 + i) = Me.Constants1(i)
            Next
            For i As Integer = 0 To 3
                Me.DecodedValues(Me.OffsetConstants2 + i) = Me.Constants2(i)
            Next
        End If
    End Sub

End Class
