'Overlay example by Aleksey Nemiro, 2013
'http://aleksey.nemiro.ru
'http://kbyte.ru

Imports System.Drawing.Imaging

Public Class Form1

  Private _bmp As Bitmap
  Private _start As Point?
  Private _end As Point?

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
    _start = e.Location
    _end = e.Location
    Me.Refresh()
  End Sub

  Private Sub Form1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    'selecting
    If _start.HasValue Then
      _end = e.Location
      Me.Refresh()
    End If
  End Sub

  Private Sub Form1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    'end selection
    _start = Nothing
    _end = Nothing
    Me.Refresh()
  End Sub

  Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    Dim g As Graphics = e.Graphics
    'draw image
    g.DrawImage(_bmp, 0, 0)

    'create region
    Dim r As New Region(New Rectangle(0, 0, _bmp.Width, _bmp.Height))

    'highlight the selected area
    If _start.HasValue AndAlso _end.HasValue Then
      Dim p As New Pen(Brushes.Red) 'create pen
      Dim rec As Rectangle = Rectangle.Empty
      Dim x, y, w, h As Integer
      If _end.Value.X - _start.Value.X < 0 Then
        x = _end.Value.X
        w = _start.Value.X - _end.Value.X
      Else
        x = _start.Value.X
        w = _end.Value.X - _start.Value.X
      End If
      If _end.Value.Y - _start.Value.Y < 0 Then
        y = _end.Value.Y
        h = _start.Value.Y - _end.Value.Y
      Else
        y = _start.Value.Y
        h = _end.Value.Y - _start.Value.Y
      End If
      rec = New Rectangle(x, y, w, h)

      If Not rec = Rectangle.Empty Then
        r.Exclude(rec)
        g.DrawRectangle(p, rec)
      End If
    End If

    'draw overlay
    Dim b As SolidBrush = New SolidBrush(Color.FromArgb(100, Color.White)) 'create brush
    g.FillRegion(b, r) 'overlay
  End Sub

End Class