Imports System.IO

'http://kbyte.ru/ru/Forums/Show.aspx?id=16457

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'в выводимый список будем добавлять объекты типа FileInfo - файлы
    ListBox1.DisplayMember = "Name" 'имя свойства FileInfo
    ListBox1.ValueMember = "FullName" 'имя свойства FileInfo

    'create playlist
    'создаем список в MediaPlayer
    AxWindowsMediaPlayer1.currentPlaylist = AxWindowsMediaPlayer1.newPlaylist("My list", "")

    'add media files to playlist
    'добавляем пару файлов для примера
    AddMelody(Path.Combine(Application.StartupPath, "E-pentatonic experiment.mp3"))
    AddMelody(Path.Combine(Application.StartupPath, "Sea Breeze.mp3"))
  End Sub

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    'select file
    'если в выводимом списке что-то выбрано, то выбираем это же в списке MediaPlayer
    If Not ListBox1.SelectedIndex = -1 Then
      AxWindowsMediaPlayer1.Ctlcontrols.currentItem = AxWindowsMediaPlayer1.currentPlaylist.Item(ListBox1.SelectedIndex)
    End If

    'play
    'воспроизводим
    AxWindowsMediaPlayer1.Ctlcontrols.play()
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    AxWindowsMediaPlayer1.Ctlcontrols.stop()
  End Sub

  Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
    'если пользователь нажмет на кнопку отличную от Ok, то просто выходим из этой процедуры
    If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then Return

    'add new file to list
    'пользователь нажал на Ok
    'добавляем файл
    AddMelody(OpenFileDialog1.FileName)
    UpdateDurationInfo()
  End Sub

  ''' <summary>
  ''' Добавляет мелодию в список
  ''' </summary>
  ''' <param name="path">Путь к файлу</param>
  ''' <remarks></remarks>
  Private Sub AddMelody(path As String)
    Dim file As New FileInfo(path)

    'добавляем в выводимый список
    ListBox1.Items.Add(file)

    'добавляем в список MediaPlayer
    AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(file.FullName))

    UpdateDurationInfo()
  End Sub

  ''' <summary>
  ''' Обновляет время списка
  ''' </summary>
  Private Sub UpdateDurationInfo()
    Dim duration As Double = 0

    For i As Integer = 0 To AxWindowsMediaPlayer1.currentPlaylist.count - 1
      duration += AxWindowsMediaPlayer1.currentPlaylist.Item(i).duration
    Next

    'show duration in the Label1
    'выводим общее время в Label
    Label1.Text = TimeSpan.FromSeconds(duration).ToString()
  End Sub

End Class