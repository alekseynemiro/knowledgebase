Public Class Form1

  Dim CustomControl11 As New CustomControl1()

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    CustomControl11.Top = 10
    CustomControl11.Left = 10
    CustomControl11.Width = 300
    CustomControl11.Height = 32

    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.White})
    CustomControl11.Items.Add(New CustomControl1.Item() With {.Color = Color.Red})

    Me.Controls.Add(CustomControl11)

    Timer1.Enabled = True
  End Sub

  Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    CustomControl11.Value += 1

    If CustomControl11.Value = CustomControl11.Max Then
      Timer1.Enabled = False
    End If
  End Sub

End Class
