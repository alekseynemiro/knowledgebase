Imports Microsoft.Office.Interop
Imports System.IO

Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim oWord As Word.Application
    Dim oDoc As Word.Document
    oWord = CreateObject("Word.Application")
    oWord.Visible = True
    oDoc = oWord.Documents.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template.docx"))
    Dim FindObject As Word.Find = oWord.ActiveWindow.Selection.Find
    With FindObject
      .ClearFormatting()

      .Text = "{Date}"
      .Replacement.ClearFormatting()
      .Replacement.Text = DateTimePicker1.Value.ToShortDateString()
      .Execute(Replace:=Word.WdReplace.wdReplaceAll)

      .Text = "{Marker}"
      .Replacement.ClearFormatting()
      .Replacement.Text = TextBox1.Text
      .Execute(Replace:=Word.WdReplace.wdReplaceAll)

      .Text = "{Тест}"
      .Replacement.ClearFormatting()
      .Replacement.Text = "ЭТО РУССКИЙ МАРКЕР"
      .Execute(Replace:=Word.WdReplace.wdReplaceAll)
    End With
  End Sub

End Class