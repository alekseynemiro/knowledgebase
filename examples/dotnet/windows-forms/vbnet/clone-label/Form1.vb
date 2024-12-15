Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim prev As Label = CType(Me.Panel1.Controls(Panel1.Controls.Count - 1), Label)

    Dim lbl As New Label()

    Dim arr() As String = {"Text", "ForeColor", "BackColor", "BorderStyle", "Visible", "AutoSize"}
    Dim properties() As System.Reflection.PropertyInfo = lbl.GetType().GetProperties()

    For Each s As String In arr
      Dim propertyName As String = s
      Dim prop As System.Reflection.PropertyInfo = Array.Find(properties, Function(p) p.Name = propertyName)
      prop.SetValue(lbl, prop.GetValue(prev, Nothing), Nothing)
    Next

    lbl.Location = New Point(prev.Location.X, prev.Location.Y + prev.Height + 2)

    Me.Panel1.Controls.Add(lbl)
  End Sub

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim properties() As System.Reflection.PropertyInfo
    'получаем тип класса, в данном случае это Form1
    Dim t As Type = GetType(Form)
    'получаем список свойств класса
    properties = t.GetProperties()
  End Sub

End Class