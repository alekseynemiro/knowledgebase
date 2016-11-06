<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.Button1 = New System.Windows.Forms.Button
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(384, 428)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(76, 20)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Выход"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.TextBox1.Location = New System.Drawing.Point(98, 291)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TextBox1.Size = New System.Drawing.Size(362, 135)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = resources.GetString("TextBox1.Text")
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackgroundImage = Global.FormiusPolneishius.My.Resources.Resources._1
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.ClientSize = New System.Drawing.Size(580, 576)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Button1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.TransparencyKey = System.Drawing.Color.White
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
