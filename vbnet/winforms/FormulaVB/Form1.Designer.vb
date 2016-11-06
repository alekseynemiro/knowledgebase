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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(55, 27)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Formula:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(129, 27)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(233, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "12^(-2)*x^9+12^(-4)*x^8"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(55, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(17, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "X:"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(129, 49)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(233, 20)
    Me.TextBox2.TabIndex = 1
    Me.TextBox2.Text = "2"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(55, 117)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 13)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Result:"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(129, 75)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 2
    Me.Button1.Text = "Solve"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(58, 133)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(304, 121)
    Me.ListBox1.TabIndex = 3
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(431, 284)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "FormulaVB by Aleksey Nemiro (http://kbyte.ru)"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

End Class
