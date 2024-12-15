using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace HexToFile
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
      if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

      var buffer = File.ReadAllText(openFileDialog1.FileName);
      if (Regex.Matches(buffer, "0x", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline).Count == 1)
      {
        buffer = Regex.Replace(buffer, "0x", "", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      }
      buffer = Regex.Replace(buffer, @"(?<type>0x|&H|%|\x5C\x27|\x5Cx|\x24){0,1}", "", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

      using (var file = new FileStream(saveFileDialog1.FileName, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
      {
        using (var writer = new BinaryWriter(file))
        {
          for (int i = 0; i < buffer.Length; i += 2)
          {
            if (i + 2 > buffer.Length) break;
            writer.Write(byte.Parse(buffer.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
          }
        }
      }

      MessageBox.Show(String.Format("Данные успешно записаны в файл \"{0}\".", Path.GetFileName(saveFileDialog1.FileName)), "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }

}