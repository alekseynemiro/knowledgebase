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
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.tbInclude = New System.Windows.Forms.TextBox()
    Me.tbExclude = New System.Windows.Forms.TextBox()
    Me.tbMax = New System.Windows.Forms.TextBox()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.tbFileName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(23, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(208, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Включить указанные символы в поиск:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(23, 58)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(227, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Исключить указанные символы из поиска:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(23, 106)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(122, 13)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Количество символов:"
    '
    'tbInclude
    '
    Me.tbInclude.Location = New System.Drawing.Point(26, 30)
    Me.tbInclude.Name = "tbInclude"
    Me.tbInclude.Size = New System.Drawing.Size(209, 20)
    Me.tbInclude.TabIndex = 1
    Me.tbInclude.Text = "ауиеяобвплтн"
    '
    'tbExclude
    '
    Me.tbExclude.Location = New System.Drawing.Point(26, 74)
    Me.tbExclude.Name = "tbExclude"
    Me.tbExclude.Size = New System.Drawing.Size(209, 20)
    Me.tbExclude.TabIndex = 2
    Me.tbExclude.Text = "йцкгшщзхъфырджэчсмью"
    '
    'tbMax
    '
    Me.tbMax.Location = New System.Drawing.Point(186, 103)
    Me.tbMax.MaxLength = 10
    Me.tbMax.Name = "tbMax"
    Me.tbMax.Size = New System.Drawing.Size(49, 20)
    Me.tbMax.TabIndex = 3
    Me.tbMax.Text = "5"
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(25, 262)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(210, 95)
    Me.ListBox1.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(23, 135)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Словарь:"
    '
    'tbFileName
    '
    Me.tbFileName.Location = New System.Drawing.Point(26, 151)
    Me.tbFileName.Name = "tbFileName"
    Me.tbFileName.ReadOnly = True
    Me.tbFileName.Size = New System.Drawing.Size(128, 20)
    Me.tbFileName.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(23, 246)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(62, 13)
    Me.Label5.TabIndex = 0
    Me.Label5.Text = "Результат:"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(160, 148)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 6
    Me.Button1.Text = "Выбрать"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.Button2.Location = New System.Drawing.Point(25, 203)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(119, 23)
    Me.Button2.TabIndex = 7
    Me.Button2.Text = "Пуск!"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.Filter = "Текстовые документы (*.txt) | *.txt"
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(285, 392)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.tbFileName)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.tbMax)
    Me.Controls.Add(Me.tbExclude)
    Me.Controls.Add(Me.tbInclude)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Name = "Form1"
    Me.Text = "SearchWords"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents tbInclude As System.Windows.Forms.TextBox
  Friend WithEvents tbExclude As System.Windows.Forms.TextBox
  Friend WithEvents tbMax As System.Windows.Forms.TextBox
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents tbFileName As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
