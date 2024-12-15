/*
 * Copyright © 2016, Aleksey Nemiro
 * https://github.com/alekseynemiro
 * http://nemiro.developer.cards
 * Licensed under the MIT license
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TableLayoutPanelGenerator
{

  public partial class Form1 : Form
  {

    private Random rnd = new Random(DateTime.Now.Millisecond);

    public Form1()
    {
      InitializeComponent();
    }

    private void MakeTable_Click(object sender, EventArgs e)
    {
      // temporarily suspend the layout logic for the table container
      TableContainer.SuspendLayout();

      // remove old table
      // удаляем предыдущую таблицу
      TableContainer.Controls.Clear();

      // create new table
      // создаем новую
      var tableLayoutPanel = new TableLayoutPanel();
      tableLayoutPanel.Dock = DockStyle.Fill;
      tableLayoutPanel.Location = new Point(0, 0);
      tableLayoutPanel.Visible = true;

      tableLayoutPanel.ColumnCount = Convert.ToInt32(Columns.Value);
      tableLayoutPanel.RowCount = Convert.ToInt32(Rows.Value);

      // random number generator to fill panels
      // генератор случайных числе для раскраски панелей (чтобы было видно)
      var rnd = new Random(DateTime.Now.Millisecond);

      // calculating size of columns and rows (percentage)
      // определяем размер одной колонки и строки, в процентах
      int width = 100 / tableLayoutPanel.ColumnCount;
      int height = 100 / tableLayoutPanel.RowCount;

      // Console.WriteLine("{0}x{1}", width, height);

      // add columns and rows
      // добавляем колонки и строки
      for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
      {
        // add column
        // добавляем колонку
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

        for (int row = 0; row < tableLayoutPanel.RowCount; row++)
        {
          // add row
          // добавляем строку
          if (col == 0)
          {
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, height));
          }

          // add colored panel
          // добавляем цветную панель, чтобы было видно ячейку в таблице
          var panel = new Panel();
          panel.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
          panel.Dock = DockStyle.Fill;
          tableLayoutPanel.Controls.Add(panel, col, row);
        }
      }

      // add table to container
      // добавляем таблицу в контейнер
      TableContainer.Controls.Add(tableLayoutPanel);

      // resume usual layout logic
      TableContainer.ResumeLayout();
    }

  }

}