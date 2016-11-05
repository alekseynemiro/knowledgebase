using System;
using System.Data;
using System.Windows.Forms;

namespace DataGridViewSelectRows
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // add random data
      // заполняем dataGridView случайными данными, для примера
      DataTable table = new DataTable();
      table.Columns.Add("Column 1");
      table.Columns.Add("Column 2");
      table.Columns.Add("Column 3");

      for (int i = 0; i <= 100; i++)
      {
        table.Rows.Add(i, DateTime.Now, Guid.NewGuid());
      }

      dataGridView1.DataSource = table;

      // настраиваем dataGridView1
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      // select rows
      // выбираем строки
      for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
      {
        if (dataGridView1.Rows[i].Cells[0].FormattedValue.ToString().Contains("1"))
        {
          dataGridView1.Rows[i].Selected = true;
        }
        else
        {
          dataGridView1.Rows[i].Selected = false;
        }
      }
    }

  }

}