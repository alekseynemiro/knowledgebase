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
    Me.TreeView1 = New System.Windows.Forms.TreeView()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SuspendLayout()
    '
    'TreeView1
    '
    Me.TreeView1.Location = New System.Drawing.Point(12, 41)
    Me.TreeView1.Name = "TreeView1"
    Me.TreeView1.Size = New System.Drawing.Size(256, 129)
    Me.TreeView1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(12, 12)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(125, 23)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Add node"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(12, 176)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(125, 23)
    Me.Button2.TabIndex = 1
    Me.Button2.Text = "Save"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(143, 176)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(125, 23)
    Me.Button3.TabIndex = 1
    Me.Button3.Text = "Open"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'SaveFileDialog1
    '
    Me.SaveFileDialog1.Filter = "Text files (*.txt) | *.txt"
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.Filter = "Text files (*.txt) | *.txt"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(283, 209)
    Me.Controls.Add(Me.Button3)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.TreeView1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
