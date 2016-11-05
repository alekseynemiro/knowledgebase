namespace SettingsExample
{
  partial class Form1
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "First name:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Last name:";
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Checked = global::SettingsExample.Properties.Settings.Default.VBNet;
      this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SettingsExample.Properties.Settings.Default, "VBNet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox2.Location = new System.Drawing.Point(16, 181);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(111, 17);
      this.checkBox2.TabIndex = 5;
      this.checkBox2.Text = "Visual Basic .NET";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Checked = global::SettingsExample.Properties.Settings.Default.CSharp;
      this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SettingsExample.Properties.Settings.Default, "CSharp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Location = new System.Drawing.Point(16, 158);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(40, 17);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "C#";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // textBox2
      // 
      this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SettingsExample.Properties.Settings.Default, "LastName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.textBox2.Location = new System.Drawing.Point(16, 74);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(177, 20);
      this.textBox2.TabIndex = 3;
      this.textBox2.Text = global::SettingsExample.Properties.Settings.Default.LastName;
      // 
      // textBox1
      // 
      this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SettingsExample.Properties.Settings.Default, "FirstName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.textBox1.Location = new System.Drawing.Point(16, 25);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(177, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = global::SettingsExample.Properties.Settings.Default.FirstName;
      // 
      // comboBox1
      // 
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(16, 122);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(177, 21);
      this.comboBox1.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 106);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(46, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Country:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(207, 213);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label3;
  }
}

