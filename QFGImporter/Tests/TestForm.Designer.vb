<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.QFG1Fighter = New System.Windows.Forms.RadioButton()
        Me.QFG1Wizard = New System.Windows.Forms.RadioButton()
        Me.QFG1Thief = New System.Windows.Forms.RadioButton()
        Me.QFG1FighterHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG1WizardHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG1ThiefHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG1FighterA = New System.Windows.Forms.RadioButton()
        Me.QFG1WizardA = New System.Windows.Forms.RadioButton()
        Me.QFG1ThiefA = New System.Windows.Forms.RadioButton()
        Me.QFG1FighterB = New System.Windows.Forms.RadioButton()
        Me.QFG1WizardB = New System.Windows.Forms.RadioButton()
        Me.QFG1ThiefB = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.QFG2Fighter = New System.Windows.Forms.RadioButton()
        Me.QFG2FighterA = New System.Windows.Forms.RadioButton()
        Me.QFG2FighterB = New System.Windows.Forms.RadioButton()
        Me.QFG2Wizard = New System.Windows.Forms.RadioButton()
        Me.QFG2WizardA = New System.Windows.Forms.RadioButton()
        Me.QFG2WizardB = New System.Windows.Forms.RadioButton()
        Me.QFG2Thief = New System.Windows.Forms.RadioButton()
        Me.QFG2ThiefA = New System.Windows.Forms.RadioButton()
        Me.QFG2ThiefB = New System.Windows.Forms.RadioButton()
        Me.QFG2FighterHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG2WizardHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG2ThiefHybrid = New System.Windows.Forms.RadioButton()
        Me.QFG2Paladin = New System.Windows.Forms.RadioButton()
        Me.QFG2PaladinA = New System.Windows.Forms.RadioButton()
        Me.QFG2PaladinB = New System.Windows.Forms.RadioButton()
        Me.QFG3Fighter = New System.Windows.Forms.RadioButton()
        Me.QFG3Wizard = New System.Windows.Forms.RadioButton()
        Me.QFG3Thief = New System.Windows.Forms.RadioButton()
        Me.QFG3Paladin = New System.Windows.Forms.RadioButton()
        Me.QFG3FighterA = New System.Windows.Forms.RadioButton()
        Me.QFG3ThiefA = New System.Windows.Forms.RadioButton()
        Me.QFG3PaladinA = New System.Windows.Forms.RadioButton()
        Me.QFG4Fighter = New System.Windows.Forms.RadioButton()
        Me.QFG4Wizard = New System.Windows.Forms.RadioButton()
        Me.QFG4Thief = New System.Windows.Forms.RadioButton()
        Me.QFG4Paladin = New System.Windows.Forms.RadioButton()
        Me.btnSaveAs = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(332, 431)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select a Test File to Load:"
        '
        'QFG1Fighter
        '
        Me.QFG1Fighter.AutoSize = True
        Me.QFG1Fighter.Checked = True
        Me.QFG1Fighter.Location = New System.Drawing.Point(136, 16)
        Me.QFG1Fighter.Name = "QFG1Fighter"
        Me.QFG1Fighter.Size = New System.Drawing.Size(94, 17)
        Me.QFG1Fighter.TabIndex = 2
        Me.QFG1Fighter.TabStop = True
        Me.QFG1Fighter.Text = "QFG1 - Fighter"
        Me.QFG1Fighter.UseVisualStyleBackColor = True
        '
        'QFG1Wizard
        '
        Me.QFG1Wizard.AutoSize = True
        Me.QFG1Wizard.Location = New System.Drawing.Point(136, 39)
        Me.QFG1Wizard.Name = "QFG1Wizard"
        Me.QFG1Wizard.Size = New System.Drawing.Size(95, 17)
        Me.QFG1Wizard.TabIndex = 3
        Me.QFG1Wizard.Text = "QFG1 - Wizard"
        Me.QFG1Wizard.UseVisualStyleBackColor = True
        '
        'QFG1Thief
        '
        Me.QFG1Thief.AutoSize = True
        Me.QFG1Thief.Location = New System.Drawing.Point(136, 62)
        Me.QFG1Thief.Name = "QFG1Thief"
        Me.QFG1Thief.Size = New System.Drawing.Size(86, 17)
        Me.QFG1Thief.TabIndex = 4
        Me.QFG1Thief.Text = "QFG1 - Thief"
        Me.QFG1Thief.UseVisualStyleBackColor = True
        '
        'QFG1FighterHybrid
        '
        Me.QFG1FighterHybrid.AutoSize = True
        Me.QFG1FighterHybrid.Location = New System.Drawing.Point(3, 16)
        Me.QFG1FighterHybrid.Name = "QFG1FighterHybrid"
        Me.QFG1FighterHybrid.Size = New System.Drawing.Size(127, 17)
        Me.QFG1FighterHybrid.TabIndex = 5
        Me.QFG1FighterHybrid.Text = "QFG1 - Fighter Hybrid"
        Me.QFG1FighterHybrid.UseVisualStyleBackColor = True
        '
        'QFG1WizardHybrid
        '
        Me.QFG1WizardHybrid.AutoSize = True
        Me.QFG1WizardHybrid.Location = New System.Drawing.Point(3, 39)
        Me.QFG1WizardHybrid.Name = "QFG1WizardHybrid"
        Me.QFG1WizardHybrid.Size = New System.Drawing.Size(128, 17)
        Me.QFG1WizardHybrid.TabIndex = 6
        Me.QFG1WizardHybrid.Text = "QFG1 - Wizard Hybrid"
        Me.QFG1WizardHybrid.UseVisualStyleBackColor = True
        '
        'QFG1ThiefHybrid
        '
        Me.QFG1ThiefHybrid.AutoSize = True
        Me.QFG1ThiefHybrid.Location = New System.Drawing.Point(3, 62)
        Me.QFG1ThiefHybrid.Name = "QFG1ThiefHybrid"
        Me.QFG1ThiefHybrid.Size = New System.Drawing.Size(119, 17)
        Me.QFG1ThiefHybrid.TabIndex = 7
        Me.QFG1ThiefHybrid.Text = "QFG1 - Thief Hybrid"
        Me.QFG1ThiefHybrid.UseVisualStyleBackColor = True
        '
        'QFG1FighterA
        '
        Me.QFG1FighterA.AutoSize = True
        Me.QFG1FighterA.Location = New System.Drawing.Point(236, 16)
        Me.QFG1FighterA.Name = "QFG1FighterA"
        Me.QFG1FighterA.Size = New System.Drawing.Size(110, 17)
        Me.QFG1FighterA.TabIndex = 2
        Me.QFG1FighterA.Text = "QFG1 - Fighter (A)"
        Me.QFG1FighterA.UseVisualStyleBackColor = True
        '
        'QFG1WizardA
        '
        Me.QFG1WizardA.AutoSize = True
        Me.QFG1WizardA.Location = New System.Drawing.Point(236, 39)
        Me.QFG1WizardA.Name = "QFG1WizardA"
        Me.QFG1WizardA.Size = New System.Drawing.Size(111, 17)
        Me.QFG1WizardA.TabIndex = 3
        Me.QFG1WizardA.Text = "QFG1 - Wizard (A)"
        Me.QFG1WizardA.UseVisualStyleBackColor = True
        '
        'QFG1ThiefA
        '
        Me.QFG1ThiefA.AutoSize = True
        Me.QFG1ThiefA.Location = New System.Drawing.Point(236, 62)
        Me.QFG1ThiefA.Name = "QFG1ThiefA"
        Me.QFG1ThiefA.Size = New System.Drawing.Size(102, 17)
        Me.QFG1ThiefA.TabIndex = 4
        Me.QFG1ThiefA.Text = "QFG1 - Thief (A)"
        Me.QFG1ThiefA.UseVisualStyleBackColor = True
        '
        'QFG1FighterB
        '
        Me.QFG1FighterB.AutoSize = True
        Me.QFG1FighterB.Location = New System.Drawing.Point(352, 16)
        Me.QFG1FighterB.Name = "QFG1FighterB"
        Me.QFG1FighterB.Size = New System.Drawing.Size(110, 17)
        Me.QFG1FighterB.TabIndex = 2
        Me.QFG1FighterB.Text = "QFG1 - Fighter (B)"
        Me.QFG1FighterB.UseVisualStyleBackColor = True
        '
        'QFG1WizardB
        '
        Me.QFG1WizardB.AutoSize = True
        Me.QFG1WizardB.Location = New System.Drawing.Point(352, 39)
        Me.QFG1WizardB.Name = "QFG1WizardB"
        Me.QFG1WizardB.Size = New System.Drawing.Size(111, 17)
        Me.QFG1WizardB.TabIndex = 3
        Me.QFG1WizardB.Text = "QFG1 - Wizard (B)"
        Me.QFG1WizardB.UseVisualStyleBackColor = True
        '
        'QFG1ThiefB
        '
        Me.QFG1ThiefB.AutoSize = True
        Me.QFG1ThiefB.Location = New System.Drawing.Point(352, 62)
        Me.QFG1ThiefB.Name = "QFG1ThiefB"
        Me.QFG1ThiefB.Size = New System.Drawing.Size(102, 17)
        Me.QFG1ThiefB.TabIndex = 4
        Me.QFG1ThiefB.Text = "QFG1 - Thief (B)"
        Me.QFG1ThiefB.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(173, 434)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Test QFG1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'QFG2Fighter
        '
        Me.QFG2Fighter.AutoSize = True
        Me.QFG2Fighter.Location = New System.Drawing.Point(136, 100)
        Me.QFG2Fighter.Name = "QFG2Fighter"
        Me.QFG2Fighter.Size = New System.Drawing.Size(94, 17)
        Me.QFG2Fighter.TabIndex = 2
        Me.QFG2Fighter.Text = "QFG2 - Fighter"
        Me.QFG2Fighter.UseVisualStyleBackColor = True
        '
        'QFG2FighterA
        '
        Me.QFG2FighterA.AutoSize = True
        Me.QFG2FighterA.Location = New System.Drawing.Point(236, 100)
        Me.QFG2FighterA.Name = "QFG2FighterA"
        Me.QFG2FighterA.Size = New System.Drawing.Size(110, 17)
        Me.QFG2FighterA.TabIndex = 2
        Me.QFG2FighterA.Text = "QFG2 - Fighter (A)"
        Me.QFG2FighterA.UseVisualStyleBackColor = True
        '
        'QFG2FighterB
        '
        Me.QFG2FighterB.AutoSize = True
        Me.QFG2FighterB.Location = New System.Drawing.Point(352, 100)
        Me.QFG2FighterB.Name = "QFG2FighterB"
        Me.QFG2FighterB.Size = New System.Drawing.Size(110, 17)
        Me.QFG2FighterB.TabIndex = 2
        Me.QFG2FighterB.Text = "QFG2 - Fighter (B)"
        Me.QFG2FighterB.UseVisualStyleBackColor = True
        '
        'QFG2Wizard
        '
        Me.QFG2Wizard.AutoSize = True
        Me.QFG2Wizard.Location = New System.Drawing.Point(136, 123)
        Me.QFG2Wizard.Name = "QFG2Wizard"
        Me.QFG2Wizard.Size = New System.Drawing.Size(95, 17)
        Me.QFG2Wizard.TabIndex = 3
        Me.QFG2Wizard.Text = "QFG2 - Wizard"
        Me.QFG2Wizard.UseVisualStyleBackColor = True
        '
        'QFG2WizardA
        '
        Me.QFG2WizardA.AutoSize = True
        Me.QFG2WizardA.Location = New System.Drawing.Point(236, 123)
        Me.QFG2WizardA.Name = "QFG2WizardA"
        Me.QFG2WizardA.Size = New System.Drawing.Size(111, 17)
        Me.QFG2WizardA.TabIndex = 3
        Me.QFG2WizardA.Text = "QFG2 - Wizard (A)"
        Me.QFG2WizardA.UseVisualStyleBackColor = True
        '
        'QFG2WizardB
        '
        Me.QFG2WizardB.AutoSize = True
        Me.QFG2WizardB.Location = New System.Drawing.Point(352, 123)
        Me.QFG2WizardB.Name = "QFG2WizardB"
        Me.QFG2WizardB.Size = New System.Drawing.Size(111, 17)
        Me.QFG2WizardB.TabIndex = 3
        Me.QFG2WizardB.Text = "QFG2 - Wizard (B)"
        Me.QFG2WizardB.UseVisualStyleBackColor = True
        '
        'QFG2Thief
        '
        Me.QFG2Thief.AutoSize = True
        Me.QFG2Thief.Location = New System.Drawing.Point(136, 146)
        Me.QFG2Thief.Name = "QFG2Thief"
        Me.QFG2Thief.Size = New System.Drawing.Size(86, 17)
        Me.QFG2Thief.TabIndex = 4
        Me.QFG2Thief.Text = "QFG2 - Thief"
        Me.QFG2Thief.UseVisualStyleBackColor = True
        '
        'QFG2ThiefA
        '
        Me.QFG2ThiefA.AutoSize = True
        Me.QFG2ThiefA.Location = New System.Drawing.Point(236, 146)
        Me.QFG2ThiefA.Name = "QFG2ThiefA"
        Me.QFG2ThiefA.Size = New System.Drawing.Size(102, 17)
        Me.QFG2ThiefA.TabIndex = 4
        Me.QFG2ThiefA.Text = "QFG2 - Thief (A)"
        Me.QFG2ThiefA.UseVisualStyleBackColor = True
        '
        'QFG2ThiefB
        '
        Me.QFG2ThiefB.AutoSize = True
        Me.QFG2ThiefB.Location = New System.Drawing.Point(352, 146)
        Me.QFG2ThiefB.Name = "QFG2ThiefB"
        Me.QFG2ThiefB.Size = New System.Drawing.Size(102, 17)
        Me.QFG2ThiefB.TabIndex = 4
        Me.QFG2ThiefB.Text = "QFG2 - Thief (B)"
        Me.QFG2ThiefB.UseVisualStyleBackColor = True
        '
        'QFG2FighterHybrid
        '
        Me.QFG2FighterHybrid.AutoSize = True
        Me.QFG2FighterHybrid.Location = New System.Drawing.Point(3, 100)
        Me.QFG2FighterHybrid.Name = "QFG2FighterHybrid"
        Me.QFG2FighterHybrid.Size = New System.Drawing.Size(127, 17)
        Me.QFG2FighterHybrid.TabIndex = 5
        Me.QFG2FighterHybrid.Text = "QFG2 - Fighter Hybrid"
        Me.QFG2FighterHybrid.UseVisualStyleBackColor = True
        '
        'QFG2WizardHybrid
        '
        Me.QFG2WizardHybrid.AutoSize = True
        Me.QFG2WizardHybrid.Location = New System.Drawing.Point(3, 123)
        Me.QFG2WizardHybrid.Name = "QFG2WizardHybrid"
        Me.QFG2WizardHybrid.Size = New System.Drawing.Size(128, 17)
        Me.QFG2WizardHybrid.TabIndex = 6
        Me.QFG2WizardHybrid.Text = "QFG2 - Wizard Hybrid"
        Me.QFG2WizardHybrid.UseVisualStyleBackColor = True
        '
        'QFG2ThiefHybrid
        '
        Me.QFG2ThiefHybrid.AutoSize = True
        Me.QFG2ThiefHybrid.Location = New System.Drawing.Point(3, 146)
        Me.QFG2ThiefHybrid.Name = "QFG2ThiefHybrid"
        Me.QFG2ThiefHybrid.Size = New System.Drawing.Size(119, 17)
        Me.QFG2ThiefHybrid.TabIndex = 7
        Me.QFG2ThiefHybrid.Text = "QFG2 - Thief Hybrid"
        Me.QFG2ThiefHybrid.UseVisualStyleBackColor = True
        '
        'QFG2Paladin
        '
        Me.QFG2Paladin.AutoSize = True
        Me.QFG2Paladin.Location = New System.Drawing.Point(136, 169)
        Me.QFG2Paladin.Name = "QFG2Paladin"
        Me.QFG2Paladin.Size = New System.Drawing.Size(97, 17)
        Me.QFG2Paladin.TabIndex = 4
        Me.QFG2Paladin.Text = "QFG2 - Paladin"
        Me.QFG2Paladin.UseVisualStyleBackColor = True
        '
        'QFG2PaladinA
        '
        Me.QFG2PaladinA.AutoSize = True
        Me.QFG2PaladinA.Location = New System.Drawing.Point(236, 169)
        Me.QFG2PaladinA.Name = "QFG2PaladinA"
        Me.QFG2PaladinA.Size = New System.Drawing.Size(113, 17)
        Me.QFG2PaladinA.TabIndex = 4
        Me.QFG2PaladinA.Text = "QFG2 - Paladin (A)"
        Me.QFG2PaladinA.UseVisualStyleBackColor = True
        '
        'QFG2PaladinB
        '
        Me.QFG2PaladinB.AutoSize = True
        Me.QFG2PaladinB.Location = New System.Drawing.Point(352, 169)
        Me.QFG2PaladinB.Name = "QFG2PaladinB"
        Me.QFG2PaladinB.Size = New System.Drawing.Size(113, 17)
        Me.QFG2PaladinB.TabIndex = 4
        Me.QFG2PaladinB.Text = "QFG2 - Paladin (B)"
        Me.QFG2PaladinB.UseVisualStyleBackColor = True
        '
        'QFG3Fighter
        '
        Me.QFG3Fighter.AutoSize = True
        Me.QFG3Fighter.Location = New System.Drawing.Point(136, 212)
        Me.QFG3Fighter.Name = "QFG3Fighter"
        Me.QFG3Fighter.Size = New System.Drawing.Size(121, 17)
        Me.QFG3Fighter.TabIndex = 2
        Me.QFG3Fighter.Text = "QFG3 - Fighter (246)"
        Me.QFG3Fighter.UseVisualStyleBackColor = True
        '
        'QFG3Wizard
        '
        Me.QFG3Wizard.AutoSize = True
        Me.QFG3Wizard.Location = New System.Drawing.Point(136, 235)
        Me.QFG3Wizard.Name = "QFG3Wizard"
        Me.QFG3Wizard.Size = New System.Drawing.Size(122, 17)
        Me.QFG3Wizard.TabIndex = 3
        Me.QFG3Wizard.Text = "QFG3 - Wizard (209)"
        Me.QFG3Wizard.UseVisualStyleBackColor = True
        '
        'QFG3Thief
        '
        Me.QFG3Thief.AutoSize = True
        Me.QFG3Thief.Location = New System.Drawing.Point(136, 258)
        Me.QFG3Thief.Name = "QFG3Thief"
        Me.QFG3Thief.Size = New System.Drawing.Size(113, 17)
        Me.QFG3Thief.TabIndex = 4
        Me.QFG3Thief.Text = "QFG3 - Thief (208)"
        Me.QFG3Thief.UseVisualStyleBackColor = True
        '
        'QFG3Paladin
        '
        Me.QFG3Paladin.AutoSize = True
        Me.QFG3Paladin.Location = New System.Drawing.Point(136, 281)
        Me.QFG3Paladin.Name = "QFG3Paladin"
        Me.QFG3Paladin.Size = New System.Drawing.Size(124, 17)
        Me.QFG3Paladin.TabIndex = 4
        Me.QFG3Paladin.Text = "QFG3 - Paladin (269)"
        Me.QFG3Paladin.UseVisualStyleBackColor = True
        '
        'QFG3FighterA
        '
        Me.QFG3FighterA.AutoSize = True
        Me.QFG3FighterA.Location = New System.Drawing.Point(263, 212)
        Me.QFG3FighterA.Name = "QFG3FighterA"
        Me.QFG3FighterA.Size = New System.Drawing.Size(137, 17)
        Me.QFG3FighterA.TabIndex = 2
        Me.QFG3FighterA.Text = "QFG3 - Fighter (A) (246)"
        Me.QFG3FighterA.UseVisualStyleBackColor = True
        '
        'QFG3ThiefA
        '
        Me.QFG3ThiefA.AutoSize = True
        Me.QFG3ThiefA.Location = New System.Drawing.Point(263, 258)
        Me.QFG3ThiefA.Name = "QFG3ThiefA"
        Me.QFG3ThiefA.Size = New System.Drawing.Size(129, 17)
        Me.QFG3ThiefA.TabIndex = 4
        Me.QFG3ThiefA.Text = "QFG3 - Thief (A) (246)"
        Me.QFG3ThiefA.UseVisualStyleBackColor = True
        '
        'QFG3PaladinA
        '
        Me.QFG3PaladinA.AutoSize = True
        Me.QFG3PaladinA.Location = New System.Drawing.Point(263, 281)
        Me.QFG3PaladinA.Name = "QFG3PaladinA"
        Me.QFG3PaladinA.Size = New System.Drawing.Size(140, 17)
        Me.QFG3PaladinA.TabIndex = 4
        Me.QFG3PaladinA.Text = "QFG3 - Paladin (A) (236)"
        Me.QFG3PaladinA.UseVisualStyleBackColor = True
        '
        'QFG4Fighter
        '
        Me.QFG4Fighter.AutoSize = True
        Me.QFG4Fighter.Location = New System.Drawing.Point(136, 316)
        Me.QFG4Fighter.Name = "QFG4Fighter"
        Me.QFG4Fighter.Size = New System.Drawing.Size(121, 17)
        Me.QFG4Fighter.TabIndex = 2
        Me.QFG4Fighter.Text = "QFG4 - Fighter (450)"
        Me.QFG4Fighter.UseVisualStyleBackColor = True
        '
        'QFG4Wizard
        '
        Me.QFG4Wizard.AutoSize = True
        Me.QFG4Wizard.Location = New System.Drawing.Point(136, 339)
        Me.QFG4Wizard.Name = "QFG4Wizard"
        Me.QFG4Wizard.Size = New System.Drawing.Size(122, 17)
        Me.QFG4Wizard.TabIndex = 3
        Me.QFG4Wizard.Text = "QFG4 - Wizard (480)"
        Me.QFG4Wizard.UseVisualStyleBackColor = True
        '
        'QFG4Thief
        '
        Me.QFG4Thief.AutoSize = True
        Me.QFG4Thief.Location = New System.Drawing.Point(136, 362)
        Me.QFG4Thief.Name = "QFG4Thief"
        Me.QFG4Thief.Size = New System.Drawing.Size(113, 17)
        Me.QFG4Thief.TabIndex = 4
        Me.QFG4Thief.Text = "QFG4 - Thief (246)"
        Me.QFG4Thief.UseVisualStyleBackColor = True
        '
        'QFG4Paladin
        '
        Me.QFG4Paladin.AutoSize = True
        Me.QFG4Paladin.Location = New System.Drawing.Point(136, 385)
        Me.QFG4Paladin.Name = "QFG4Paladin"
        Me.QFG4Paladin.Size = New System.Drawing.Size(124, 17)
        Me.QFG4Paladin.TabIndex = 4
        Me.QFG4Paladin.Text = "QFG4 - Paladin (444)"
        Me.QFG4Paladin.UseVisualStyleBackColor = True
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Location = New System.Drawing.Point(254, 434)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAs.TabIndex = 9
        Me.btnSaveAs.Text = "Save As..."
        Me.btnSaveAs.UseVisualStyleBackColor = True
        Me.btnSaveAs.Visible = False
        '
        'TestForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(490, 472)
        Me.Controls.Add(Me.btnSaveAs)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.QFG2ThiefHybrid)
        Me.Controls.Add(Me.QFG1ThiefHybrid)
        Me.Controls.Add(Me.QFG2WizardHybrid)
        Me.Controls.Add(Me.QFG1WizardHybrid)
        Me.Controls.Add(Me.QFG2FighterHybrid)
        Me.Controls.Add(Me.QFG2PaladinB)
        Me.Controls.Add(Me.QFG2ThiefB)
        Me.Controls.Add(Me.QFG1FighterHybrid)
        Me.Controls.Add(Me.QFG2PaladinA)
        Me.Controls.Add(Me.QFG2ThiefA)
        Me.Controls.Add(Me.QFG3PaladinA)
        Me.Controls.Add(Me.QFG4Paladin)
        Me.Controls.Add(Me.QFG3Paladin)
        Me.Controls.Add(Me.QFG1ThiefB)
        Me.Controls.Add(Me.QFG3ThiefA)
        Me.Controls.Add(Me.QFG4Thief)
        Me.Controls.Add(Me.QFG3Thief)
        Me.Controls.Add(Me.QFG2Paladin)
        Me.Controls.Add(Me.QFG2Thief)
        Me.Controls.Add(Me.QFG1ThiefA)
        Me.Controls.Add(Me.QFG2WizardB)
        Me.Controls.Add(Me.QFG1Thief)
        Me.Controls.Add(Me.QFG2WizardA)
        Me.Controls.Add(Me.QFG4Wizard)
        Me.Controls.Add(Me.QFG3Wizard)
        Me.Controls.Add(Me.QFG1WizardB)
        Me.Controls.Add(Me.QFG2Wizard)
        Me.Controls.Add(Me.QFG1WizardA)
        Me.Controls.Add(Me.QFG2FighterB)
        Me.Controls.Add(Me.QFG1Wizard)
        Me.Controls.Add(Me.QFG2FighterA)
        Me.Controls.Add(Me.QFG3FighterA)
        Me.Controls.Add(Me.QFG4Fighter)
        Me.Controls.Add(Me.QFG3Fighter)
        Me.Controls.Add(Me.QFG1FighterB)
        Me.Controls.Add(Me.QFG2Fighter)
        Me.Controls.Add(Me.QFG1FighterA)
        Me.Controls.Add(Me.QFG1Fighter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TestForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TestForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QFG1Fighter As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1Wizard As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1Thief As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1FighterHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1WizardHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1ThiefHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1FighterA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1WizardA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1ThiefA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1FighterB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1WizardB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG1ThiefB As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents QFG2Fighter As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2FighterA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2FighterB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2Wizard As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2WizardA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2WizardB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2Thief As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2ThiefA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2ThiefB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2FighterHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2WizardHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2ThiefHybrid As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2Paladin As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2PaladinA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG2PaladinB As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3Fighter As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3Wizard As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3Thief As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3Paladin As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3FighterA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3ThiefA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG3PaladinA As System.Windows.Forms.RadioButton
    Friend WithEvents QFG4Fighter As System.Windows.Forms.RadioButton
    Friend WithEvents QFG4Wizard As System.Windows.Forms.RadioButton
    Friend WithEvents QFG4Thief As System.Windows.Forms.RadioButton
    Friend WithEvents QFG4Paladin As System.Windows.Forms.RadioButton
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button

End Class
