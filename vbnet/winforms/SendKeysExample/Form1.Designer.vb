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
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(116, 25)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Send"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(12, 27)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(98, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "7 - 5"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(213, 65)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Button1)
    Me.Name = "Form1"
    Me.Text = "SendKeys"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
