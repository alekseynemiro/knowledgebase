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
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.PictureBox2 = New System.Windows.Forms.PictureBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = Global.ReplaceColor.My.Resources.Resources.kbyte305x130
    Me.PictureBox1.Location = New System.Drawing.Point(12, 25)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(305, 130)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'PictureBox2
    '
    Me.PictureBox2.Image = Global.ReplaceColor.My.Resources.Resources.kbyte305x130
    Me.PictureBox2.InitialImage = Nothing
    Me.PictureBox2.Location = New System.Drawing.Point(15, 262)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(305, 130)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox2.TabIndex = 1
    Me.PictureBox2.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 163)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(114, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Color under the cursor:"
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Location = New System.Drawing.Point(126, 161)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(18, 18)
    Me.Panel1.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(9, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(242, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Move your mouse over the image to select a color"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 185)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(78, 13)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Selected color:"
    '
    'Panel2
    '
    Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel2.Location = New System.Drawing.Point(126, 185)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(18, 18)
    Me.Panel2.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 209)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(62, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Replace to:"
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.Black
    Me.Button1.Location = New System.Drawing.Point(126, 205)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(20, 21)
    Me.Button1.TabIndex = 4
    Me.Button1.UseVisualStyleBackColor = False
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(152, 204)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(80, 22)
    Me.Button2.TabIndex = 5
    Me.Button2.Text = "Replace!"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 246)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "Result:"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 418)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(110, 13)
    Me.Label6.TabIndex = 6
    Me.Label6.Text = "Aleksey Nemiro, 2011"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Location = New System.Drawing.Point(244, 418)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(76, 13)
    Me.LinkLabel1.TabIndex = 7
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "http://kbyte.ru"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(333, 445)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox2)
    Me.Controls.Add(Me.PictureBox1)
    Me.MaximizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ReplaceColor"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

End Class
