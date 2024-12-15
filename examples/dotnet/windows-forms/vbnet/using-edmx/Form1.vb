Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Using example As New ExampleEntities()
      example.Users.AddObject _
      ( _
        New Users() With _
        { _
          .Id = Guid.NewGuid(), _
          .UserEmail = TextBox2.Text, _
          .UserName = TextBox1.Text, _
          .DateCreated = Now _
        } _
      )
      example.SaveChanges()
    End Using

    TextBox2.Text = ""
    TextBox1.Text = ""

    MessageBox.Show("Data successfully added!", "Adding data", MessageBoxButtons.OK, MessageBoxIcon.Information)
    'MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    Using example As New ExampleEntities()
      DataGridView1.DataSource = example.Users
    End Using
  End Sub

End Class