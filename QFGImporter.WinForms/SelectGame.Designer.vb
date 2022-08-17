<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectGame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectGame))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.rdoQFG1 = New System.Windows.Forms.RadioButton()
        Me.imgBoxArt = New System.Windows.Forms.ImageList(Me.components)
        Me.rdoQFG2 = New System.Windows.Forms.RadioButton()
        Me.rdoQFG3 = New System.Windows.Forms.RadioButton()
        Me.rdoQFG4 = New System.Windows.Forms.RadioButton()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(704, 292)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(78, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(88, 3)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'rdoQFG1
        '
        Me.rdoQFG1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoQFG1.AutoSize = True
        Me.rdoQFG1.Checked = True
        Me.rdoQFG1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.rdoQFG1.ImageKey = "QFG1"
        Me.rdoQFG1.ImageList = Me.imgBoxArt
        Me.rdoQFG1.Location = New System.Drawing.Point(12, 12)
        Me.rdoQFG1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rdoQFG1.Name = "rdoQFG1"
        Me.rdoQFG1.Size = New System.Drawing.Size(206, 278)
        Me.rdoQFG1.TabIndex = 1
        Me.rdoQFG1.TabStop = True
        Me.rdoQFG1.Text = "Quest For Glory 1"
        Me.rdoQFG1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rdoQFG1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.rdoQFG1.UseVisualStyleBackColor = True
        '
        'imgBoxArt
        '
        Me.imgBoxArt.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imgBoxArt.ImageStream = CType(resources.GetObject("imgBoxArt.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgBoxArt.TransparentColor = System.Drawing.Color.Transparent
        Me.imgBoxArt.Images.SetKeyName(0, "QFG1")
        Me.imgBoxArt.Images.SetKeyName(1, "QFG2")
        Me.imgBoxArt.Images.SetKeyName(2, "QFG3")
        Me.imgBoxArt.Images.SetKeyName(3, "QFG4")
        '
        'rdoQFG2
        '
        Me.rdoQFG2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoQFG2.AutoSize = True
        Me.rdoQFG2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.rdoQFG2.ImageKey = "QFG2"
        Me.rdoQFG2.ImageList = Me.imgBoxArt
        Me.rdoQFG2.Location = New System.Drawing.Point(232, 12)
        Me.rdoQFG2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rdoQFG2.Name = "rdoQFG2"
        Me.rdoQFG2.Size = New System.Drawing.Size(206, 278)
        Me.rdoQFG2.TabIndex = 2
        Me.rdoQFG2.TabStop = True
        Me.rdoQFG2.Text = "Quest For Glory 2"
        Me.rdoQFG2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rdoQFG2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.rdoQFG2.UseVisualStyleBackColor = True
        '
        'rdoQFG3
        '
        Me.rdoQFG3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoQFG3.AutoSize = True
        Me.rdoQFG3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.rdoQFG3.ImageKey = "QFG3"
        Me.rdoQFG3.ImageList = Me.imgBoxArt
        Me.rdoQFG3.Location = New System.Drawing.Point(452, 12)
        Me.rdoQFG3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rdoQFG3.Name = "rdoQFG3"
        Me.rdoQFG3.Size = New System.Drawing.Size(206, 278)
        Me.rdoQFG3.TabIndex = 3
        Me.rdoQFG3.TabStop = True
        Me.rdoQFG3.Text = "Quest For Glory 3"
        Me.rdoQFG3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rdoQFG3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.rdoQFG3.UseVisualStyleBackColor = True
        '
        'rdoQFG4
        '
        Me.rdoQFG4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoQFG4.AutoSize = True
        Me.rdoQFG4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.rdoQFG4.ImageKey = "QFG4"
        Me.rdoQFG4.ImageList = Me.imgBoxArt
        Me.rdoQFG4.Location = New System.Drawing.Point(672, 12)
        Me.rdoQFG4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.rdoQFG4.Name = "rdoQFG4"
        Me.rdoQFG4.Size = New System.Drawing.Size(206, 278)
        Me.rdoQFG4.TabIndex = 4
        Me.rdoQFG4.TabStop = True
        Me.rdoQFG4.Text = "Quest For Glory 4"
        Me.rdoQFG4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rdoQFG4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.rdoQFG4.UseVisualStyleBackColor = True
        '
        'SelectGame
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(889, 339)
        Me.Controls.Add(Me.rdoQFG4)
        Me.Controls.Add(Me.rdoQFG3)
        Me.Controls.Add(Me.rdoQFG2)
        Me.Controls.Add(Me.rdoQFG1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectGame"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select A Game"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents rdoQFG1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQFG2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQFG3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQFG4 As System.Windows.Forms.RadioButton
    Friend WithEvents imgBoxArt As System.Windows.Forms.ImageList

End Class
