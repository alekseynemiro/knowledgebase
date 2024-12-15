'Copyright © 2012, Aleksey Nemiro
'The MIT License (MIT)

'Простой пример прорисовки сетки на форме и определения клетки, над которой находится курсор
'Автор: Алексей Немиро
'http://aleksey.nemiro.ru
'http://kbyte.ru

Public Class Form1

  Private _X, _Y As Integer

  'maximum number of cells
  'максимальное число клеток
  Private _Cells As Integer = 10

  'width and height of one cell
  'ширина и высота одной клетки
  Private _CellSizeWidth, _CellSizeHeight As Integer

  Private Sub Form1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    _X = (e.X \ _CellSizeWidth)
    _Y = (e.Y \ _CellSizeHeight)

    Me.Text = String.Format("{0}x{1}", _X, _Y)

    'redraw me
    'перерисовываем сетку
    Me.Refresh()
  End Sub

  Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    'drawing cells
    'рисуем стеку
    'это правильней делать и линиями, но квадратики проще понять :)
    For x As Integer = 0 To _Cells - 1
      For y As Integer = 0 To _Cells - 1
        If _X = x AndAlso _Y = y Then
          'если x и y равен x и у выбранной клетки, рисуем синий квадратик
          e.Graphics.FillRectangle(Brushes.Blue, x * _CellSizeWidth, y * _CellSizeHeight, _CellSizeWidth, _CellSizeHeight)
        Else
          'если нет, рисуем пустой квадратик
          e.Graphics.DrawRectangle(Pens.Black, x * _CellSizeWidth, y * _CellSizeHeight, _CellSizeWidth, _CellSizeHeight)
        End If
      Next
    Next
  End Sub

  Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
    'determine the size of cell
    'определяем размер клетки
    _CellSizeWidth = (Me.ClientSize.Width * 1) / _Cells
    _CellSizeHeight = (Me.ClientSize.Height * 1) / _Cells

    'redraw me
    'перерисовываем сетку
    Me.Refresh()
  End Sub

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'double buffering to eliminate flicker
    'двойная буферизация, чтобы исключить мерцание при прорисовке клеток
    Me.DoubleBuffered = True
  End Sub

End Class