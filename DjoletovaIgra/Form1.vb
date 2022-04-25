Public Class Form1
    Private firstClicked As Label = Nothing

    Private secondClicked As Label = Nothing

    Private random As New Random

    Private icons =
        New List(Of String) From {"!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z"}

    Private Sub AssignIconsToSquares()
        For Each control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(control, Label)
            If iconLabel IsNot Nothing Then
                Dim randomNumber = random.Next(icons.count)
                iconLabel.Text = icons(randomNumber)
                iconLabel.ForeColor = iconLabel.BackColor
                icons.RemoveAt(randomNumber)
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AssignIconsToSquares()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Label1.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click, Label16.Click, Label15.Click, Label14.Click, Label13.Click, Label12.Click, Label11.Click, Label10.Click
        Dim clickedLabel = TryCast(sender, Label)

        If clickedLabel IsNot Nothing Then
            If clickedLabel.ForeColor = Color.Black Then Exit Sub

            If firstClicked Is Nothing Then
                firstClicked = clickedLabel
                firstClicked.ForeColor = Color.Black
                Exit Sub
            End If

            secondClicked = clickedLabel
            secondClicked.ForeColor = Color.Black

            CheckForWinner()

            If firstClicked.Text = secondClicked.Text Then
                firstClicked = Nothing
                secondClicked = Nothing
                Exit Sub
            End If


            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick() Handles Timer1.Tick

        Timer1.Stop()

        firstClicked.ForeColor = firstClicked.BackColor
        secondClicked.ForeColor = secondClicked.BackColor

        firstClicked = Nothing
        secondClicked = Nothing
    End Sub

    Private Sub CheckForWinner()

        For Each control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(control, Label)
            If iconLabel IsNot Nothing AndAlso
                    iconLabel.ForeColor = iconLabel.BackColor Then Exit Sub
        Next


        MessageBox.Show("Uspio si spojiti sve ikonice!", "Čestitamo")
        Close()
    End Sub
End Class
