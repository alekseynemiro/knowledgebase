using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxDisableKeys
{

  public partial class Form1 : Form
  {

    // prohibited chars
    private char[] DisabledChars = 
    { 
      '0', '1', '2', '3', '4', '5',
      '6', '7', '8', '9', 'V', 'v',
      'Z', 'z', 'G', 'g', 'B', 'b'
    };

    // prohibited keys
    private Keys[] DisabledKeys = { Keys.Insert, Keys.F1, Keys.F2, Keys.F3 };

    public Form1()
    {
      InitializeComponent();
    }

    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      lblKey.Text = e.KeyCode.ToString();

      if (Array.IndexOf(this.DisabledKeys, e.KeyCode) != -1)
      {
        e.Handled = true;
        lblStatus.Text = "[cancelled]";
        lblStatus.ForeColor = Color.Red;
      }
      else
      {
        lblStatus.Text = "[ok]";
        lblStatus.ForeColor = Color.Green;
      }
    }

    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      lblKey.Text = e.KeyChar.ToString();

      if (Array.IndexOf(this.DisabledChars, e.KeyChar) != -1)
      {
        e.Handled = true;
        lblStatus.Text = "[cancelled]";
        lblStatus.ForeColor = Color.Red;
      }
      else
      {
        lblStatus.Text = "[ok]";
        lblStatus.ForeColor = Color.Green;
      }
    }

  }

}