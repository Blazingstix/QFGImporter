Public Class Form1
    Private Property Loading As Boolean = True
    Private Property OriginalTitle As String = String.Empty
    Private Property LoadedFilename As String = String.Empty
    Public Property LoadedChar As CharGeneric = Nothing
    Public Property ReferenceChar As CharGeneric = Nothing
    Public DeltaOffsets As New Collections.ArrayList
    Public Property UnalteredData As Byte()

#Region "Events_Main"
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.OriginalTitle = Me.Text
        Call EnableTestData(False)
        lblOtherDataFilename.Text = String.Empty
        Me.Loading = False
        Call SetMaximumSkill(127)
        Call SetQFG1Display()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Dim fso As New OpenFileDialog
        fso.Filter = CharGeneric.QFGFileFilter
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call Me.CloseCharacter()
            Me.LoadedFilename = fso.FileName
            Dim fileContents As String = String.Empty
            Dim s As IO.FileStream = fso.OpenFile()
            If s.Length < 1024 Then
                Dim t As New IO.StreamReader(s)
                fileContents = t.ReadToEnd
            End If
            s.Close()

            'set the form's title, baased on the open file's name
            Me.Text = Me.OriginalTitle & ": " & System.IO.Path.GetFileName(Me.LoadedFilename)
            Call LoadGameFromFileContents(fileContents)
        End If
    End Sub

    Private Sub LoadGameFromFileContents(fileContents As String)
        'CharGeneric.ParseCharacter(fileContents)
        Select Case CharGeneric.GetGame(fileContents)
            Case Enums.Games.QFG1
                Me.LoadedChar = New CharQFG1(fileContents)
                Call LoadForm()
            Case Enums.Games.QFG2
                Me.LoadedChar = New CharQFG2(fileContents)
                Call LoadForm()
            Case Enums.Games.QFG3
                Me.LoadedChar = New CharQFG3(fileContents)
                Call LoadForm()
                Call RefreshTestDecrypting()
            Case Enums.Games.QFG4

        End Select

    End Sub

    Private Sub RefreshTestDecrypting()
        txtEncodedString.Text = Me.LoadedChar.EncodedString
        lblEncodedStringLength.Text = Me.LoadedChar.EncodedString.Length
        txtEncodedByteArray.Text = CharGeneric.BytesToString(DirectCast(Me.LoadedChar, CharQFG3).EncodedData2)
        txtDecodedByteArray.Text = CharGeneric.BytesToString(DirectCast(Me.LoadedChar, CharQFG3).DecodedValues2)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim fso As New SaveFileDialog
        fso.Filter = CharGeneric.QFGFileFilter
        fso.InitialDirectory = IO.Path.GetDirectoryName(Me.LoadedFilename)
        fso.FileName = IO.Path.GetFileName(Me.LoadedFilename)
        fso.OverwritePrompt = True
        fso.DefaultExt = ".sav"
        fso.Title = "Save QFG Character File As..."
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fs As New IO.StreamWriter(fso.OpenFile())
            fs.Write(Me.LoadedChar.ToByteString)
            fs.Close()
        End If
    End Sub

    Private Sub rdoQFG_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoQFG1.CheckedChanged, rdoQFG2.CheckedChanged, rdoQFG3.CheckedChanged, rdoQFG4.CheckedChanged
        Select Case DirectCast(sender, Control).Name
            Case rdoQFG1.Name
                Call SetQFG1Display()
            Case rdoQFG2.Name
                Call SetQFG2Display()
            Case rdoQFG3.Name
                Call SetQFG3Display()
            Case rdoQFG4.Name
                Call SetQFG4Display()
        End Select

        EnableQFG4(rdoQFG4.Checked)
        EnableQFG3(rdoQFG4.Checked Or rdoQFG3.Checked)
        EnableQFG2(rdoQFG4.Checked Or rdoQFG3.Checked Or rdoQFG2.Checked)
        EnableQFG1(rdoQFG4.Checked Or rdoQFG3.Checked Or rdoQFG2.Checked Or rdoQFG1.Checked)
        If rdoQFG1.Checked And rdoPaladin.Checked Then
            rdoFighter.Checked = True
        End If
        rdoPaladin.Enabled = True
    End Sub

    Private Sub numInventory_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numGold.ValueChanged, numDaggers.ValueChanged, numHealingPotions.ValueChanged, numVigorPotions.ValueChanged, numMagicPotions.ValueChanged, numOtherPotions.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            Select Case numValue.Name
                Case numGold.Name
                    Me.LoadedChar.Currency = numValue.Value
                Case numDaggers.Name
                    Me.LoadedChar.Daggers = numValue.Value
                Case numHealingPotions.Name
                    Me.LoadedChar.HealingPotions = numValue.Value
                Case numVigorPotions.Name
                    Me.LoadedChar.StaminaPotions = numValue.Value
                Case numMagicPotions.Name
                    Me.LoadedChar.MagicPotions = numValue.Value
                Case numOtherPotions.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG1 Then
                        DirectCast(Me.LoadedChar, CharQFG1).UndeadUnguent = numValue.Value
                    End If
            End Select
        End If
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As System.EventArgs) Handles txtName.LostFocus
        If Me.LoadedChar IsNot Nothing Then
            DirectCast(sender, TextBox).Text = Me.LoadedChar.Name
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtName.TextChanged
        If Me.LoadedChar IsNot Nothing Then
            Me.LoadedChar.Name = DirectCast(sender, TextBox).Text
        End If
    End Sub

    Private Sub chkUniqueInventory_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFlag1.CheckedChanged, chkFlag2.CheckedChanged, chkFlag3.CheckedChanged, chkFlag4.CheckedChanged, chkFlag5.CheckedChanged, chkFlag6.CheckedChanged, chkFlag7.CheckedChanged, chkFlag8.CheckedChanged
        Dim chkFlag As CheckBox = sender
        If Me.LoadedChar IsNot Nothing Then
            If TypeOf Me.LoadedChar Is CharQFG1 Then
                Dim QFG1 As CharQFG1 = Me.LoadedChar
                Select Case chkFlag.Name
                    Case chkFlag1.Name
                        QFG1.Flag1 = chkFlag.Checked
                    Case chkFlag2.Name
                        QFG1.Flag2 = chkFlag.Checked
                    Case chkFlag3.Name
                        QFG1.Flag3 = chkFlag.Checked
                    Case chkFlag4.Name
                        QFG1.Flag4 = chkFlag.Checked
                    Case chkFlag5.Name
                        QFG1.Flag5 = chkFlag.Checked
                    Case chkFlag6.Name
                        QFG1.Flag6 = chkFlag.Checked
                    Case chkFlag7.Name
                        QFG1.Flag7 = chkFlag.Checked
                    Case chkFlag8.Name

                End Select
            ElseIf TypeOf Me.LoadedChar Is CharQFG2 Then
                Dim QFG2 As CharQFG2 = Me.LoadedChar
                Select Case chkFlag.Name
                    Case chkFlag1.Name
                        QFG2.Flag1 = chkFlag.Checked
                    Case chkFlag2.Name
                        QFG2.Flag2 = chkFlag.Checked
                    Case chkFlag3.Name
                        QFG2.Flag3 = chkFlag.Checked
                    Case chkFlag4.Name
                        QFG2.Flag4 = chkFlag.Checked
                    Case chkFlag5.Name
                        QFG2.Flag5 = chkFlag.Checked
                    Case chkFlag6.Name
                        QFG2.Flag6 = chkFlag.Checked
                    Case chkFlag7.Name
                        QFG2.Flag7 = chkFlag.Checked
                    Case chkFlag8.Name
                        QFG2.Flag8 = chkFlag.Checked
                End Select
            End If
        End If
    End Sub

    Private Sub rdoCharClass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoFighter.CheckedChanged, rdoWizard.CheckedChanged, rdoThief.CheckedChanged, rdoPaladin.CheckedChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim classChange As RadioButton = sender
            Select Case classChange.Name
                Case rdoFighter.Name
                    Me.LoadedChar.CharacterClass = Enums.CharacterClass.Fighter
                Case rdoWizard.Name
                    Me.LoadedChar.CharacterClass = Enums.CharacterClass.Magic
                Case rdoThief.Name
                    Me.LoadedChar.CharacterClass = Enums.CharacterClass.Thief
                Case rdoPaladin.Name
                    Me.LoadedChar.CharacterClass = Enums.CharacterClass.Paladin
            End Select
        End If
    End Sub

    Private Sub numAbilitySkill_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numStrength.ValueChanged, numIntelligence.ValueChanged, numAgility.ValueChanged, numVitality.ValueChanged, numLuck.ValueChanged, numWeaponUse.ValueChanged, numParry.ValueChanged, numDodge.ValueChanged, numStealth.ValueChanged, numPickLocks.ValueChanged, numThrowing.ValueChanged, numClimbing.ValueChanged, numMagic.ValueChanged, numCommunication.ValueChanged, numHonor.ValueChanged, numAcrobatics.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            Select Case numValue.Name
                Case numStrength.Name
                    Me.LoadedChar.Strength = numValue.Value
                Case numIntelligence.Name
                    Me.LoadedChar.Intelligence = numValue.Value
                Case numAgility.Name
                    Me.LoadedChar.Agility = numValue.Value
                Case numVitality.Name
                    Me.LoadedChar.Vitality = numValue.Value
                Case numLuck.Name
                    Me.LoadedChar.Luck = numValue.Value
                Case numWeaponUse.Name
                    Me.LoadedChar.WeaponUse = numValue.Value
                Case numParry.Name
                    Me.LoadedChar.Parry = numValue.Value
                Case numDodge.Name
                    Me.LoadedChar.Dodge = numValue.Value
                Case numStealth.Name
                    Me.LoadedChar.Stealth = numValue.Value
                Case numPickLocks.Name
                    Me.LoadedChar.PickLocks = numValue.Value
                Case numThrowing.Name
                    Me.LoadedChar.Throwing = numValue.Value
                Case numClimbing.Name
                    Me.LoadedChar.Climbing = numValue.Value
                Case numMagic.Name
                    Me.LoadedChar.Magic = numValue.Value
                Case numCommunication.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG2 Then
                        DirectCast(Me.LoadedChar, CharQFG2).Communication = numValue.Value
                        'TODO: Add communication change for other games
                    End If
                Case numHonor.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG2 Then
                        DirectCast(Me.LoadedChar, CharQFG2).Honor = numValue.Value
                        'TODO: Add Honor change for other games
                    End If
                Case numAcrobatics.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG4 Then
                        'TODO: Add Acrobatics change
                    End If
            End Select
        End If
    End Sub

    Private Sub numMagicSpells_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numOpen.ValueChanged, numDetectMagic.ValueChanged, numTrigger.ValueChanged, numDazzle.ValueChanged, numZap.ValueChanged, numCalm.ValueChanged, numFlameDart.ValueChanged, numFetch.ValueChanged, numForceBolt.ValueChanged, numLevitation.ValueChanged, numReversal.ValueChanged, numJugglingLights.ValueChanged, numLightningBall.ValueChanged, numSummonStaff.ValueChanged, numHide.ValueChanged, numProtection.ValueChanged, numAura.ValueChanged, numGlide.ValueChanged, numResistance.ValueChanged, numFrostBite.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            Select Case numValue.Name
                Case numOpen.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Open, numValue.Value)
                Case numDetectMagic.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Detect, numValue.Value)
                Case numTrigger.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Trigger, numValue.Value)
                Case numDazzle.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Dazzle, numValue.Value)
                Case numZap.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Zap, numValue.Value)
                Case numCalm.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Calm, numValue.Value)
                Case numFlameDart.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Flame, numValue.Value)
                Case numFetch.Name
                    Me.LoadedChar.SetMagicSpell(Enums.Magic.Fetch, numValue.Value)
                Case numForceBolt.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG2 Then
                        DirectCast(Me.LoadedChar, CharQFG2).SetMagicSpell(Enums.Magic.ForceBolt, numValue.Value)
                    End If
                Case numLevitation.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG2 Then
                        DirectCast(Me.LoadedChar, CharQFG2).SetMagicSpell(Enums.Magic.Levitation, numValue.Value)
                    End If
                Case numReversal.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG2 Then
                        DirectCast(Me.LoadedChar, CharQFG2).SetMagicSpell(Enums.Magic.Reversal, numValue.Value)
                    End If
            End Select
        End If
    End Sub

    Private Sub numOther_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numPuzzlePoints.ValueChanged, numExperience.ValueChanged, numHealthPoints.ValueChanged, numStaminaPoints.ValueChanged, numMagicPoints.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            Select Case numValue.Name
                Case numPuzzlePoints.Name
                    Me.LoadedChar.PuzzlePoints = numValue.Value
                Case numExperience.Name
                    Me.LoadedChar.Experience = numValue.Value
                Case numHealthPoints.Name
                    Me.LoadedChar.HealthPoints = numValue.Value
                Case numStaminaPoints.Name
                    Me.LoadedChar.StaminaPoints = numValue.Value
                Case numMagicPoints.Name
                    Me.LoadedChar.MagicPoints = numValue.Value
            End Select
        End If
    End Sub

#End Region

#Region "Declarations_Main"

    Private Sub CloseCharacter()
        Me.LoadedChar = Nothing
        Me.LoadedFilename = Nothing
        Me.UnalteredData = Nothing
    End Sub

    Private Sub LoadForm()
        Me.Loading = True
        If Me.LoadedChar Is Nothing Then
            grpAbilities.Enabled = False
            grpClass.Enabled = False
            grpGames.Enabled = False
            grpSkills.Enabled = False
            grpSpells.Enabled = False
        Else
            txtName.Text = Me.LoadedChar.Name
            Call SelectClass(Me.LoadedChar.CharacterClass)
            Call SelectGame(Me.LoadedChar.Game)

            If TypeOf Me.LoadedChar Is CharQFG1 Then
                Call SetMaximumSkill(127)
                Call SetMaximumInventory(127)
                Call LoadQFG1Common()
                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag1
                chkFlag2.Checked = Me.LoadedChar.Flag2
                chkFlag3.Checked = Me.LoadedChar.Flag3
                chkFlag4.Checked = Me.LoadedChar.Flag4
                chkFlag5.Checked = Me.LoadedChar.Flag5
                chkFlag6.Checked = Me.LoadedChar.Flag6
                chkFlag7.Checked = Me.LoadedChar.Flag7

                'inventory
                numGold.Maximum = 10000
                numGold.Value = Me.LoadedChar.Currency

                numDaggers.Value = Me.LoadedChar.Daggers
                numHealingPotions.Value = Me.LoadedChar.HealingPotions
                numVigorPotions.Value = Me.LoadedChar.StaminaPotions
                numMagicPotions.Value = Me.LoadedChar.MagicPotions
                numOtherPotions.Value = DirectCast(Me.LoadedChar, CharQFG1).UndeadUnguent
            ElseIf TypeOf Me.LoadedChar Is CharQFG2 Then
                Call SetMaximumSkill(255)
                Call SetMaximumInventory(255)
                Call LoadQFG1Common()
                Call LoadQFG2Common()
                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag1
                chkFlag2.Checked = Me.LoadedChar.Flag2
                chkFlag3.Checked = Me.LoadedChar.Flag3
                chkFlag4.Checked = Me.LoadedChar.Flag4
                chkFlag5.Checked = Me.LoadedChar.Flag5
                chkFlag6.Checked = Me.LoadedChar.Flag6
                chkFlag7.Checked = Me.LoadedChar.Flag7
                chkFlag8.Checked = Me.LoadedChar.Flag8

                'inventory
                numGold.Maximum = 10000
                numGold.Value = Me.LoadedChar.Currency

                numDaggers.Value = Me.LoadedChar.Daggers
                numHealingPotions.Value = Me.LoadedChar.HealingPotions
                numVigorPotions.Value = Me.LoadedChar.StaminaPotions
                numMagicPotions.Value = Me.LoadedChar.MagicPotions
                numOtherPotions.Value = DirectCast(Me.LoadedChar, CharQFG2).PoisonCurePills

            End If

        End If
        EnableTestData(True)
        Call LoadTestData()
        Me.Loading = False
    End Sub

    Private Sub SetQFG1Display()
        chkFlag1.Text = "Broadsword"
        chkFlag2.Text = "Chainmail Armor"
        chkFlag3.Text = "Lock Pick"
        chkFlag4.Text = "Thief’s Tool Kit"
        chkFlag5.Text = "Hero of Spielburg"
        chkFlag6.Text = "Defeated Baba Yaga"
        chkFlag7.Text = "Flag7"
        chkFlag8.Text = "(unused)"
        chkFlag8.Enabled = False

        lblCurrency.Text = "Gold"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"
        lblOtherPotions.Text = "Undead Unguent"
    End Sub

    Private Sub SetQFG2Display()
        chkFlag1.Text = "Fine Sword"
        chkFlag2.Text = "Soulforge"
        chkFlag3.Text = "Saphirre Pin"
        chkFlag4.Text = "Brass Lamp"
        chkFlag5.Text = "EOF Badge"
        chkFlag6.Text = "X-Ray Glasses"
        chkFlag7.Text = "Broadsword"
        chkFlag8.Text = "Chainmail Armor"
        chkFlag8.Enabled = True

        lblCurrency.Text = "Golden Dinars"
        lblHealingPotions.Text = "Healing Pills"
        lblMagicPotions.Text = "Magic Pills"
        lblVigorPotions.Text = "Vigor Pills"
        lblOtherPotions.Text = "Poison Cure Pills"
    End Sub

    Private Sub SetQFG3Display()
        chkFlag1.Text = "Flag 1"
        chkFlag2.Text = "Flag 2"
        chkFlag3.Text = "Flag 3"
        chkFlag4.Text = "Flag 4"
        chkFlag5.Text = "Flag 5"
        chkFlag6.Text = "Flag 6"
        chkFlag7.Text = "Flag 7"
        chkFlag8.Text = "Flag 8"

        lblCurrency.Text = "Currency"
        lblHealingPotions.Text = "Healing Pills"
        lblMagicPotions.Text = "Magic Pills"
        lblVigorPotions.Text = "Vigor Pills"
        lblOtherPotions.Text = "Poison Cure Pills"
    End Sub

    Private Sub SetQFG4Display()
        chkFlag1.Text = "Flag 1"
        chkFlag2.Text = "Flag 2"
        chkFlag3.Text = "Flag 3"
        chkFlag4.Text = "Flag 4"
        chkFlag5.Text = "Flag 5"
        chkFlag6.Text = "Flag 6"
        chkFlag7.Text = "Flag 7"
        chkFlag8.Text = "Flag 8"

        lblCurrency.Text = "Currency"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"
        lblOtherPotions.Text = "Poison Cure Pills"
    End Sub

    Private Sub SelectGame(game As Enums.Games)
        Select Case game
            Case Enums.Games.QFG1
                rdoQFG1.Checked = True
            Case Enums.Games.QFG2
                rdoQFG2.Checked = True

            Case Enums.Games.QFG3
                rdoQFG3.Checked = True
            Case Enums.Games.QFG4
                rdoQFG4.Checked = True
        End Select
    End Sub

    Private Sub SelectClass(charClass As Enums.CharacterClass)
        Select Case charClass
            Case Enums.CharacterClass.Fighter
                rdoFighter.Checked = True
            Case Enums.CharacterClass.Magic
                rdoWizard.Checked = True
            Case Enums.CharacterClass.Thief
                rdoThief.Checked = True
            Case Enums.CharacterClass.Paladin
                rdoPaladin.Checked = True
            Case Else
        End Select
    End Sub

    Private Sub LoadQFG1Common()
        'abilities
        numStrength.Value = Me.LoadedChar.Strength
        numIntelligence.Value = Me.LoadedChar.Intelligence
        numAgility.Value = Me.LoadedChar.Agility
        numVitality.Value = Me.LoadedChar.Vitality
        numLuck.Value = Me.LoadedChar.Luck

        'skills
        numWeaponUse.Value = Me.LoadedChar.WeaponUse
        numParry.Value = Me.LoadedChar.Parry
        numDodge.Value = Me.LoadedChar.Dodge
        numStealth.Value = Me.LoadedChar.Stealth
        numPickLocks.Value = Me.LoadedChar.PickLocks
        numThrowing.Value = Me.LoadedChar.Throwing
        numClimbing.Value = Me.LoadedChar.Climbing
        numMagic.Value = Me.LoadedChar.Magic

        'magic
        numOpen.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Open)
        numDetectMagic.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Detect)
        numTrigger.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Trigger)
        numDazzle.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Dazzle)
        numZap.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Zap)
        numCalm.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Calm)
        numFlameDart.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Flame)
        numFetch.Value = Me.LoadedChar.GetMagicSpell(Enums.Magic.Fetch)

        'assorted other attributesd
        numExperience.Value = Me.LoadedChar.Experience
        numHealthPoints.Value = Me.LoadedChar.HealthPoints
        numStaminaPoints.Value = Me.LoadedChar.StaminaPoints
        numMagicPoints.Value = Me.LoadedChar.MagicPoints
        numPuzzlePoints.Maximum = 500
        numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints

    End Sub

    Private Sub LoadQFG2Common()
        numCommunication.Value = DirectCast(Me.LoadedChar, CharQFG2).Communication
        numHonor.Value = DirectCast(Me.LoadedChar, CharQFG2).Honor

        numForceBolt.Value = DirectCast(Me.LoadedChar, CharQFG2).GetMagicSpell(Enums.Magic.ForceBolt)
        numLevitation.Value = DirectCast(Me.LoadedChar, CharQFG2).GetMagicSpell(Enums.Magic.Levitation)
        numReversal.Value = DirectCast(Me.LoadedChar, CharQFG2).GetMagicSpell(Enums.Magic.Reversal)
    End Sub

    Private Sub EnableQFG1(enabled As Boolean)
        'Abilities QFG1
        lblStrength.Enabled = enabled
        numStrength.Enabled = enabled
        lblIntelligence.Enabled = enabled
        numIntelligence.Enabled = enabled
        lblAgility.Enabled = enabled
        numAgility.Enabled = enabled
        lblVitality.Enabled = enabled
        numVitality.Enabled = enabled
        lblLuck.Enabled = enabled
        numLuck.Enabled = enabled

        'Skills QFG1
        lblWeaponUse.Enabled = enabled
        numWeaponUse.Enabled = enabled
        lblParry.Enabled = enabled
        numParry.Enabled = enabled
        lblDodge.Enabled = enabled
        numDodge.Enabled = enabled
        lblStealth.Enabled = enabled
        numStealth.Enabled = enabled
        lblPickLocks.Enabled = enabled
        numPickLocks.Enabled = enabled
        lblThrowing.Enabled = enabled
        numThrowing.Enabled = enabled
        lblClimbing.Enabled = enabled
        numClimbing.Enabled = enabled
        lblMagic.Enabled = enabled
        numMagic.Enabled = enabled

        'Other QFG1
        lblExperience.Enabled = enabled
        numExperience.Enabled = enabled

        'Magic spells QFG1
        lblOpen.Enabled = enabled
        numOpen.Enabled = enabled
        lblDetectMagic.Enabled = enabled
        numDetectMagic.Enabled = enabled
        lblTrigger.Enabled = enabled
        numTrigger.Enabled = enabled
        lblDazzle.Enabled = enabled
        numDazzle.Enabled = enabled
        lblZap.Enabled = enabled
        numZap.Enabled = enabled
        lblCalm.Enabled = enabled
        numCalm.Enabled = enabled
        lblFlameDart.Enabled = enabled
        numFlameDart.Enabled = enabled
        lblFetch.Enabled = enabled
        numFetch.Enabled = enabled


    End Sub

    Private Sub EnableQFG2(enabled As Boolean)
        'magic spells QFG2
        lblForceBolt.Enabled = enabled
        numForceBolt.Enabled = enabled
        lblLevitation.Enabled = enabled
        numLevitation.Enabled = enabled
        lblReversal.Enabled = enabled
        numReversal.Enabled = enabled

        'skills QFG2
        lblCommunication.Enabled = enabled
        numCommunication.Enabled = enabled

        'other QFG2
        lblHonor.Enabled = enabled
        numHonor.Enabled = enabled

        rdoPaladin.Enabled = enabled
    End Sub

    Private Sub EnableQFG3(enabled As Boolean)
        lblJugglingLights.Enabled = enabled
        numJugglingLights.Enabled = enabled
        lblLightningBall.Enabled = enabled
        numLightningBall.Enabled = enabled
        lblSummonStaff.Enabled = enabled
        numSummonStaff.Enabled = enabled
    End Sub

    Private Sub EnableQFG4(enabled As Boolean)
        lblAcrobatics.Enabled = enabled
        numAcrobatics.Enabled = enabled

        lblGlide.Enabled = enabled
        numGlide.Enabled = enabled
        lblAura.Enabled = enabled
        numAura.Enabled = enabled
        lblFrostBite.Enabled = enabled
        numFrostBite.Enabled = enabled
        lblHide.Enabled = enabled
        numHide.Enabled = enabled
        lblProtection.Enabled = enabled
        numProtection.Enabled = enabled
        lblResistance.Enabled = enabled
        numResistance.Enabled = enabled
    End Sub

    Private Sub SetMaximumSkill(value As UShort)
        For Each num As Control In grpAbilities.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Maximum = value
            End If
        Next

        For Each num As Control In grpSkills.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Maximum = value
            End If
        Next

        For Each num As Control In grpSpells.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Maximum = value
            End If
        Next

        numHealingPotions.Maximum = value
        numStaminaPoints.Maximum = value
        numMagicPoints.Maximum = value
    End Sub

    Private Sub SetMaximumInventory(value As UShort)
        numDaggers.Maximum = value
        numHealingPotions.Maximum = value
        numVigorPotions.Maximum = value
        numMagicPotions.Maximum = value
        numOtherPotions.Maximum = value
    End Sub

#End Region

#Region "Events_RawEdit"
    Private Sub numOffset_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numOffset.ValueChanged
        Me.Loading = True
        Call LoadSelectedByte()
        Call HighlightSelectedByte()
        Me.Loading = False
    End Sub

    Private Sub numBytes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numBytes.ValueChanged
        If Not Me.Loading Then
            If numBytes.Value > 1 Then
                EnableEditingControls(False)
            Else
                EnableEditingControls(True)
            End If
            Call HighlightSelectedByte()
            Call LoadSelectedByte()
        End If
    End Sub

    Private Sub rdoBE_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoBE.CheckedChanged, rdoLE.CheckedChanged
        If Not Me.Loading Then
            Call LoadSelectedByte()
        End If
    End Sub

    Private Sub btnLoadReference_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadReference.Click
        Dim fso As New OpenFileDialog
        fso.Filter = "QFG Import Character (*.sav)|*.sav|All Files (*.*)|*.*"
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileContents As String = String.Empty
            Dim s As IO.FileStream = fso.OpenFile()
            If s.Length < 1024 Then
                Dim t As New IO.StreamReader(s)
                fileContents = t.ReadToEnd
            End If
            s.Close()

            lblOtherDataFilename.Text = System.IO.Path.GetFileName(fso.FileName)
            'CharGeneric.ParseCharacter(fileContents)
            Select Case CharGeneric.GetGame(fileContents)
                Case Enums.Games.QFG1
                    Me.ReferenceChar = New CharQFG1(fileContents)
                    Call LoadReferenceData()
                Case Enums.Games.QFG2
                    Me.ReferenceChar = New CharQFG2(fileContents)
                    Call LoadReferenceData()
                Case Enums.Games.QFG3
                Case Enums.Games.QFG4

            End Select

        End If
    End Sub

    Private Sub btnDeltaPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnDeltaPrev.Click
        For i As Integer = Me.DeltaOffsets.Count - 1 To 0 Step -1
            If Me.DeltaOffsets(i) < numOffset.Value Then
                numOffset.Value = Me.DeltaOffsets(i)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnDeltaNext_Click(sender As System.Object, e As System.EventArgs) Handles btnDeltaNext.Click
        For Each delta As Integer In Me.DeltaOffsets
            If delta > numOffset.Value Then
                numOffset.Value = delta
                Exit For
            End If
        Next
    End Sub

    Private Sub numValue_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numValue.ValueChanged
        If Not Me.Loading Then
            Call UpdateSelectedByte()
        End If
    End Sub

    Private Sub chkBit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBit0.CheckedChanged, chkBit1.CheckedChanged, chkBit2.CheckedChanged, chkBit3.CheckedChanged, chkBit4.CheckedChanged, chkBit5.CheckedChanged, chkBit6.CheckedChanged, chkBit7.CheckedChanged
        If Not Me.Loading Then
            Dim mask As Byte = 0
            mask = mask Or (Convert.ToSByte(chkBit0.Checked) << 0)
            mask = mask Or (Convert.ToSByte(chkBit1.Checked) << 1)
            mask = mask Or (Convert.ToSByte(chkBit2.Checked) << 2)
            mask = mask Or (Convert.ToSByte(chkBit3.Checked) << 3)
            mask = mask Or (Convert.ToSByte(chkBit4.Checked) << 4)
            mask = mask Or (Convert.ToSByte(chkBit5.Checked) << 5)
            mask = mask Or (Convert.ToSByte(chkBit6.Checked) << 6)
            mask = mask Or (Convert.ToByte(chkBit7.Checked) << 7)
            numValue.Value = mask
        End If
    End Sub

    Private Sub txtOriginalData_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOriginalData.MouseUp
        If Not Me.Loading Then
            Dim selected As Integer = 0
            selected = DirectCast(sender, TextBox).SelectionStart
            selected = Math.Floor(selected / 3)
            numOffset.Value = selected
        End If
    End Sub

    Private Sub btnCloseReference_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseReference.Click
        Call CloseReferenceData()
    End Sub

#End Region


#Region "Declarations_RawEdit"
    Private Sub EnableTestData(enabled As Boolean)
        For Each x As Control In tabRawData.Controls
            x.Enabled = enabled
        Next
    End Sub

    Private Sub LoadTestData()
        txtOriginalData.Text = Me.LoadedChar.DecodedValuesToString
        numOffset.Maximum = Me.LoadedChar.DecodedValues.Length - 1

        Call LoadSelectedByte()
        Call HighlightSelectedByte()
    End Sub

    ''' <summary>
    ''' Loads the selected byte for viewing/editing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSelectedByte()

        Dim offset As Integer = CInt(numOffset.Value)
        Dim byteCount As Integer = CInt(numBytes.Value)

        'set the maximum displayed value based on the number of Bytes represented
        numValue.Maximum = 2 ^ (8 * byteCount) - 1
        numValueHex.Maximum = numValue.Maximum

        Dim testvalue As Integer = Me.LoadedChar.DecodedValues(offset)

        'if we're doing multiple bytes, make sure we're not going outside the boundaries
        If (byteCount > 1) And (offset + byteCount < Me.LoadedChar.DecodedValues.Length) Then
            Dim bytes(byteCount - 1) As Byte
            For i As Integer = 0 To byteCount - 1
                bytes(i) = Me.LoadedChar.DecodedValues(offset + i)
            Next
            'sort big-endian or little endian accordingly
            testvalue = combineBytes(bytes, rdoLE.Checked)
        End If

        Call DisplaySelectedByte(testvalue)

        Call LoadSelectedByteReference()

        Select Case Me.LoadedChar.Game
            Case Enums.Games.QFG1
                lblByteName.Text = DirectCast(CInt(numOffset.Value), CharQFG1.ByteNames).ToString
            Case Enums.Games.QFG2
                lblByteName.Text = DirectCast(CInt(numOffset.Value), CharQFG2.ByteNames).ToString
            Case Enums.Games.QFG3
            Case Enums.Games.QFG4
        End Select
    End Sub

    Private Sub DisplaySelectedByte(value As Integer)
        numValue.Value = value
        numValueHex.Value = value

        If numBytes.Value = 1 AndAlso value < 256 Then
            SetBitCheckbox(value)
        Else
            SetBitCheckbox(0)
        End If
    End Sub

    Private Sub LoadSelectedByteReference()
        Dim offset As Integer = CInt(numOffset.Value)
        Dim byteCount As Integer = CInt(numBytes.Value)

        'only load if the reference character is loaded
        If Me.ReferenceChar IsNot Nothing Then
            'set the maximum displayed value based on the number of Bytes represented
            numReferenceValue.Maximum = 2 ^ (8 * byteCount) - 1
            numReferenceValueHex.Maximum = numReferenceValue.Maximum
            Dim tstOther As Integer = 0
            tstOther = Me.ReferenceChar.DecodedValues(offset)

            If (byteCount > 1) And (offset + byteCount < Me.ReferenceChar.DecodedValues.Length) Then
                Dim bytes(byteCount - 1) As Byte
                For i As Integer = 0 To byteCount - 1
                    bytes(i) = Me.ReferenceChar.DecodedValues(offset + i)
                Next
                tstOther = combineBytes(bytes, rdoLE.Checked)
            End If

            Call DisplaySelectedByteReference(tstOther)

        End If

    End Sub

    Private Sub DisplaySelectedByteReference(value As Integer)
        numReferenceValue.Value = value
        numReferenceValueHex.Value = value

        If numBytes.Value = 1 AndAlso value < 256 Then
            SetBitCheckboxReference(value)
        Else
            SetBitCheckboxReference(0)
        End If
    End Sub

    Private Function getBit(inputByte As Byte, bit As Byte) As Boolean
        If bit > 7 Then
            Return 0
        End If
        Dim mask As Byte = 1 << bit

        Return inputByte And mask
    End Function

    Private Sub SetBitCheckbox(value As Byte)
        chkBit0.Checked = getBit(value, 0)
        chkBit1.Checked = getBit(value, 1)
        chkBit2.Checked = getBit(value, 2)
        chkBit3.Checked = getBit(value, 3)
        chkBit4.Checked = getBit(value, 4)
        chkBit5.Checked = getBit(value, 5)
        chkBit6.Checked = getBit(value, 6)
        chkBit7.Checked = getBit(value, 7)
    End Sub

    Private Sub SetBitCheckboxReference(value As Byte)
        chkOther0.Checked = getBit(value, 0)
        chkOther1.Checked = getBit(value, 1)
        chkOther2.Checked = getBit(value, 2)
        chkOther3.Checked = getBit(value, 3)
        chkOther4.Checked = getBit(value, 4)
        chkOther5.Checked = getBit(value, 5)
        chkOther6.Checked = getBit(value, 6)
        chkOther7.Checked = getBit(value, 7)
    End Sub

    Private Function combineBytes(byteArray As Byte(), LittleEndian As Boolean) As Integer
        Dim rtn As Integer = 0
        Dim len As Integer = byteArray.Length
        If Not LittleEndian Then
            Array.Reverse(byteArray)
        End If
        Select Case byteArray.Length
            Case 1
                Return byteArray(0)
            Case 2
                Return BitConverter.ToInt16(byteArray, 0)
            Case 3
                Dim newB(4) As Byte
                newB(0) = 0
                For i As Integer = 1 To 3
                    newB(i) = byteArray(i)
                Next
                Return BitConverter.ToInt32(newB, 0)
            Case 4
                Return BitConverter.ToInt32(byteArray, 0)
            Case Else
                Return 0
        End Select
    End Function

    Private Sub HighlightSelectedByte()
        txtOriginalData.SelectionStart = 3 * numOffset.Value
        txtOriginalData.SelectionLength = (3 * numBytes.Value) - 1
        If Me.ReferenceChar IsNot Nothing Then
            txtReferenceData.SelectionStart = txtOriginalData.SelectionStart
            txtReferenceData.SelectionLength = txtOriginalData.SelectionLength
        End If
    End Sub

    Private Sub EnableEditingControls(enabled As Boolean)
        numValue.ReadOnly = Not enabled
        chkBit0.Enabled = enabled
        chkBit1.Enabled = enabled
        chkBit2.Enabled = enabled
        chkBit3.Enabled = enabled
        chkBit4.Enabled = enabled
        chkBit5.Enabled = enabled
        chkBit6.Enabled = enabled
        chkBit7.Enabled = enabled
    End Sub

    Private Sub LoadReferenceData()
        If Me.ReferenceChar IsNot Nothing Then
            numOffset.Value = 0
            txtReferenceData.Text = Me.ReferenceChar.DecodedValuesToString
            Me.DeltaOffsets.Clear()
            For i As Integer = 0 To Me.LoadedChar.DecodedValues.Length - 1
                If Not Me.LoadedChar.DecodedValues(i).Equals(Me.ReferenceChar.DecodedValues(i)) Then
                    Me.DeltaOffsets.Add(i)
                End If
            Next
            lblDifferences.Text = Me.DeltaOffsets.Count & " Differences"
            SetBitCheckboxReference(Me.ReferenceChar.DecodedValues(0))
            Call HighlightSelectedByte()
        Else
            txtReferenceData.Text = String.Empty
            lblOtherDataFilename.Text = String.Empty
        End If
    End Sub

    Private Sub CloseReferenceData()
        Me.ReferenceChar = Nothing
        Call LoadReferenceData()
    End Sub

    Private Sub UpdateSelectedByte()
        Me.LoadedChar.DecodedValues(numOffset.Value) = numValue.Value
        Call LoadForm()
    End Sub
#End Region

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        Dim tstDlg As New TestForm

        If tstDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileContents As String = tstDlg.FileContents

            Call LoadGameFromFileContents(fileContents)
        End If
    End Sub

    Private Sub Test()
        Dim qfg1 As CharQFG1 = LoadedChar
        Dim output As String = String.Empty
        For Each i As Integer In qfg1.DecodedValues
            output &= i.ToString & " "
        Next
        'MessageBox.Show(output)

        Dim newValues(qfg1.DecodedValues.Length - 1) As Integer
        newValues(0) = qfg1.EncodedData(0) >> 6
        For i As Integer = 1 To newValues.Length - 1
            newValues(i) = qfg1.EncodedData(i) >> 4 Or qfg1.EncodedData(i - 1) << 4
        Next

        Dim output2 As String = String.Empty
        For Each i As Integer In newValues
            output2 &= i.ToString & " "
        Next

        'MessageBox.Show(output & vbCrLf & vbCrLf & output2)
    End Sub

    Private Sub btnCipher_Click(sender As System.Object, e As System.EventArgs)
        If Me.UnalteredData Is Nothing Then
            Me.UnalteredData = Me.LoadedChar.EncodedData
            txtReferenceData.Text = CharGeneric.BytesToString(Me.UnalteredData)
        End If
        Dim s As String = InputBox("Please enter a cipher value (0 - 255):")
        Dim i As Byte
        If Byte.TryParse(s, i) Then
            Me.LoadedChar.DecodedValues = CharGeneric.DecodeBytesXor(Me.LoadedChar.EncodedData, i)
            Call LoadTestData()
        End If
    End Sub

    Private Sub btnAttemptRevert_Click(sender As System.Object, e As System.EventArgs)
        If Me.UnalteredData IsNot Nothing Then
            Me.LoadedChar.EncodedData = Me.UnalteredData
            Call Me.LoadedChar.DecodeValues()
            Call LoadTestData()
        End If
    End Sub

    Private Sub numCipher_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numCipher.ValueChanged, numEncodedBitShift.ValueChanged, numDecodedBitShift.ValueChanged
        If Not Me.Loading Then
            If TypeOf Me.LoadedChar Is CharQFG3 Then
                DirectCast(Me.LoadedChar, CharQFG3).RecalculateTestValues(numEncodedBitShift.Value, numDecodedBitShift.Value, numCipher.Value)
                Call RefreshTestDecrypting()
            End If
        End If
    End Sub
End Class
