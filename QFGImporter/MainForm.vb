Public Class MainForm

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs)
        Dim SelGame As New SelectGame
        If SelGame.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim newChar As CharGeneric = Nothing
            Select Case SelGame.Game
                Case Enums.Games.QFG1
                    newChar = New CharQFG1
                Case Enums.Games.QFG2
                    newChar = New CharQFG2
                Case Enums.Games.QFG3
                    newChar = New CharQFG3
                Case Enums.Games.QFG4
                    newChar = New CharQFG4
            End Select
            Dim charEdit As New CharacterEditor(newChar)
            charEdit.ShowDialog()
        End If

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Dim fso As New OpenFileDialog
        fso.Filter = CharGeneric.QFGFileFilter
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim charEdit As New CharacterEditor(fso.FileName)
            charEdit.ShowDialog()
        End If
    End Sub

    Private Sub btnNewTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnNewTemplate.Click
        Dim x As New TestForm
        If x.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim charEdit As New CharacterEditor()
            charEdit.LoadContents(x.FileContents)
            charEdit.ShowDialog()
        End If

    End Sub

    Private Sub btnNewQFG_Click(sender As System.Object, e As System.EventArgs) Handles btnNewQFG1.Click, btnNewQFG2.Click, btnNewQFG3.Click, btnNewQFG4.Click
        Dim newChar As CharGeneric = Nothing
        Dim xSender As Button = sender
        Select Case xSender.Name
            Case btnNewQFG1.Name
                newChar = New CharQFG1
            Case btnNewQFG2.Name
                newChar = New CharQFG2
            Case btnNewQFG3.Name
                newChar = New CharQFG3
            Case btnNewQFG4.Name
                newChar = New CharQFG4
        End Select
        Dim charEdit As New CharacterEditor(newChar)
        charEdit.ShowDialog()
    End Sub
End Class