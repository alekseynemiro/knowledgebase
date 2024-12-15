'Решатель
'by Aleksey Nemiro
'http://aleksey.nemiro.ru
'http://kbyte.ru

Imports System.Reflection
Imports System.CodeDom.Compiler

Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim myCode As CodeDomProvider = CodeDomProvider.CreateProvider("VB")
    Dim myPar As New CompilerParameters()

    'make class for calculation
    'формируем виртуальный класс, в котором будет производиться расчет
    Dim myCodeBody As New System.Text.StringBuilder()

    myCodeBody.AppendLine("Public Class MyCalculator")
    myCodeBody.AppendLine("Public Function Calc() As System.Collections.Generic.List(Of Double)")
    myCodeBody.AppendLine("Dim result As New System.Collections.Generic.List(Of Double)") 'коллекция с результатами

    'make code with 100 random values
    'создаем 100 точек со случайными значениями
    'Dim points(99) As Double
    'Dim r As New Random()

    'For i As Integer = 0 To 10000
    'Dim x As Double = r.Next(0, 1000)
    'myCodeBody.AppendLine(String.Format("result.Add({0})", TextBox1.Text.ToLower().Replace("x", x).Replace(",", ".")))
    'Next

    myCodeBody.AppendLine(String.Format("result.Add({0})", TextBox1.Text.ToLower().Replace("x", TextBox2.Text).Replace(",", ".")))

    myCodeBody.AppendLine("Return result") 'возвращаем результат
    myCodeBody.AppendLine("End Function")
    myCodeBody.AppendLine("End Class")

    'compile
    'компилируем
    Dim myResult As CompilerResults = myCode.CompileAssemblyFromSource(myPar, myCodeBody.ToString())
    If myResult.Errors.HasErrors Then
      'errors
      'какие-то ошибки
      For i As Integer = 0 To myResult.Errors.Count - 1
        ListBox1.Items.Insert(0, myResult.Errors(i).ErrorText)
      Next
      Return
    End If

    'no erros, get class
    'ошибок нет, выдергиваем наш класс
    Dim myAsm As Assembly = myResult.CompiledAssembly()
    Dim myCls As Object = myAsm.CreateInstance("MyCalculator", True)

    'get result
    'получаем результат
    Dim result As System.Collections.Generic.List(Of Double) = myCls.Calc()

    'output result
    'выводим результат
    For Each rp As Double In result
      ListBox1.Items.Insert(0, rp)
    Next
  End Sub

End Class