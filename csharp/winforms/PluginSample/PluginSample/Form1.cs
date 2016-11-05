using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PluginSample
{

  public partial class Form1 : Form
  {

    private string _CurrentFile = "";

    public Form1()
    {
      InitializeComponent();
    }

    private void mnuNew_Click(object sender, EventArgs e)
    {
      textBox1.Text = "";
    }

    private void mnuOpen_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        _CurrentFile = openFileDialog1.FileName;
        System.IO.StreamReader myRead = new System.IO.StreamReader(_CurrentFile, System.Text.Encoding.GetEncoding(1251));
        textBox1.Text = myRead.ReadToEnd();
        myRead.Close();
      }
    }

    private void mnuSave_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        _CurrentFile = saveFileDialog1.FileName;
        System.IO.StreamWriter myWrite = new System.IO.StreamWriter(_CurrentFile, false, System.Text.Encoding.GetEncoding(1251));
        myWrite.Write(textBox1.Text);
        myWrite.Close();
      }
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        if (MessageBox.Show("Are you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        // if (MessageBox.Show("Вы действительно хотие выйти из программы?", "Выход?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
          e.Cancel = true;
        }
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
      // openFileDialog1.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";
      // saveFileDialog1.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";
      LoadPlugins();
    }

    private void LoadPlugins()
    {
      string sPath = Application.StartupPath;
      List<IPlugin> lPlugins = new List<IPlugin>();

      foreach (string f in System.IO.Directory.GetFiles(sPath, "*.dll"))
      {
        System.Reflection.Assembly a = System.Reflection.Assembly.LoadFile(f);

        foreach (Type t in a.GetTypes())
        {
          foreach (Type i in t.GetInterfaces())
          {
            if (i.Equals(Type.GetType("PluginSample.IPlugin")))
            {
              IPlugin p = (IPlugin)Activator.CreateInstance(t);
              lPlugins.Add(p);
              p.Initialize(this);
              break;
            }
          }
        }
      }
    }

  }

}