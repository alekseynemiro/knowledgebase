Public Class Form1

  Private _CurrentFile As String = ""

  Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
    TextBox1.Text = ""
  End Sub

  Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
    If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      _CurrentFile = OpenFileDialog1.FileName
      Dim myRead As New IO.StreamReader(_CurrentFile, System.Text.Encoding.GetEncoding(1251))
      TextBox1.Text = myRead.ReadToEnd
      myRead.Close()
    End If
  End Sub

  Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
    If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      _CurrentFile = SaveFileDialog1.FileName
      Dim myWrite As New IO.StreamWriter(_CurrentFile, False, System.Text.Encoding.GetEncoding(1251))
      myWrite.Write(TextBox1.Text)
      myWrite.Close()
    End If
  End Sub

  Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    Me.Close()
  End Sub

  Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If e.CloseReason = CloseReason.UserClosing Then
      If MsgBox("Are you want to exit?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
      'If MsgBox("Вы действительно хотие выйти из программы?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
    End If
    End
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    OpenFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
    SaveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
    'OpenFileDialog1.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*"
    'SaveFileDialog1.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*"
    LoadPlugins()
  End Sub

  'процедура подключения плагинов
  Private Sub LoadPlugins()
    Dim sPath As String = Application.StartupPath
    Dim lPlugins As New List(Of IPlugin)
    For Each f As String In IO.Directory.GetFiles(sPath, "*.dll")
      Dim a As Reflection.Assembly = Reflection.Assembly.LoadFile(f)
      For Each t As Type In a.GetTypes()
        For Each i As Type In t.GetInterfaces()
          If i.Equals(GetType(IPlugin)) Then
            Dim p As IPlugin = CType(Activator.CreateInstance(t), IPlugin)
            lPlugins.Add(p)
            p.Initialize(Me)
            Exit For
          End If
        Next
      Next
    Next
  End Sub

End Class