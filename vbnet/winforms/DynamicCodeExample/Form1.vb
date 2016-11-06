'Простой пример вызова метода из динамичного кода
'by Aleksey Nemiro
'http://aleksey.nemiro.ru
'special for Kbyte.Ru
'http://kbyte.ru

Imports System.CodeDom.Compiler
Imports System.Text
Imports System.Reflection
Imports System.IO

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim myCode As CodeDomProvider = CodeDomProvider.CreateProvider("VB")
    Dim myPar As New CompilerParameters()

    'add reference to System.Windows.Forms
    'добавляем ссылку на сборку, чтобы иметь доступ к MessagesBox
    myPar.ReferencedAssemblies.Add("System.Windows.Forms.dll")

    If RadioButton2.Checked Then
      'add reference to the current assembly
      'для вызова метода Kbyte, нужно добавить ссылку на текщую сборку
      myPar.ReferencedAssemblies.Add("DynamicCodeExample.exe")
    End If

    'компилируем
    Dim myResult As CompilerResults = myCode.CompileAssemblyFromSource(myPar, TextBox1.Text)
    If myResult.Errors.HasErrors Then
      'errors
      'какие-то ошибки
      Dim erros As New StringBuilder()

      For i As Integer = 0 To myResult.Errors.Count - 1
        erros.AppendLine(myResult.Errors(i).ErrorText)
      Next

      MsgBox(erros.ToString(), MsgBoxStyle.Critical)
      Return
    End If

    'no errors, get our class
    'ошибок нет, выдергиваем наш класс 
    Dim myAsm As Assembly = myResult.CompiledAssembly()
    Dim myCls As Object = myAsm.CreateInstance("Example")

    'execute method Run
    'выполняем метод Run
    If RadioButton1.Checked Then
      'вызов метода из динамичного класса с передачей ему параметров
      myCls.GetType().InvokeMember("Run", BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.Public, Nothing, myCls, New Object() {1, 2}) '1 и 2 - параметры, которые будут переданы в метод Run - x и y
    Else
      'вызов метода из динамичного класса с передачей ему текущего экземпляра класса (текушей формы) и последующим вызовом метода этого класса (формы)
      myCls.GetType().InvokeMember("Run", BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.Public, Nothing, myCls, New Object() {Me}) 'передаем текущую форму - Me
    End If
  End Sub

  Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
    If RadioButton1.Checked Then
      TextBox1.Text = File.ReadAllText("1.txt")
    Else
      TextBox1.Text = File.ReadAllText("2.txt")
    End If
  End Sub

  Public Sub Kbyte()
    MessageBox.Show("Hi! My name is Kbyte.Ru!", "Hi!")
    'MessageBox.Show("Привет! Меня зовут Kbyte.Ru!", "Ой!")
  End Sub

End Class