Module Module1

  Sub Main()

    SendRequest().Wait()

    Console.WriteLine("Press any key to exit.")
    Console.ReadKey()
  End Sub

  Private Async Function SendRequest() As Task
    Dim client As New System.Net.Http.HttpClient()
    Dim content As New System.Net.Http.MultipartFormDataContent()

    'text fields
    'параметры
    Dim stringContent As New Net.Http.StringContent("example@from.ru")
    stringContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
    stringContent.Headers.ContentDisposition.Name = "mail_from"
    content.Add(stringContent)

    stringContent = New Net.Http.StringContent("example@to.ru")
    stringContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
    stringContent.Headers.ContentDisposition.Name = "mail_to"
    content.Add(stringContent)

    stringContent = New Net.Http.StringContent("zamer")
    stringContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
    stringContent.Headers.ContentDisposition.Name = "mail_subject"
    content.Add(stringContent)

    stringContent = New Net.Http.StringContent("hello world!")
    stringContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
    stringContent.Headers.ContentDisposition.Name = "mail_msg"
    content.Add(stringContent)

    'attach file
    'добавляем файл
    Dim fs As New System.IO.FileStream("G:\123.zip", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Inheritable)
    Dim streamContent As New System.Net.Http.StreamContent(fs)

    streamContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream")
    streamContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
    streamContent.Headers.ContentDisposition.Name = "mail_file"
    streamContent.Headers.ContentDisposition.FileName = "123.zip"

    content.Add(streamContent)

    'send form
    'отправляем асинхронный запрос
    Dim result = Await client.PostAsync("http://api.foxtools.ru/v2/Http", content)

    'show results
    Console.WriteLine(Await result.Content.ReadAsStringAsync())
  End Function

End Module