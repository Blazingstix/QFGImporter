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
        Dim name As String = "Unknown Hero"
        Me.FileContents = String.Empty
        If IsQFG3() Then
            Me.FileContents = " glory3.sav" & vbLf
        ElseIf IsQFG4() Then
            Me.FileContents = " glory4.sav" & vbLf
        End If
        Me.FileContents &= name
        Me.FileContents &= vbLf
        Me.FileContents &= GetTestCase()
        Me.FileContents &= vbLf
    End Sub

    Private Function GetTestCase() As String
        'QFG1
        If QFG1Fighter.Checked Then
            Return TestCases.Glory1Fighter
        ElseIf QFG1FighterA.Checked Then
            Return TestCases.Glory1FighterA
        ElseIf QFG1FighterB.Checked Then
            Return TestCases.Glory1FighterB
        ElseIf QFG1FighterHybrid.Checked Then
            Return TestCases.Glory1FighterPerfect

        ElseIf QFG1Wizard.Checked Then
            Return TestCases.Glory1Wizard
        ElseIf QFG1WizardA.Checked Then
            Return TestCases.Glory1WizardA
        ElseIf QFG1WizardB.Checked Then
            Return TestCases.Glory1WizardB
        ElseIf QFG1WizardHybrid.Checked Then
            Return TestCases.Glory1WizardPerfect

        ElseIf QFG1Thief.Checked Then
            Return TestCases.Glory1Thief
        ElseIf QFG1ThiefA.Checked Then
            Return TestCases.Glory1ThiefA
        ElseIf QFG1ThiefB.Checked Then
            Return TestCases.Glory1ThiefB
        ElseIf QFG1ThiefHybrid.Checked Then
            Return TestCases.Glory1ThiefPerfect

            'QFG2
        ElseIf QFG2Fighter.Checked Then
            Return TestCases.Glory2Fighter
        ElseIf QFG2FighterA.Checked Then
            Return TestCases.Glory2FighterA
        ElseIf QFG2FighterB.Checked Then
            Return TestCases.Glory2FighterB
        ElseIf QFG2FighterHybrid.Checked Then
            Return TestCases.Glory2FighterPerfect

        ElseIf QFG2Wizard.Checked Then
            Return TestCases.Glory2Wizard
        ElseIf QFG2WizardA.Checked Then
            Return TestCases.Glory2WizardA
        ElseIf QFG2WizardB.Checked Then
            Return TestCases.Glory2WizardB
        ElseIf QFG2WizardHybrid.Checked Then
            Return TestCases.Glory2WizardPerfect

        ElseIf QFG2Thief.Checked Then
            Return TestCases.Glory2Thief
        ElseIf QFG2ThiefA.Checked Then
            Return TestCases.Glory2ThiefA
        ElseIf QFG2ThiefB.Checked Then
            Return TestCases.Glory2ThiefB
        ElseIf QFG2ThiefHybrid.Checked Then
            Return TestCases.Glory2ThiefPerfect

        ElseIf QFG2Paladin.Checked Then
            Return TestCases.Glory2Paladin
        ElseIf QFG2PaladinA.Checked Then
            Return TestCases.Glory2PaladinA
        ElseIf QFG2PaladinB.Checked Then
            Return TestCases.Glory2PaladinB

            'QFG3
        ElseIf QFG3Fighter.Checked Then
            Return TestCases.Glory3Fighter
        ElseIf QFG3FighterA.Checked Then
            Return TestCases.Glory3FighterA
        ElseIf QFG3Wizard.Checked Then
            Return TestCases.Glory3Wizard
        ElseIf QFG3Thief.Checked Then
            Return TestCases.Glory3Thief
        ElseIf QFG3ThiefA.Checked Then
            Return TestCases.Glory3ThiefA
        ElseIf QFG3Paladin.Checked Then
            Return TestCases.Glory3Paladin
        ElseIf QFG3PaladinA.Checked Then
            Return TestCases.Glory3PaladinA

            'QFG4
        ElseIf QFG4Fighter.Checked Then
            Return TestCases.Glory4Fighter
        ElseIf QFG4Wizard.Checked Then
            Return TestCases.Glory4Wizard
        ElseIf QFG4Thief.Checked Then
            Return TestCases.Glory4Thief
        ElseIf QFG4Paladin.Checked Then
            Return TestCases.Glory4Paladin
        End If

        Return String.Empty
    End Function

    Private Function IsQFG3() As Boolean
        Dim rslt As Boolean = False
        rslt = rslt Or QFG3Fighter.Checked
        rslt = rslt Or QFG3FighterA.Checked
        rslt = rslt Or QFG3Wizard.Checked
        rslt = rslt Or QFG3Thief.Checked
        rslt = rslt Or QFG3ThiefA.Checked
        rslt = rslt Or QFG3Paladin.Checked
        rslt = rslt Or QFG3PaladinA.Checked
        Return rslt
    End Function

    Private Function IsQFG4() As Boolean
        Dim rslt As Boolean = False
        rslt = rslt Or QFG4Fighter.Checked
        rslt = rslt Or QFG4Wizard.Checked
        rslt = rslt Or QFG4Thief.Checked
        rslt = rslt Or QFG4Paladin.Checked
        Return rslt
    End Function

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
