Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("You clicked the button.")
    End Sub

    Private Sub openFileBtn_Click(sender As Object, e As EventArgs) Handles openFileBtn.Click
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            Using sr As StreamReader = File.OpenText(OpenFileDialog1.FileName)

                Label1.Text = sr.ReadToEnd()

            End Using
        End If
    End Sub
End Class
