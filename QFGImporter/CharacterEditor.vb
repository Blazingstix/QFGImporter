Public Class CharacterEditor
    Private Property Loading As Boolean = True
    Private Property OriginalTitle As String = String.Empty
    Private Property LoadedFilename As String = String.Empty
    Public Property LoadedChar As CharGeneric = Nothing
    Public Property ReferenceChar As CharGeneric = Nothing
    Public DeltaOffsets As New Collections.ArrayList
    Public Property UnalteredData As Byte()

#Region "Events_Main"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call PreLoadForm()
    End Sub

    Public Sub New(filename As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call PreLoadForm()
        Call Me.CloseCharacter()
        Me.LoadedFilename = filename
        Call LoadFromFile(filename)
    End Sub

    Public Sub New(character As CharGeneric)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call PreLoadForm()
        Me.LoadedFilename = "New Export"
        Me.LoadedChar = character
        Call LoadForm()
    End Sub

    Private Sub LoadFromFile(filename As String)
        Me.LoadedFilename = filename
        Dim fileContents As String = String.Empty
        Dim s As IO.FileStream = System.IO.File.OpenRead(filename)
        If s.Length < 1024 Then
            Dim t As New IO.StreamReader(s)
            fileContents = t.ReadToEnd
        End If
        s.Close()

        'set the form's title, based on the open file's name
        If LoadContents(fileContents) Then
            Me.Text = Me.OriginalTitle & ": " & System.IO.Path.GetFileName(Me.LoadedFilename)
        Else
            Me.Text = Me.OriginalTitle
            Me.LoadedFilename = Nothing
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Call PreLoadForm()
    End Sub

    Private Sub PreLoadForm()
        Me.OriginalTitle = Me.Text
        Call EnableTestData(False)
        lblOtherDataFilename.Text = String.Empty
        Me.Loading = False
        Call SetMaximumSkill(100)
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

            'set the form's title, based on the open file's name
            If LoadContents(fileContents) Then
                Me.Text = Me.OriginalTitle & ": " & System.IO.Path.GetFileName(Me.LoadedFilename)
            Else
                Me.Text = Me.OriginalTitle
                Me.LoadedFilename = Nothing
            End If

        End If
    End Sub

    Public Function LoadContents(fileContents As String) As Boolean
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
            Case Enums.Games.QFG4
                Me.LoadedChar = New CharQFG4(fileContents)
                Call LoadForm()
        End Select
        'now load the 3rd tab, all the debugging information
        Call LoadTestDisplay()
        Return True
    End Function

    Private Sub LoadCoverPicture()
        Dim xSelGame As New SelectGame
        picCover.Image = xSelGame.GetCover(Me.LoadedChar.Game)
    End Sub


    Private Sub RefreshTestDecrypting()
        'txtEncodedString.Text = Me.LoadedChar.EncodedString
        'lblEncodedStringLength.Text = Me.LoadedChar.EncodedString.Length
        'txtEncodedByteArray.Text = CharGeneric.BytesToString(DirectCast(Me.LoadedChar, CharQFG3).EncodedDataShort)
        'txtDecodedByteArray.Text = CharGeneric.BytesToString(DirectCast(Me.LoadedChar, CharQFG3).DecodedValuesShort)
        'txtDecodedByteArrayDecimal.Text = CharGeneric.BytesToString(DirectCast(Me.LoadedChar, CharQFG3).DecodedValuesShort, False)
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
            fs.Write(Me.LoadedChar.ExportString)
            fs.Close()
        End If
    End Sub

    Private Sub numInventory_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numGold.ValueChanged, numDaggers.ValueChanged, numHealingPotions.ValueChanged, numVigorPotions.ValueChanged, numMagicPotions.ValueChanged, numUndeadUnguent.ValueChanged, numPoisonCurePills.ValueChanged, numUnknownItem3.ValueChanged, numUnknownItem2.ValueChanged, numUnknownItem1.ValueChanged
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            Dim numValue As NumericUpDown = sender
            Select Case numValue.Name
                Case numGold.Name
                    Me.LoadedChar.Currency = numValue.Value
                Case numDaggers.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.Daggers) = numValue.Value
                Case numHealingPotions.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion) = numValue.Value
                Case numVigorPotions.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion) = numValue.Value
                Case numMagicPotions.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion) = numValue.Value
                Case numUndeadUnguent.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.UndeadUnguent) = numValue.Value
                Case numPoisonCurePills.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.PoisonCurePill) = numValue.Value
                Case numUnknownItem1.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem1) = numValue.Value
                Case numUnknownItem2.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem2) = numValue.Value
                Case numUnknownItem3.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem3) = numValue.Value
            End Select
        End If
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As System.EventArgs) Handles txtName.LostFocus
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            DirectCast(sender, TextBox).Text = Me.LoadedChar.Name
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtName.TextChanged
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            Me.LoadedChar.Name = DirectCast(sender, TextBox).Text
        End If
    End Sub

    Private Sub chkUniqueInventory_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFlag1.CheckedChanged, chkFlag2.CheckedChanged, chkFlag3.CheckedChanged, chkFlag4.CheckedChanged, chkFlag5.CheckedChanged, chkFlag6.CheckedChanged, chkFlag7.CheckedChanged, chkFlag8.CheckedChanged, chkFlag11.CheckedChanged, chkFlag16.CheckedChanged, chkFlag15.CheckedChanged, chkFlag14.CheckedChanged, chkFlag13.CheckedChanged, chkFlag12.CheckedChanged, chkFlag10.CheckedChanged, chkFlag9.CheckedChanged
        Dim chkFlag As CheckBox = sender
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            Select Case chkFlag.Name
                Case chkFlag1.Name
                    Me.LoadedChar.Flag(0) = chkFlag.Checked
                Case chkFlag2.Name
                    Me.LoadedChar.Flag(1) = chkFlag.Checked
                Case chkFlag3.Name
                    Me.LoadedChar.Flag(2) = chkFlag.Checked
                Case chkFlag4.Name
                    Me.LoadedChar.Flag(3) = chkFlag.Checked
                Case chkFlag5.Name
                    Me.LoadedChar.Flag(4) = chkFlag.Checked
                Case chkFlag6.Name
                    Me.LoadedChar.Flag(5) = chkFlag.Checked
                Case chkFlag7.Name
                    Me.LoadedChar.Flag(6) = chkFlag.Checked
                Case chkFlag8.Name
                    Me.LoadedChar.Flag(7) = chkFlag.Checked
                Case chkFlag9.Name
                    Me.LoadedChar.Flag(8) = chkFlag.Checked
                Case chkFlag10.Name
                    Me.LoadedChar.Flag(9) = chkFlag.Checked
                Case chkFlag11.Name
                    Me.LoadedChar.Flag(10) = chkFlag.Checked
                Case chkFlag12.Name
                    Me.LoadedChar.Flag(11) = chkFlag.Checked
                Case chkFlag13.Name
                    Me.LoadedChar.Flag(12) = chkFlag.Checked
                Case chkFlag14.Name
                    Me.LoadedChar.Flag(13) = chkFlag.Checked
                Case chkFlag15.Name
                    Me.LoadedChar.Flag(14) = chkFlag.Checked
                Case chkFlag16.Name
                    Me.LoadedChar.Flag(15) = chkFlag.Checked
            End Select
        End If
    End Sub

    Private Sub rdoCharClass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoFighter.CheckedChanged, rdoWizard.CheckedChanged, rdoThief.CheckedChanged, rdoPaladin.CheckedChanged
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
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

    Private Sub SetErrorColour(numeric As NumericUpDown)
        numeric.BackColor = Color.FromArgb(255, 199, 206)
        numeric.ForeColor = Color.FromArgb(156, 0, 6)
    End Sub

    Private Sub SetNormalColour(numeric As NumericUpDown)
        numeric.BackColor = Color.FromKnownColor(KnownColor.Window)
        numeric.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
    End Sub

    Private Sub SetWarningColour(numeric As NumericUpDown)
        numeric.BackColor = Color.Orange
        numeric.ForeColor = Color.Brown
    End Sub

    Private Sub numericUpDown_GotFocus(sender As Object, e As System.EventArgs) Handles numStrength.GotFocus, numIntelligence.GotFocus, numAgility.GotFocus, numVitality.GotFocus, numLuck.GotFocus, numWeaponUse.GotFocus, numParry.GotFocus, numDodge.GotFocus, numStealth.GotFocus, numPickLocks.GotFocus, numThrowing.GotFocus, numClimbing.GotFocus, numMagic.GotFocus, numCommunication.GotFocus, numHonor.GotFocus, numAcrobatics.GotFocus, numPuzzlePoints.GotFocus, numExperience.GotFocus, numHealthPoints.GotFocus, numStaminaPoints.GotFocus, numMagicPoints.GotFocus, numOpen.GotFocus, numDetectMagic.GotFocus, numTrigger.GotFocus, numDazzle.GotFocus, numZap.GotFocus, numCalm.GotFocus, numFlameDart.GotFocus, numFetch.GotFocus, numForceBolt.GotFocus, numLevitation.GotFocus, numReversal.GotFocus, numJugglingLights.GotFocus, numSummonStaff.GotFocus, numLightningBall.GotFocus, numHide.GotFocus, numProtection.GotFocus, numAura.GotFocus, numGlide.GotFocus, numResistance.GotFocus, numFrostBite.GotFocus, numGold.GotFocus, numDaggers.GotFocus, numHealingPotions.GotFocus, numMagicPotions.GotFocus, numVigorPotions.GotFocus, numUndeadUnguent.GotFocus, numPoisonCurePills.GotFocus, numUnknownItem1.GotFocus, numUnknownItem2.GotFocus, numUnknownItem3.GotFocus
        Dim xSender As NumericUpDown = sender
        xSender.Select(0, xSender.Value.ToString.Length)
    End Sub


    Private Sub numAbilitySkill_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numStrength.ValueChanged, numIntelligence.ValueChanged, numAgility.ValueChanged, numVitality.ValueChanged, numLuck.ValueChanged, numWeaponUse.ValueChanged, numParry.ValueChanged, numDodge.ValueChanged, numStealth.ValueChanged, numPickLocks.ValueChanged, numThrowing.ValueChanged, numClimbing.ValueChanged, numMagic.ValueChanged, numCommunication.ValueChanged, numHonor.ValueChanged, numAcrobatics.ValueChanged
        Dim numValue As NumericUpDown = sender
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            Select Case numValue.Name
                Case numStrength.Name
                    Me.LoadedChar.Skill(Enums.Skills.Strength) = numValue.Value
                Case numIntelligence.Name
                    Me.LoadedChar.Skill(Enums.Skills.Intelligence) = numValue.Value
                Case numAgility.Name
                    Me.LoadedChar.Skill(Enums.Skills.Agility) = numValue.Value
                Case numVitality.Name
                    Me.LoadedChar.Skill(Enums.Skills.Vitality) = numValue.Value
                Case numLuck.Name
                    Me.LoadedChar.Skill(Enums.Skills.Luck) = numValue.Value
                Case numWeaponUse.Name
                    Me.LoadedChar.Skill(Enums.Skills.WeaponUse) = numValue.Value
                Case numParry.Name
                    Me.LoadedChar.Skill(Enums.Skills.Parry) = numValue.Value
                Case numDodge.Name
                    Me.LoadedChar.Skill(Enums.Skills.Dodge) = numValue.Value
                Case numStealth.Name
                    Me.LoadedChar.Skill(Enums.Skills.Stealth) = numValue.Value
                Case numPickLocks.Name
                    Me.LoadedChar.Skill(Enums.Skills.Picklocks) = numValue.Value
                Case numThrowing.Name
                    Me.LoadedChar.Skill(Enums.Skills.Throwing) = numValue.Value
                Case numClimbing.Name
                    Me.LoadedChar.Skill(Enums.Skills.Climbing) = numValue.Value
                Case numMagic.Name
                    Me.LoadedChar.Skill(Enums.Skills.Magic) = numValue.Value
                Case numCommunication.Name
                    If Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                        Me.LoadedChar.Skill(Enums.Skills.Communication) = numValue.Value
                    End If
                Case numHonor.Name
                    If Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                        Me.LoadedChar.Skill(Enums.Skills.Honor) = numValue.Value
                    End If
                Case numAcrobatics.Name
                    If Me.LoadedChar.Game = Enums.Games.QFG4 Then
                        Me.LoadedChar.Skill(Enums.Skills.Acrobatics) = numValue.Value
                    End If
            End Select
        End If
        If Me.LoadedChar IsNot Nothing Then
            If numValue.Value < 0 Or numValue.Value > Me.LoadedChar.SkillTechnicalMaximum Then
                SetErrorColour(numValue)
            Else
                SetNormalColour(numValue)
            End If
        End If
    End Sub

    Private Sub numMagicSpells_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numOpen.ValueChanged, numDetectMagic.ValueChanged, numTrigger.ValueChanged, numDazzle.ValueChanged, numZap.ValueChanged, numCalm.ValueChanged, numFlameDart.ValueChanged, numFetch.ValueChanged, numForceBolt.ValueChanged, numLevitation.ValueChanged, numReversal.ValueChanged, numJugglingLights.ValueChanged, numLightningBall.ValueChanged, numSummonStaff.ValueChanged, numHide.ValueChanged, numProtection.ValueChanged, numAura.ValueChanged, numGlide.ValueChanged, numResistance.ValueChanged, numFrostBite.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            If Not Me.Loading Then
                Select Case numValue.Name
                    Case numOpen.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Open) = numValue.Value
                    Case numDetectMagic.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Detect) = numValue.Value
                    Case numTrigger.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Trigger) = numValue.Value
                    Case numDazzle.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Dazzle) = numValue.Value
                    Case numZap.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Zap) = numValue.Value
                    Case numCalm.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Calm) = numValue.Value
                    Case numFlameDart.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Flame) = numValue.Value
                    Case numFetch.Name
                        Me.LoadedChar.MagicSpell(Enums.Magic.Fetch) = numValue.Value
                    Case numForceBolt.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.ForceBolt) = numValue.Value
                        End If
                    Case numLevitation.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Levitation) = numValue.Value
                        End If
                    Case numReversal.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Reversal) = numValue.Value
                        End If
                    Case numJugglingLights.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG3 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.JugglingLights) = numValue.Value
                        End If
                    Case numSummonStaff.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG3 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.SummonStaff) = numValue.Value
                        End If
                    Case numLightningBall.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG3 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.LightningBall) = numValue.Value
                        End If
                    Case numHide.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Hide) = numValue.Value
                        End If
                    Case numProtection.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Protection) = numValue.Value
                        End If
                    Case numAura.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Aura) = numValue.Value
                        End If
                    Case numGlide.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Glide) = numValue.Value
                        End If
                    Case numResistance.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Resistance) = numValue.Value
                        End If
                    Case numFrostBite.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.FrostBite) = numValue.Value
                        End If
                End Select
            End If

            'set control colours
            If numValue.Value < 0 Or numValue.Value > Me.LoadedChar.SkillTechnicalMaximum Then
                SetErrorColour(numValue)
            Else
                SetNormalColour(numValue)
            End If
        End If
    End Sub

    Private Sub numOther_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numPuzzlePoints.ValueChanged, numExperience.ValueChanged, numHealthPoints.ValueChanged, numStaminaPoints.ValueChanged, numMagicPoints.ValueChanged
        If Me.LoadedChar IsNot Nothing Then
            Dim numValue As NumericUpDown = sender
            If Not Me.Loading Then
                Select Case numValue.Name
                    Case numPuzzlePoints.Name
                        Me.LoadedChar.PuzzlePoints = numValue.Value
                    Case numExperience.Name
                        Me.LoadedChar.OtherSkill(Enums.OtherSkills.Experience) = numValue.Value
                    Case numHealthPoints.Name
                        Me.LoadedChar.OtherSkill(Enums.OtherSkills.HealthPoints) = numValue.Value
                    Case numStaminaPoints.Name
                        Me.LoadedChar.OtherSkill(Enums.OtherSkills.StaminaPoints) = numValue.Value
                    Case numMagicPoints.Name
                        Me.LoadedChar.OtherSkill(Enums.OtherSkills.MagicPoints) = numValue.Value
                End Select
            End If
            'set control colours
            Dim min As Integer = 0
            Dim max As Integer = Me.LoadedChar.SkillTechnicalMaximum
            Select Case numValue.Name
                Case numExperience.Name
                    max = 10000
            End Select
            If numValue.Value < min Or numValue.Value > max Then
                SetErrorColour(numValue)
            Else
                SetNormalColour(numValue)
            End If
        End If
    End Sub

#End Region

#Region "Declarations_Main"

    Private Sub CloseCharacter()
        Me.LoadedChar = Nothing
        Me.LoadedFilename = Nothing
        Me.UnalteredData = Nothing
        Call ClearAllFields()
    End Sub

    Private Sub ClearAllFields()
        For Each x As Control In grpAbilities.Controls
            If TypeOf x Is NumericUpDown Then
                DirectCast(x, NumericUpDown).Value = 0
            End If
        Next

        For Each x As Control In grpSkills.Controls
            If TypeOf x Is NumericUpDown Then
                DirectCast(x, NumericUpDown).Value = 0
            End If
        Next

        For Each x As Control In grpOther.Controls
            If TypeOf x Is NumericUpDown Then
                DirectCast(x, NumericUpDown).Value = 0
            End If
        Next

        For Each x As Control In grpSpells.Controls
            If TypeOf x Is NumericUpDown Then
                DirectCast(x, NumericUpDown).Value = 0
            End If
        Next

        For Each x As Control In grpInventory.Controls
            If TypeOf x Is NumericUpDown Then
                DirectCast(x, NumericUpDown).Value = 0
            End If
        Next

        For Each x As Control In grpUniqueInventory.Controls
            If TypeOf x Is CheckBox Then
                DirectCast(x, CheckBox).Checked = False
            End If
        Next

    End Sub

    Private Sub LoadForm()
        Me.Loading = True

        If Me.LoadedChar Is Nothing Then
            grpAbilities.Enabled = False
            grpClass.Enabled = False
            grpSkills.Enabled = False
            grpSpells.Enabled = False
        Else
            Call LoadCoverPicture()

            txtName.Text = Me.LoadedChar.Name
            Call SelectClass(Me.LoadedChar.CharacterClass)

            Call SelectGame(Me.LoadedChar.Game)

            If TypeOf Me.LoadedChar Is CharQFG1 Then
                Call SetMaximumSkill(100)
                Call SetMinimumSkill(0)
                Call SetMaximumInventory(127)
                Call LoadQFG1Common()

                'load puzzle points
                numPuzzlePoints.Maximum = 500
                numPuzzlePoints.Enabled = True
                numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints

                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag(0)
                chkFlag2.Checked = Me.LoadedChar.Flag(1)
                chkFlag3.Checked = Me.LoadedChar.Flag(2)
                chkFlag4.Checked = Me.LoadedChar.Flag(3)
                chkFlag5.Checked = Me.LoadedChar.Flag(4)
                chkFlag6.Checked = Me.LoadedChar.Flag(5)
                chkFlag7.Checked = Me.LoadedChar.Flag(6)

                'inventory
                numGold.Maximum = 10000
                SafeSetNumericValue(numGold, Me.LoadedChar.Currency)

                SafeSetNumericValue(numDaggers, Me.LoadedChar.Inventory(Enums.Inventory.Daggers))
                SafeSetNumericValue(numHealingPotions, Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion))
                SafeSetNumericValue(numMagicPotions, Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion))
                SafeSetNumericValue(numPoisonCurePills, 0)
                SafeSetNumericValue(numVigorPotions, Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion))
                SafeSetNumericValue(numUndeadUnguent, Me.LoadedChar.Inventory(Enums.Inventory.UndeadUnguent))
                SafeSetNumericValue(numUnknownItem1, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem1))
                SafeSetNumericValue(numUnknownItem2, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem2))
                SafeSetNumericValue(numUnknownItem3, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem3))
            ElseIf TypeOf Me.LoadedChar Is CharQFG2 Then
                Call SetMaximumSkill(255)
                Call SetMinimumSkill(0)
                Call SetMaximumInventory(255)
                Call LoadQFG1Common()
                Call LoadQFG2Common()

                'load puzzle points
                numPuzzlePoints.Maximum = 550
                numPuzzlePoints.Enabled = True
                numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints

                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag(0)
                chkFlag2.Checked = Me.LoadedChar.Flag(1)
                chkFlag3.Checked = Me.LoadedChar.Flag(2)
                chkFlag4.Checked = Me.LoadedChar.Flag(3)
                chkFlag5.Checked = Me.LoadedChar.Flag(4)
                chkFlag6.Checked = Me.LoadedChar.Flag(5)
                chkFlag7.Checked = Me.LoadedChar.Flag(6)
                chkFlag8.Checked = Me.LoadedChar.Flag(7)

                'inventory
                numGold.Maximum = 10000
                SafeSetNumericValue(numGold, Me.LoadedChar.Currency)

                SafeSetNumericValue(numDaggers, Me.LoadedChar.Inventory(Enums.Inventory.Daggers))
                SafeSetNumericValue(numHealingPotions, Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion))
                SafeSetNumericValue(numMagicPotions, Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion))
                SafeSetNumericValue(numPoisonCurePills, Me.LoadedChar.Inventory(Enums.Inventory.PoisonCurePill))
                SafeSetNumericValue(numVigorPotions, Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion))
                SafeSetNumericValue(numUndeadUnguent, 0)
                SafeSetNumericValue(numUnknownItem1, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem1))
                SafeSetNumericValue(numUnknownItem2, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem2))
                SafeSetNumericValue(numUnknownItem3, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem3))
            ElseIf TypeOf Me.LoadedChar Is CharQFG3 Then
                Call SetMaximumSkill(Me.LoadedChar.SkillTechnicalMaximum)
                Call SetMinimumSkill(0)
                Call SetMaximumInventory(500)
                Call LoadQFG1Common()
                Call LoadQFG2Common()
                Call LoadQFG3Common()
                'load puzzle points
                numPuzzlePoints.Maximum = 500
                numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints
                numPuzzlePoints.Enabled = False

                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag(0)
                chkFlag2.Checked = Me.LoadedChar.Flag(1)
                chkFlag3.Checked = Me.LoadedChar.Flag(2)
                chkFlag4.Checked = Me.LoadedChar.Flag(3)
                chkFlag5.Checked = Me.LoadedChar.Flag(4)
                chkFlag6.Checked = Me.LoadedChar.Flag(5)
                chkFlag7.Checked = Me.LoadedChar.Flag(6)
                chkFlag8.Checked = Me.LoadedChar.Flag(7)
                chkFlag9.Checked = Me.LoadedChar.Flag(8)
                chkFlag10.Checked = Me.LoadedChar.Flag(9)
                chkFlag11.Checked = Me.LoadedChar.Flag(10)
                chkFlag12.Checked = Me.LoadedChar.Flag(11)
                chkFlag13.Checked = Me.LoadedChar.Flag(12)
                chkFlag14.Checked = Me.LoadedChar.Flag(13)
                chkFlag15.Checked = Me.LoadedChar.Flag(14)
                chkFlag16.Checked = Me.LoadedChar.Flag(15)

                'inventory
                numGold.Maximum = 10000
                SafeSetNumericValue(numGold, Me.LoadedChar.Currency)

                SafeSetNumericValue(numDaggers, Me.LoadedChar.Inventory(Enums.Inventory.Daggers))
                SafeSetNumericValue(numHealingPotions, Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion))
                SafeSetNumericValue(numMagicPotions, Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion))
                SafeSetNumericValue(numPoisonCurePills, Me.LoadedChar.Inventory(Enums.Inventory.PoisonCurePill))
                SafeSetNumericValue(numVigorPotions, Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion))
                SafeSetNumericValue(numUndeadUnguent, 0)
                SafeSetNumericValue(numUnknownItem1, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem1))
                SafeSetNumericValue(numUnknownItem2, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem2))
                SafeSetNumericValue(numUnknownItem3, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem3))

            ElseIf TypeOf Me.LoadedChar Is CharQFG4 Then
                Call SetMaximumSkill(Me.LoadedChar.SkillTechnicalMaximum)
                Call SetMinimumSkill(0)
                Call SetMaximumInventory(500)
                Call LoadQFG1Common()
                Call LoadQFG2Common()
                Call LoadQFG3Common()
                Call LoadQFG4Common()

                numPuzzlePoints.Enabled = False
                numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints

                'unique inventory
                chkFlag1.Checked = Me.LoadedChar.Flag(0)
                chkFlag2.Checked = Me.LoadedChar.Flag(1)
                chkFlag3.Checked = Me.LoadedChar.Flag(2)
                chkFlag4.Checked = Me.LoadedChar.Flag(3)
                chkFlag5.Checked = Me.LoadedChar.Flag(4)
                chkFlag6.Checked = Me.LoadedChar.Flag(5)
                chkFlag7.Checked = Me.LoadedChar.Flag(6)
                chkFlag8.Checked = Me.LoadedChar.Flag(7)
                chkFlag9.Checked = Me.LoadedChar.Flag(8)
                chkFlag10.Checked = Me.LoadedChar.Flag(9)
                chkFlag11.Checked = Me.LoadedChar.Flag(10)
                chkFlag12.Checked = Me.LoadedChar.Flag(11)
                chkFlag13.Checked = Me.LoadedChar.Flag(12)
                chkFlag14.Checked = Me.LoadedChar.Flag(13)
                chkFlag15.Checked = Me.LoadedChar.Flag(14)
                chkFlag16.Checked = Me.LoadedChar.Flag(15)

                'inventory
                numGold.Maximum = 10000
                SafeSetNumericValue(numGold, Me.LoadedChar.Currency)

                SafeSetNumericValue(numDaggers, Me.LoadedChar.Inventory(Enums.Inventory.Daggers))
                SafeSetNumericValue(numHealingPotions, Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion))
                SafeSetNumericValue(numMagicPotions, Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion))
                SafeSetNumericValue(numPoisonCurePills, Me.LoadedChar.Inventory(Enums.Inventory.PoisonCurePill))
                SafeSetNumericValue(numVigorPotions, Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion))
                SafeSetNumericValue(numUndeadUnguent, 0)
                SafeSetNumericValue(numUnknownItem1, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem1))
                SafeSetNumericValue(numUnknownItem2, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem2))
                SafeSetNumericValue(numUnknownItem3, Me.LoadedChar.Inventory(Enums.Inventory.UnknownItem3))
            End If

        End If
        EnableTestData(True)
        Call LoadTestData()
        Me.Loading = False
    End Sub

    Private Sub SafeSetNumericValue(numeric As NumericUpDown, value As Integer)
        If value > numeric.Maximum Then
            numeric.Tag = numeric.Maximum
            numeric.Maximum = value
            numeric.Value = value
        ElseIf value < numeric.Minimum Then
            numeric.Tag = numeric.Minimum
            numeric.Minimum = value
            numeric.Value = value
        Else
            numeric.Value = value
        End If
    End Sub

    Private Sub ExtendedUniqueItemsEnabled(enabled As Boolean)
        chkFlag9.Enabled = enabled
        chkFlag10.Enabled = enabled
        chkFlag11.Enabled = enabled
        chkFlag12.Enabled = enabled
        chkFlag13.Enabled = enabled
        chkFlag14.Enabled = enabled
        chkFlag15.Enabled = enabled
        chkFlag16.Enabled = enabled
        If Not enabled Then
            chkFlag9.Text = "(unused)"
            chkFlag10.Text = "(unused)"
            chkFlag11.Text = "(unused)"
            chkFlag12.Text = "(unused)"
            chkFlag13.Text = "(unused)"
            chkFlag14.Text = "(unused)"
            chkFlag15.Text = "(unused)"
            chkFlag16.Text = "(unused)"
        End If
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
        ExtendedUniqueItemsEnabled(False)

        lblCurrency.Text = "Gold"
        lblDaggers.Text = "Daggers"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"
        numVigorPotions.Enabled = True
        numUndeadUnguent.Enabled = True
        numPoisonCurePills.Enabled = False
        numUnknownItem1.Enabled = False
        numUnknownItem2.Enabled = False
        numUnknownItem3.Enabled = False
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
        ExtendedUniqueItemsEnabled(False)

        lblCurrency.Text = "Golden Dinars"
        lblDaggers.Text = "Daggers"
        lblHealingPotions.Text = "Healing Pills"
        lblMagicPotions.Text = "Magic Pills"
        lblVigorPotions.Text = "Vigor Pills"
        numVigorPotions.Enabled = True
        numUndeadUnguent.Enabled = False
        numPoisonCurePills.Enabled = True
        numUnknownItem1.Enabled = False
        numUnknownItem2.Enabled = False
        numUnknownItem3.Enabled = False
    End Sub

    Private Sub SetQFG3Display()
        chkFlag1.Text = "Flag 1"
        chkFlag2.Text = "Flag 2"
        chkFlag3.Text = "Sapphire Pin"
        chkFlag4.Text = "Flag 4"
        chkFlag5.Text = "Flag 5"
        chkFlag6.Text = "Flag 6"
        chkFlag7.Text = "Flag 7"
        chkFlag8.Text = "Flag 8"
        chkFlag9.Text = "Flag 9"
        chkFlag10.Text = "Flag 10"
        chkFlag11.Text = "Flag 11"
        chkFlag12.Text = "Flag 12"
        chkFlag13.Text = "Flag 13"
        chkFlag14.Text = "Flag 14"
        chkFlag15.Text = "Flag 15"
        chkFlag16.Text = "Flag 16"
        chkFlag8.Enabled = True
        ExtendedUniqueItemsEnabled(True)

        lblCurrency.Text = "Golden Royals"
        lblDaggers.Text = "Throwing Daggers"
        lblHealingPotions.Text = "Healing Pills"
        lblMagicPotions.Text = "Magic Pills"
        lblVigorPotions.Text = "Vigor Pills"

        numVigorPotions.Enabled = False
        numUndeadUnguent.Enabled = False
        numPoisonCurePills.Enabled = True
        numUnknownItem1.Enabled = True
        numUnknownItem2.Enabled = True
        numUnknownItem3.Enabled = True

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
        chkFlag9.Text = "Flag 9"
        chkFlag10.Text = "Flag 10"
        chkFlag11.Text = "Flag 11"
        chkFlag12.Text = "Flag 12"
        chkFlag13.Text = "Flag 13"
        chkFlag14.Text = "Flag 14"
        chkFlag15.Text = "Flag 15"
        chkFlag16.Text = "Flag 16"
        chkFlag8.Enabled = True
        ExtendedUniqueItemsEnabled(True)

        lblCurrency.Text = "Golden Crowns"
        lblDaggers.Text = "Throwing Daggers"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"

        numVigorPotions.Enabled = False
        numUndeadUnguent.Enabled = False
        numPoisonCurePills.Enabled = True
        numUnknownItem1.Enabled = True
        numUnknownItem2.Enabled = True
        numUnknownItem3.Enabled = True

    End Sub

    Private Sub SelectGame(game As Enums.Games)
        Dim Is4 As Boolean = False
        Dim Is3 As Boolean = False
        Dim Is2 As Boolean = False
        Dim Is1 As Boolean = False

        Select Case game
            Case Enums.Games.QFG1
                Call SetQFG1Display()
                Is1 = True
            Case Enums.Games.QFG2
                Call SetQFG2Display()
                Is2 = True
            Case Enums.Games.QFG3
                Call SetQFG3Display()
                Is3 = True
            Case Enums.Games.QFG4
                Call SetQFG4Display()
                Is4 = True
        End Select

        EnableQFG4(Is4)
        EnableQFG3(Is4 Or Is3)
        EnableQFG2(Is4 Or Is3 Or Is2)
        EnableQFG1(Is4 Or Is3 Or Is2 Or Is1)
        If game = Enums.Games.QFG1 And rdoPaladin.Checked Then
            rdoFighter.Checked = True
        End If
        rdoPaladin.Enabled = True

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
        SafeSetNumericValue(numStrength, Me.LoadedChar.Skill(Enums.Skills.Strength))
        SafeSetNumericValue(numIntelligence, Me.LoadedChar.Skill(Enums.Skills.Intelligence))
        SafeSetNumericValue(numAgility, Me.LoadedChar.Skill(Enums.Skills.Agility))
        SafeSetNumericValue(numVitality, Me.LoadedChar.Skill(Enums.Skills.Vitality))
        SafeSetNumericValue(numLuck, Me.LoadedChar.Skill(Enums.Skills.Luck))

        'skills
        SafeSetNumericValue(numWeaponUse, Me.LoadedChar.Skill(Enums.Skills.WeaponUse))
        SafeSetNumericValue(numParry, Me.LoadedChar.Skill(Enums.Skills.Parry))
        SafeSetNumericValue(numDodge, Me.LoadedChar.Skill(Enums.Skills.Dodge))
        SafeSetNumericValue(numStealth, Me.LoadedChar.Skill(Enums.Skills.Stealth))
        SafeSetNumericValue(numPickLocks, Me.LoadedChar.Skill(Enums.Skills.Picklocks))
        SafeSetNumericValue(numThrowing, Me.LoadedChar.Skill(Enums.Skills.Throwing))
        SafeSetNumericValue(numClimbing, Me.LoadedChar.Skill(Enums.Skills.Climbing))
        SafeSetNumericValue(numMagic, Me.LoadedChar.Skill(Enums.Skills.Magic))

        'magic
        SafeSetNumericValue(numOpen, Me.LoadedChar.MagicSpell(Enums.Magic.Open))
        SafeSetNumericValue(numDetectMagic, Me.LoadedChar.MagicSpell(Enums.Magic.Detect))
        SafeSetNumericValue(numTrigger, Me.LoadedChar.MagicSpell(Enums.Magic.Trigger))
        SafeSetNumericValue(numDazzle, Me.LoadedChar.MagicSpell(Enums.Magic.Dazzle))
        SafeSetNumericValue(numZap, Me.LoadedChar.MagicSpell(Enums.Magic.Zap))
        SafeSetNumericValue(numCalm, Me.LoadedChar.MagicSpell(Enums.Magic.Calm))
        SafeSetNumericValue(numFlameDart, Me.LoadedChar.MagicSpell(Enums.Magic.Flame))
        SafeSetNumericValue(numFetch, Me.LoadedChar.MagicSpell(Enums.Magic.Fetch))

        'assorted other attributesd
        If TypeOf Me.LoadedChar Is CharV2 Then
            numExperience.Maximum = 10000
        End If
        SafeSetNumericValue(numExperience, Me.LoadedChar.OtherSkill(Enums.OtherSkills.Experience))
        SafeSetNumericValue(numHealthPoints, Me.LoadedChar.OtherSkill(Enums.OtherSkills.HealthPoints))
        SafeSetNumericValue(numStaminaPoints, Me.LoadedChar.OtherSkill(Enums.OtherSkills.StaminaPoints))
        SafeSetNumericValue(numMagicPoints, Me.LoadedChar.OtherSkill(Enums.OtherSkills.MagicPoints))

    End Sub

    Private Sub LoadQFG2Common()
        SafeSetNumericValue(numCommunication, Me.LoadedChar.Skill(Enums.Skills.Communication))
        SafeSetNumericValue(numHonor, Me.LoadedChar.Skill(Enums.Skills.Honor))

        SafeSetNumericValue(numForceBolt, Me.LoadedChar.MagicSpell(Enums.Magic.ForceBolt))
        SafeSetNumericValue(numLevitation, Me.LoadedChar.MagicSpell(Enums.Magic.Levitation))
        SafeSetNumericValue(numReversal, Me.LoadedChar.MagicSpell(Enums.Magic.Reversal))
    End Sub

    Private Sub LoadQFG3Common()
        SafeSetNumericValue(numJugglingLights, Me.LoadedChar.MagicSpell(Enums.Magic.JugglingLights))
        SafeSetNumericValue(numLightningBall, Me.LoadedChar.MagicSpell(Enums.Magic.LightningBall))
        SafeSetNumericValue(numSummonStaff, Me.LoadedChar.MagicSpell(Enums.Magic.SummonStaff))
    End Sub

    Private Sub LoadQFG4Common()
        SafeSetNumericValue(numAcrobatics, Me.LoadedChar.Skill(Enums.Skills.Acrobatics))

        SafeSetNumericValue(numHide, Me.LoadedChar.MagicSpell(Enums.Magic.Hide))
        SafeSetNumericValue(numProtection, Me.LoadedChar.MagicSpell(Enums.Magic.Protection))
        SafeSetNumericValue(numAura, Me.LoadedChar.MagicSpell(Enums.Magic.Aura))
        SafeSetNumericValue(numGlide, Me.LoadedChar.MagicSpell(Enums.Magic.Glide))
        SafeSetNumericValue(numResistance, Me.LoadedChar.MagicSpell(Enums.Magic.Resistance))
        SafeSetNumericValue(numFrostBite, Me.LoadedChar.MagicSpell(Enums.Magic.FrostBite))
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

    Private Sub SetMaximumSkill(value As Short)
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

        numHealthPoints.Maximum = value
        numStaminaPoints.Maximum = value
        numMagicPoints.Maximum = value
    End Sub

    Private Sub SetMinimumSkill(value As Short)
        For Each num As Control In grpAbilities.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Minimum = value
            End If
        Next

        For Each num As Control In grpSkills.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Minimum = value
            End If
        Next

        For Each num As Control In grpSpells.Controls
            If TypeOf num Is NumericUpDown Then
                DirectCast(num, NumericUpDown).Minimum = value
            End If
        Next

        numHealthPoints.Minimum = value
        numStaminaPoints.Minimum = value
        numMagicPoints.Minimum = value
    End Sub


    Private Sub SetMaximumInventory(max As Short, Optional min As Short = 0)
        numDaggers.Maximum = max
        numDaggers.Minimum = min
        numHealingPotions.Maximum = max
        numHealingPotions.Minimum = min
        numVigorPotions.Maximum = max
        numVigorPotions.Minimum = min
        numMagicPotions.Maximum = max
        numMagicPoints.Minimum = min
        numUndeadUnguent.Maximum = max
        numUndeadUnguent.Minimum = min
        numPoisonCurePills.Maximum = max
        numPoisonCurePills.Minimum = min
        numUnknownItem1.Maximum = max
        numUnknownItem1.Minimum = min
        numUnknownItem2.Maximum = max
        numUnknownItem1.Minimum = min
        numUnknownItem3.Maximum = max
        numUnknownItem3.Minimum = min
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
            If TypeOf Me.LoadedChar Is CharV2 Then
                Dim selected As Integer = 0
                selected = DirectCast(sender, TextBox).SelectionStart
                selected = Math.Floor(selected / 5)
                numOffset.Value = selected
            Else
                Dim selected As Integer = 0
                selected = DirectCast(sender, TextBox).SelectionStart
                selected = Math.Floor(selected / 3)
                numOffset.Value = selected
            End If
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
        If TypeOf Me.LoadedChar Is CharV2 Then
            numOffset.Maximum = DirectCast(Me.LoadedChar, CharV2).DecodedValues.Length - 1
        Else
            numOffset.Maximum = Me.LoadedChar.DecodedValues.Length - 1
        End If

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

        Dim testvalue As Integer = 0
        If TypeOf Me.LoadedChar Is CharV2 Then
            testvalue = DirectCast(Me.LoadedChar, CharV2).DecodedValues(offset)
        Else
            testvalue = Me.LoadedChar.DecodedValues(offset)
        End If

        'if we're doing multiple bytes, make sure we're not going outside the boundaries
        If TypeOf Me.LoadedChar Is CharV2 Then
            'If (byteCount > 1) And (offset + byteCount < DirectCast(Me.LoadedChar, CharV2).DecodedValues.Length) Then
            '    Dim bytes(byteCount - 1) As Short
            '    For i As Integer = 0 To byteCount - 1
            '        bytes(i) = Me.LoadedChar.DecodedValues(offset + i)
            '    Next
            '    'sort big-endian or little endian accordingly
            '    ' testvalue = combineBytes(bytes, rdoLE.Checked)
            'End If
        Else
            If (byteCount > 1) And (offset + byteCount < Me.LoadedChar.DecodedValues.Length) Then
                Dim bytes(byteCount - 1) As Byte
                For i As Integer = 0 To byteCount - 1
                    bytes(i) = Me.LoadedChar.DecodedValues(offset + i)
                Next
                'sort big-endian or little endian accordingly
                testvalue = combineBytes(bytes, rdoLE.Checked)
            End If
        End If

        'Call DisplaySelectedByte(testvalue)

        'Call LoadSelectedByteReference()

        Select Case Me.LoadedChar.Game
            Case Enums.Games.QFG1
                lblByteName.Text = DirectCast(CInt(numOffset.Value), CharQFG1.ByteNames).ToString
            Case Enums.Games.QFG2
                lblByteName.Text = DirectCast(CInt(numOffset.Value), CharQFG2.ByteNames).ToString
            Case Enums.Games.QFG3
                lblByteName.Text = DirectCast(CInt(numOffset.Value), CharQFG3.ByteNames).ToString
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
        If TypeOf Me.LoadedChar Is CharV2 Then
            DirectCast(Me.LoadedChar, CharV2).DecodedValues(numOffset.Value) = numValue.Value
        Else
            Me.LoadedChar.DecodedValues(numOffset.Value) = numValue.Value
        End If
        Call LoadForm()
    End Sub
#End Region

    Private Sub LoadTestDisplay()
        If Me.LoadedChar IsNot Nothing Then
            txtEncodedString.Text = Me.LoadedChar.EncodedString
            lblEncodedStringLength.Text = txtEncodedString.TextLength
            txtEncodedByteArray.Text = Me.LoadedChar.EncodedDataToString
            txtDecodedByteArray.Text = Me.LoadedChar.DecodedValuesToString
            txtDecodedByteArrayDecimal.Text = Me.LoadedChar.DecodedValuesToString(False)
        End If
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        Dim tstDlg As New TestForm

        If tstDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call Me.CloseCharacter()
            Dim fileContents As String = tstDlg.FileContents

            Call LoadContents(fileContents)
        End If
    End Sub

    Private Sub btnAttemptRevert_Click(sender As System.Object, e As System.EventArgs)
        If Me.UnalteredData IsNot Nothing Then
            Me.LoadedChar.EncodedData = Me.UnalteredData
            Call Me.LoadedChar.DecodeValues()
            Call LoadTestData()
        End If
    End Sub

    Private Sub numCipher_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numCipher.ValueChanged
        If Not Me.Loading Then
            If TypeOf Me.LoadedChar Is CharQFG3 Then
                'DirectCast(Me.LoadedChar, CharQFG3).RecalculateTestValues(numEncodedBitShift.Value, numDecodedBitShift.Value, numCipher.Value)
                Call RefreshTestDecrypting()
            End If
        End If
    End Sub

End Class
