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
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = Global.RandomTextGenerator.My.Resources.Resources.kbyte88x31_2
    Me.PictureBox1.Location = New System.Drawing.Point(288, 221)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(88, 31)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.Button1.Location = New System.Drawing.Point(12, 12)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(364, 36)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Генерировать речь!"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(12, 63)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TextBox1.Size = New System.Drawing.Size(364, 132)
    Me.TextBox1.TabIndex = 2
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(390, 263)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.PictureBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Генератор речи"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
