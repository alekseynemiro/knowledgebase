Public Class ProgressForm

  ''' <summary>
  ''' Возвращает или задает текст для Label.
  ''' </summary>
  Public Property Title As String
    Get
      Return Label1.Text
    End Get
    Set(value As String)
      Label1.Text = value
    End Set
  End Property

  ''' <summary>
  ''' Возвращает или задает значение для ProgressBar.
  ''' </summary>
  Public Property Value As Integer
    Get
      Return ProgressBar1.Value
    End Get
    Set(value As Integer)
      ProgressBar1.Value = value
    End Set
  End Property

End Class