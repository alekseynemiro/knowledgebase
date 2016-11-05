using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocalizeExample
{
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      /*// Если в настройках есть язык, устанавлияем его для текущего потока, в котором выполняется приложение.
      if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
      {
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
      }*/
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
