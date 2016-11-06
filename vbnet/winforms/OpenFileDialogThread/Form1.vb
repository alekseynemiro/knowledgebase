Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then Return

    Dim t As New Threading.Thread(AddressOf ThreadReadFile)
    t.IsBackground = True
    t.Start(OpenFileDialog1.FileName)
  End Sub

  Private Sub ThreadReadFile(fileName As Object)
    SetLabel("Reading...")
    'SetLabel("Чтение файла...")

    Using fs As New System.IO.FileStream(fileName.ToString(), IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
      Using br As New System.IO.BinaryReader(fs, System.Text.Encoding.UTF8)

        SetProgress(0, fs.Length, 0)

        Dim readed As Integer = 0
        Dim buffer(255) As Byte
        Dim rb As Integer = br.Read(buffer, 0, buffer.Length)
        While rb > 0
          'reading in idle
          'читам в пустую

          'you can find reading bytes in the variable "buffer"
          'если нужно обрабатывать данные, то они будут в переменной buffer
          'отсчет от нуля до rb (кол-во прочитанных байт)

          'get bytes
          'For i As Integer = 0 To rb
          'buffer(i) '<- байт прочитанных данных
          'Next

          'увеличиваем счетчик прочитанных байт
          readed += rb

          'change progress
          'меняем progress
          SetProgress(0, fs.Length, readed)

          'pause, only for demo (don't use in real case)
          'пауза 10 мс, для наглядности работы кода
          System.Threading.Thread.Sleep(10)

          'следующая пачка данных
          rb = br.Read(buffer, 0, buffer.Length)
        End While

        SetProgress(0, fs.Length, fs.Length)
      End Using
    End Using

    SetLabel("Done!")
    'SetLabel("Файл прочитан!")
  End Sub

  Private Delegate Sub SetLabelDelegate(msg As String)

  Private Sub SetLabel(msg As String)
    If Me.InvokeRequired Then 'если вызов не из родного потока
      'перенаправляем вызов в родной поток
      Me.Invoke(New SetLabelDelegate(AddressOf SetLabel), msg) 'нужно не забывать передавать параметры
      Return 'выходим, чтобы не случилось ничего плохого
    End If

    'устанавливаем сообщение
    Label1.Text = msg
  End Sub

  Private Delegate Sub SetProgressDelegate(min As Integer, max As Integer, value As Integer)

  Private Sub SetProgress(min As Integer, max As Integer, value As Integer)
    If Me.InvokeRequired Then 'если вызов не из родного потока
      'перенаправляем вызов в родной поток
      Me.Invoke(New SetProgressDelegate(AddressOf SetProgress), min, max, value) 'нужно не забывать передавать параметры
      Return 'выходим, чтобы не случилось ничего плохого
    End If

    'меняем значение ProgressBar
    ProgressBar1.Maximum = max
    ProgressBar1.Minimum = min
    ProgressBar1.Value = value
  End Sub

End Class