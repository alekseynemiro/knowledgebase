namespace KbyteForumThread17354
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.button1 = new System.Windows.Forms.Button();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.flowLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(59, 3);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(67, 20);
      this.textBox1.TabIndex = 0;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 26);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(362, 236);
      this.dataGridView1.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(151, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "Remove";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.label1);
      this.flowLayoutPanel1.Controls.Add(this.textBox1);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 26);
      this.flowLayoutPanel1.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Left;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Columns:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // flowLayoutPanel2
      // 
      this.flowLayoutPanel2.AutoSize = true;
      this.flowLayoutPanel2.Controls.Add(this.label2);
      this.flowLayoutPanel2.Controls.Add(this.textBox2);
      this.flowLayoutPanel2.Controls.Add(this.button1);
      this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 233);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new System.Drawing.Size(362, 29);
      this.flowLayoutPanel2.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Left;
      this.label2.Location = new System.Drawing.Point(3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 29);
      this.label2.TabIndex = 3;
      this.label2.Text = "Min columns:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(78, 3);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(67, 20);
      this.textBox2.TabIndex = 4;
      this.textBox2.Text = "1";
      this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(362, 262);
      this.Controls.Add(this.flowLayoutPanel2);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.flowLayoutPanel1);
      this.MinimumSize = new System.Drawing.Size(378, 300);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel2.ResumeLayout(false);
      this.flowLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox2;
  }
}

