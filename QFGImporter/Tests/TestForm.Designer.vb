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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(332, 343)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
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
        Me.QFG1Fighter.Location = New System.Drawing.Point(3, 16)
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
        Me.QFG1Wizard.Location = New System.Drawing.Point(3, 39)
        Me.QFG1Wizard.Name = "QFG1Wizard"
        Me.QFG1Wizard.Size = New System.Drawing.Size(95, 17)
        Me.QFG1Wizard.TabIndex = 3
        Me.QFG1Wizard.TabStop = True
        Me.QFG1Wizard.Text = "QFG1 - Wizard"
        Me.QFG1Wizard.UseVisualStyleBackColor = True
        '
        'QFG1Thief
        '
        Me.QFG1Thief.AutoSize = True
        Me.QFG1Thief.Location = New System.Drawing.Point(3, 62)
        Me.QFG1Thief.Name = "QFG1Thief"
        Me.QFG1Thief.Size = New System.Drawing.Size(86, 17)
        Me.QFG1Thief.TabIndex = 4
        Me.QFG1Thief.TabStop = True
        Me.QFG1Thief.Text = "QFG1 - Thief"
        Me.QFG1Thief.UseVisualStyleBackColor = True
        '
        'QFG1FighterHybrid
        '
        Me.QFG1FighterHybrid.AutoSize = True
        Me.QFG1FighterHybrid.Location = New System.Drawing.Point(3, 85)
        Me.QFG1FighterHybrid.Name = "QFG1FighterHybrid"
        Me.QFG1FighterHybrid.Size = New System.Drawing.Size(127, 17)
        Me.QFG1FighterHybrid.TabIndex = 5
        Me.QFG1FighterHybrid.TabStop = True
        Me.QFG1FighterHybrid.Text = "QFG1 - Fighter Hybrid"
        Me.QFG1FighterHybrid.UseVisualStyleBackColor = True
        '
        'QFG1WizardHybrid
        '
        Me.QFG1WizardHybrid.AutoSize = True
        Me.QFG1WizardHybrid.Location = New System.Drawing.Point(3, 108)
        Me.QFG1WizardHybrid.Name = "QFG1WizardHybrid"
        Me.QFG1WizardHybrid.Size = New System.Drawing.Size(128, 17)
        Me.QFG1WizardHybrid.TabIndex = 6
        Me.QFG1WizardHybrid.TabStop = True
        Me.QFG1WizardHybrid.Text = "QFG1 - Wizard Hybrid"
        Me.QFG1WizardHybrid.UseVisualStyleBackColor = True
        '
        'QFG1ThiefHybrid
        '
        Me.QFG1ThiefHybrid.AutoSize = True
        Me.QFG1ThiefHybrid.Location = New System.Drawing.Point(3, 131)
        Me.QFG1ThiefHybrid.Name = "QFG1ThiefHybrid"
        Me.QFG1ThiefHybrid.Size = New System.Drawing.Size(119, 17)
        Me.QFG1ThiefHybrid.TabIndex = 7
        Me.QFG1ThiefHybrid.TabStop = True
        Me.QFG1ThiefHybrid.Text = "QFG1 - Thief Hybrid"
        Me.QFG1ThiefHybrid.UseVisualStyleBackColor = True
        '
        'QFG1FighterA
        '
        Me.QFG1FighterA.AutoSize = True
        Me.QFG1FighterA.Location = New System.Drawing.Point(103, 16)
        Me.QFG1FighterA.Name = "QFG1FighterA"
        Me.QFG1FighterA.Size = New System.Drawing.Size(110, 17)
        Me.QFG1FighterA.TabIndex = 2
        Me.QFG1FighterA.TabStop = True
        Me.QFG1FighterA.Text = "QFG1 - Fighter (A)"
        Me.QFG1FighterA.UseVisualStyleBackColor = True
        '
        'QFG1WizardA
        '
        Me.QFG1WizardA.AutoSize = True
        Me.QFG1WizardA.Location = New System.Drawing.Point(103, 39)
        Me.QFG1WizardA.Name = "QFG1WizardA"
        Me.QFG1WizardA.Size = New System.Drawing.Size(111, 17)
        Me.QFG1WizardA.TabIndex = 3
        Me.QFG1WizardA.TabStop = True
        Me.QFG1WizardA.Text = "QFG1 - Wizard (A)"
        Me.QFG1WizardA.UseVisualStyleBackColor = True
        '
        'QFG1ThiefA
        '
        Me.QFG1ThiefA.AutoSize = True
        Me.QFG1ThiefA.Location = New System.Drawing.Point(103, 62)
        Me.QFG1ThiefA.Name = "QFG1ThiefA"
        Me.QFG1ThiefA.Size = New System.Drawing.Size(102, 17)
        Me.QFG1ThiefA.TabIndex = 4
        Me.QFG1ThiefA.TabStop = True
        Me.QFG1ThiefA.Text = "QFG1 - Thief (A)"
        Me.QFG1ThiefA.UseVisualStyleBackColor = True
        '
        'QFG1FighterB
        '
        Me.QFG1FighterB.AutoSize = True
        Me.QFG1FighterB.Location = New System.Drawing.Point(219, 16)
        Me.QFG1FighterB.Name = "QFG1FighterB"
        Me.QFG1FighterB.Size = New System.Drawing.Size(110, 17)
        Me.QFG1FighterB.TabIndex = 2
        Me.QFG1FighterB.TabStop = True
        Me.QFG1FighterB.Text = "QFG1 - Fighter (B)"
        Me.QFG1FighterB.UseVisualStyleBackColor = True
        '
        'QFG1WizardB
        '
        Me.QFG1WizardB.AutoSize = True
        Me.QFG1WizardB.Location = New System.Drawing.Point(219, 39)
        Me.QFG1WizardB.Name = "QFG1WizardB"
        Me.QFG1WizardB.Size = New System.Drawing.Size(111, 17)
        Me.QFG1WizardB.TabIndex = 3
        Me.QFG1WizardB.TabStop = True
        Me.QFG1WizardB.Text = "QFG1 - Wizard (B)"
        Me.QFG1WizardB.UseVisualStyleBackColor = True
        '
        'QFG1ThiefB
        '
        Me.QFG1ThiefB.AutoSize = True
        Me.QFG1ThiefB.Location = New System.Drawing.Point(219, 62)
        Me.QFG1ThiefB.Name = "QFG1ThiefB"
        Me.QFG1ThiefB.Size = New System.Drawing.Size(102, 17)
        Me.QFG1ThiefB.TabIndex = 4
        Me.QFG1ThiefB.TabStop = True
        Me.QFG1ThiefB.Text = "QFG1 - Thief (B)"
        Me.QFG1ThiefB.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(251, 346)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Test QFG1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TestForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(490, 384)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.QFG1ThiefHybrid)
        Me.Controls.Add(Me.QFG1WizardHybrid)
        Me.Controls.Add(Me.QFG1FighterHybrid)
        Me.Controls.Add(Me.QFG1ThiefB)
        Me.Controls.Add(Me.QFG1ThiefA)
        Me.Controls.Add(Me.QFG1Thief)
        Me.Controls.Add(Me.QFG1WizardB)
        Me.Controls.Add(Me.QFG1WizardA)
        Me.Controls.Add(Me.QFG1Wizard)
        Me.Controls.Add(Me.QFG1FighterB)
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

End Class
