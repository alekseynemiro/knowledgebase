'Free-form area selection by Aleksey Nemiro, 2013
'http://aleksey.nemiro.ru
'http://kbyte.ru
Imports System.Drawing.Imaging

Public Class Form1

  Private _bmp As Bitmap
  Private _points As List(Of Point)

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'to avoid flicker
    Me.DoubleBuffered = True
    ' get primary screen
    Dim s As Screen = Screen.PrimaryScreen
    ' create bitmap
    _bmp = New Bitmap(s.Bounds.Width, s.Bounds.Height, PixelFormat.Format32bppArgb)
    ' create graphics from bitmap
    Dim g As Graphics = Graphics.FromImage(_bmp)
    ' copy screen to bitmap
    g.CopyFromScreen(s.Bounds.X, s.Bounds.Y, 0, 0, s.Bounds.Size, CopyPixelOperation.SourceCopy)
  End Sub

  Private Sub Form1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    'start selection
    _points = New List(Of Point)
    _points.Add(e.Location)
    Me.Refresh()
  End Sub

  Private Sub Form1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    'selecting
    If _points IsNot Nothing Then
      _points.Add(e.Location)
      Me.Refresh()
    End If
  End Sub

  Private Sub Form1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    'end selection
    _points = Nothing
    Me.Refresh()
  End Sub

  Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    Dim g As Graphics = e.Graphics
    'draw image
    g.DrawImage(_bmp, 0, 0)

    'create region
    Dim r As New Region(New Rectangle(0, 0, _bmp.Width, _bmp.Height))

    'highlight the selected area
    If _points IsNot Nothing AndAlso _points.Count > 1 Then
      Dim p As New Pen(Brushes.Red)
      Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
      gp.AddCurve(_points.ToArray())
      'r.Exclude(gp)
      g.DrawPath(p, gp)
    End If

    'draw overlay
    Dim b As SolidBrush = New SolidBrush(Color.FromArgb(100, Color.White)) 'create brush
    g.FillRegion(b, r) 'overlay
  End Sub

End Class
