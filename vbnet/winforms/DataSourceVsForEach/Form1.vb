Imports System.IO
Imports System.Data.OleDb

Public Class Form1

  Dim sw As New Stopwatch()
  Dim total As Integer = 0

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    sw.Restart()

    Using myConn As New OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", Path.Combine(Application.StartupPath, "example.mdb")))
      myConn.Open()

      Dim DA As New OleDbDataAdapter("SELECT * FROM table1", myConn)
      Dim DT As New DataTable()

      DA.Fill(DT)

      DataGridView1.DataSource = DT
    End Using

    sw.Stop()

    MessageBox.Show(sw.Elapsed.ToString(), "Elapsed: DataSource", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    sw.Restart()

    Using myConn As New OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", Path.Combine(Application.StartupPath, "example.mdb")))
      myConn.Open()

      Dim DA As New OleDbDataAdapter("SELECT * FROM table1", myConn)
      Dim DT As New DataTable()

      DA.Fill(DT)
      DataGridView1.DataSource = Nothing

      Dim i As Integer = 0

      For Each r As DataRow In DT.Rows
        DataGridView1.Rows.Add(New Object() {r("title"), r("date_created")})

        If i Mod 1000 = 0 Then
          Me.Text = String.Format("{0} from {1}", i, DT.Rows.Count)
          Application.DoEvents()
        End If

        i += 1
      Next
    End Using

    sw.Stop()

    MessageBox.Show(sw.Elapsed.ToString(), "Elapsed: For Each", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
    sw.Restart()

    Using myConn As New OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", Path.Combine(Application.StartupPath, "example.mdb")))
      myConn.Open()

      Dim DA As New OleDbDataAdapter("SELECT * FROM table1", myConn)
      Dim DT As New DataTable()

      DA.Fill(DT)
      DataGridView1.DataSource = Nothing

      DataGridView1.Visible = False

      Dim i As Integer = 0

      For Each r As DataRow In DT.Rows
        DataGridView1.Rows.Add(New Object() {r("title"), r("date_created")})

        If i Mod 1000 = 0 Then
          Me.Text = String.Format("{0} from {1}", i, DT.Rows.Count)
          Application.DoEvents()
        End If

        i += 1
      Next
    End Using

    DataGridView1.Visible = True

    sw.Stop()

    MessageBox.Show(sw.Elapsed.ToString(), "Elapsed: For Each + Invisible", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub ContextMenuStrip1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
    If DataGridView1.CurrentCell Is Nothing Then Return 'колонка не выбрана
    Select Case DataGridView1.CurrentCell.ColumnIndex
      Case 0
        ToolStripMenuItem2.Visible = False
        ToolStripMenuItem3.Visible = True
        ToolStripMenuItem4.Visible = True

      Case 1
        ToolStripMenuItem2.Visible = False
        ToolStripMenuItem3.Visible = True
        ToolStripMenuItem4.Visible = False

      Case 2
        ToolStripMenuItem2.Visible = True
        ToolStripMenuItem3.Visible = False
        ToolStripMenuItem4.Visible = True
    End Select
  End Sub

End Class