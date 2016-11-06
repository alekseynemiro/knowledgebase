Imports System.Data.SqlServerCe

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'create connection
    'создание экземпляра объекта Connection.
    Dim conn As SqlCeConnection = New SqlCeConnection("Data Source=|DataDirectory|\example.sdf;")

    Try
      'open connection
      conn.Open()

      'create command
      'создание экземпляра объекта Command.
      Dim cmd As SqlCeCommand = New SqlCeCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME", conn)

      'fill table
      'выполняем запрос и получаем таблицу
      Dim adapter As New SqlCeDataAdapter(cmd)
      Dim table As New DataTable()
      adapter.Fill(table)

      'set table to DataGridView
      'передаем таблицу в DataGridView
      DataGridView1.DataSource = table

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'close connections
      'закрываем соединение
      If conn.State = ConnectionState.Open Then
        conn.Close()
      End If
    End Try
  End Sub

End Class