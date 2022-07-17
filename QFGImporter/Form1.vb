Public Class Form1

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Dim fso As New OpenFileDialog
        fso.Filter = CharGeneric.QFGFileFilter
        If fso.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileContents As String = String.Empty
            Dim s As IO.FileStream = System.IO.File.OpenRead(fso.FileName)
            If s.Length < 1024 Then
                Dim t As New IO.StreamReader(s)
                fileContents = t.ReadToEnd
            End If
            s.Close()
            Dim OpenedChar As CharGeneric = CharGeneric.GetCharacterFromContents(fileContents)
            OpenedChar.Filename = fso.FileName

            Dim charEdit As New CharacterEditor(OpenedChar)
            charEdit.ShowDialog()
        End If
    End Sub

    Private Sub btnNewTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnNewTemplate.Click
        Dim x As New TestForm
        If x.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim PreMadeCharacter As CharGeneric = CharGeneric.GetCharacterFromContents(x.FileContents)

            Dim charEdit As New CharacterEditor(PreMadeCharacter)
            charEdit.ShowDialog()
        End If

    End Sub

    Private Sub btnNewQFG_Click(sender As System.Object, e As System.EventArgs) Handles btnNewQFG1.Click, btnNewQFG2.Click, btnNewQFG3.Click, btnNewQFG4.Click
        Dim newChar As CharGeneric = Nothing
        Dim xSender As Button = sender
        Select Case xSender.Name
            Case btnNewQFG1.Name
                newChar = MinimumCharacters.GetCharacter(Enums.Games.QFG1, Enums.CharacterClass.Fighter)
            Case btnNewQFG2.Name
                newChar = MinimumCharacters.GetCharacter(Enums.Games.QFG2, Enums.CharacterClass.Fighter)
            Case btnNewQFG3.Name
                newChar = MinimumCharacters.GetCharacter(Enums.Games.QFG3, Enums.CharacterClass.Fighter)
            Case btnNewQFG4.Name
                newChar = MinimumCharacters.GetCharacter(Enums.Games.QFG4, Enums.CharacterClass.Fighter)
        End Select
        Dim charEdit As New CharacterEditor(newChar)
        charEdit.ShowDialog()
    End Sub
End Class