Public Class Form1

  Private _LastX As Integer
  Private _LastY As Integer

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    _LastX = Cursor.Position.X
    _LastY = Cursor.Position.Y
  End Sub

  Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    If _LastX = Cursor.Position.X AndAlso _LastY = Cursor.Position.Y Then
      If Not Me.Text = "Пользователь не держится за мышку" Then
        Me.PictureBox1.Image = My.Resources.zzz
      End If

      Me.Text = "Пользователь не держится за мышку"
    Else
      If Not Me.Text = "Пользователь держится за мышку" Then
        Me.PictureBox1.Image = My.Resources.mouse
      End If

      Me.Text = "Пользователь держится за мышку"
    End If

    'запоминаем текущую позицию
    _LastX = Cursor.Position.X
    _LastY = Cursor.Position.Y
  End Sub

End Class
