Imports System.IO

Public Class Upload
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Response.Clear()
    Response.ContentType = "text/plain"
    'here you need to use a standard file upload code
    'здесь нужно использовать обычный код загрузки файла, без потоков и прочего мусора
    'я не буду писать код сохранения файлов
    'паузу делаю специально, чтобы было видно, что все работает правильно и процесс загрузки не проходил мгновенно

    If Request.Files.Count <= 0 Then
      'no files, return error
      Response.Write("Files is required. Please, select file and try again.")
      'нет файлов, показываем ошибку
      'Response.Write("Необходимо указать файл.")
      Return
    End If

    'one file in request
    'файлы от клиента будут отправляться по одному, в отдельных потоках (запросах)
    Dim file As HttpPostedFile = Request.Files(0)

    Dim buffer(4095) As Byte, readBytes As Integer = -1

    While Not readBytes = 0
      readBytes = file.InputStream.Read(buffer, 0, buffer.Length)
      'writer.Write(buffer, 0, readBytes)

      'пауза для наглядности, чтобы был виден процесс загрузки
      'pause for to show the uploading process (only for localhost!) 
      Threading.Thread.Sleep(New Random(Now.Millisecond).Next(10, 100))
    End While

    Response.Write("Done!")
    'Response.Write("Файл успешно загружен!")
  End Sub

End Class