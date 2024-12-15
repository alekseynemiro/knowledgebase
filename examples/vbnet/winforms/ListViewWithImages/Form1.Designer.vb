<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.ListView1 = New System.Windows.Forms.ListView()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.SuspendLayout()
    '
    'ListView1
    '
    Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListView1.Location = New System.Drawing.Point(0, 0)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(649, 381)
    Me.ListView1.TabIndex = 0
    Me.ListView1.UseCompatibleStateImageBehavior = False
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "kbyteru88x31blk.gif")
    Me.ImageList1.Images.SetKeyName(1, "yolper88x31.gif")
    Me.ImageList1.Images.SetKeyName(2, "flud_nelzya.gif")
    Me.ImageList1.Images.SetKeyName(3, "tema_zakrita.gif")
    Me.ImageList1.Images.SetKeyName(4, "ne_huliganit.gif")
    Me.ImageList1.Images.SetKeyName(5, "fans.gif")
    Me.ImageList1.Images.SetKeyName(6, "beer.gif")
    Me.ImageList1.Images.SetKeyName(7, "santa2.gif")
    Me.ImageList1.Images.SetKeyName(8, "ded_snegurochka2.gif")
    Me.ImageList1.Images.SetKeyName(9, "biggrin24.gif")
    Me.ImageList1.Images.SetKeyName(10, "ph34r.gif")
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(649, 381)
    Me.Controls.Add(Me.ListView1)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ListView with images"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
