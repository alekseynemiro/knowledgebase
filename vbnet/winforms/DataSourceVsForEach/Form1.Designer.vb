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
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
    Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
    Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.Size = New System.Drawing.Size(594, 324)
    Me.DataGridView1.TabIndex = 0
    '
    'Column1
    '
    Me.Column1.DataPropertyName = "title"
    Me.Column1.HeaderText = "Заголовок"
    Me.Column1.Name = "Column1"
    Me.Column1.ReadOnly = True
    '
    'Column2
    '
    Me.Column2.DataPropertyName = "date_created"
    Me.Column2.HeaderText = "Дата"
    Me.Column2.Name = "Column2"
    Me.Column2.ReadOnly = True
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(81, 70)
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripMenuItem2.Text = "1"
    '
    'ToolStripMenuItem3
    '
    Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
    Me.ToolStripMenuItem3.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripMenuItem3.Text = "2"
    '
    'ToolStripMenuItem4
    '
    Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
    Me.ToolStripMenuItem4.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripMenuItem4.Text = "3"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(361, 64)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(183, 23)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "DataSource"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(361, 93)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(183, 23)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "For Each"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(361, 122)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(183, 23)
    Me.Button3.TabIndex = 3
    Me.Button3.Text = "For Each + Invisible"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(594, 324)
    Me.Controls.Add(Me.Button3)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.DataGridView1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
