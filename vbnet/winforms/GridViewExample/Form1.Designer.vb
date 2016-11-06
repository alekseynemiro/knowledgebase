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
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cmbRows = New System.Windows.Forms.ComboBox()
    Me.cmbColumns = New System.Windows.Forms.ComboBox()
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.FlowLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.AllowUserToDeleteRows = False
    Me.DataGridView1.AllowUserToResizeColumns = False
    Me.DataGridView1.AllowUserToResizeRows = False
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.ColumnHeadersVisible = False
    Me.DataGridView1.Location = New System.Drawing.Point(12, 49)
    Me.DataGridView1.MultiSelect = False
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.RowHeadersVisible = False
    Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.DataGridView1.Size = New System.Drawing.Size(430, 207)
    Me.DataGridView1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
    Me.Label1.Location = New System.Drawing.Point(3, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(50, 29)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Columns:"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
    Me.Label2.Location = New System.Drawing.Point(136, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(37, 29)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Rows:"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'cmbRows
    '
    Me.cmbRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbRows.FormattingEnabled = True
    Me.cmbRows.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
    Me.cmbRows.Location = New System.Drawing.Point(179, 3)
    Me.cmbRows.Name = "cmbRows"
    Me.cmbRows.Size = New System.Drawing.Size(71, 21)
    Me.cmbRows.TabIndex = 2
    '
    'cmbColumns
    '
    Me.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbColumns.FormattingEnabled = True
    Me.cmbColumns.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
    Me.cmbColumns.Location = New System.Drawing.Point(59, 3)
    Me.cmbColumns.Name = "cmbColumns"
    Me.cmbColumns.Size = New System.Drawing.Size(71, 21)
    Me.cmbColumns.TabIndex = 2
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
    Me.FlowLayoutPanel1.Controls.Add(Me.cmbColumns)
    Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
    Me.FlowLayoutPanel1.Controls.Add(Me.cmbRows)
    Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 13)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(430, 30)
    Me.FlowLayoutPanel1.TabIndex = 3
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(256, 3)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 3
    Me.Button1.Text = "Make"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(12, 262)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(133, 23)
    Me.Button2.TabIndex = 4
    Me.Button2.Text = "Make array"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(12, 291)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ReadOnly = True
    Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TextBox1.Size = New System.Drawing.Size(430, 86)
    Me.TextBox1.TabIndex = 5
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(463, 389)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.FlowLayoutPanel1)
    Me.Controls.Add(Me.DataGridView1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.FlowLayoutPanel1.ResumeLayout(False)
    Me.FlowLayoutPanel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cmbRows As System.Windows.Forms.ComboBox
  Friend WithEvents cmbColumns As System.Windows.Forms.ComboBox
  Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
