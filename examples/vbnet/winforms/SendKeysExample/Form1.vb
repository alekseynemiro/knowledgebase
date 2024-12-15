Public Class Form1

  Declare Auto Function FindWindow Lib "USER32.DLL" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
  Declare Auto Function SetForegroundWindow Lib "USER32.DLL" (ByVal hWnd As IntPtr) As Boolean

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim calculatorHandle As IntPtr = FindWindow("CalcFrame", "Калькулятор") 'в этом месте может потребоваться изменение, в зависимости от системы

    If calculatorHandle = IntPtr.Zero Then
      Process.Start("calc")
      calculatorHandle = FindWindow("CalcFrame", "Калькулятор")
      Threading.Thread.Sleep(1000)
    End If

    SetForegroundWindow(calculatorHandle)

    For Each ch As Char In TextBox1.Text
      If ch = " " Then Continue For
      SendKeys.SendWait(ch)
    Next

    SendKeys.SendWait("=")
  End Sub

End Class
