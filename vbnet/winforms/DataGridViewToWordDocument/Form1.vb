Imports Microsoft.Office.Interop
Imports System.IO

Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim word As Word.Application
    Dim doc As Word.Document
    word = CreateObject("Word.Application")
    word.Visible = True
    doc = word.Documents.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template.docx"))

    'search marker for table
    'ищем метку в документе
    Dim FindObject As Word.Find = word.ActiveWindow.Selection.Find

    With FindObject
      .ClearFormatting()
      .Text = "{Table}" 'найти в документе строку {Table}
      .Execute()
    End With

    'add table to document
    'добавляем таблицу в документ
    Dim tableLocation As Word.Range = doc.Range(Start:=word.Selection.Start, End:=word.Selection.Start + "{Table}".Length)

    'RowCount + 1 - одна строка для названий колонок

    doc.Tables.Add(Range:=tableLocation, NumRows:=DataGridView1.RowCount + 1, NumColumns:=DataGridView1.ColumnCount)

    'set styles
    'стили таблицы
    doc.Tables.Item(1).Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack
    doc.Tables.Item(1).Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
    doc.Tables.Item(1).Borders.OutsideLineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth100pt
    doc.Tables.Item(1).Borders.InsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorBlack
    doc.Tables.Item(1).Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle
    doc.Tables.Item(1).Borders.InsideLineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth100pt

    'table header
    'шляпа
    For i As Integer = 0 To DataGridView1.ColumnCount - 1
      doc.Tables.Item(1).Rows(1).Cells(i + 1).Range.Text = DataGridView1.Columns(i).HeaderText
    Next

    'set data to table
    'переносим данные
    For i As Integer = 0 To DataGridView1.RowCount - 1 'строки
      For j As Integer = 0 To DataGridView1.ColumnCount - 1 'колонки
        'skip empty
        'если данных нет, пропускаем
        If DataGridView1.Rows(i).Cells(j).Value Is Nothing Then Continue For
        'set cell
        'помещаем данные в ячейку
        'i + 2, т.к. первая строка использовалась для названий колонок
        'отсчет с 1
        doc.Tables.Item(1).Rows(i + 2).Cells(j + 1).Range.Text = DataGridView1.Rows(i).Cells(j).Value.ToString()
      Next
    Next

  End Sub

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'random data
    'случайные данные
    For i As Integer = 0 To 9
      DataGridView1.Rows.Add(Guid.NewGuid, i, DateTime.Now.Ticks)
    Next
  End Sub

End Class