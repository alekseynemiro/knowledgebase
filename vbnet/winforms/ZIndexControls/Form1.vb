Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'just add five buttons
    'добавляем кнопки без сортировки
    For i As Integer = 0 To 4
      'create button instance
      Dim btn As New Button()

      'set button size
      'размер кнопки 30x30px
      btn.Width = 30
      btn.Height = 30

      'set button position
      'позиция кнопки
      btn.Top = i * 15
      btn.Left = 8

      'set button text
      'текст кнопки
      btn.Text = (i + 1).ToString()

      'add click handler
      'обработчик события
      AddHandler btn.Click, AddressOf btn_Click

      'add button to form
      'добавляем кнопку
      Me.Controls.Add(btn)
    Next

    'add five buttons with specified order
    'добавляем кнопки с явным указанием позиции
    For i As Integer = 0 To 4
      'create button instance
      Dim btn As New Button()

      'set button size
      'размер кнопки 30x30px
      btn.Width = 30
      btn.Height = 30

      'set button position
      'позиция кнопки
      btn.Top = i * 15
      btn.Left = 40

      'set button text
      'текст кнопки
      btn.Text = (i + 1).ToString()

      'add click handler
      'обработчик события
      AddHandler btn.Click, AddressOf btn_Click

      'add button to form
      'добавляем кнопку
      Me.Controls.Add(btn)

      'move into background
      'переносив вниз
      Me.Controls.SetChildIndex(btn, 0)
    Next

  End Sub

  Private Sub btn_Click(sender As Object, e As EventArgs)
    'get instance
    'ссылка на объект, вызвавшего событие находится в sender
    Dim btn As Button = CType(sender, Button)
    'show button text
    MsgBox(btn.Text)
  End Sub

End Class
