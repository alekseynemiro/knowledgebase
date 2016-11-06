'Простой пример использования изображений в ListView 
'Автор: Aleksey Nemiro
'http://aleksey.nemiro.ru
'http://kbyte.ru
'Обсуждение:
'http://kbyte.ru/ru/Forums/Show.aspx?id=12296
Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    ListView1.View = View.LargeIcon
    ListView1.LargeImageList = ImageList1
    For i As Integer = 0 To ImageList1.Images.Count - 1
      ListView1.Items.Add(String.Format("Image {0}", i), i)
    Next
  End Sub

End Class
