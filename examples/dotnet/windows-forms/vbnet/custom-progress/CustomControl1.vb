Public Class CustomControl1

  Public Property Items As ItemCollection

  Private _Value As Integer = 0

  Public Property Value As Integer
    Get
      Return _Value
    End Get
    Set(value As Integer)
      _Value = value
      Me.Refresh()
    End Set
  End Property

  Public Property Max As Integer = 100

  Public Sub New()
    InitializeComponent()
    Me.BackColor = Color.White
    Me.Items = New ItemCollection()
  End Sub

  Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    MyBase.OnPaint(e)

    If Me.Max <= 0 Then Return

    Dim g As Graphics = e.Graphics

    Dim x As Integer = 0, w As Integer = ((100 / Me.Items.Count) * Me.Width) / 100
    Dim vx As Integer = (((Me.Value * 100) / Me.Max) * Me.Width) / 100

    For Each itm As Item In Me.Items

      g.FillRectangle(New SolidBrush(itm.Color), x, 0, w, Me.Height)

      g.FillRectangle(New SolidBrush(Color.Black), vx, 0, 5, Me.Height)

      x += w
    Next

  End Sub

  Public Class ItemCollection
    Inherits List(Of Item)
  End Class

  Public Class Item

    Public Property Color As Color = Color.White

  End Class

End Class