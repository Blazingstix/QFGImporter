Public Class CharacterEditor
    Private Property DebugMode As Boolean = False
    Private Property Loading As Boolean = True
    Private Property OriginalTitle As String = String.Empty
    'Private Property LoadedFilename As String = String.Empty
    Public Property LoadedChar As CharGeneric = Nothing
    Public Property ReferenceChar As CharGeneric = Nothing
    Public DeltaOffsets As New Collections.ArrayList
    Public Property UnalteredData As Byte()
    Private Property CurrentError As ErrorStates = ErrorStates.NO_ERROR
    Private Property Archetype As CharGeneric = Nothing
    Private ReadOnly Property FlagCollections As New List(Of CheckBox)
    Private ReadOnly Property SkillNumboxes As New List(Of NumericUpDown)
    Private ReadOnly Property MagicSpellNumboxes As New List(Of NumericUpDown)
    Private ReadOnly Property NumBoxLabels As New Dictionary(Of NumericUpDown, Label)

    Private Enum ErrorStates
        NO_ERROR = 0
        BELOW_ARCHETYPE
        APPROACHING_OVERFLOW
        OVERFLOW
    End Enum

#Region "Events_Main"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call PreLoadForm()
    End Sub

    Public Sub New(character As CharGeneric)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call PreLoadForm()
        Me.LoadedChar = character

        If Me.LoadedChar.IsNewCharacter Then
            Me.Text = Me.OriginalTitle & ": " & "New Export Character"
        Else
            Me.Text = Me.OriginalTitle & ": " & System.IO.Path.GetFileName(Me.LoadedChar.Filename)
        End If

        Call RefreshAll()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Call PreLoadForm()
    End Sub

    Private Sub PreLoadForm()
        Call LoadFlagCollection()
        Call LoadSkillNumericUpDown()
        Call LoadMagicSpellNumericUpDown()
        Call AssignNumboxLabels()
        Me.OriginalTitle = Me.Text
        Me.Loading = False
        Call SetMaximumSkill(100)
        Call SetQFG1Display()
    End Sub

    ''' <summary>
    ''' Creates a collection of the Flag checkboxes
    ''' </summary>
    Private Sub LoadFlagCollection()
        FlagCollections.Clear()
        FlagCollections.Add(chkFlag1)
        FlagCollections.Add(chkFlag2)
        FlagCollections.Add(chkFlag3)
        FlagCollections.Add(chkFlag4)
        FlagCollections.Add(chkFlag5)
        FlagCollections.Add(chkFlag6)
        FlagCollections.Add(chkFlag7)
        FlagCollections.Add(chkFlag8)
        FlagCollections.Add(chkFlag9)
        FlagCollections.Add(chkFlag10)
        FlagCollections.Add(chkFlag11)
        FlagCollections.Add(chkFlag12)
        FlagCollections.Add(chkFlag13)
        FlagCollections.Add(chkFlag14)
        FlagCollections.Add(chkFlag15)
        FlagCollections.Add(chkFlag16)
    End Sub
    ''' <summary>
    ''' Creates a collection of the NumericUpDowns used for Skills/Abilities
    ''' </summary>
    Private Sub LoadSkillNumericUpDown()
        SkillNumboxes.Clear()
        'add Abilities
        SkillNumboxes.Add(numStrength)
        SkillNumboxes.Add(numIntelligence)
        SkillNumboxes.Add(numAgility)
        SkillNumboxes.Add(numVitality)
        SkillNumboxes.Add(numLuck)
        'add Skills
        SkillNumboxes.Add(numWeaponUse)
        SkillNumboxes.Add(numParry)
        SkillNumboxes.Add(numDodge)
        SkillNumboxes.Add(numStealth)
        SkillNumboxes.Add(numPickLocks)
        SkillNumboxes.Add(numThrowing)
        SkillNumboxes.Add(numClimbing)
        SkillNumboxes.Add(numMagic)
        SkillNumboxes.Add(numCommunication)
        SkillNumboxes.Add(numHonor)
        SkillNumboxes.Add(numAcrobatics)
    End Sub
    ''' <summary>
    ''' Creates a collection of the NumericUpDowns used for Magic Spells
    ''' </summary>
    Private Sub LoadMagicSpellNumericUpDown()
        MagicSpellNumboxes.Add(numOpen)
        MagicSpellNumboxes.Add(numDetectMagic)
        MagicSpellNumboxes.Add(numTrigger)
        MagicSpellNumboxes.Add(numDazzle)
        MagicSpellNumboxes.Add(numZap)
        MagicSpellNumboxes.Add(numCalm)
        MagicSpellNumboxes.Add(numFlameDart)
        MagicSpellNumboxes.Add(numFetch)
        MagicSpellNumboxes.Add(numForceBolt)
        MagicSpellNumboxes.Add(numLevitation)
        MagicSpellNumboxes.Add(numReversal)
        MagicSpellNumboxes.Add(numJugglingLights)
        MagicSpellNumboxes.Add(numSummonStaff)
        MagicSpellNumboxes.Add(numLightningBall)
        MagicSpellNumboxes.Add(numFrostBite)
        MagicSpellNumboxes.Add(numRitualOfRelease)
        MagicSpellNumboxes.Add(numHide)
        MagicSpellNumboxes.Add(numAura)
        MagicSpellNumboxes.Add(numProtection)
        MagicSpellNumboxes.Add(numResistance)
        MagicSpellNumboxes.Add(numGlide)
    End Sub

    Private Sub AssignNumboxLabels()
        NumBoxLabels.Clear()
        'abilities
        NumBoxLabels.Add(numStrength, lblStrength)
        NumBoxLabels.Add(numIntelligence, lblIntelligence)
        NumBoxLabels.Add(numAgility, lblAgility)
        NumBoxLabels.Add(numVitality, lblVitality)
        NumBoxLabels.Add(numLuck, lblLuck)
        'skills
        NumBoxLabels.Add(numWeaponUse, lblWeaponUse)
        NumBoxLabels.Add(numParry, lblParry)
        NumBoxLabels.Add(numDodge, lblDodge)
        NumBoxLabels.Add(numStealth, lblStealth)
        NumBoxLabels.Add(numPickLocks, lblPickLocks)
        NumBoxLabels.Add(numThrowing, lblThrowing)
        NumBoxLabels.Add(numClimbing, lblClimbing)
        NumBoxLabels.Add(numMagic, lblMagic)
        NumBoxLabels.Add(numCommunication, lblCommunication)
        NumBoxLabels.Add(numHonor, lblHonor)
        NumBoxLabels.Add(numAcrobatics, lblAcrobatics)
        'other skills
        NumBoxLabels.Add(numPuzzlePoints, lblPuzzlePoints)
        NumBoxLabels.Add(numExperience, lblExperience)
        NumBoxLabels.Add(numHealthPoints, lblHealthPoints)
        NumBoxLabels.Add(numStaminaPoints, lblStaminaPoints)
        NumBoxLabels.Add(numMagicPoints, lblMagicPoints)
        'magic spells
        NumBoxLabels.Add(numOpen, lblOpen)
        NumBoxLabels.Add(numDetectMagic, lblDetectMagic)
        NumBoxLabels.Add(numTrigger, lblTrigger)
        NumBoxLabels.Add(numDazzle, lblDazzle)
        NumBoxLabels.Add(numZap, lblZap)
        NumBoxLabels.Add(numCalm, lblCalm)
        NumBoxLabels.Add(numFlameDart, lblFlameDart)
        NumBoxLabels.Add(numFetch, lblFetch)
        NumBoxLabels.Add(numForceBolt, lblForceBolt)
        NumBoxLabels.Add(numLevitation, lblLevitation)
        NumBoxLabels.Add(numReversal, lblReversal)
        NumBoxLabels.Add(numJugglingLights, lblJugglingLights)
        NumBoxLabels.Add(numSummonStaff, lblSummonStaff)
        NumBoxLabels.Add(numLightningBall, lblLightningBall)
        NumBoxLabels.Add(numFrostBite, lblFrostBite)
        NumBoxLabels.Add(numRitualOfRelease, lblRitualOfRelease)
        NumBoxLabels.Add(numHide, lblHide)
        NumBoxLabels.Add(numAura, lblAura)
        NumBoxLabels.Add(numProtection, lblProtection)
        NumBoxLabels.Add(numResistance, lblResistance)
        NumBoxLabels.Add(numGlide, lblGlide)
        'paladin spells
        NumBoxLabels.Add(numPaladinHealingSpell, lblPaladinHealingSpell)
        'inventory
        NumBoxLabels.Add(numGold, lblCurrency)
        NumBoxLabels.Add(numDaggers, lblDaggers)
        NumBoxLabels.Add(numHealingPotions, lblHealingPotions)
        NumBoxLabels.Add(numMagicPotions, lblMagicPotions)
        NumBoxLabels.Add(numVigorPotions, lblVigorPotions)
        NumBoxLabels.Add(numUndeadUnguent, lblUndeadUnguent)
        NumBoxLabels.Add(numPoisonCurePills, lblPoisonCurePills)
        NumBoxLabels.Add(numOilFlasks, lblOilFlasks)
        NumBoxLabels.Add(numRations, lblRations)
    End Sub

    Private Sub LoadCoverPicture()
        Dim xSelGame As New SelectGame
        picCover.Image = xSelGame.GetCover(Me.LoadedChar.Game)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim fso As New SaveFileDialog
        fso.Filter = CharGeneric.QFGFileFilter
        If Not String.IsNullOrWhiteSpace(Me.LoadedChar.Filename) Then
            fso.InitialDirectory = IO.Path.GetDirectoryName(Me.LoadedChar.Filename)
        End If
        fso.FileName = IO.Path.GetFileName(Me.LoadedChar.Filename)
        fso.OverwritePrompt = True
        fso.DefaultExt = ".sav"
        fso.Title = "Save QFG Character File As..."
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fs As New IO.StreamWriter(fso.OpenFile())
            fs.Write(Me.LoadedChar.ExportString)
            fs.Close()
        End If
    End Sub

    Private Sub numInventory_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numGold.ValueChanged, numDaggers.ValueChanged, numHealingPotions.ValueChanged, numVigorPotions.ValueChanged, numMagicPotions.ValueChanged, numUndeadUnguent.ValueChanged, numPoisonCurePills.ValueChanged, numOilFlasks.ValueChanged, numRations.ValueChanged, numPaladinHealingSpell.ValueChanged
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
                Case numPaladinHealingSpell.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.PaladinHealingSpell) = numValue.Value
                Case numRations.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.Rations) = numValue.Value
                Case numOilFlasks.Name
                    Me.LoadedChar.Inventory(Enums.Inventory.OilFlasks) = numValue.Value
            End Select
            Call SafeUpdateNumericMinMax(numValue)

            If Me.LoadedChar IsNot Nothing Then
                If numValue.Value < 0 Or numValue.Value > Me.LoadedChar.SkillTechnicalMaximum Then
                    SetErrorColour(numValue)
                Else
                    If Not SetArchetypeColour(numValue) Then
                        SetNormalColour(numValue)
                    End If
                End If
                Call RefreshErrorDisplay()
            End If

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
            Dim idx As Integer = FlagCollections.IndexOf(chkFlag)
            If idx <> -1 Then
                Me.LoadedChar.Flag(idx) = chkFlag.Checked
            End If
        End If
        If Me.LoadedChar IsNot Nothing Then
            If Not SetArchetypeColour(chkFlag) Then
                SetNormalColour(chkFlag)
            End If
            Call RefreshErrorDisplay()
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

            Dim oldArchetype As CharGeneric = Me.Archetype
            Me.Archetype = MinimumCharacters.GetCharacter(Me.LoadedChar.Game, Me.LoadedChar.CharacterClass)
            If Me.LoadedChar.IsNewCharacter() Then
                Call LoadedChar.ResetCharacterValues(oldArchetype, Me.Archetype)
            End If
            Call RefreshFormValues()
        End If
    End Sub


    Private Sub SetErrorColour(control As Control)
        control.BackColor = Color.FromArgb(255, 199, 206)
        control.ForeColor = Color.FromArgb(156, 0, 6)
    End Sub

    Private Sub SetNormalColour(control As Control)
        control.BackColor = Color.FromKnownColor(KnownColor.Window)
        control.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
    End Sub

    Private Sub SetWarningColour(control As Control)
        control.BackColor = Color.FromArgb(255, 235, 156)
        control.ForeColor = Color.FromArgb(156, 101, 0)
    End Sub

    Private Sub numericUpDown_GotFocus(sender As Object, e As System.EventArgs) Handles numStrength.GotFocus, numIntelligence.GotFocus, numAgility.GotFocus, numVitality.GotFocus, numLuck.GotFocus, numWeaponUse.GotFocus, numParry.GotFocus, numDodge.GotFocus, numStealth.GotFocus, numPickLocks.GotFocus, numThrowing.GotFocus, numClimbing.GotFocus, numMagic.GotFocus, numCommunication.GotFocus, numHonor.GotFocus, numAcrobatics.GotFocus, numPuzzlePoints.GotFocus, numExperience.GotFocus, numHealthPoints.GotFocus, numStaminaPoints.GotFocus, numMagicPoints.GotFocus, numOpen.GotFocus, numDetectMagic.GotFocus, numTrigger.GotFocus, numDazzle.GotFocus, numZap.GotFocus, numCalm.GotFocus, numFlameDart.GotFocus, numFetch.GotFocus, numForceBolt.GotFocus, numLevitation.GotFocus, numReversal.GotFocus, numJugglingLights.GotFocus, numSummonStaff.GotFocus, numLightningBall.GotFocus, numHide.GotFocus, numProtection.GotFocus, numAura.GotFocus, numGlide.GotFocus, numResistance.GotFocus, numFrostBite.GotFocus, numGold.GotFocus, numDaggers.GotFocus, numHealingPotions.GotFocus, numMagicPotions.GotFocus, numVigorPotions.GotFocus, numUndeadUnguent.GotFocus, numPoisonCurePills.GotFocus, numPaladinHealingSpell.GotFocus, numRations.GotFocus, numOilFlasks.GotFocus, numRitualOfRelease.GotFocus
        Dim xSender As NumericUpDown = sender
        xSender.Select(0, xSender.Value.ToString.Length)
    End Sub

    Private Sub numAbilitySkill_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numStrength.ValueChanged, numIntelligence.ValueChanged, numAgility.ValueChanged, numVitality.ValueChanged, numLuck.ValueChanged, numWeaponUse.ValueChanged, numParry.ValueChanged, numDodge.ValueChanged, numStealth.ValueChanged, numPickLocks.ValueChanged, numThrowing.ValueChanged, numClimbing.ValueChanged, numMagic.ValueChanged, numCommunication.ValueChanged, numHonor.ValueChanged, numAcrobatics.ValueChanged
        Dim numValue As NumericUpDown = sender
        If Me.LoadedChar IsNot Nothing AndAlso Not Me.Loading Then
            Dim idx As Integer = SkillNumboxes.IndexOf(numValue)
            Dim okay As Boolean = False
            If idx < Enums.Skills.Communication Then
                'all game have access to skills below Communication
                okay = True
            ElseIf idx < Enums.Skills.Acrobatics AndAlso Me.LoadedChar.Game >= Enums.Games.QFG2 Then
                'only QFG2 or higher have access to skills between Communication and less than Acrobatics
                okay = True
            ElseIf Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                'only QFG4 has access to all skills
                okay = True
            End If

            If okay Then
                Me.LoadedChar.Skill(idx) = numValue.Value
            End If
            Call SafeUpdateNumericMinMax(numValue)
        End If
        If Me.LoadedChar IsNot Nothing Then
            If numValue.Value < 0 Or numValue.Value > Me.LoadedChar.SkillTechnicalMaximum Then
                SetErrorColour(numValue)
            Else
                If Not SetArchetypeColour(numValue) Then
                    SetNormalColour(numValue)
                End If
            End If
            Call RefreshErrorDisplay()
        End If
    End Sub

    Private Sub numMagicSpells_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numOpen.ValueChanged, numDetectMagic.ValueChanged, numTrigger.ValueChanged, numDazzle.ValueChanged, numZap.ValueChanged, numCalm.ValueChanged, numFlameDart.ValueChanged, numFetch.ValueChanged, numForceBolt.ValueChanged, numLevitation.ValueChanged, numReversal.ValueChanged, numJugglingLights.ValueChanged, numLightningBall.ValueChanged, numSummonStaff.ValueChanged, numHide.ValueChanged, numProtection.ValueChanged, numAura.ValueChanged, numGlide.ValueChanged, numResistance.ValueChanged, numFrostBite.ValueChanged, numRitualOfRelease.ValueChanged
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
                    Case numFrostBite.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.FrostBite) = numValue.Value
                        End If
                    Case numGlide.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Glide) = numValue.Value
                        End If
                    Case numHide.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Hide) = numValue.Value
                        End If
                    Case numAura.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Aura) = numValue.Value
                        End If
                    Case numProtection.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Protection) = numValue.Value
                        End If
                    Case numResistance.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.Resistance) = numValue.Value
                        End If
                    Case numRitualOfRelease.Name
                        If Me.LoadedChar.Game >= Enums.Games.QFG4 Then
                            Me.LoadedChar.MagicSpell(Enums.Magic.RitualOfRelease) = numValue.Value
                        End If
                End Select

                Call SafeUpdateNumericMinMax(numValue)
            End If

            'set control colours
            If numValue.Value < 0 Or numValue.Value > Me.LoadedChar.SkillTechnicalMaximum Then
                SetErrorColour(numValue)
            Else
                If Not SetArchetypeColour(numValue) Then
                    SetNormalColour(numValue)
                End If
            End If
            Call RefreshErrorDisplay()
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

                Call SafeUpdateNumericMinMax(numValue)
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
                If Not SetArchetypeColour(numValue) Then
                    SetNormalColour(numValue)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Declarations_Main"

    Private Sub CloseCharacter()
        Me.LoadedChar = Nothing
        'Me.LoadedFilename = Nothing
        Me.UnalteredData = Nothing
        Call ClearAllFields()
    End Sub

    ''' <summary>
    ''' Sets all controls to have a blank, 0, or unchecked value.
    ''' </summary>
    ''' <remarks></remarks>
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

    Private Sub RefreshAll()
        Call RefreshFormLayout()
        Call RefreshFormValues()
    End Sub

    ''' <summary>
    ''' This enables or disables controls based on the Game selected.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshFormLayout()
        Dim SelfSetLoading As Boolean = False
        If Me.Loading Then SelfSetLoading = True
        Me.Loading = True

        If Me.LoadedChar Is Nothing Then
            grpAbilities.Enabled = False
            grpClass.Enabled = False
            grpSkills.Enabled = False
            grpSpells.Enabled = False
        Else
            Call LoadCoverPicture()
            Call SelectGame(Me.LoadedChar.Game)

            numGold.Maximum = 10000

            Select Case Me.LoadedChar.Game
                Case Enums.Games.QFG1
                    Call SetMaximumSkill(Me.LoadedChar.SkillMaximum)
                    Call SetMinimumSkill(0)
                    Call SetMaximumInventory(Me.LoadedChar.SkillTechnicalMaximum)
                    numPuzzlePoints.Maximum = 500
                    EnableNumUpDown(numPuzzlePoints, True)
                    numExperience.Maximum = Me.LoadedChar.SkillTechnicalMaximum
                Case Enums.Games.QFG2
                    Call SetMaximumSkill(Me.LoadedChar.SkillTechnicalMaximum)
                    Call SetMinimumSkill(0)
                    Call SetMaximumInventory(Me.LoadedChar.SkillTechnicalMaximum)
                    numPuzzlePoints.Maximum = 550
                    EnableNumUpDown(numPuzzlePoints, True)
                    numExperience.Maximum = Me.LoadedChar.SkillTechnicalMaximum
                Case Enums.Games.QFG3
                    Call SetMaximumSkill(Me.LoadedChar.SkillMaximum)
                    Call SetMinimumSkill(0)
                    Call SetMaximumInventory(Me.LoadedChar.SkillTechnicalMaximum)
                    numPuzzlePoints.Maximum = 500
                    EnableNumUpDown(numPuzzlePoints, False)
                    numExperience.Maximum = 10000
                Case Enums.Games.QFG4
                    Call SetMaximumSkill(Me.LoadedChar.SkillMaximum)
                    Call SetMinimumSkill(0)
                    Call SetMaximumInventory(Me.LoadedChar.SkillTechnicalMaximum)
                    numPuzzlePoints.Maximum = 500
                    EnableNumUpDown(numPuzzlePoints, False)
                    numExperience.Maximum = 10000
            End Select

        End If

        If SelfSetLoading Then Me.Loading = False
    End Sub

    Private Sub RefreshFormValues()
        Me.Loading = True
        Me.Archetype = MinimumCharacters.GetCharacter(Me.LoadedChar.Game, Me.LoadedChar.CharacterClass)

        If Me.LoadedChar IsNot Nothing Then
            txtName.Text = Me.LoadedChar.Name
            Call SelectClass(Me.LoadedChar.CharacterClass)

            If Me.LoadedChar.Game = Enums.Games.QFG1 Then
                Call LoadQFG1Common()
            ElseIf Me.LoadedChar.Game = Enums.Games.QFG2 Then
                Call LoadQFG1Common()
                Call LoadQFG2Common()
            ElseIf Me.LoadedChar.Game = Enums.Games.QFG3 Then
                Call LoadQFG1Common()
                Call LoadQFG2Common()
                Call LoadQFG3Common()
            ElseIf Me.LoadedChar.Game = Enums.Games.QFG4 Then
                Call LoadQFG1Common()
                Call LoadQFG2Common()
                Call LoadQFG3Common()
                Call LoadQFG4Common()
            End If

            'load puzzle points
            numPuzzlePoints.Value = Me.LoadedChar.PuzzlePoints

            'unique inventory
            For i As Integer = 0 To FlagCollections.Count - 1
                FlagCollections(i).Checked = LoadedChar.Flag(i)
            Next

            'inventory
            SafeSetNumericValue(numGold, Me.LoadedChar.Currency)

            SafeSetNumericValue(numDaggers, Me.LoadedChar.Inventory(Enums.Inventory.Daggers))
            SafeSetNumericValue(numHealingPotions, Me.LoadedChar.Inventory(Enums.Inventory.HealingPotion))
            SafeSetNumericValue(numMagicPotions, Me.LoadedChar.Inventory(Enums.Inventory.MagicPotion))
            SafeSetNumericValue(numVigorPotions, Me.LoadedChar.Inventory(Enums.Inventory.VigorPotion))
            SafeSetNumericValue(numPaladinHealingSpell, Me.LoadedChar.Inventory(Enums.Inventory.PaladinHealingSpell))
            SafeSetNumericValue(numRations, Me.LoadedChar.Inventory(Enums.Inventory.Rations))
            SafeSetNumericValue(numOilFlasks, Me.LoadedChar.Inventory(Enums.Inventory.OilFlasks))
            If Me.LoadedChar.Game = Enums.Games.QFG1 Then
                SafeSetNumericValue(numPoisonCurePills, 0)
                SafeSetNumericValue(numUndeadUnguent, Me.LoadedChar.Inventory(Enums.Inventory.UndeadUnguent))
            Else
                SafeSetNumericValue(numPoisonCurePills, Me.LoadedChar.Inventory(Enums.Inventory.PoisonCurePill))
                SafeSetNumericValue(numUndeadUnguent, 0)
            End If
        End If

        Call RefreshControlColours()
        Call RefreshErrorDisplay()

        Me.Loading = False
    End Sub

    Private Sub RefreshControlColours()
        Call RefreshControlColours(grpAbilities)
        Call RefreshControlColours(grpSkills)
        Call RefreshControlColours(grpSpells)
        Call RefreshControlColours(grpInventory)
        Call RefreshControlColours(grpUniqueInventory)
    End Sub

    Private Sub RefreshControlColours(group As GroupBox)
        For Each x As Control In group.Controls
            If TypeOf x Is NumericUpDown Then
                Dim numValue As NumericUpDown = x
                If TypeOf numValue.Tag Is Decimal Then
                    SetErrorColour(numValue)
                Else
                    If Not SetArchetypeColour(numValue) Then
                        SetNormalColour(numValue)
                    End If
                End If
            ElseIf TypeOf x Is CheckBox Then
                Dim chkValue As CheckBox = x
                If Not SetArchetypeColour(chkValue) Then
                    SetNormalColour(chkValue)
                End If
            End If
        Next

        'because UndeadUnguent and PoisonCurePills use the same InventoryID if 
        'the PoisonCurePills are too low in QFG2-4, then the UndeadUnguent will highlight as yellow, too
        'so if we're in anything other than QFG1, make UndeadUnguent normal coloured regardless.
        If Me.LoadedChar.Game <> Enums.Games.QFG1 Then
            SetNormalColour(numUndeadUnguent)
        End If
    End Sub

    Private Function SetArchetypeColour(chkValue As CheckBox) As Boolean
        Dim idx As Integer = FlagCollections.IndexOf(chkValue)
        If idx <> -1 Then
            Return CompareArchetypeFlag(idx, chkValue)
        End If
        Return False
    End Function

    Private Function SetArchetypeColour(numValue As NumericUpDown) As Boolean
        Dim idx As Integer

        'skills
        idx = SkillNumboxes.IndexOf(numValue)
        If idx <> -1 Then
            Return CompareArchetypeSkill(idx, numValue)
        End If

        'spells
        idx = MagicSpellNumboxes.IndexOf(numValue)
        If idx <> -1 Then
            Return CompareArchetypeMagic(idx, numValue)
        End If

        Select Case numValue.Name
                'paladin spells
            Case numPaladinHealingSpell.Name
                Return CompareArchetypeInventory(Enums.Inventory.PaladinHealingSpell, numValue)
                'inventory
            Case numDaggers.Name
                Return CompareArchetypeInventory(Enums.Inventory.Daggers, numValue)
            Case numHealingPotions.Name
                Return CompareArchetypeInventory(Enums.Inventory.HealingPotion, numValue)
            Case numMagicPotions.Name
                Return CompareArchetypeInventory(Enums.Inventory.MagicPotion, numValue)
            Case numVigorPotions.Name
                Return CompareArchetypeInventory(Enums.Inventory.VigorPotion, numValue)
            Case numUndeadUnguent.Name
                Return CompareArchetypeInventory(Enums.Inventory.UndeadUnguent, numValue)
            Case numPoisonCurePills.Name
                Return CompareArchetypeInventory(Enums.Inventory.PoisonCurePill, numValue)
            Case numRations.Name
                Return CompareArchetypeInventory(Enums.Inventory.Rations, numValue)
            Case numOilFlasks.Name
                Return CompareArchetypeInventory(Enums.Inventory.OilFlasks, numValue)
            Case numGold.Name
                If Me.LoadedChar.Currency < Me.Archetype.Currency Then
                    Call SetWarningColour(numValue)
                    Return True
                End If
                Return False
            Case Else
                Return False
        End Select
    End Function

    Private Function CompareArchetypeSkill(ByVal Skill As Enums.Skills, numUpDown As NumericUpDown) As Boolean
        If Me.LoadedChar.Skill(Skill) < Me.Archetype.Skill(Skill) Then
            Call SetWarningColour(numUpDown)
            Return True
        End If
        Return False
    End Function

    Private Function CompareArchetypeMagic(ByVal Spell As Enums.Magic, numUpDown As NumericUpDown) As Boolean
        If Me.LoadedChar.MagicSpell(Spell) < Me.Archetype.MagicSpell(Spell) Then
            Call SetWarningColour(numUpDown)
            Return True
        End If
        Return False
    End Function

    Private Function CompareArchetypeInventory(ByVal inventory As Enums.Inventory, numUpDown As NumericUpDown) As Boolean
        If Me.LoadedChar.Inventory(inventory) < Me.Archetype.Inventory(inventory) Then
            Call SetWarningColour(numUpDown)
            Return True
        End If
        Return False
    End Function

    Private Function CompareArchetypeFlag(ByVal flag As Byte, chkFlag As CheckBox) As Boolean
        If Not Me.LoadedChar.Flag(flag) And Me.Archetype.Flag(flag) Then
            Call SetWarningColour(chkFlag)
            Return True
        End If
        Return False
    End Function

    Private Sub RefreshErrorDisplay()
        If Me.LoadedChar.HasOverflowError Then
            Me.CurrentError = ErrorStates.OVERFLOW
        ElseIf IsNumericOver() Then
            Me.CurrentError = ErrorStates.APPROACHING_OVERFLOW
        ElseIf LoadedChar.IsBelowArchetype(Me.Archetype) Then
            Me.CurrentError = ErrorStates.BELOW_ARCHETYPE
        Else
            Me.CurrentError = ErrorStates.NO_ERROR
        End If

        Select Case Me.CurrentError
            Case ErrorStates.OVERFLOW
                picWarning.Image = SystemIcons.Warning.ToBitmap
                picWarning.Visible = True
                btnFix.Visible = True
                lblOverflowError.Text = "Warning: This exported character contains an overflow error, which may cause problems when trying to import."
                lblOverflowError.Visible = True
            Case ErrorStates.APPROACHING_OVERFLOW
                picWarning.Image = SystemIcons.Warning.ToBitmap
                picWarning.Visible = True
                btnFix.Visible = True
                lblOverflowError.Text = "Warning: This character may contain an overflow error when exported, which may cause problems when trying to import."
                lblOverflowError.Visible = True
            Case ErrorStates.BELOW_ARCHETYPE
                picWarning.Image = SystemIcons.Information.ToBitmap
                picWarning.Visible = True
                btnFix.Visible = True
                lblOverflowError.Text = "Some values are lower than starting a brand new game."
                lblOverflowError.Visible = True
            Case ErrorStates.NO_ERROR
                picWarning.Visible = False
                btnFix.Visible = False
                lblOverflowError.Visible = False
        End Select
    End Sub

    ''' <summary>
    ''' Search through all the numeric updown controls and see if any are above the default maximum.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsNumericOver() As Boolean
        Dim rtn As Boolean = False
        rtn = rtn Or IsNumericOver(grpInventory)
        rtn = rtn Or IsNumericOver(grpAbilities)
        rtn = rtn Or IsNumericOver(grpOther)
        rtn = rtn Or IsNumericOver(grpSkills)
        rtn = rtn Or IsNumericOver(grpSpells)
        Return rtn
    End Function

    Private Function IsNumericOver(ByVal group As GroupBox) As Boolean
        For Each cont As Control In group.Controls
            If TypeOf cont Is NumericUpDown Then
                If TypeOf DirectCast(cont, NumericUpDown).Tag Is Decimal Then
                    Dim x As NumericUpDown = cont

                    Return True
                End If
            End If
        Next
        Return False
    End Function



    Private Sub FixOverflow()
        FixOverflow(grpInventory)
        FixOverflow(grpAbilities)
        FixOverflow(grpOther)
        FixOverflow(grpSkills)
        If Me.LoadedChar.Skill(Enums.Skills.Magic) > 0 Then
            FixOverflow(grpSpells)
        Else
            For Each cont As Control In grpSpells.Controls
                If TypeOf cont Is NumericUpDown Then
                    SafeUpdateNumericMinMax(cont, 0)
                End If
            Next
        End If
        Me.LoadedChar.Update()
    End Sub

    Private Sub FixOverflow(ByVal Group As GroupBox)
        For Each cont As Control In Group.Controls
            If TypeOf cont Is NumericUpDown Then
                Call SafeResetNumericMinMax(cont)
            End If
        Next
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

    Private Sub SafeResetNumericMinMax(numeric As NumericUpDown)
        If numeric.Tag IsNot Nothing AndAlso TypeOf numeric.Tag Is Decimal Then
            If numeric.Tag > 0 Then
                numeric.Maximum = numeric.Tag
                numeric.Tag = Nothing
            ElseIf numeric.Tag < 0 Then
                numeric.Minimum = numeric.Tag
                numeric.Tag = Nothing
            End If
        End If
    End Sub

    Private Sub SafeUpdateNumericMinMax(numeric As NumericUpDown, value As Integer)
        If numeric.Value <> value Then
            SafeSetNumericValue(numeric, value)
        End If
        If numeric.Tag IsNot Nothing AndAlso TypeOf numeric.Tag Is Decimal Then
            If numeric.Tag > 0 Then
                numeric.Maximum = Math.Max(CInt(value), numeric.Tag)
                If numeric.Maximum = numeric.Tag Then
                    numeric.Tag = Nothing
                End If
            ElseIf numeric.Tag < 0 Then
                numeric.Minimum = Math.Min(CInt(value), numeric.Tag)
                If numeric.Minimum = numeric.Tag Then numeric.Tag = Nothing
            End If
        End If
    End Sub

    Private Sub SafeUpdateNumericMinMax(numeric As NumericUpDown)
        SafeUpdateNumericMinMax(numeric, numeric.Value)
    End Sub

    Private Sub ExtendedUniqueItemsEnabled(enabled As Boolean)
        For i As Integer = 8 To FlagCollections.Count - 2
            FlagCollections(i).Enabled = enabled
            If Not FlagCollections(i).Enabled Then
                FlagCollections(i).Text = "(unavailable)"
            End If
        Next
        FlagCollections.Last.Enabled = False
    End Sub

    Private Sub SetQFG1Display()
        chkFlag1.Text = "Broadsword"
        chkFlag2.Text = "Chainmail Armor"
        chkFlag3.Text = "Lock Pick"
        chkFlag4.Text = "Thief’s Tool Kit"
        chkFlag5.Text = "Magic Mirror"
        chkFlag6.Text = "Defeated Baba Yaga"
        chkFlag7.Text = "Puzzle Points > 255"
        chkFlag8.Text = "(unavailable)"
        chkFlag8.Enabled = False
        ExtendedUniqueItemsEnabled(False)

        lblCurrency.Text = "Gold"
        lblDaggers.Text = "Daggers"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"
        EnableNumUpDown(numVigorPotions, True)
        EnableNumUpDown(numUndeadUnguent, True)

        EnableNumUpDown(numPoisonCurePills, False)
        EnableNumUpDown(numRations, False)
        EnableNumUpDown(numOilFlasks, False)

        EnableNumUpDown(numPaladinHealingSpell, False)
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
        EnableNumUpDown(numVigorPotions, True)
        EnableNumUpDown(numUndeadUnguent, False)

        EnableNumUpDown(numPoisonCurePills, True)
        EnableNumUpDown(numRations, False)
        EnableNumUpDown(numOilFlasks, False)

        EnableNumUpDown(numPaladinHealingSpell, False)
    End Sub

    Private Sub SetQFG3Display()
        chkFlag1.Text = "Dispell Potion"
        chkFlag2.Text = "Tinderbox"
        chkFlag3.Text = "Sapphire Pin"
        chkFlag4.Text = "Fine Dagger"
        chkFlag5.Text = "Waterskin"
        chkFlag6.Text = "Fake Black Bird"
        chkFlag7.Text = "Defeated Baba Yaga"
        chkFlag8.Text = "Rope"
        chkFlag9.Text = "Thieves Toolkit"
        chkFlag10.Text = "Sword"
        chkFlag11.Text = "Shield"
        chkFlag12.Text = "(unused)"
        chkFlag13.Text = "(unused)"
        chkFlag14.Text = "(unused)"
        chkFlag15.Text = "(unused)"
        chkFlag16.Text = "(unavailable)"
        chkFlag8.Enabled = True
        ExtendedUniqueItemsEnabled(True)

        lblCurrency.Text = "Golden Royals"
        lblDaggers.Text = "Throwing Daggers"
        lblHealingPotions.Text = "Healing Pills"
        lblMagicPotions.Text = "Magic Pills"
        lblVigorPotions.Text = "Vigor Pills"
        EnableNumUpDown(numVigorPotions, False)
        EnableNumUpDown(numUndeadUnguent, False)

        EnableNumUpDown(numPoisonCurePills, True)
        EnableNumUpDown(numRations, True)
        EnableNumUpDown(numOilFlasks, True)

        EnableNumUpDown(numPaladinHealingSpell, True)
    End Sub

    Private Sub SetQFG4Display()
        chkFlag1.Text = "(unused)"
        chkFlag2.Text = "(unused)"
        chkFlag3.Text = "(unused)"
        chkFlag4.Text = "(unused)"
        chkFlag5.Text = "Black Bird (from QFG3)"
        chkFlag6.Text = "Black Bird (from QFG4)"
        chkFlag7.Text = "(unused)"
        chkFlag8.Text = "(unused)"
        chkFlag9.Text = "(unused)"
        chkFlag10.Text = "(unused)"
        chkFlag11.Text = "(unused)"
        chkFlag12.Text = "(unused)"
        chkFlag13.Text = "(unused)"
        chkFlag14.Text = "(unused)"
        chkFlag15.Text = "(unused)"
        chkFlag16.Text = "(unavailable)"
        chkFlag8.Enabled = True
        ExtendedUniqueItemsEnabled(True)

        lblCurrency.Text = "Golden Crowns"
        lblDaggers.Text = "Throwing Daggers"
        lblHealingPotions.Text = "Healing Potions"
        lblMagicPotions.Text = "Magic Potions"
        lblVigorPotions.Text = "Vigor Potions"
        EnableNumUpDown(numVigorPotions, False)
        EnableNumUpDown(numUndeadUnguent, False)

        EnableNumUpDown(numPoisonCurePills, True)
        EnableNumUpDown(numRations, True)
        EnableNumUpDown(numOilFlasks, True)

        EnableNumUpDown(numPaladinHealingSpell, True)
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
            'rdoFighter.Checked = True
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

        'assorted other attributes
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

        SafeSetNumericValue(numFrostBite, Me.LoadedChar.MagicSpell(Enums.Magic.FrostBite))
        SafeSetNumericValue(numGlide, Me.LoadedChar.MagicSpell(Enums.Magic.Glide))
        SafeSetNumericValue(numHide, Me.LoadedChar.MagicSpell(Enums.Magic.Hide))
        SafeSetNumericValue(numAura, Me.LoadedChar.MagicSpell(Enums.Magic.Aura))
        SafeSetNumericValue(numProtection, Me.LoadedChar.MagicSpell(Enums.Magic.Protection))
        SafeSetNumericValue(numResistance, Me.LoadedChar.MagicSpell(Enums.Magic.Resistance))
        SafeSetNumericValue(numRitualOfRelease, Me.LoadedChar.MagicSpell(Enums.Magic.RitualOfRelease))

    End Sub

    Private Sub EnableNumUpDown(numUpDown As NumericUpDown, enabled As Boolean)
        numUpDown.Enabled = enabled
        If NumBoxLabels.ContainsKey(numUpDown) Then
            NumBoxLabels(numUpDown).Enabled = enabled
        End If
    End Sub

    Private Sub EnableQFG1(enabled As Boolean)
        'Abilities QFG1
        EnableNumUpDown(numStrength, enabled)
        EnableNumUpDown(numIntelligence, enabled)
        EnableNumUpDown(numAgility, enabled)
        EnableNumUpDown(numVitality, enabled)
        EnableNumUpDown(numLuck, enabled)

        'Skills QFG1
        EnableNumUpDown(numWeaponUse, enabled)
        EnableNumUpDown(numParry, enabled)
        EnableNumUpDown(numDodge, enabled)
        EnableNumUpDown(numStealth, enabled)
        EnableNumUpDown(numPickLocks, enabled)
        EnableNumUpDown(numThrowing, enabled)
        EnableNumUpDown(numClimbing, enabled)
        EnableNumUpDown(numMagic, enabled)

        'Other QFG1
        EnableNumUpDown(numExperience, enabled)

        'Magic spells QFG1
        EnableNumUpDown(numOpen, enabled)
        EnableNumUpDown(numDetectMagic, enabled)
        EnableNumUpDown(numTrigger, enabled)
        EnableNumUpDown(numDazzle, enabled)
        EnableNumUpDown(numZap, enabled)
        EnableNumUpDown(numCalm, enabled)
        EnableNumUpDown(numFlameDart, enabled)
        EnableNumUpDown(numFetch, enabled)
    End Sub

    Private Sub EnableQFG2(enabled As Boolean)
        'magic spells QFG2
        EnableNumUpDown(numForceBolt, enabled)
        EnableNumUpDown(numLevitation, enabled)
        EnableNumUpDown(numReversal, enabled)

        'skills QFG2
        EnableNumUpDown(numCommunication, enabled)

        'other QFG2
        EnableNumUpDown(numHonor, enabled)

        'paladin was introduced in QFG2
        rdoPaladin.Enabled = enabled
    End Sub

    Private Sub EnableQFG3(enabled As Boolean)
        '3 new spells added in QFG3
        EnableNumUpDown(numJugglingLights, enabled)
        EnableNumUpDown(numLightningBall, enabled)
        EnableNumUpDown(numSummonStaff, enabled)
    End Sub

    Private Sub EnableQFG4(enabled As Boolean)
        '1 new skill added in QFG4
        EnableNumUpDown(numAcrobatics, enabled)

        '7 new spells added in QFG4
        EnableNumUpDown(numFrostBite, enabled)
        EnableNumUpDown(numGlide, enabled)
        EnableNumUpDown(numHide, enabled)
        EnableNumUpDown(numAura, enabled)
        EnableNumUpDown(numProtection, enabled)
        EnableNumUpDown(numResistance, enabled)
        EnableNumUpDown(numRitualOfRelease, enabled)
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
        numPaladinHealingSpell.Maximum = max
        numPaladinHealingSpell.Minimum = min
        numRations.Maximum = max
        numPaladinHealingSpell.Minimum = min
        numOilFlasks.Maximum = max
        numOilFlasks.Minimum = min
    End Sub

#End Region

    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        Select Case Me.CurrentError
            Case ErrorStates.OVERFLOW, ErrorStates.APPROACHING_OVERFLOW
                Call FixOverflow()
                Call RefreshFormValues()
            Case ErrorStates.BELOW_ARCHETYPE
                Call LoadedChar.FixBelowArchetype(Me.Archetype)
                Call RefreshFormValues()
            Case Else
        End Select
    End Sub

End Class
