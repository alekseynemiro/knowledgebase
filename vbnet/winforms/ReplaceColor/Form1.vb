Imports System.Drawing

Public Class Form1

  Private _Bmp As Bitmap

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _Bmp = New Bitmap(PictureBox1.Image)
  End Sub

  Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
    Panel1.BackColor = _Bmp.GetPixel(e.X, e.Y)
  End Sub

  Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
    Panel2.BackColor = _Bmp.GetPixel(e.X, e.Y)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      Button1.BackColor = ColorDialog1.Color
    End If
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim newBmp As New Bitmap(_Bmp)
    Dim g As Graphics = Graphics.FromImage(newBmp)

    'создаем карту цветов
    Dim colorsMap(0) As Imaging.ColorMap
    colorsMap(0) = New Imaging.ColorMap()
    colorsMap(0).OldColor = Panel2.BackColor 'какой чвет менять
    colorsMap(0).NewColor = Button1.BackColor 'на какой

    'устанавливаем параметры прорисовки
    Dim myImageAttributes As New Imaging.ImageAttributes()
    myImageAttributes.SetRemapTable(colorsMap)

    'рисуем
    g.DrawImage(newBmp, New Rectangle(0, 0, newBmp.Width, newBmp.Height), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel, myImageAttributes)

    PictureBox2.Image = newBmp
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    Process.Start(LinkLabel1.Text)
  End Sub

End Class