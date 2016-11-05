using System;
using System.Windows.Forms;
using System.Data;

namespace SettingsExample
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.CountryId = comboBox1.SelectedValue.ToString();
      Properties.Settings.Default.Save();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      DataTable countries = new DataTable();
      countries.Columns.Add("id");
      countries.Columns.Add("name");

      countries.Rows.Add("RU", "Russia");
      countries.Rows.Add("UA", "Ukraine");
      countries.Rows.Add("BY", "Belarus");
      countries.Rows.Add("KZ", "Kazakhstan");

      comboBox1.DisplayMember = "name";
      comboBox1.ValueMember = "id";
      comboBox1.DataSource = countries;

      comboBox1.SelectedValue = Properties.Settings.Default.CountryId;
    }

  }

}