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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
    CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(12, 168)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(100, 23)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Play"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(118, 168)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(97, 23)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "Stop"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(12, 41)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(371, 121)
    Me.ListBox1.TabIndex = 3
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(12, 12)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(100, 23)
    Me.Button3.TabIndex = 4
    Me.Button3.Text = "Add"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.Filter = "Files mp3 (*.mp3)|*.mp3|All files (*.*)| *.*"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 207)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 13)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Label1"
    '
    'AxWindowsMediaPlayer1
    '
    Me.AxWindowsMediaPlayer1.Enabled = True
    Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(406, 208)
    Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
    Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
    Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(253, 161)
    Me.AxWindowsMediaPlayer1.TabIndex = 0
    Me.AxWindowsMediaPlayer1.Visible = False
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(395, 236)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Button3)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.AxWindowsMediaPlayer1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
