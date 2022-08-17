<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CharacterEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CharacterEditor))
        Me.grpClass = New System.Windows.Forms.GroupBox()
        Me.rdoPaladin = New System.Windows.Forms.RadioButton()
        Me.rdoThief = New System.Windows.Forms.RadioButton()
        Me.rdoWizard = New System.Windows.Forms.RadioButton()
        Me.rdoFighter = New System.Windows.Forms.RadioButton()
        Me.grpSkills = New System.Windows.Forms.GroupBox()
        Me.numHonor = New System.Windows.Forms.NumericUpDown()
        Me.lblHonor = New System.Windows.Forms.Label()
        Me.lblMagic = New System.Windows.Forms.Label()
        Me.lblAcrobatics = New System.Windows.Forms.Label()
        Me.lblClimbing = New System.Windows.Forms.Label()
        Me.lblCommunication = New System.Windows.Forms.Label()
        Me.lblThrowing = New System.Windows.Forms.Label()
        Me.lblPickLocks = New System.Windows.Forms.Label()
        Me.lblStealth = New System.Windows.Forms.Label()
        Me.lblDodge = New System.Windows.Forms.Label()
        Me.lblParry = New System.Windows.Forms.Label()
        Me.lblWeaponUse = New System.Windows.Forms.Label()
        Me.numMagic = New System.Windows.Forms.NumericUpDown()
        Me.numAcrobatics = New System.Windows.Forms.NumericUpDown()
        Me.numClimbing = New System.Windows.Forms.NumericUpDown()
        Me.numCommunication = New System.Windows.Forms.NumericUpDown()
        Me.numThrowing = New System.Windows.Forms.NumericUpDown()
        Me.numPickLocks = New System.Windows.Forms.NumericUpDown()
        Me.numStealth = New System.Windows.Forms.NumericUpDown()
        Me.numDodge = New System.Windows.Forms.NumericUpDown()
        Me.numParry = New System.Windows.Forms.NumericUpDown()
        Me.numWeaponUse = New System.Windows.Forms.NumericUpDown()
        Me.lblExperience = New System.Windows.Forms.Label()
        Me.lblLuck = New System.Windows.Forms.Label()
        Me.lblVitality = New System.Windows.Forms.Label()
        Me.lblAgility = New System.Windows.Forms.Label()
        Me.lblIntelligence = New System.Windows.Forms.Label()
        Me.lblStrength = New System.Windows.Forms.Label()
        Me.numExperience = New System.Windows.Forms.NumericUpDown()
        Me.numLuck = New System.Windows.Forms.NumericUpDown()
        Me.numVitality = New System.Windows.Forms.NumericUpDown()
        Me.numAgility = New System.Windows.Forms.NumericUpDown()
        Me.numIntelligence = New System.Windows.Forms.NumericUpDown()
        Me.numStrength = New System.Windows.Forms.NumericUpDown()
        Me.grpSpells = New System.Windows.Forms.GroupBox()
        Me.lblFetch = New System.Windows.Forms.Label()
        Me.numOpen = New System.Windows.Forms.NumericUpDown()
        Me.lblPaladinHealingSpell = New System.Windows.Forms.Label()
        Me.lblFrostBite = New System.Windows.Forms.Label()
        Me.lblGlide = New System.Windows.Forms.Label()
        Me.numLightningBall = New System.Windows.Forms.NumericUpDown()
        Me.lblLightningBall = New System.Windows.Forms.Label()
        Me.lblSummonStaff = New System.Windows.Forms.Label()
        Me.lblHide = New System.Windows.Forms.Label()
        Me.lblReversal = New System.Windows.Forms.Label()
        Me.lblRitualOfRelease = New System.Windows.Forms.Label()
        Me.lblResistance = New System.Windows.Forms.Label()
        Me.numPaladinHealingSpell = New System.Windows.Forms.NumericUpDown()
        Me.lblAura = New System.Windows.Forms.Label()
        Me.lblLevitation = New System.Windows.Forms.Label()
        Me.numDetectMagic = New System.Windows.Forms.NumericUpDown()
        Me.lblFlameDart = New System.Windows.Forms.Label()
        Me.numTrigger = New System.Windows.Forms.NumericUpDown()
        Me.lblProtection = New System.Windows.Forms.Label()
        Me.lblJugglingLights = New System.Windows.Forms.Label()
        Me.lblForceBolt = New System.Windows.Forms.Label()
        Me.numDazzle = New System.Windows.Forms.NumericUpDown()
        Me.lblCalm = New System.Windows.Forms.Label()
        Me.numZap = New System.Windows.Forms.NumericUpDown()
        Me.lblZap = New System.Windows.Forms.Label()
        Me.numCalm = New System.Windows.Forms.NumericUpDown()
        Me.lblDazzle = New System.Windows.Forms.Label()
        Me.numProtection = New System.Windows.Forms.NumericUpDown()
        Me.numJugglingLights = New System.Windows.Forms.NumericUpDown()
        Me.numForceBolt = New System.Windows.Forms.NumericUpDown()
        Me.lblTrigger = New System.Windows.Forms.Label()
        Me.numFlameDart = New System.Windows.Forms.NumericUpDown()
        Me.numFrostBite = New System.Windows.Forms.NumericUpDown()
        Me.numGlide = New System.Windows.Forms.NumericUpDown()
        Me.numSummonStaff = New System.Windows.Forms.NumericUpDown()
        Me.lblDetectMagic = New System.Windows.Forms.Label()
        Me.numRitualOfRelease = New System.Windows.Forms.NumericUpDown()
        Me.numResistance = New System.Windows.Forms.NumericUpDown()
        Me.numAura = New System.Windows.Forms.NumericUpDown()
        Me.numHide = New System.Windows.Forms.NumericUpDown()
        Me.numReversal = New System.Windows.Forms.NumericUpDown()
        Me.numLevitation = New System.Windows.Forms.NumericUpDown()
        Me.lblOpen = New System.Windows.Forms.Label()
        Me.numFetch = New System.Windows.Forms.NumericUpDown()
        Me.grpAbilities = New System.Windows.Forms.GroupBox()
        Me.grpOther = New System.Windows.Forms.GroupBox()
        Me.lblPuzzlePoints = New System.Windows.Forms.Label()
        Me.lblMagicPoints = New System.Windows.Forms.Label()
        Me.lblStaminaPoints = New System.Windows.Forms.Label()
        Me.lblHealthPoints = New System.Windows.Forms.Label()
        Me.numPuzzlePoints = New System.Windows.Forms.NumericUpDown()
        Me.numMagicPoints = New System.Windows.Forms.NumericUpDown()
        Me.numStaminaPoints = New System.Windows.Forms.NumericUpDown()
        Me.numHealthPoints = New System.Windows.Forms.NumericUpDown()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCharacter = New System.Windows.Forms.TabPage()
        Me.picWarning = New System.Windows.Forms.PictureBox()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.lblOverflowError = New System.Windows.Forms.Label()
        Me.picCover = New System.Windows.Forms.PictureBox()
        Me.grpInventory = New System.Windows.Forms.GroupBox()
        Me.lblOilFlasks = New System.Windows.Forms.Label()
        Me.lblRations = New System.Windows.Forms.Label()
        Me.lblPoisonCurePills = New System.Windows.Forms.Label()
        Me.lblUndeadUnguent = New System.Windows.Forms.Label()
        Me.lblMagicPotions = New System.Windows.Forms.Label()
        Me.lblVigorPotions = New System.Windows.Forms.Label()
        Me.lblHealingPotions = New System.Windows.Forms.Label()
        Me.lblDaggers = New System.Windows.Forms.Label()
        Me.numOilFlasks = New System.Windows.Forms.NumericUpDown()
        Me.numRations = New System.Windows.Forms.NumericUpDown()
        Me.numPoisonCurePills = New System.Windows.Forms.NumericUpDown()
        Me.numUndeadUnguent = New System.Windows.Forms.NumericUpDown()
        Me.numMagicPotions = New System.Windows.Forms.NumericUpDown()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.numGold = New System.Windows.Forms.NumericUpDown()
        Me.numVigorPotions = New System.Windows.Forms.NumericUpDown()
        Me.numHealingPotions = New System.Windows.Forms.NumericUpDown()
        Me.numDaggers = New System.Windows.Forms.NumericUpDown()
        Me.grpUniqueInventory = New System.Windows.Forms.GroupBox()
        Me.chkFlag16 = New System.Windows.Forms.CheckBox()
        Me.chkFlag8 = New System.Windows.Forms.CheckBox()
        Me.chkFlag15 = New System.Windows.Forms.CheckBox()
        Me.chkFlag7 = New System.Windows.Forms.CheckBox()
        Me.chkFlag14 = New System.Windows.Forms.CheckBox()
        Me.chkFlag6 = New System.Windows.Forms.CheckBox()
        Me.chkFlag13 = New System.Windows.Forms.CheckBox()
        Me.chkFlag5 = New System.Windows.Forms.CheckBox()
        Me.chkFlag12 = New System.Windows.Forms.CheckBox()
        Me.chkFlag4 = New System.Windows.Forms.CheckBox()
        Me.chkFlag3 = New System.Windows.Forms.CheckBox()
        Me.chkFlag2 = New System.Windows.Forms.CheckBox()
        Me.chkFlag1 = New System.Windows.Forms.CheckBox()
        Me.chkFlag11 = New System.Windows.Forms.CheckBox()
        Me.chkFlag10 = New System.Windows.Forms.CheckBox()
        Me.chkFlag9 = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpClass.SuspendLayout()
        Me.grpSkills.SuspendLayout()
        CType(Me.numHonor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMagic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAcrobatics, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numClimbing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCommunication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numThrowing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPickLocks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStealth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDodge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numParry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWeaponUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numExperience, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLuck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVitality, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAgility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIntelligence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSpells.SuspendLayout()
        CType(Me.numOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLightningBall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPaladinHealingSpell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDetectMagic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTrigger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDazzle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numZap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCalm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numProtection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJugglingLights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numForceBolt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFlameDart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFrostBite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGlide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSummonStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRitualOfRelease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numResistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numReversal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLevitation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFetch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAbilities.SuspendLayout()
        Me.grpOther.SuspendLayout()
        CType(Me.numPuzzlePoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMagicPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStaminaPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHealthPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabCharacter.SuspendLayout()
        CType(Me.picWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInventory.SuspendLayout()
        CType(Me.numOilFlasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPoisonCurePills, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUndeadUnguent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMagicPotions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVigorPotions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHealingPotions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDaggers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUniqueInventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpClass
        '
        Me.grpClass.Controls.Add(Me.rdoPaladin)
        Me.grpClass.Controls.Add(Me.rdoThief)
        Me.grpClass.Controls.Add(Me.rdoWizard)
        Me.grpClass.Controls.Add(Me.rdoFighter)
        Me.grpClass.Location = New System.Drawing.Point(214, 37)
        Me.grpClass.Name = "grpClass"
        Me.grpClass.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grpClass.Size = New System.Drawing.Size(150, 249)
        Me.grpClass.TabIndex = 1
        Me.grpClass.TabStop = False
        Me.grpClass.Text = "Character Class"
        '
        'rdoPaladin
        '
        Me.rdoPaladin.AutoSize = True
        Me.rdoPaladin.Location = New System.Drawing.Point(80, 48)
        Me.rdoPaladin.Name = "rdoPaladin"
        Me.rdoPaladin.Size = New System.Drawing.Size(64, 19)
        Me.rdoPaladin.TabIndex = 3
        Me.rdoPaladin.Text = "Paladin"
        Me.rdoPaladin.UseVisualStyleBackColor = True
        '
        'rdoThief
        '
        Me.rdoThief.AutoSize = True
        Me.rdoThief.Location = New System.Drawing.Point(7, 48)
        Me.rdoThief.Name = "rdoThief"
        Me.rdoThief.Size = New System.Drawing.Size(51, 19)
        Me.rdoThief.TabIndex = 2
        Me.rdoThief.Text = "Thief"
        Me.rdoThief.UseVisualStyleBackColor = True
        '
        'rdoWizard
        '
        Me.rdoWizard.AutoSize = True
        Me.rdoWizard.Location = New System.Drawing.Point(80, 22)
        Me.rdoWizard.Name = "rdoWizard"
        Me.rdoWizard.Size = New System.Drawing.Size(61, 19)
        Me.rdoWizard.TabIndex = 1
        Me.rdoWizard.Text = "Wizard"
        Me.rdoWizard.UseVisualStyleBackColor = True
        '
        'rdoFighter
        '
        Me.rdoFighter.AutoSize = True
        Me.rdoFighter.Checked = True
        Me.rdoFighter.Location = New System.Drawing.Point(7, 22)
        Me.rdoFighter.Name = "rdoFighter"
        Me.rdoFighter.Size = New System.Drawing.Size(62, 19)
        Me.rdoFighter.TabIndex = 0
        Me.rdoFighter.TabStop = True
        Me.rdoFighter.Text = "Fighter"
        Me.rdoFighter.UseVisualStyleBackColor = True
        '
        'grpSkills
        '
        Me.grpSkills.Controls.Add(Me.numHonor)
        Me.grpSkills.Controls.Add(Me.lblHonor)
        Me.grpSkills.Controls.Add(Me.lblMagic)
        Me.grpSkills.Controls.Add(Me.lblAcrobatics)
        Me.grpSkills.Controls.Add(Me.lblClimbing)
        Me.grpSkills.Controls.Add(Me.lblCommunication)
        Me.grpSkills.Controls.Add(Me.lblThrowing)
        Me.grpSkills.Controls.Add(Me.lblPickLocks)
        Me.grpSkills.Controls.Add(Me.lblStealth)
        Me.grpSkills.Controls.Add(Me.lblDodge)
        Me.grpSkills.Controls.Add(Me.lblParry)
        Me.grpSkills.Controls.Add(Me.lblWeaponUse)
        Me.grpSkills.Controls.Add(Me.numMagic)
        Me.grpSkills.Controls.Add(Me.numAcrobatics)
        Me.grpSkills.Controls.Add(Me.numClimbing)
        Me.grpSkills.Controls.Add(Me.numCommunication)
        Me.grpSkills.Controls.Add(Me.numThrowing)
        Me.grpSkills.Controls.Add(Me.numPickLocks)
        Me.grpSkills.Controls.Add(Me.numStealth)
        Me.grpSkills.Controls.Add(Me.numDodge)
        Me.grpSkills.Controls.Add(Me.numParry)
        Me.grpSkills.Controls.Add(Me.numWeaponUse)
        Me.grpSkills.Location = New System.Drawing.Point(182, 292)
        Me.grpSkills.Name = "grpSkills"
        Me.grpSkills.Size = New System.Drawing.Size(182, 306)
        Me.grpSkills.TabIndex = 3
        Me.grpSkills.TabStop = False
        Me.grpSkills.Text = "Skills"
        '
        'numHonor
        '
        Me.numHonor.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numHonor.Location = New System.Drawing.Point(7, 252)
        Me.numHonor.Name = "numHonor"
        Me.numHonor.Size = New System.Drawing.Size(61, 23)
        Me.numHonor.TabIndex = 9
        Me.numHonor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numHonor, "Only available in QFG2, QFG3, and QFG4")
        '
        'lblHonor
        '
        Me.lblHonor.AutoSize = True
        Me.lblHonor.Location = New System.Drawing.Point(74, 254)
        Me.lblHonor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHonor.Name = "lblHonor"
        Me.lblHonor.Size = New System.Drawing.Size(41, 15)
        Me.lblHonor.TabIndex = 6
        Me.lblHonor.Text = "Honor"
        '
        'lblMagic
        '
        Me.lblMagic.AutoSize = True
        Me.lblMagic.Location = New System.Drawing.Point(74, 202)
        Me.lblMagic.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMagic.Name = "lblMagic"
        Me.lblMagic.Size = New System.Drawing.Size(40, 15)
        Me.lblMagic.TabIndex = 8
        Me.lblMagic.Text = "Magic"
        '
        'lblAcrobatics
        '
        Me.lblAcrobatics.AutoSize = True
        Me.lblAcrobatics.Enabled = False
        Me.lblAcrobatics.Location = New System.Drawing.Point(74, 280)
        Me.lblAcrobatics.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAcrobatics.Name = "lblAcrobatics"
        Me.lblAcrobatics.Size = New System.Drawing.Size(63, 15)
        Me.lblAcrobatics.TabIndex = 8
        Me.lblAcrobatics.Text = "Acrobatics"
        '
        'lblClimbing
        '
        Me.lblClimbing.AutoSize = True
        Me.lblClimbing.Location = New System.Drawing.Point(74, 176)
        Me.lblClimbing.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClimbing.Name = "lblClimbing"
        Me.lblClimbing.Size = New System.Drawing.Size(56, 15)
        Me.lblClimbing.TabIndex = 7
        Me.lblClimbing.Text = "Climbing"
        '
        'lblCommunication
        '
        Me.lblCommunication.AutoSize = True
        Me.lblCommunication.Location = New System.Drawing.Point(74, 228)
        Me.lblCommunication.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCommunication.Name = "lblCommunication"
        Me.lblCommunication.Size = New System.Drawing.Size(94, 15)
        Me.lblCommunication.TabIndex = 7
        Me.lblCommunication.Text = "Communication"
        '
        'lblThrowing
        '
        Me.lblThrowing.AutoSize = True
        Me.lblThrowing.Location = New System.Drawing.Point(74, 150)
        Me.lblThrowing.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblThrowing.Name = "lblThrowing"
        Me.lblThrowing.Size = New System.Drawing.Size(57, 15)
        Me.lblThrowing.TabIndex = 6
        Me.lblThrowing.Text = "Throwing"
        '
        'lblPickLocks
        '
        Me.lblPickLocks.AutoSize = True
        Me.lblPickLocks.Location = New System.Drawing.Point(74, 124)
        Me.lblPickLocks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPickLocks.Name = "lblPickLocks"
        Me.lblPickLocks.Size = New System.Drawing.Size(62, 15)
        Me.lblPickLocks.TabIndex = 5
        Me.lblPickLocks.Text = "Pick Locks"
        '
        'lblStealth
        '
        Me.lblStealth.AutoSize = True
        Me.lblStealth.Location = New System.Drawing.Point(74, 98)
        Me.lblStealth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStealth.Name = "lblStealth"
        Me.lblStealth.Size = New System.Drawing.Size(43, 15)
        Me.lblStealth.TabIndex = 4
        Me.lblStealth.Text = "Stealth"
        '
        'lblDodge
        '
        Me.lblDodge.AutoSize = True
        Me.lblDodge.Location = New System.Drawing.Point(74, 72)
        Me.lblDodge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDodge.Name = "lblDodge"
        Me.lblDodge.Size = New System.Drawing.Size(42, 15)
        Me.lblDodge.TabIndex = 3
        Me.lblDodge.Text = "Dodge"
        '
        'lblParry
        '
        Me.lblParry.AutoSize = True
        Me.lblParry.Location = New System.Drawing.Point(74, 46)
        Me.lblParry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblParry.Name = "lblParry"
        Me.lblParry.Size = New System.Drawing.Size(34, 15)
        Me.lblParry.TabIndex = 2
        Me.lblParry.Text = "Parry"
        '
        'lblWeaponUse
        '
        Me.lblWeaponUse.AutoSize = True
        Me.lblWeaponUse.Location = New System.Drawing.Point(74, 20)
        Me.lblWeaponUse.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWeaponUse.Name = "lblWeaponUse"
        Me.lblWeaponUse.Size = New System.Drawing.Size(73, 15)
        Me.lblWeaponUse.TabIndex = 1
        Me.lblWeaponUse.Text = "Weapon Use"
        '
        'numMagic
        '
        Me.numMagic.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numMagic.Location = New System.Drawing.Point(7, 200)
        Me.numMagic.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numMagic.Name = "numMagic"
        Me.numMagic.Size = New System.Drawing.Size(61, 23)
        Me.numMagic.TabIndex = 7
        Me.numMagic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numAcrobatics
        '
        Me.numAcrobatics.Enabled = False
        Me.numAcrobatics.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numAcrobatics.Location = New System.Drawing.Point(7, 278)
        Me.numAcrobatics.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numAcrobatics.Name = "numAcrobatics"
        Me.numAcrobatics.Size = New System.Drawing.Size(61, 23)
        Me.numAcrobatics.TabIndex = 10
        Me.numAcrobatics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numAcrobatics, "Only available in QFG4")
        '
        'numClimbing
        '
        Me.numClimbing.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numClimbing.Location = New System.Drawing.Point(7, 174)
        Me.numClimbing.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numClimbing.Name = "numClimbing"
        Me.numClimbing.Size = New System.Drawing.Size(61, 23)
        Me.numClimbing.TabIndex = 6
        Me.numClimbing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numCommunication
        '
        Me.numCommunication.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numCommunication.Location = New System.Drawing.Point(7, 226)
        Me.numCommunication.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numCommunication.Name = "numCommunication"
        Me.numCommunication.Size = New System.Drawing.Size(61, 23)
        Me.numCommunication.TabIndex = 8
        Me.numCommunication.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numCommunication, "Only available in QFG2, QFG3, and QFG4")
        '
        'numThrowing
        '
        Me.numThrowing.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numThrowing.Location = New System.Drawing.Point(7, 148)
        Me.numThrowing.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numThrowing.Name = "numThrowing"
        Me.numThrowing.Size = New System.Drawing.Size(61, 23)
        Me.numThrowing.TabIndex = 5
        Me.numThrowing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numPickLocks
        '
        Me.numPickLocks.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numPickLocks.Location = New System.Drawing.Point(7, 122)
        Me.numPickLocks.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numPickLocks.Name = "numPickLocks"
        Me.numPickLocks.Size = New System.Drawing.Size(61, 23)
        Me.numPickLocks.TabIndex = 4
        Me.numPickLocks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numStealth
        '
        Me.numStealth.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numStealth.Location = New System.Drawing.Point(7, 96)
        Me.numStealth.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numStealth.Name = "numStealth"
        Me.numStealth.Size = New System.Drawing.Size(61, 23)
        Me.numStealth.TabIndex = 3
        Me.numStealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDodge
        '
        Me.numDodge.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numDodge.Location = New System.Drawing.Point(7, 70)
        Me.numDodge.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numDodge.Name = "numDodge"
        Me.numDodge.Size = New System.Drawing.Size(61, 23)
        Me.numDodge.TabIndex = 2
        Me.numDodge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numParry
        '
        Me.numParry.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numParry.Location = New System.Drawing.Point(7, 44)
        Me.numParry.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numParry.Name = "numParry"
        Me.numParry.Size = New System.Drawing.Size(61, 23)
        Me.numParry.TabIndex = 1
        Me.numParry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numWeaponUse
        '
        Me.numWeaponUse.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numWeaponUse.Location = New System.Drawing.Point(7, 18)
        Me.numWeaponUse.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numWeaponUse.Name = "numWeaponUse"
        Me.numWeaponUse.Size = New System.Drawing.Size(61, 23)
        Me.numWeaponUse.TabIndex = 0
        Me.numWeaponUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblExperience
        '
        Me.lblExperience.AutoSize = True
        Me.lblExperience.Location = New System.Drawing.Point(74, 44)
        Me.lblExperience.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExperience.Name = "lblExperience"
        Me.lblExperience.Size = New System.Drawing.Size(64, 15)
        Me.lblExperience.TabIndex = 8
        Me.lblExperience.Text = "Experience"
        '
        'lblLuck
        '
        Me.lblLuck.AutoSize = True
        Me.lblLuck.Location = New System.Drawing.Point(74, 124)
        Me.lblLuck.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLuck.Name = "lblLuck"
        Me.lblLuck.Size = New System.Drawing.Size(32, 15)
        Me.lblLuck.TabIndex = 5
        Me.lblLuck.Text = "Luck"
        '
        'lblVitality
        '
        Me.lblVitality.AutoSize = True
        Me.lblVitality.Location = New System.Drawing.Point(74, 98)
        Me.lblVitality.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVitality.Name = "lblVitality"
        Me.lblVitality.Size = New System.Drawing.Size(43, 15)
        Me.lblVitality.TabIndex = 4
        Me.lblVitality.Text = "Vitality"
        '
        'lblAgility
        '
        Me.lblAgility.AutoSize = True
        Me.lblAgility.Location = New System.Drawing.Point(74, 72)
        Me.lblAgility.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAgility.Name = "lblAgility"
        Me.lblAgility.Size = New System.Drawing.Size(41, 15)
        Me.lblAgility.TabIndex = 3
        Me.lblAgility.Text = "Agility"
        '
        'lblIntelligence
        '
        Me.lblIntelligence.AutoSize = True
        Me.lblIntelligence.Location = New System.Drawing.Point(74, 46)
        Me.lblIntelligence.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIntelligence.Name = "lblIntelligence"
        Me.lblIntelligence.Size = New System.Drawing.Size(68, 15)
        Me.lblIntelligence.TabIndex = 2
        Me.lblIntelligence.Text = "Intelligence"
        '
        'lblStrength
        '
        Me.lblStrength.AutoSize = True
        Me.lblStrength.Location = New System.Drawing.Point(74, 20)
        Me.lblStrength.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStrength.Name = "lblStrength"
        Me.lblStrength.Size = New System.Drawing.Size(52, 15)
        Me.lblStrength.TabIndex = 1
        Me.lblStrength.Text = "Strength"
        '
        'numExperience
        '
        Me.numExperience.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numExperience.Location = New System.Drawing.Point(7, 42)
        Me.numExperience.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numExperience.Name = "numExperience"
        Me.numExperience.Size = New System.Drawing.Size(61, 23)
        Me.numExperience.TabIndex = 1
        Me.numExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numLuck
        '
        Me.numLuck.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numLuck.Location = New System.Drawing.Point(7, 122)
        Me.numLuck.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numLuck.Name = "numLuck"
        Me.numLuck.Size = New System.Drawing.Size(61, 23)
        Me.numLuck.TabIndex = 4
        Me.numLuck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numVitality
        '
        Me.numVitality.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numVitality.Location = New System.Drawing.Point(7, 96)
        Me.numVitality.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numVitality.Name = "numVitality"
        Me.numVitality.Size = New System.Drawing.Size(61, 23)
        Me.numVitality.TabIndex = 3
        Me.numVitality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numAgility
        '
        Me.numAgility.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numAgility.Location = New System.Drawing.Point(7, 70)
        Me.numAgility.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numAgility.Name = "numAgility"
        Me.numAgility.Size = New System.Drawing.Size(61, 23)
        Me.numAgility.TabIndex = 2
        Me.numAgility.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numIntelligence
        '
        Me.numIntelligence.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numIntelligence.Location = New System.Drawing.Point(7, 44)
        Me.numIntelligence.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numIntelligence.Name = "numIntelligence"
        Me.numIntelligence.Size = New System.Drawing.Size(61, 23)
        Me.numIntelligence.TabIndex = 1
        Me.numIntelligence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numStrength
        '
        Me.numStrength.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numStrength.Location = New System.Drawing.Point(7, 18)
        Me.numStrength.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numStrength.Name = "numStrength"
        Me.numStrength.Size = New System.Drawing.Size(61, 23)
        Me.numStrength.TabIndex = 0
        Me.numStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpSpells
        '
        Me.grpSpells.Controls.Add(Me.lblFetch)
        Me.grpSpells.Controls.Add(Me.numOpen)
        Me.grpSpells.Controls.Add(Me.lblPaladinHealingSpell)
        Me.grpSpells.Controls.Add(Me.lblFrostBite)
        Me.grpSpells.Controls.Add(Me.lblGlide)
        Me.grpSpells.Controls.Add(Me.numLightningBall)
        Me.grpSpells.Controls.Add(Me.lblLightningBall)
        Me.grpSpells.Controls.Add(Me.lblSummonStaff)
        Me.grpSpells.Controls.Add(Me.lblHide)
        Me.grpSpells.Controls.Add(Me.lblReversal)
        Me.grpSpells.Controls.Add(Me.lblRitualOfRelease)
        Me.grpSpells.Controls.Add(Me.lblResistance)
        Me.grpSpells.Controls.Add(Me.numPaladinHealingSpell)
        Me.grpSpells.Controls.Add(Me.lblAura)
        Me.grpSpells.Controls.Add(Me.lblLevitation)
        Me.grpSpells.Controls.Add(Me.numDetectMagic)
        Me.grpSpells.Controls.Add(Me.lblFlameDart)
        Me.grpSpells.Controls.Add(Me.numTrigger)
        Me.grpSpells.Controls.Add(Me.lblProtection)
        Me.grpSpells.Controls.Add(Me.lblJugglingLights)
        Me.grpSpells.Controls.Add(Me.lblForceBolt)
        Me.grpSpells.Controls.Add(Me.numDazzle)
        Me.grpSpells.Controls.Add(Me.lblCalm)
        Me.grpSpells.Controls.Add(Me.numZap)
        Me.grpSpells.Controls.Add(Me.lblZap)
        Me.grpSpells.Controls.Add(Me.numCalm)
        Me.grpSpells.Controls.Add(Me.lblDazzle)
        Me.grpSpells.Controls.Add(Me.numProtection)
        Me.grpSpells.Controls.Add(Me.numJugglingLights)
        Me.grpSpells.Controls.Add(Me.numForceBolt)
        Me.grpSpells.Controls.Add(Me.lblTrigger)
        Me.grpSpells.Controls.Add(Me.numFlameDart)
        Me.grpSpells.Controls.Add(Me.numFrostBite)
        Me.grpSpells.Controls.Add(Me.numGlide)
        Me.grpSpells.Controls.Add(Me.numSummonStaff)
        Me.grpSpells.Controls.Add(Me.lblDetectMagic)
        Me.grpSpells.Controls.Add(Me.numRitualOfRelease)
        Me.grpSpells.Controls.Add(Me.numResistance)
        Me.grpSpells.Controls.Add(Me.numAura)
        Me.grpSpells.Controls.Add(Me.numHide)
        Me.grpSpells.Controls.Add(Me.numReversal)
        Me.grpSpells.Controls.Add(Me.numLevitation)
        Me.grpSpells.Controls.Add(Me.lblOpen)
        Me.grpSpells.Controls.Add(Me.numFetch)
        Me.grpSpells.Location = New System.Drawing.Point(372, 292)
        Me.grpSpells.Name = "grpSpells"
        Me.grpSpells.Size = New System.Drawing.Size(366, 306)
        Me.grpSpells.TabIndex = 5
        Me.grpSpells.TabStop = False
        Me.grpSpells.Text = "Spells"
        '
        'lblFetch
        '
        Me.lblFetch.AutoSize = True
        Me.lblFetch.Location = New System.Drawing.Point(74, 203)
        Me.lblFetch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFetch.Name = "lblFetch"
        Me.lblFetch.Size = New System.Drawing.Size(36, 15)
        Me.lblFetch.TabIndex = 8
        Me.lblFetch.Text = "Fetch"
        '
        'numOpen
        '
        Me.numOpen.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numOpen.Location = New System.Drawing.Point(7, 18)
        Me.numOpen.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numOpen.Name = "numOpen"
        Me.numOpen.Size = New System.Drawing.Size(61, 23)
        Me.numOpen.TabIndex = 0
        Me.numOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPaladinHealingSpell
        '
        Me.lblPaladinHealingSpell.AutoSize = True
        Me.lblPaladinHealingSpell.Location = New System.Drawing.Point(262, 280)
        Me.lblPaladinHealingSpell.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPaladinHealingSpell.Name = "lblPaladinHealingSpell"
        Me.lblPaladinHealingSpell.Size = New System.Drawing.Size(90, 15)
        Me.lblPaladinHealingSpell.TabIndex = 1
        Me.lblPaladinHealingSpell.Text = "Paladin Healing"
        '
        'lblFrostBite
        '
        Me.lblFrostBite.AutoSize = True
        Me.lblFrostBite.Enabled = False
        Me.lblFrostBite.Location = New System.Drawing.Point(261, 99)
        Me.lblFrostBite.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFrostBite.Name = "lblFrostBite"
        Me.lblFrostBite.Size = New System.Drawing.Size(56, 15)
        Me.lblFrostBite.TabIndex = 8
        Me.lblFrostBite.Text = "Frost Bite"
        '
        'lblGlide
        '
        Me.lblGlide.AutoSize = True
        Me.lblGlide.Enabled = False
        Me.lblGlide.Location = New System.Drawing.Point(261, 255)
        Me.lblGlide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGlide.Name = "lblGlide"
        Me.lblGlide.Size = New System.Drawing.Size(34, 15)
        Me.lblGlide.TabIndex = 8
        Me.lblGlide.Text = "Glide"
        '
        'numLightningBall
        '
        Me.numLightningBall.Enabled = False
        Me.numLightningBall.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numLightningBall.Location = New System.Drawing.Point(195, 70)
        Me.numLightningBall.Name = "numLightningBall"
        Me.numLightningBall.Size = New System.Drawing.Size(61, 23)
        Me.numLightningBall.TabIndex = 13
        Me.numLightningBall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numLightningBall, "Available in QFG3 and higher")
        '
        'lblLightningBall
        '
        Me.lblLightningBall.AutoSize = True
        Me.lblLightningBall.Enabled = False
        Me.lblLightningBall.Location = New System.Drawing.Point(261, 73)
        Me.lblLightningBall.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLightningBall.Name = "lblLightningBall"
        Me.lblLightningBall.Size = New System.Drawing.Size(80, 15)
        Me.lblLightningBall.TabIndex = 8
        Me.lblLightningBall.Text = "Lightning Ball"
        '
        'lblSummonStaff
        '
        Me.lblSummonStaff.AutoSize = True
        Me.lblSummonStaff.Enabled = False
        Me.lblSummonStaff.Location = New System.Drawing.Point(261, 47)
        Me.lblSummonStaff.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSummonStaff.Name = "lblSummonStaff"
        Me.lblSummonStaff.Size = New System.Drawing.Size(83, 15)
        Me.lblSummonStaff.TabIndex = 8
        Me.lblSummonStaff.Text = "Summon Staff"
        '
        'lblHide
        '
        Me.lblHide.AutoSize = True
        Me.lblHide.Location = New System.Drawing.Point(261, 151)
        Me.lblHide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHide.Name = "lblHide"
        Me.lblHide.Size = New System.Drawing.Size(32, 15)
        Me.lblHide.TabIndex = 8
        Me.lblHide.Text = "Hide"
        '
        'lblReversal
        '
        Me.lblReversal.AutoSize = True
        Me.lblReversal.Location = New System.Drawing.Point(74, 280)
        Me.lblReversal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReversal.Name = "lblReversal"
        Me.lblReversal.Size = New System.Drawing.Size(50, 15)
        Me.lblReversal.TabIndex = 8
        Me.lblReversal.Text = "Reversal"
        '
        'lblRitualOfRelease
        '
        Me.lblRitualOfRelease.AutoSize = True
        Me.lblRitualOfRelease.Enabled = False
        Me.lblRitualOfRelease.Location = New System.Drawing.Point(261, 125)
        Me.lblRitualOfRelease.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRitualOfRelease.Name = "lblRitualOfRelease"
        Me.lblRitualOfRelease.Size = New System.Drawing.Size(93, 15)
        Me.lblRitualOfRelease.TabIndex = 8
        Me.lblRitualOfRelease.Text = "Ritual of Release"
        '
        'lblResistance
        '
        Me.lblResistance.AutoSize = True
        Me.lblResistance.Enabled = False
        Me.lblResistance.Location = New System.Drawing.Point(261, 229)
        Me.lblResistance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResistance.Name = "lblResistance"
        Me.lblResistance.Size = New System.Drawing.Size(62, 15)
        Me.lblResistance.TabIndex = 8
        Me.lblResistance.Text = "Resistance"
        '
        'numPaladinHealingSpell
        '
        Me.numPaladinHealingSpell.Location = New System.Drawing.Point(195, 278)
        Me.numPaladinHealingSpell.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numPaladinHealingSpell.Name = "numPaladinHealingSpell"
        Me.numPaladinHealingSpell.Size = New System.Drawing.Size(61, 23)
        Me.numPaladinHealingSpell.TabIndex = 5
        Me.numPaladinHealingSpell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numPaladinHealingSpell, "Only available in QFG3 and QFG4")
        '
        'lblAura
        '
        Me.lblAura.AutoSize = True
        Me.lblAura.Enabled = False
        Me.lblAura.Location = New System.Drawing.Point(261, 177)
        Me.lblAura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAura.Name = "lblAura"
        Me.lblAura.Size = New System.Drawing.Size(32, 15)
        Me.lblAura.TabIndex = 8
        Me.lblAura.Text = "Aura"
        '
        'lblLevitation
        '
        Me.lblLevitation.AutoSize = True
        Me.lblLevitation.Location = New System.Drawing.Point(74, 255)
        Me.lblLevitation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLevitation.Name = "lblLevitation"
        Me.lblLevitation.Size = New System.Drawing.Size(59, 15)
        Me.lblLevitation.TabIndex = 8
        Me.lblLevitation.Text = "Levitation"
        '
        'numDetectMagic
        '
        Me.numDetectMagic.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numDetectMagic.Location = New System.Drawing.Point(7, 44)
        Me.numDetectMagic.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numDetectMagic.Name = "numDetectMagic"
        Me.numDetectMagic.Size = New System.Drawing.Size(61, 23)
        Me.numDetectMagic.TabIndex = 1
        Me.numDetectMagic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFlameDart
        '
        Me.lblFlameDart.AutoSize = True
        Me.lblFlameDart.Location = New System.Drawing.Point(74, 177)
        Me.lblFlameDart.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFlameDart.Name = "lblFlameDart"
        Me.lblFlameDart.Size = New System.Drawing.Size(64, 15)
        Me.lblFlameDart.TabIndex = 7
        Me.lblFlameDart.Text = "Flame Dart"
        '
        'numTrigger
        '
        Me.numTrigger.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numTrigger.Location = New System.Drawing.Point(7, 70)
        Me.numTrigger.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numTrigger.Name = "numTrigger"
        Me.numTrigger.Size = New System.Drawing.Size(61, 23)
        Me.numTrigger.TabIndex = 2
        Me.numTrigger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProtection
        '
        Me.lblProtection.AutoSize = True
        Me.lblProtection.Enabled = False
        Me.lblProtection.Location = New System.Drawing.Point(261, 203)
        Me.lblProtection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProtection.Name = "lblProtection"
        Me.lblProtection.Size = New System.Drawing.Size(62, 15)
        Me.lblProtection.TabIndex = 7
        Me.lblProtection.Text = "Protection"
        '
        'lblJugglingLights
        '
        Me.lblJugglingLights.AutoSize = True
        Me.lblJugglingLights.Enabled = False
        Me.lblJugglingLights.Location = New System.Drawing.Point(261, 21)
        Me.lblJugglingLights.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJugglingLights.Name = "lblJugglingLights"
        Me.lblJugglingLights.Size = New System.Drawing.Size(87, 15)
        Me.lblJugglingLights.TabIndex = 7
        Me.lblJugglingLights.Text = "Juggling Lights"
        '
        'lblForceBolt
        '
        Me.lblForceBolt.AutoSize = True
        Me.lblForceBolt.Location = New System.Drawing.Point(74, 229)
        Me.lblForceBolt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblForceBolt.Name = "lblForceBolt"
        Me.lblForceBolt.Size = New System.Drawing.Size(60, 15)
        Me.lblForceBolt.TabIndex = 7
        Me.lblForceBolt.Text = "Force Bolt"
        '
        'numDazzle
        '
        Me.numDazzle.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numDazzle.Location = New System.Drawing.Point(7, 96)
        Me.numDazzle.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numDazzle.Name = "numDazzle"
        Me.numDazzle.Size = New System.Drawing.Size(61, 23)
        Me.numDazzle.TabIndex = 3
        Me.numDazzle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCalm
        '
        Me.lblCalm.AutoSize = True
        Me.lblCalm.Location = New System.Drawing.Point(74, 151)
        Me.lblCalm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalm.Name = "lblCalm"
        Me.lblCalm.Size = New System.Drawing.Size(35, 15)
        Me.lblCalm.TabIndex = 6
        Me.lblCalm.Text = "Calm"
        '
        'numZap
        '
        Me.numZap.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numZap.Location = New System.Drawing.Point(7, 122)
        Me.numZap.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numZap.Name = "numZap"
        Me.numZap.Size = New System.Drawing.Size(61, 23)
        Me.numZap.TabIndex = 4
        Me.numZap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblZap
        '
        Me.lblZap.AutoSize = True
        Me.lblZap.Location = New System.Drawing.Point(74, 125)
        Me.lblZap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblZap.Name = "lblZap"
        Me.lblZap.Size = New System.Drawing.Size(27, 15)
        Me.lblZap.TabIndex = 5
        Me.lblZap.Text = "Zap"
        '
        'numCalm
        '
        Me.numCalm.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numCalm.Location = New System.Drawing.Point(7, 148)
        Me.numCalm.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numCalm.Name = "numCalm"
        Me.numCalm.Size = New System.Drawing.Size(61, 23)
        Me.numCalm.TabIndex = 5
        Me.numCalm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDazzle
        '
        Me.lblDazzle.AutoSize = True
        Me.lblDazzle.Location = New System.Drawing.Point(74, 99)
        Me.lblDazzle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDazzle.Name = "lblDazzle"
        Me.lblDazzle.Size = New System.Drawing.Size(40, 15)
        Me.lblDazzle.TabIndex = 4
        Me.lblDazzle.Text = "Dazzle"
        '
        'numProtection
        '
        Me.numProtection.Enabled = False
        Me.numProtection.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numProtection.Location = New System.Drawing.Point(195, 200)
        Me.numProtection.Name = "numProtection"
        Me.numProtection.Size = New System.Drawing.Size(61, 23)
        Me.numProtection.TabIndex = 18
        Me.numProtection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numProtection, "Only available in QFG4")
        '
        'numJugglingLights
        '
        Me.numJugglingLights.Enabled = False
        Me.numJugglingLights.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numJugglingLights.Location = New System.Drawing.Point(195, 18)
        Me.numJugglingLights.Name = "numJugglingLights"
        Me.numJugglingLights.Size = New System.Drawing.Size(61, 23)
        Me.numJugglingLights.TabIndex = 11
        Me.numJugglingLights.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numJugglingLights, "Available in QFG3 and higher")
        '
        'numForceBolt
        '
        Me.numForceBolt.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numForceBolt.Location = New System.Drawing.Point(7, 226)
        Me.numForceBolt.Name = "numForceBolt"
        Me.numForceBolt.Size = New System.Drawing.Size(61, 23)
        Me.numForceBolt.TabIndex = 8
        Me.numForceBolt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numForceBolt, "Available in QFG2 and higher")
        '
        'lblTrigger
        '
        Me.lblTrigger.AutoSize = True
        Me.lblTrigger.Location = New System.Drawing.Point(74, 73)
        Me.lblTrigger.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrigger.Name = "lblTrigger"
        Me.lblTrigger.Size = New System.Drawing.Size(43, 15)
        Me.lblTrigger.TabIndex = 3
        Me.lblTrigger.Text = "Trigger"
        '
        'numFlameDart
        '
        Me.numFlameDart.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numFlameDart.Location = New System.Drawing.Point(7, 174)
        Me.numFlameDart.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numFlameDart.Name = "numFlameDart"
        Me.numFlameDart.Size = New System.Drawing.Size(61, 23)
        Me.numFlameDart.TabIndex = 6
        Me.numFlameDart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numFrostBite
        '
        Me.numFrostBite.Enabled = False
        Me.numFrostBite.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numFrostBite.Location = New System.Drawing.Point(195, 96)
        Me.numFrostBite.Name = "numFrostBite"
        Me.numFrostBite.Size = New System.Drawing.Size(61, 23)
        Me.numFrostBite.TabIndex = 14
        Me.numFrostBite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numFrostBite, "Only available in QFG4")
        '
        'numGlide
        '
        Me.numGlide.Enabled = False
        Me.numGlide.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numGlide.Location = New System.Drawing.Point(195, 252)
        Me.numGlide.Name = "numGlide"
        Me.numGlide.Size = New System.Drawing.Size(61, 23)
        Me.numGlide.TabIndex = 15
        Me.numGlide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numGlide, "Only available in QFG4")
        '
        'numSummonStaff
        '
        Me.numSummonStaff.Enabled = False
        Me.numSummonStaff.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numSummonStaff.Location = New System.Drawing.Point(195, 44)
        Me.numSummonStaff.Name = "numSummonStaff"
        Me.numSummonStaff.Size = New System.Drawing.Size(61, 23)
        Me.numSummonStaff.TabIndex = 12
        Me.numSummonStaff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numSummonStaff, "Available in QFG3 and higher")
        '
        'lblDetectMagic
        '
        Me.lblDetectMagic.AutoSize = True
        Me.lblDetectMagic.Location = New System.Drawing.Point(74, 47)
        Me.lblDetectMagic.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDetectMagic.Name = "lblDetectMagic"
        Me.lblDetectMagic.Size = New System.Drawing.Size(77, 15)
        Me.lblDetectMagic.TabIndex = 2
        Me.lblDetectMagic.Text = "Detect Magic"
        '
        'numRitualOfRelease
        '
        Me.numRitualOfRelease.Enabled = False
        Me.numRitualOfRelease.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numRitualOfRelease.Location = New System.Drawing.Point(195, 122)
        Me.numRitualOfRelease.Name = "numRitualOfRelease"
        Me.numRitualOfRelease.Size = New System.Drawing.Size(61, 23)
        Me.numRitualOfRelease.TabIndex = 19
        Me.numRitualOfRelease.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numRitualOfRelease, "Only available in QFG4")
        '
        'numResistance
        '
        Me.numResistance.Enabled = False
        Me.numResistance.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numResistance.Location = New System.Drawing.Point(195, 226)
        Me.numResistance.Name = "numResistance"
        Me.numResistance.Size = New System.Drawing.Size(61, 23)
        Me.numResistance.TabIndex = 19
        Me.numResistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numResistance, "Only available in QFG4")
        '
        'numAura
        '
        Me.numAura.Enabled = False
        Me.numAura.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numAura.Location = New System.Drawing.Point(195, 174)
        Me.numAura.Name = "numAura"
        Me.numAura.Size = New System.Drawing.Size(61, 23)
        Me.numAura.TabIndex = 17
        Me.numAura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numAura, "Only available in QFG4")
        '
        'numHide
        '
        Me.numHide.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numHide.Location = New System.Drawing.Point(195, 148)
        Me.numHide.Name = "numHide"
        Me.numHide.Size = New System.Drawing.Size(61, 23)
        Me.numHide.TabIndex = 16
        Me.numHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numHide, "Only available in QFG4")
        '
        'numReversal
        '
        Me.numReversal.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numReversal.Location = New System.Drawing.Point(7, 278)
        Me.numReversal.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.numReversal.Name = "numReversal"
        Me.numReversal.Size = New System.Drawing.Size(61, 23)
        Me.numReversal.TabIndex = 10
        Me.numReversal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numReversal, "Available in QFG2 and higher")
        '
        'numLevitation
        '
        Me.numLevitation.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numLevitation.Location = New System.Drawing.Point(7, 252)
        Me.numLevitation.Name = "numLevitation"
        Me.numLevitation.Size = New System.Drawing.Size(61, 23)
        Me.numLevitation.TabIndex = 9
        Me.numLevitation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numLevitation, "Available in QFG2 and higher")
        '
        'lblOpen
        '
        Me.lblOpen.AutoSize = True
        Me.lblOpen.Location = New System.Drawing.Point(74, 21)
        Me.lblOpen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOpen.Name = "lblOpen"
        Me.lblOpen.Size = New System.Drawing.Size(36, 15)
        Me.lblOpen.TabIndex = 1
        Me.lblOpen.Text = "Open"
        '
        'numFetch
        '
        Me.numFetch.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numFetch.Location = New System.Drawing.Point(7, 200)
        Me.numFetch.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numFetch.Name = "numFetch"
        Me.numFetch.Size = New System.Drawing.Size(61, 23)
        Me.numFetch.TabIndex = 7
        Me.numFetch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpAbilities
        '
        Me.grpAbilities.Controls.Add(Me.numStrength)
        Me.grpAbilities.Controls.Add(Me.numIntelligence)
        Me.grpAbilities.Controls.Add(Me.numAgility)
        Me.grpAbilities.Controls.Add(Me.numVitality)
        Me.grpAbilities.Controls.Add(Me.numLuck)
        Me.grpAbilities.Controls.Add(Me.lblStrength)
        Me.grpAbilities.Controls.Add(Me.lblIntelligence)
        Me.grpAbilities.Controls.Add(Me.lblLuck)
        Me.grpAbilities.Controls.Add(Me.lblAgility)
        Me.grpAbilities.Controls.Add(Me.lblVitality)
        Me.grpAbilities.Location = New System.Drawing.Point(7, 292)
        Me.grpAbilities.Name = "grpAbilities"
        Me.grpAbilities.Size = New System.Drawing.Size(169, 151)
        Me.grpAbilities.TabIndex = 2
        Me.grpAbilities.TabStop = False
        Me.grpAbilities.Text = "Abilities"
        '
        'grpOther
        '
        Me.grpOther.Controls.Add(Me.lblPuzzlePoints)
        Me.grpOther.Controls.Add(Me.lblMagicPoints)
        Me.grpOther.Controls.Add(Me.lblStaminaPoints)
        Me.grpOther.Controls.Add(Me.lblHealthPoints)
        Me.grpOther.Controls.Add(Me.lblExperience)
        Me.grpOther.Controls.Add(Me.numPuzzlePoints)
        Me.grpOther.Controls.Add(Me.numMagicPoints)
        Me.grpOther.Controls.Add(Me.numStaminaPoints)
        Me.grpOther.Controls.Add(Me.numHealthPoints)
        Me.grpOther.Controls.Add(Me.numExperience)
        Me.grpOther.Location = New System.Drawing.Point(7, 449)
        Me.grpOther.Name = "grpOther"
        Me.grpOther.Size = New System.Drawing.Size(170, 149)
        Me.grpOther.TabIndex = 4
        Me.grpOther.TabStop = False
        Me.grpOther.Text = "Other"
        '
        'lblPuzzlePoints
        '
        Me.lblPuzzlePoints.AutoSize = True
        Me.lblPuzzlePoints.Location = New System.Drawing.Point(74, 20)
        Me.lblPuzzlePoints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPuzzlePoints.Name = "lblPuzzlePoints"
        Me.lblPuzzlePoints.Size = New System.Drawing.Size(76, 15)
        Me.lblPuzzlePoints.TabIndex = 8
        Me.lblPuzzlePoints.Text = "Puzzle Points"
        '
        'lblMagicPoints
        '
        Me.lblMagicPoints.AutoSize = True
        Me.lblMagicPoints.Location = New System.Drawing.Point(74, 123)
        Me.lblMagicPoints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMagicPoints.Name = "lblMagicPoints"
        Me.lblMagicPoints.Size = New System.Drawing.Size(76, 15)
        Me.lblMagicPoints.TabIndex = 8
        Me.lblMagicPoints.Text = "Magic Points"
        '
        'lblStaminaPoints
        '
        Me.lblStaminaPoints.AutoSize = True
        Me.lblStaminaPoints.Location = New System.Drawing.Point(74, 98)
        Me.lblStaminaPoints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStaminaPoints.Name = "lblStaminaPoints"
        Me.lblStaminaPoints.Size = New System.Drawing.Size(86, 15)
        Me.lblStaminaPoints.TabIndex = 8
        Me.lblStaminaPoints.Text = "Stamina Points"
        '
        'lblHealthPoints
        '
        Me.lblHealthPoints.AutoSize = True
        Me.lblHealthPoints.Location = New System.Drawing.Point(74, 74)
        Me.lblHealthPoints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHealthPoints.Name = "lblHealthPoints"
        Me.lblHealthPoints.Size = New System.Drawing.Size(78, 15)
        Me.lblHealthPoints.TabIndex = 8
        Me.lblHealthPoints.Text = "Health Points"
        '
        'numPuzzlePoints
        '
        Me.numPuzzlePoints.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numPuzzlePoints.Location = New System.Drawing.Point(7, 18)
        Me.numPuzzlePoints.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numPuzzlePoints.Name = "numPuzzlePoints"
        Me.numPuzzlePoints.Size = New System.Drawing.Size(61, 23)
        Me.numPuzzlePoints.TabIndex = 0
        Me.numPuzzlePoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numPuzzlePoints, "Only available in QFG1 and QFG2")
        '
        'numMagicPoints
        '
        Me.numMagicPoints.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numMagicPoints.Location = New System.Drawing.Point(7, 120)
        Me.numMagicPoints.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numMagicPoints.Name = "numMagicPoints"
        Me.numMagicPoints.Size = New System.Drawing.Size(61, 23)
        Me.numMagicPoints.TabIndex = 4
        Me.numMagicPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numStaminaPoints
        '
        Me.numStaminaPoints.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numStaminaPoints.Location = New System.Drawing.Point(7, 96)
        Me.numStaminaPoints.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numStaminaPoints.Name = "numStaminaPoints"
        Me.numStaminaPoints.Size = New System.Drawing.Size(61, 23)
        Me.numStaminaPoints.TabIndex = 3
        Me.numStaminaPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numHealthPoints
        '
        Me.numHealthPoints.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numHealthPoints.Location = New System.Drawing.Point(7, 72)
        Me.numHealthPoints.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numHealthPoints.Name = "numHealthPoints"
        Me.numHealthPoints.Size = New System.Drawing.Size(61, 23)
        Me.numHealthPoints.TabIndex = 2
        Me.numHealthPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 10)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(42, 15)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(54, 7)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(312, 23)
        Me.txtName.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabCharacter)
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(754, 662)
        Me.TabControl1.TabIndex = 9
        '
        'tabCharacter
        '
        Me.tabCharacter.Controls.Add(Me.picWarning)
        Me.tabCharacter.Controls.Add(Me.btnFix)
        Me.tabCharacter.Controls.Add(Me.lblOverflowError)
        Me.tabCharacter.Controls.Add(Me.picCover)
        Me.tabCharacter.Controls.Add(Me.grpInventory)
        Me.tabCharacter.Controls.Add(Me.grpUniqueInventory)
        Me.tabCharacter.Controls.Add(Me.grpClass)
        Me.tabCharacter.Controls.Add(Me.grpSkills)
        Me.tabCharacter.Controls.Add(Me.txtName)
        Me.tabCharacter.Controls.Add(Me.grpSpells)
        Me.tabCharacter.Controls.Add(Me.lblName)
        Me.tabCharacter.Controls.Add(Me.grpAbilities)
        Me.tabCharacter.Controls.Add(Me.grpOther)
        Me.tabCharacter.Location = New System.Drawing.Point(4, 24)
        Me.tabCharacter.Name = "tabCharacter"
        Me.tabCharacter.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCharacter.Size = New System.Drawing.Size(746, 634)
        Me.tabCharacter.TabIndex = 0
        Me.tabCharacter.Text = "Character Sheet"
        Me.tabCharacter.UseVisualStyleBackColor = True
        '
        'picWarning
        '
        Me.picWarning.Location = New System.Drawing.Point(85, 607)
        Me.picWarning.Name = "picWarning"
        Me.picWarning.Size = New System.Drawing.Size(24, 24)
        Me.picWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picWarning.TabIndex = 10
        Me.picWarning.TabStop = False
        Me.picWarning.Visible = False
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(6, 608)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 23)
        Me.btnFix.TabIndex = 9
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        Me.btnFix.Visible = False
        '
        'lblOverflowError
        '
        Me.lblOverflowError.AutoSize = True
        Me.lblOverflowError.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblOverflowError.Location = New System.Drawing.Point(109, 613)
        Me.lblOverflowError.Name = "lblOverflowError"
        Me.lblOverflowError.Size = New System.Drawing.Size(579, 13)
        Me.lblOverflowError.TabIndex = 8
        Me.lblOverflowError.Text = "Warning: This exported character contains an overflow error, which may cause prob" &
    "lems when trying to import."
        Me.lblOverflowError.Visible = False
        '
        'picCover
        '
        Me.picCover.Location = New System.Drawing.Point(7, 37)
        Me.picCover.Name = "picCover"
        Me.picCover.Size = New System.Drawing.Size(200, 249)
        Me.picCover.TabIndex = 6
        Me.picCover.TabStop = False
        '
        'grpInventory
        '
        Me.grpInventory.Controls.Add(Me.lblOilFlasks)
        Me.grpInventory.Controls.Add(Me.lblRations)
        Me.grpInventory.Controls.Add(Me.lblPoisonCurePills)
        Me.grpInventory.Controls.Add(Me.lblUndeadUnguent)
        Me.grpInventory.Controls.Add(Me.lblMagicPotions)
        Me.grpInventory.Controls.Add(Me.lblVigorPotions)
        Me.grpInventory.Controls.Add(Me.lblHealingPotions)
        Me.grpInventory.Controls.Add(Me.lblDaggers)
        Me.grpInventory.Controls.Add(Me.numOilFlasks)
        Me.grpInventory.Controls.Add(Me.numRations)
        Me.grpInventory.Controls.Add(Me.numPoisonCurePills)
        Me.grpInventory.Controls.Add(Me.numUndeadUnguent)
        Me.grpInventory.Controls.Add(Me.numMagicPotions)
        Me.grpInventory.Controls.Add(Me.lblCurrency)
        Me.grpInventory.Controls.Add(Me.numGold)
        Me.grpInventory.Controls.Add(Me.numVigorPotions)
        Me.grpInventory.Controls.Add(Me.numHealingPotions)
        Me.grpInventory.Controls.Add(Me.numDaggers)
        Me.grpInventory.Location = New System.Drawing.Point(372, 3)
        Me.grpInventory.Name = "grpInventory"
        Me.grpInventory.Size = New System.Drawing.Size(182, 290)
        Me.grpInventory.TabIndex = 6
        Me.grpInventory.TabStop = False
        Me.grpInventory.Text = "Inventory"
        '
        'lblOilFlasks
        '
        Me.lblOilFlasks.AutoSize = True
        Me.lblOilFlasks.Location = New System.Drawing.Point(74, 209)
        Me.lblOilFlasks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOilFlasks.Name = "lblOilFlasks"
        Me.lblOilFlasks.Size = New System.Drawing.Size(56, 15)
        Me.lblOilFlasks.TabIndex = 1
        Me.lblOilFlasks.Text = "Oil Flasks"
        '
        'lblRations
        '
        Me.lblRations.AutoSize = True
        Me.lblRations.Location = New System.Drawing.Point(74, 236)
        Me.lblRations.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRations.Name = "lblRations"
        Me.lblRations.Size = New System.Drawing.Size(46, 15)
        Me.lblRations.TabIndex = 1
        Me.lblRations.Text = "Rations"
        '
        'lblPoisonCurePills
        '
        Me.lblPoisonCurePills.AutoSize = True
        Me.lblPoisonCurePills.Location = New System.Drawing.Point(74, 183)
        Me.lblPoisonCurePills.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPoisonCurePills.Name = "lblPoisonCurePills"
        Me.lblPoisonCurePills.Size = New System.Drawing.Size(95, 15)
        Me.lblPoisonCurePills.TabIndex = 1
        Me.lblPoisonCurePills.Text = "Poison Cure Pills"
        '
        'lblUndeadUnguent
        '
        Me.lblUndeadUnguent.AutoSize = True
        Me.lblUndeadUnguent.Location = New System.Drawing.Point(74, 155)
        Me.lblUndeadUnguent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUndeadUnguent.Name = "lblUndeadUnguent"
        Me.lblUndeadUnguent.Size = New System.Drawing.Size(97, 15)
        Me.lblUndeadUnguent.TabIndex = 1
        Me.lblUndeadUnguent.Text = "Undead Unguent"
        '
        'lblMagicPotions
        '
        Me.lblMagicPotions.AutoSize = True
        Me.lblMagicPotions.Location = New System.Drawing.Point(74, 101)
        Me.lblMagicPotions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMagicPotions.Name = "lblMagicPotions"
        Me.lblMagicPotions.Size = New System.Drawing.Size(83, 15)
        Me.lblMagicPotions.TabIndex = 1
        Me.lblMagicPotions.Text = "Magic Potions"
        '
        'lblVigorPotions
        '
        Me.lblVigorPotions.AutoSize = True
        Me.lblVigorPotions.Location = New System.Drawing.Point(74, 128)
        Me.lblVigorPotions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVigorPotions.Name = "lblVigorPotions"
        Me.lblVigorPotions.Size = New System.Drawing.Size(78, 15)
        Me.lblVigorPotions.TabIndex = 1
        Me.lblVigorPotions.Text = "Vigor Potions"
        '
        'lblHealingPotions
        '
        Me.lblHealingPotions.AutoSize = True
        Me.lblHealingPotions.Location = New System.Drawing.Point(74, 74)
        Me.lblHealingPotions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHealingPotions.Name = "lblHealingPotions"
        Me.lblHealingPotions.Size = New System.Drawing.Size(91, 15)
        Me.lblHealingPotions.TabIndex = 1
        Me.lblHealingPotions.Text = "Healing Potions"
        '
        'lblDaggers
        '
        Me.lblDaggers.AutoSize = True
        Me.lblDaggers.Location = New System.Drawing.Point(74, 47)
        Me.lblDaggers.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDaggers.Name = "lblDaggers"
        Me.lblDaggers.Size = New System.Drawing.Size(50, 15)
        Me.lblDaggers.TabIndex = 1
        Me.lblDaggers.Text = "Daggers"
        '
        'numOilFlasks
        '
        Me.numOilFlasks.Location = New System.Drawing.Point(7, 207)
        Me.numOilFlasks.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numOilFlasks.Name = "numOilFlasks"
        Me.numOilFlasks.Size = New System.Drawing.Size(61, 23)
        Me.numOilFlasks.TabIndex = 5
        Me.numOilFlasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numOilFlasks, "Only available in QFG3 and QFG4")
        '
        'numRations
        '
        Me.numRations.Location = New System.Drawing.Point(7, 234)
        Me.numRations.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numRations.Name = "numRations"
        Me.numRations.Size = New System.Drawing.Size(61, 23)
        Me.numRations.TabIndex = 5
        Me.numRations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numRations, "Only available in QFG3 and QFG4")
        '
        'numPoisonCurePills
        '
        Me.numPoisonCurePills.Location = New System.Drawing.Point(7, 180)
        Me.numPoisonCurePills.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numPoisonCurePills.Name = "numPoisonCurePills"
        Me.numPoisonCurePills.Size = New System.Drawing.Size(61, 23)
        Me.numPoisonCurePills.TabIndex = 5
        Me.numPoisonCurePills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numPoisonCurePills, "Only available in QFG2, QFG3, and QFG4")
        '
        'numUndeadUnguent
        '
        Me.numUndeadUnguent.Location = New System.Drawing.Point(7, 153)
        Me.numUndeadUnguent.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numUndeadUnguent.Name = "numUndeadUnguent"
        Me.numUndeadUnguent.Size = New System.Drawing.Size(61, 23)
        Me.numUndeadUnguent.TabIndex = 5
        Me.numUndeadUnguent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numUndeadUnguent, "Only available in QFG1")
        '
        'numMagicPotions
        '
        Me.numMagicPotions.Location = New System.Drawing.Point(7, 99)
        Me.numMagicPotions.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numMagicPotions.Name = "numMagicPotions"
        Me.numMagicPotions.Size = New System.Drawing.Size(61, 23)
        Me.numMagicPotions.TabIndex = 3
        Me.numMagicPotions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCurrency
        '
        Me.lblCurrency.Location = New System.Drawing.Point(74, 20)
        Me.lblCurrency.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(55, 15)
        Me.lblCurrency.TabIndex = 1
        Me.lblCurrency.Text = "Currency"
        '
        'numGold
        '
        Me.numGold.Location = New System.Drawing.Point(7, 17)
        Me.numGold.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGold.Name = "numGold"
        Me.numGold.Size = New System.Drawing.Size(61, 23)
        Me.numGold.TabIndex = 0
        Me.numGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numVigorPotions
        '
        Me.numVigorPotions.Location = New System.Drawing.Point(7, 126)
        Me.numVigorPotions.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numVigorPotions.Name = "numVigorPotions"
        Me.numVigorPotions.Size = New System.Drawing.Size(61, 23)
        Me.numVigorPotions.TabIndex = 4
        Me.numVigorPotions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.numVigorPotions, "Only available in QFG1 and QFG2")
        '
        'numHealingPotions
        '
        Me.numHealingPotions.Location = New System.Drawing.Point(7, 72)
        Me.numHealingPotions.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numHealingPotions.Name = "numHealingPotions"
        Me.numHealingPotions.Size = New System.Drawing.Size(61, 23)
        Me.numHealingPotions.TabIndex = 2
        Me.numHealingPotions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDaggers
        '
        Me.numDaggers.Location = New System.Drawing.Point(7, 44)
        Me.numDaggers.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
        Me.numDaggers.Name = "numDaggers"
        Me.numDaggers.Size = New System.Drawing.Size(61, 23)
        Me.numDaggers.TabIndex = 1
        Me.numDaggers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpUniqueInventory
        '
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag16)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag8)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag15)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag7)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag14)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag6)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag13)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag5)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag12)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag4)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag3)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag2)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag1)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag11)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag10)
        Me.grpUniqueInventory.Controls.Add(Me.chkFlag9)
        Me.grpUniqueInventory.Location = New System.Drawing.Point(560, 3)
        Me.grpUniqueInventory.Name = "grpUniqueInventory"
        Me.grpUniqueInventory.Size = New System.Drawing.Size(178, 290)
        Me.grpUniqueInventory.TabIndex = 7
        Me.grpUniqueInventory.TabStop = False
        Me.grpUniqueInventory.Text = "Unique Inventory"
        '
        'chkFlag16
        '
        Me.chkFlag16.AutoSize = True
        Me.chkFlag16.Enabled = False
        Me.chkFlag16.Location = New System.Drawing.Point(6, 264)
        Me.chkFlag16.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag16.Name = "chkFlag16"
        Me.chkFlag16.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag16.TabIndex = 6
        Me.chkFlag16.Text = "Flag16"
        Me.chkFlag16.UseVisualStyleBackColor = True
        '
        'chkFlag8
        '
        Me.chkFlag8.AutoSize = True
        Me.chkFlag8.Enabled = False
        Me.chkFlag8.Location = New System.Drawing.Point(6, 129)
        Me.chkFlag8.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag8.Name = "chkFlag8"
        Me.chkFlag8.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag8.TabIndex = 6
        Me.chkFlag8.Text = "Flag8"
        Me.chkFlag8.UseVisualStyleBackColor = True
        '
        'chkFlag15
        '
        Me.chkFlag15.AutoSize = True
        Me.chkFlag15.Location = New System.Drawing.Point(6, 248)
        Me.chkFlag15.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag15.Name = "chkFlag15"
        Me.chkFlag15.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag15.TabIndex = 6
        Me.chkFlag15.Text = "Flag15"
        Me.chkFlag15.UseVisualStyleBackColor = True
        '
        'chkFlag7
        '
        Me.chkFlag7.AutoSize = True
        Me.chkFlag7.Location = New System.Drawing.Point(6, 113)
        Me.chkFlag7.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag7.Name = "chkFlag7"
        Me.chkFlag7.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag7.TabIndex = 6
        Me.chkFlag7.Text = "Flag7"
        Me.chkFlag7.UseVisualStyleBackColor = True
        '
        'chkFlag14
        '
        Me.chkFlag14.AutoSize = True
        Me.chkFlag14.Location = New System.Drawing.Point(6, 232)
        Me.chkFlag14.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag14.Name = "chkFlag14"
        Me.chkFlag14.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag14.TabIndex = 5
        Me.chkFlag14.Text = "Flag14"
        Me.chkFlag14.UseVisualStyleBackColor = True
        '
        'chkFlag6
        '
        Me.chkFlag6.AutoSize = True
        Me.chkFlag6.Location = New System.Drawing.Point(6, 97)
        Me.chkFlag6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag6.Name = "chkFlag6"
        Me.chkFlag6.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag6.TabIndex = 5
        Me.chkFlag6.Text = "Flag6"
        Me.chkFlag6.UseVisualStyleBackColor = True
        '
        'chkFlag13
        '
        Me.chkFlag13.AutoSize = True
        Me.chkFlag13.Location = New System.Drawing.Point(6, 216)
        Me.chkFlag13.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag13.Name = "chkFlag13"
        Me.chkFlag13.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag13.TabIndex = 4
        Me.chkFlag13.Text = "Flag13"
        Me.chkFlag13.UseVisualStyleBackColor = True
        '
        'chkFlag5
        '
        Me.chkFlag5.AutoSize = True
        Me.chkFlag5.Location = New System.Drawing.Point(6, 81)
        Me.chkFlag5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag5.Name = "chkFlag5"
        Me.chkFlag5.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag5.TabIndex = 4
        Me.chkFlag5.Text = "Flag5"
        Me.chkFlag5.UseVisualStyleBackColor = True
        '
        'chkFlag12
        '
        Me.chkFlag12.AutoSize = True
        Me.chkFlag12.Location = New System.Drawing.Point(6, 200)
        Me.chkFlag12.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag12.Name = "chkFlag12"
        Me.chkFlag12.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag12.TabIndex = 3
        Me.chkFlag12.Text = "Flag12"
        Me.chkFlag12.UseVisualStyleBackColor = True
        '
        'chkFlag4
        '
        Me.chkFlag4.AutoSize = True
        Me.chkFlag4.Location = New System.Drawing.Point(6, 65)
        Me.chkFlag4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag4.Name = "chkFlag4"
        Me.chkFlag4.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag4.TabIndex = 3
        Me.chkFlag4.Text = "Flag4"
        Me.chkFlag4.UseVisualStyleBackColor = True
        '
        'chkFlag3
        '
        Me.chkFlag3.AutoSize = True
        Me.chkFlag3.Location = New System.Drawing.Point(6, 49)
        Me.chkFlag3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag3.Name = "chkFlag3"
        Me.chkFlag3.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag3.TabIndex = 2
        Me.chkFlag3.Text = "Flag3"
        Me.chkFlag3.UseVisualStyleBackColor = True
        '
        'chkFlag2
        '
        Me.chkFlag2.AutoSize = True
        Me.chkFlag2.Location = New System.Drawing.Point(6, 33)
        Me.chkFlag2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag2.Name = "chkFlag2"
        Me.chkFlag2.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag2.TabIndex = 1
        Me.chkFlag2.Text = "Flag2"
        Me.chkFlag2.UseVisualStyleBackColor = True
        '
        'chkFlag1
        '
        Me.chkFlag1.AutoSize = True
        Me.chkFlag1.Location = New System.Drawing.Point(6, 17)
        Me.chkFlag1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag1.Name = "chkFlag1"
        Me.chkFlag1.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag1.TabIndex = 0
        Me.chkFlag1.Text = "Flag1"
        Me.chkFlag1.UseVisualStyleBackColor = True
        '
        'chkFlag11
        '
        Me.chkFlag11.AutoSize = True
        Me.chkFlag11.Location = New System.Drawing.Point(6, 184)
        Me.chkFlag11.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag11.Name = "chkFlag11"
        Me.chkFlag11.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag11.TabIndex = 2
        Me.chkFlag11.Text = "Flag11"
        Me.chkFlag11.UseVisualStyleBackColor = True
        '
        'chkFlag10
        '
        Me.chkFlag10.AutoSize = True
        Me.chkFlag10.Location = New System.Drawing.Point(6, 168)
        Me.chkFlag10.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag10.Name = "chkFlag10"
        Me.chkFlag10.Size = New System.Drawing.Size(60, 19)
        Me.chkFlag10.TabIndex = 1
        Me.chkFlag10.Text = "Flag10"
        Me.chkFlag10.UseVisualStyleBackColor = True
        '
        'chkFlag9
        '
        Me.chkFlag9.AutoSize = True
        Me.chkFlag9.Location = New System.Drawing.Point(6, 152)
        Me.chkFlag9.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkFlag9.Name = "chkFlag9"
        Me.chkFlag9.Size = New System.Drawing.Size(54, 19)
        Me.chkFlag9.TabIndex = 0
        Me.chkFlag9.Text = "Flag9"
        Me.chkFlag9.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save As..."
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'CharacterEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 715)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "CharacterEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "QFG Importer"
        Me.grpClass.ResumeLayout(False)
        Me.grpClass.PerformLayout()
        Me.grpSkills.ResumeLayout(False)
        Me.grpSkills.PerformLayout()
        CType(Me.numHonor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMagic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAcrobatics, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numClimbing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCommunication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numThrowing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPickLocks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStealth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDodge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numParry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWeaponUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numExperience, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLuck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVitality, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAgility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIntelligence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStrength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSpells.ResumeLayout(False)
        Me.grpSpells.PerformLayout()
        CType(Me.numOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLightningBall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPaladinHealingSpell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDetectMagic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTrigger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDazzle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numZap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCalm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numProtection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJugglingLights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numForceBolt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFlameDart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFrostBite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGlide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSummonStaff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRitualOfRelease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numResistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numReversal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLevitation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFetch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAbilities.ResumeLayout(False)
        Me.grpAbilities.PerformLayout()
        Me.grpOther.ResumeLayout(False)
        Me.grpOther.PerformLayout()
        CType(Me.numPuzzlePoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMagicPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStaminaPoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHealthPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabCharacter.ResumeLayout(False)
        Me.tabCharacter.PerformLayout()
        CType(Me.picWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInventory.ResumeLayout(False)
        Me.grpInventory.PerformLayout()
        CType(Me.numOilFlasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPoisonCurePills, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUndeadUnguent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMagicPotions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVigorPotions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHealingPotions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDaggers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUniqueInventory.ResumeLayout(False)
        Me.grpUniqueInventory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpClass As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPaladin As System.Windows.Forms.RadioButton
    Friend WithEvents rdoThief As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWizard As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFighter As System.Windows.Forms.RadioButton
    Friend WithEvents grpSkills As System.Windows.Forms.GroupBox
    Friend WithEvents lblLuck As System.Windows.Forms.Label
    Friend WithEvents lblVitality As System.Windows.Forms.Label
    Friend WithEvents lblAgility As System.Windows.Forms.Label
    Friend WithEvents lblIntelligence As System.Windows.Forms.Label
    Friend WithEvents lblStrength As System.Windows.Forms.Label
    Friend WithEvents numLuck As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVitality As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAgility As System.Windows.Forms.NumericUpDown
    Friend WithEvents numIntelligence As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStrength As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAcrobatics As System.Windows.Forms.Label
    Friend WithEvents lblCommunication As System.Windows.Forms.Label
    Friend WithEvents lblHonor As System.Windows.Forms.Label
    Friend WithEvents numAcrobatics As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCommunication As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHonor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMagic As System.Windows.Forms.Label
    Friend WithEvents lblExperience As System.Windows.Forms.Label
    Friend WithEvents lblClimbing As System.Windows.Forms.Label
    Friend WithEvents lblThrowing As System.Windows.Forms.Label
    Friend WithEvents lblPickLocks As System.Windows.Forms.Label
    Friend WithEvents lblStealth As System.Windows.Forms.Label
    Friend WithEvents lblDodge As System.Windows.Forms.Label
    Friend WithEvents lblParry As System.Windows.Forms.Label
    Friend WithEvents lblWeaponUse As System.Windows.Forms.Label
    Friend WithEvents numMagic As System.Windows.Forms.NumericUpDown
    Friend WithEvents numExperience As System.Windows.Forms.NumericUpDown
    Friend WithEvents numClimbing As System.Windows.Forms.NumericUpDown
    Friend WithEvents numThrowing As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPickLocks As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStealth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDodge As System.Windows.Forms.NumericUpDown
    Friend WithEvents numParry As System.Windows.Forms.NumericUpDown
    Friend WithEvents numWeaponUse As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpSpells As System.Windows.Forms.GroupBox
    Friend WithEvents grpAbilities As System.Windows.Forms.GroupBox
    Friend WithEvents grpOther As System.Windows.Forms.GroupBox
    Friend WithEvents lblFetch As System.Windows.Forms.Label
    Friend WithEvents numOpen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblReversal As System.Windows.Forms.Label
    Friend WithEvents lblLevitation As System.Windows.Forms.Label
    Friend WithEvents numDetectMagic As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFlameDart As System.Windows.Forms.Label
    Friend WithEvents numTrigger As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblForceBolt As System.Windows.Forms.Label
    Friend WithEvents numDazzle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCalm As System.Windows.Forms.Label
    Friend WithEvents numZap As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblZap As System.Windows.Forms.Label
    Friend WithEvents numCalm As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDazzle As System.Windows.Forms.Label
    Friend WithEvents numForceBolt As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTrigger As System.Windows.Forms.Label
    Friend WithEvents numFlameDart As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDetectMagic As System.Windows.Forms.Label
    Friend WithEvents numReversal As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLevitation As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOpen As System.Windows.Forms.Label
    Friend WithEvents numFetch As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSummonStaff As System.Windows.Forms.Label
    Friend WithEvents lblLightningBall As System.Windows.Forms.Label
    Friend WithEvents lblJugglingLights As System.Windows.Forms.Label
    Friend WithEvents numJugglingLights As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSummonStaff As System.Windows.Forms.NumericUpDown
    Friend WithEvents numLightningBall As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabCharacter As System.Windows.Forms.TabPage
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblFrostBite As System.Windows.Forms.Label
    Friend WithEvents lblGlide As System.Windows.Forms.Label
    Friend WithEvents lblHide As System.Windows.Forms.Label
    Friend WithEvents lblResistance As System.Windows.Forms.Label
    Friend WithEvents lblAura As System.Windows.Forms.Label
    Friend WithEvents lblProtection As System.Windows.Forms.Label
    Friend WithEvents numProtection As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFrostBite As System.Windows.Forms.NumericUpDown
    Friend WithEvents numGlide As System.Windows.Forms.NumericUpDown
    Friend WithEvents numResistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAura As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHide As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpUniqueInventory As System.Windows.Forms.GroupBox
    Friend WithEvents chkFlag2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents numGold As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkFlag3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag4 As System.Windows.Forms.CheckBox
    Friend WithEvents grpInventory As System.Windows.Forms.GroupBox
    Friend WithEvents lblUndeadUnguent As System.Windows.Forms.Label
    Friend WithEvents lblMagicPotions As System.Windows.Forms.Label
    Friend WithEvents lblVigorPotions As System.Windows.Forms.Label
    Friend WithEvents lblHealingPotions As System.Windows.Forms.Label
    Friend WithEvents lblDaggers As System.Windows.Forms.Label
    Friend WithEvents numUndeadUnguent As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMagicPotions As System.Windows.Forms.NumericUpDown
    Friend WithEvents numVigorPotions As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHealingPotions As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDaggers As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMagicPoints As System.Windows.Forms.Label
    Friend WithEvents lblStaminaPoints As System.Windows.Forms.Label
    Friend WithEvents lblHealthPoints As System.Windows.Forms.Label
    Friend WithEvents numMagicPoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStaminaPoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHealthPoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkFlag6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag5 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPuzzlePoints As System.Windows.Forms.Label
    Friend WithEvents numPuzzlePoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkFlag7 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag8 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag11 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag16 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag15 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag14 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag13 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag12 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag10 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFlag9 As System.Windows.Forms.CheckBox
    Friend WithEvents lblOilFlasks As System.Windows.Forms.Label
    Friend WithEvents lblRations As System.Windows.Forms.Label
    Friend WithEvents lblPaladinHealingSpell As System.Windows.Forms.Label
    Friend WithEvents lblPoisonCurePills As System.Windows.Forms.Label
    Friend WithEvents numOilFlasks As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRations As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPaladinHealingSpell As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPoisonCurePills As System.Windows.Forms.NumericUpDown
    Friend WithEvents picCover As System.Windows.Forms.PictureBox
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents lblOverflowError As System.Windows.Forms.Label
    Friend WithEvents lblRitualOfRelease As System.Windows.Forms.Label
    Friend WithEvents numRitualOfRelease As System.Windows.Forms.NumericUpDown
    Friend WithEvents picWarning As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
