Imports System.Windows.Forms

Public Class SelectGame
    Public Property Game As Enums.Games = Enums.Games.QFG1
    Private Property Loading As Boolean = True

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectGame_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call SetGame(Me.Game)
        Me.Loading = False
    End Sub

    Private Sub SetGame(game As Enums.Games)
        Select Case game
            Case Enums.Games.QFG1
                rdoQFG1.Checked = True
            Case Enums.Games.QFG2
                rdoQFG2.Checked = True
            Case Enums.Games.QFG3
                rdoQFG3.Checked = True
            Case Enums.Games.QFG4
                rdoQFG4.Checked = True
        End Select
    End Sub

    Private Sub rdoQFG_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoQFG1.CheckedChanged, rdoQFG2.CheckedChanged, rdoQFG3.CheckedChanged, rdoQFG4.CheckedChanged
        If Not Loading Then
            Dim senderX As RadioButton = sender
            Select Case senderX.Name
                Case rdoQFG1.Name
                    Me.Game = Enums.Games.QFG1
                Case rdoQFG2.Name
                    Me.Game = Enums.Games.QFG2
                Case rdoQFG3.Name
                    Me.Game = Enums.Games.QFG3
                Case rdoQFG4.Name
                    Me.Game = Enums.Games.QFG4
            End Select
        End If
    End Sub

    Public Function GetCover(Game As Enums.Games) As Bitmap
        Select Case Game
            Case Enums.Games.QFG1
                Return imgBoxArt.Images("QFG1")
            Case Enums.Games.QFG2
                Return imgBoxArt.Images("QFG2")
            Case Enums.Games.QFG3
                Return imgBoxArt.Images("QFG3")
            Case Enums.Games.QFG4
                Return imgBoxArt.Images("QFG4")
            Case Else
                Return Nothing
        End Select
    End Function

End Class

