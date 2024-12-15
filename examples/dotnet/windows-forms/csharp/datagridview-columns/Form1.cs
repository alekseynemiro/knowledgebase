using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace KbyteForumThread17354
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      // is not numeric
      // проверяем, что введеный символ является числом
      if (!Char.IsDigit(e.KeyChar))
      {
        // exit
        // если не число, то отменяем ввод символа в поле
        e.Handled = true;
        return;
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      // remove all columns
      // удаляем все колонки
      dataGridView1.Columns.Clear();

      if (String.IsNullOrEmpty(textBox1.Text)) { return; }

      int max = Convert.ToInt32(textBox1.Text);

      // add columns
      // добавляем колонки
      for (int i = 1; i <= max; i++)
      {
        dataGridView1.Columns.Add(String.Format("Column{0}", i), String.Format("Column #{0}", i));
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int min = 0;

      int.TryParse(textBox2.Text, out min);

      while (dataGridView1.Columns.Count > min)
      {
        dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
      }
    }

  }

}