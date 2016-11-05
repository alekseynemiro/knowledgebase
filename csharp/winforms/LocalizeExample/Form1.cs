using System;
using System.Windows.Forms;

namespace LocalizeExample
{

  public partial class Form1 : Form
  {

    // Initialize an instance of the form.
    // Инициализация экземпляра формы.
    public Form1()
    {
      // If the settings contains a language, use the language for the current thread.
      // Если в настройках есть язык, устанавливаем его для текущего потока, в котором выполняется приложение.
      if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
      {
        // IMPORTANT: Set the language needed before creating form elements!
        // ВАЖНО: Устанавливать язык нужно до создания элементов формы!
        // Это можно сделать глобально, в рамках приложения в классе Program (см. файл Program.cs).
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
      }

      // Call the standard method of initializing the form elements
      // Вызов создания элементов формы (создан Visual Studio автоматически)
      InitializeComponent();
    }

    // Обработчик нажатия на кнопку "Выход".
    private void button1_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(MyStrings.ExitRequest, MyStrings.ExitTitle, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
      {
        this.Close();
      }
    }

    // Обработчик загрузки формы.
    private void Form1_Load(object sender, EventArgs e)
    {
      // Create list of languages.
      // Заносим список поддерживаемых языков.
      comboBox1.DataSource = new System.Globalization.CultureInfo[]{
        System.Globalization.CultureInfo.GetCultureInfo("ru-RU"),
        System.Globalization.CultureInfo.GetCultureInfo("en-US")
      };

      // Каждый элемент списка comboBox1 будет являться экземпляром класса CultureInfo.

      comboBox1.DisplayMember = "NativeName"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NativeName
      comboBox1.ValueMember = "Name"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").Name

      // Select current language.
      // Если в настройках есть язык, выбираем его в списке.
      if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
      {
        comboBox1.SelectedValue = Properties.Settings.Default.Language;
      }

    }

    // Обработчик закрытия формы.
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      // Save selected language.
      // Сохраняем выбранный язык.
      Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
      Properties.Settings.Default.Save();
    }

  }

}