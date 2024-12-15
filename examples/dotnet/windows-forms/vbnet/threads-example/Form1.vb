'Thread class is in the System.Threading namespace
'класс Thread находится в этом пространстве имен
Imports System.Threading

Public Class Form1

  Private _Progress As ProgressForm = Nothing

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    'create new Thread
    'создаем поток
    Dim t As New Thread(AddressOf MyTask)

    'create form
    'создаем и показываем форму
    _Progress = New ProgressForm()

    'current form is owner of the ProgressForm
    'текущая форма является родителем
    _Progress.Owner = Me

    'show form
    _Progress.Show()

    'start thread
    'запускаем поток
    t.Start()
  End Sub

  ''' <summary>
  ''' <para>The method that will be carried out in a thread.</para>
  ''' <para lang="ru">Метод, который будет выполняться в потоке.</para>
  ''' </summary>
  Private Sub MyTask()
    'put your code here,
    'I'm just doing a cycle with pauses
    'здесь можно поместить код продолжительной задачи
    'я просто сделаю код с паузами, чтобы было видно, что все работает
    For i As Integer = 0 To 100
      'set text to label
      'устанавливаем значение в label и меняем progress
      Me.SetProgressData(String.Format("Processing {0}%", i), i)
      'Me.SetProgressData(String.Format("Выполнено на {0}%", i), i)

      'pause
      'делаем паузу, замораживая текущий поток
      'при этом сами формы будут работать нормально (не будут подвисать)
      Thread.Sleep(1000)
    Next
  End Sub

  ''' <summary>
  ''' <para>Changes the label and progressValue.</para>
  ''' <para lang="ru">Меняет значение label и progressValue в форме.</para>
  ''' </summary>
  Private Sub SetProgressData(title As String, value As Integer)
    'current thread is not thread of the current form
    'если мы находим не в своем потоке
    If Me.InvokeRequired Then
      'jump to thread of the form
      'возвращаемся в свой поток
      Me.Invoke(New Action(Of String, Integer)(AddressOf Me.SetProgressData), title, value)
      'New Action(Of String, Integer)
      'соответствует параметрам метода:
      'SetProgressData(title As String, value As Integer)
      'первый параметр - title As String, второй - value As Integer
      'поэтому: New Action(Of String, Integer)
      Return
    End If

    'set values
    'теперь мы в своем потоке, и можем внести изменения в форму
    _Progress.Title = title
    _Progress.Value = value
  End Sub

End Class