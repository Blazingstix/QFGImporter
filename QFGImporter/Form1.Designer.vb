<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnNewTemplate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNewQFG4 = New System.Windows.Forms.Button()
        Me.btnNewQFG3 = New System.Windows.Forms.Button()
        Me.btnNewQFG2 = New System.Windows.Forms.Button()
        Me.btnNewQFG1 = New System.Windows.Forms.Button()
        Me.grpLoad = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.grpLoad.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(6, 19)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(138, 85)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load Export File..."
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnNewTemplate
        '
        Me.btnNewTemplate.Location = New System.Drawing.Point(6, 169)
        Me.btnNewTemplate.Name = "btnNewTemplate"
        Me.btnNewTemplate.Size = New System.Drawing.Size(138, 39)
        Me.btnNewTemplate.TabIndex = 1
        Me.btnNewTemplate.Text = "Pre-Created Characters..."
        Me.btnNewTemplate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNewQFG4)
        Me.GroupBox1.Controls.Add(Me.btnNewQFG3)
        Me.GroupBox1.Controls.Add(Me.btnNewQFG2)
        Me.GroupBox1.Controls.Add(Me.btnNewQFG1)
        Me.GroupBox1.Location = New System.Drawing.Point(169, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(632, 215)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create New Export Character"
        '
        'btnNewQFG4
        '
        Me.btnNewQFG4.Image = Global.QFGImporter.My.Resources.Resources.s_QFG4_Cover
        Me.btnNewQFG4.Location = New System.Drawing.Point(474, 19)
        Me.btnNewQFG4.Name = "btnNewQFG4"
        Me.btnNewQFG4.Size = New System.Drawing.Size(150, 189)
        Me.btnNewQFG4.TabIndex = 3
        Me.btnNewQFG4.UseVisualStyleBackColor = True
        '
        'btnNewQFG3
        '
        Me.btnNewQFG3.Image = Global.QFGImporter.My.Resources.Resources.s_QFG3_Cover
        Me.btnNewQFG3.Location = New System.Drawing.Point(318, 19)
        Me.btnNewQFG3.Name = "btnNewQFG3"
        Me.btnNewQFG3.Size = New System.Drawing.Size(150, 189)
        Me.btnNewQFG3.TabIndex = 2
        Me.btnNewQFG3.UseVisualStyleBackColor = True
        '
        'btnNewQFG2
        '
        Me.btnNewQFG2.Image = Global.QFGImporter.My.Resources.Resources.s_QFG2_Cover
        Me.btnNewQFG2.Location = New System.Drawing.Point(162, 19)
        Me.btnNewQFG2.Name = "btnNewQFG2"
        Me.btnNewQFG2.Size = New System.Drawing.Size(150, 189)
        Me.btnNewQFG2.TabIndex = 1
        Me.btnNewQFG2.UseVisualStyleBackColor = True
        '
        'btnNewQFG1
        '
        Me.btnNewQFG1.Image = Global.QFGImporter.My.Resources.Resources.s_QFG1VGA_Cover
        Me.btnNewQFG1.Location = New System.Drawing.Point(6, 19)
        Me.btnNewQFG1.Name = "btnNewQFG1"
        Me.btnNewQFG1.Size = New System.Drawing.Size(150, 189)
        Me.btnNewQFG1.TabIndex = 0
        Me.btnNewQFG1.UseVisualStyleBackColor = True
        '
        'grpLoad
        '
        Me.grpLoad.Controls.Add(Me.btnLoad)
        Me.grpLoad.Controls.Add(Me.btnNewTemplate)
        Me.grpLoad.Location = New System.Drawing.Point(12, 12)
        Me.grpLoad.Name = "grpLoad"
        Me.grpLoad.Size = New System.Drawing.Size(150, 215)
        Me.grpLoad.TabIndex = 0
        Me.grpLoad.TabStop = False
        Me.grpLoad.Text = "Load Character"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 237)
        Me.Controls.Add(Me.grpLoad)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Quest For Glory Passport"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpLoad.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnNewTemplate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewQFG1 As System.Windows.Forms.Button
    Friend WithEvents btnNewQFG4 As System.Windows.Forms.Button
    Friend WithEvents btnNewQFG3 As System.Windows.Forms.Button
    Friend WithEvents btnNewQFG2 As System.Windows.Forms.Button
    Friend WithEvents grpLoad As System.Windows.Forms.GroupBox
End Class
