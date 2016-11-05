/*
 * Copyright © 2016, Aleksey Nemiro
 * https://github.com/alekseynemiro
 * http://nemiro.developer.cards
 * Licensed under the MIT license
 */
namespace TableLayoutPanelGenerator
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
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
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.LabelColumns = new System.Windows.Forms.Label();
      this.Columns = new System.Windows.Forms.NumericUpDown();
      this.LabelRows = new System.Windows.Forms.Label();
      this.Rows = new System.Windows.Forms.NumericUpDown();
      this.MakeTable = new System.Windows.Forms.Button();
      this.TableContainer = new System.Windows.Forms.Panel();
      this.flowLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Columns)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Rows)).BeginInit();
      this.SuspendLayout();
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 250;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.LabelColumns);
      this.flowLayoutPanel1.Controls.Add(this.Columns);
      this.flowLayoutPanel1.Controls.Add(this.LabelRows);
      this.flowLayoutPanel1.Controls.Add(this.Rows);
      this.flowLayoutPanel1.Controls.Add(this.MakeTable);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(475, 29);
      this.flowLayoutPanel1.TabIndex = 6;
      // 
      // LabelColumns
      // 
      this.LabelColumns.AutoSize = true;
      this.LabelColumns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelColumns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.LabelColumns.Location = new System.Drawing.Point(3, 0);
      this.LabelColumns.Name = "LabelColumns";
      this.LabelColumns.Size = new System.Drawing.Size(50, 29);
      this.LabelColumns.TabIndex = 0;
      this.LabelColumns.Text = "Columns:";
      this.LabelColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // Columns
      // 
      this.Columns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Columns.Location = new System.Drawing.Point(59, 3);
      this.Columns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.Columns.Name = "Columns";
      this.Columns.Size = new System.Drawing.Size(49, 20);
      this.Columns.TabIndex = 1;
      this.Columns.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      // 
      // LabelRows
      // 
      this.LabelRows.AutoSize = true;
      this.LabelRows.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelRows.Location = new System.Drawing.Point(114, 0);
      this.LabelRows.Name = "LabelRows";
      this.LabelRows.Size = new System.Drawing.Size(37, 29);
      this.LabelRows.TabIndex = 2;
      this.LabelRows.Text = "Rows:";
      this.LabelRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // Rows
      // 
      this.Rows.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Rows.Location = new System.Drawing.Point(157, 3);
      this.Rows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.Rows.Name = "Rows";
      this.Rows.Size = new System.Drawing.Size(49, 20);
      this.Rows.TabIndex = 3;
      this.Rows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      // 
      // MakeTable
      // 
      this.MakeTable.AutoSize = true;
      this.MakeTable.Dock = System.Windows.Forms.DockStyle.Left;
      this.MakeTable.Location = new System.Drawing.Point(212, 3);
      this.MakeTable.Name = "MakeTable";
      this.MakeTable.Size = new System.Drawing.Size(75, 23);
      this.MakeTable.TabIndex = 4;
      this.MakeTable.Text = "Make table";
      this.MakeTable.UseVisualStyleBackColor = true;
      this.MakeTable.Click += new System.EventHandler(this.MakeTable_Click);
      // 
      // TableContainer
      // 
      this.TableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TableContainer.Location = new System.Drawing.Point(0, 29);
      this.TableContainer.Name = "TableContainer";
      this.TableContainer.Size = new System.Drawing.Size(475, 272);
      this.TableContainer.TabIndex = 7;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(475, 301);
      this.Controls.Add(this.TableContainer);
      this.Controls.Add(this.flowLayoutPanel1);
      this.MinimumSize = new System.Drawing.Size(420, 128);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form42";
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Columns)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Rows)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label LabelColumns;
    private System.Windows.Forms.NumericUpDown Columns;
    private System.Windows.Forms.Label LabelRows;
    private System.Windows.Forms.NumericUpDown Rows;
    private System.Windows.Forms.Button MakeTable;
    private System.Windows.Forms.Panel TableContainer;
  }
}

