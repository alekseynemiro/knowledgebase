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
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(12, 73)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(121, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Select file"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(12, 22)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(260, 23)
    Me.ProgressBar1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(86, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Please select file"
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 262)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.Button1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
