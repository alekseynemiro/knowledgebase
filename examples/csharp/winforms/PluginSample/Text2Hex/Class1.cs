using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PluginSample;

namespace Text2Hex
{

  /// <summary>
  /// <para>Simple example of plugin</para>
  /// <para lang="ru">Простой пример плагина</para>
  /// </summary>
  /// <remarks>
  /// Aleksey Nemiro, 28.11.2007
  /// http://kbyte.ru - лучший в рунете портал для программиство и разработчиков!
  /// http://aleksey.nemiro.ru
  /// </remarks>
  public class Class1 : IPlugin
  {

    // в этой переменной мы будем хранить ссылку на текстовое поле формы
    private TextBox _textBox;

    public string AuthorName
    {
      get { return "Aleksey Nemiro"; }
    }

    public string Description
    {
      get 
      {
        return "Converts text to hexadecimal and back"; 
        // return "Плагин преобразует текст в шестнадцатеричный код и обратно"; 
      }
    }

    public string Name
    {
      get { return "Text2Hex"; }
    }

    public Version Version 
    {
      get { return new Version(1, 0, 0, 0); }
    }

    public void Initialize(object MainContainer)
    {
      if (MainContainer == null) { throw new Exception("Container not found!"); }
      // if (MainContainer == null) { throw new Exception("Контейнер не найден!"); }

      // get a reference to the form
      // получаем ссылку на форму
      Form frm = (Form)MainContainer;

      // get menu of the form
      // получаем меню формы
      MenuStrip mnu = null;

      if (frm.Controls.Find("MenuStrip1", false) != null && frm.Controls.Find("MenuStrip1", false).Length > 0)
      {
        mnu = (MenuStrip)frm.Controls.Find("MenuStrip1", false)[0];
      }

      // get TextBox
      // получаем текстовое поле
      if (frm.Controls.Find("TextBox1", false) !=null  && frm.Controls.Find("TextBox1", false).Length > 0)
      {
        _textBox = (TextBox)frm.Controls.Find("TextBox1", false)[0];
      }

      if (mnu == null) { throw new Exception("Menu not found."); }
      // if (mnu == null) { throw new Exception("Меню не найдено"); }
      if (_textBox == null) { throw new Exception("Text field not found."); }
      // if (_textBox == null) { throw new Exception("Текстовое поле не найдено"); }

      // create elements of the plugin
      // создаем новые элементы меню
      ToolStripMenuItem myText2HexMenu = new ToolStripMenuItem();
      myText2HexMenu.Text = "Text2Hex";
      ToolStripMenuItem myConvertText2HexMenu = new ToolStripMenuItem();
      ToolStripMenuItem myConvertHex2TextMenu = new ToolStripMenuItem();
      ToolStripMenuItem myAboutMenu = new ToolStripMenuItem();
      myConvertText2HexMenu.Click += new EventHandler(ConvertText2HexMenu_Click);
      myConvertHex2TextMenu.Click += new EventHandler(ConvertHex2TextMenu_Click);
      myAboutMenu.Click += new EventHandler(AboutMenu_Click);
      myConvertText2HexMenu.Text = "Text => HEX";
      myConvertHex2TextMenu.Text = "HEX => Text";
      myAboutMenu.Text = "About Text2Hex...";
      // myConvertText2HexMenu.Text = "Конвертировать текст в hex";
      // myConvertHex2TextMenu.Text = "Конвертировать hex в текст";
      // myAboutMenu.Text = "О Text2Hex...";
      myText2HexMenu.DropDownItems.Add(myConvertText2HexMenu);
      myText2HexMenu.DropDownItems.Add(myConvertHex2TextMenu);
      myText2HexMenu.DropDownItems.Add(new ToolStripSeparator());
      myText2HexMenu.DropDownItems.Add(myAboutMenu);

      // add elements to form
      // добавляем новые элементы меню на форму
      mnu.Items.Add(myText2HexMenu);
    }

    // обработка события нажания на меню ConvertText2Hex (Конвертировать Текст в Шестнадцатеричный код)
    public void ConvertText2HexMenu_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(_textBox.Text)) { return; } // нет текста, выходим

      string sResult = "";

      foreach (char s in _textBox.Text)
      {
        sResult += Encoding.GetEncoding(1251).GetBytes(new char[] { s })[0].ToString("x").Length < 2 ? "0" + Encoding.GetEncoding(1251).GetBytes(new char[] { s })[0].ToString("x") : Encoding.GetEncoding(1251).GetBytes(new char[] { s })[0].ToString("x");
      }
      _textBox.Text = sResult;
    }

    // обработка события нажания на меню ConvertHex2TextMenu (Конвертировать Шестнадцатеричный код в Текст)
    public void ConvertHex2TextMenu_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(_textBox.Text)) { return; } // нет текста, выходим

      string sResult = "";

      // удаляем все символы, которые нельзя преобразовать в hex
      _textBox.Text = _textBox.Text.ToUpper();
      System.Text.RegularExpressions.Regex myRegEx = new System.Text.RegularExpressions.Regex("[^0-9ABCDEF]*");
      _textBox.Text = myRegEx.Replace(_textBox.Text, "");

      if (String.IsNullOrEmpty(_textBox.Text)) { return; } // нет текста, выходим

      for (int i = 0; i <= _textBox.Text.Length - 2; i = i + 2)
      {
        if (int.Parse(_textBox.Text.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier) <= 255)
        {
          sResult += Encoding.GetEncoding(1251).GetString(new byte[] { byte.Parse(_textBox.Text.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier) });
        }
      }

      _textBox.Text = sResult;
    }

    // обработка события нажания на меню AboutMenu (О программе)
    public void AboutMenu_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Simple example of plugin.", "About..", MessageBoxButtons.OK, MessageBoxIcon.Information);
      // MessageBox.Show("Простой пример плагина", "О плагине..", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void Dispose()
    {
    }

  }

}