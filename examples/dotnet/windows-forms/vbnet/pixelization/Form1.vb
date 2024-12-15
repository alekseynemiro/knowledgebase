'Pixelization example by Aleksey Nemiro, 2013
'http://aleksey.nemiro.ru
'http://kbyte.ru
Imports System.Drawing.Imaging

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim tab As New TabControl()
    tab.Dock = DockStyle.Fill
    tab.TabPages.Add("Original")

    Dim pic As New PictureBox() With {.Left = 0, .Top = 0, .Width = 250, .Height = 135}
    pic.Image = Image.FromFile("logo250x135.gif")
    'pic.Image = Image.FromStream(New System.IO.MemoryStream( _
    '                             New System.Net.WebClient().DownloadData("http://s.codeproject.com/App_Themes/Std/Img/logo250x135.gif") _
    '                             ))
    tab.TabPages(tab.TabPages.Count - 1).Controls.Add(pic)

    For i As Integer = 1 To 8
      tab.TabPages.Add(String.Format("Pixelized {0}px", i * 4))
      Dim pic2 As New PictureBox() With {.Left = 0, .Top = 0, .Width = 250, .Height = 135}
      pic2.Image = Pixelization(pic.Image, i * 4)
      tab.TabPages(tab.TabPages.Count - 1).Controls.Add(pic2)
    Next

    Me.Controls.Add(tab)
  End Sub

  Private Function Pixelization(img As Bitmap, size As Integer) As Bitmap
    'create result image
    Dim result As New Bitmap(img.Width, img.Height)

    Try
      Dim g2 As Graphics = Graphics.FromImage(result)

      Dim pixWidth As Integer = size
      Dim pixHeight As Integer = size

      If pixWidth > size Then
        pixWidth = img.Width
      End If
      If pixHeight > size Then
        pixHeight = img.Height
      End If

      For x As Integer = 0 To img.Width Step pixWidth

        For y As Integer = 0 To img.Height Step pixHeight

          'get red, green and blue colors
          Dim ir As Integer? = Nothing, ig As Integer? = Nothing, ib As Integer? = Nothing
          For x2 As Integer = x To x + pixWidth - 1

            If x2 >= img.Width Then Exit For

            For y2 As Integer = y To y + pixHeight - 1

              If y2 >= img.Height Then Exit For

              Dim clr As Color = img.GetPixel(x2, y2)

              If Not ir.HasValue Then
                ir = 0 : ig = 0 : ib = 0
              End If

              ir += clr.R
              ig += clr.G
              ib += clr.B

            Next
          Next
          '//--

          'has color
          If ir.HasValue Then
            'calculate average color of a square
            ir \= pixWidth * pixHeight
            ig \= pixWidth * pixHeight
            ib \= pixWidth * pixHeight

            'draw "big pixel"
            g2.FillRectangle(New SolidBrush(Color.FromArgb(255, ir, ig, ib)), x, y, pixWidth, pixHeight)
          End If

        Next
      Next


    Catch ex As Exception
    End Try

    Return result
  End Function

End Class