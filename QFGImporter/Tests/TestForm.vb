Imports System.Windows.Forms
Public Class TestForm
    Public Property FileContents As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Call SelectFile()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectFile()
        Dim name As String = "Unknown Hero" & vbLf
        If QFG1Fighter.Checked Then
            Me.FileContents = name & TestCases.Glory1Fighter
        ElseIf QFG1FighterA.Checked Then
            Me.FileContents = name & TestCases.Glory1FighterA
        ElseIf QFG1FighterB.Checked Then
            Me.FileContents = name & TestCases.Glory1FighterB
        ElseIf QFG1FighterHybrid.Checked Then
            Me.FileContents = name & TestCases.Glory1FighterPerfect

        ElseIf QFG1Wizard.Checked Then
            Me.FileContents = name & TestCases.Glory1Wizard
        ElseIf QFG1WizardA.Checked Then
            Me.FileContents = name & TestCases.Glory1WizardA
        ElseIf QFG1WizardB.Checked Then
            Me.FileContents = name & TestCases.Glory1WizardB
        ElseIf QFG1WizardHybrid.Checked Then
            Me.FileContents = name & TestCases.Glory1WizardPerfect

        ElseIf QFG1Thief.Checked Then
            Me.FileContents = name & TestCases.Glory1Thief
        ElseIf QFG1ThiefA.Checked Then
            Me.FileContents = name & TestCases.Glory1ThiefA
        ElseIf QFG1ThiefB.Checked Then
            Me.FileContents = name & TestCases.Glory1ThiefB
        ElseIf QFG1ThiefHybrid.Checked Then
            Me.FileContents = name & TestCases.Glory1ThiefPerfect


        End If

        Me.FileContents &= vbLf
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim col As New Collections.ArrayList
        Dim fso As New FolderBrowserDialog
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim d As New IO.DirectoryInfo(fso.SelectedPath)
            Dim f() As IO.FileInfo = d.GetFiles("*.sav")
            For Each x As IO.FileInfo In f
                Dim ff As New IO.StreamReader(x.FullName)
                col.Add(New CharQFG1(ff.ReadToEnd()))
                ff.Close()
            Next
        End If

        Dim output As New Collections.ArrayList
        Dim str As New System.Text.StringBuilder
        For Each qfg As CharQFG1 In col
            output.Add(qfg.DecodedValuesToString)
            str.AppendLine(qfg.DecodedValuesToString)
        Next

        Dim out As String = str.ToString
        MessageBox.Show(out)

    End Sub
End Class
