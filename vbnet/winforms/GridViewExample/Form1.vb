Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    cmbColumns.SelectedIndex = 2
    cmbRows.SelectedIndex = 2
  End Sub

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    'удаляем старые данные
    DataGridView1.Rows.Clear()
    DataGridView1.Columns.Clear()

    'создаем новые столбцы
    For i As Integer = 0 To cmbColumns.SelectedIndex
      DataGridView1.Columns.Add(i.ToString(), i.ToString())
    Next

    'строки
    For i As Integer = 0 To cmbRows.SelectedIndex
      DataGridView1.Rows.Add()
    Next
  End Sub

  Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    'запус режима редактирования при клике по ячейке
    DataGridView1.BeginEdit(True)
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    If DataGridView1.Columns.Count <= 0 OrElse DataGridView1.Rows.Count <= 0 Then Return 'is empty // ничего нет

    'make array
    'создаем массив
    Dim arr(DataGridView1.Columns.Count - 1, DataGridView1.Rows.Count - 1) As Double

    For Each row As DataGridViewRow In DataGridView1.Rows 'листаем строки
      For Each cell As DataGridViewCell In row.Cells 'листаем ячейки
        arr(cell.ColumnIndex, cell.RowIndex) = CType(cell.Value, Double) 'добавляем данные из ячейки в массив
      Next
    Next

    TextBox1.Text = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(arr)

    'you can get array from variable "arr"
    'тут будет заполненный массив arr
  End Sub

End Class