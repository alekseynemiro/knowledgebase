Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    DataGridView1.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text)
  End Sub

End Class