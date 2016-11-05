/*
 * Copyright © 2011, Aleksey Nemiro
 * https://github.com/alekseynemiro
 * http://aleksey.nemiro.ru
 * Licensed under the MIT license
 * -------------------------------------------------------
 * Пример получения интернет-страниц по списку 
 * с использованием асинхронных сокетов
 * и вспомогательного класса
 * 
 * Автор: Алексей Немиро
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * 
 * Обсуждение: 
 * http://kbyte.ru/ru/Forums/Show.aspx?id=12287
 */
using System;
using System.Windows.Forms;

namespace AsyncSocketExample
{

  /*
   * ATTENTION: MAKE SURE THAT THE FIREWALL DOES NOT BLOCK THE PROGRAM.
   * -----------------------------------------------------------------------------------
   * ВНИМАНИЕ: ПЕРЕД ПРОВЕРКОЙ РАБОТЫ ПРОГРАММЫ, УБЕДИТЕСЬ, ЧТО ФАЙРФОЛ ЕЁ НЕ БЛОКИРУЕТ!
   */
  public partial class Form1 : Form
  {

    private delegate void MyDelegate(object args);

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // add sites to list
      // добавляем сайты в список, это просто для примера
      listBox1.Items.Clear();
      listBox1.Items.Add(new WebItem("http://kbyte.ru"));
      listBox1.Items.Add(new WebItem("http://www.yandex.ru"));
      listBox1.Items.Add(new WebItem("http://yolper.ru"));
      listBox1.Items.Add(new WebItem("http://habrahabr.ru/blogs/infosecurity/70330/"));
      listBox1.Items.Add(new WebItem("http://kbyte.ru/ru/Forums/Show.aspx?id=12287&page=2"));
      listBox1.Items.Add(new WebItem("http://www.facebook.com/"));
      listBox1.Items.Add(new WebItem("http://www.youtube.com/"));

      // display values of Url property
      // показывать в списке будем url
      listBox1.DisplayMember = "Url";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(textBox1.Text)) 
      {
        MessageBox.Show("Url is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        // MessageBox.Show("Необходимо указать url!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // add url to list
      // добавляем в список новый url
      listBox1.Items.Add(new WebItem(textBox1.Text));
    }

    private void button2_Click(object sender, EventArgs e)
    {
      progressBar1.Value = 0;
      progressBar1.Maximum = listBox1.Items.Count;

      // loop over all tasks
      // листаем все задания
      foreach (WebItem itm in listBox1.Items)
      {
        // add handler to event Complete
        // привязываем к заданию обработчик события complete
        // это может быть сделано и по другому, но мне в этом примере проще сделать так
        itm.Completed += new EventHandler(WebItem_Complete);
        // run task
        // запускаем процесс выполнения задания
        itm.Execute();
      }

      // кстати, если нажать на кнопку еще раз, задания будут запущены повторно :)
      // для подобных случаев неплохо бы написать какой-нибудь фильтр
    }

    // событие будет происходить, когда задение будет успешно выполнено (для всех заданий один обработчик)
    private void WebItem_Complete(object sender, EventArgs e)
    {
      // меняем состояние прогресса
      SetProgress();
    }

    private void SetProgress()
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action(() => { if (progressBar1.Value < progressBar1.Maximum) { progressBar1.Value++; } })); // либо можно по старинке, чтоб не спотыкаться :)
      }
      else
      {
        if (progressBar1.Value < progressBar1.Maximum) { progressBar1.Value++; }
      }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      // show task info
      // реагируем на выбор пользователем задания в списке
      if (listBox1.SelectedItem == null) return;
      WebItem itm = (WebItem)listBox1.SelectedItem;
      lblSize.Text = itm.ReceivedBytes.ToString();
      lblStatus.Text = itm.State.ToString();
      lblUrl.Text = itm.Url;
    }

    private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // show request results
      // при двойном клике по списку пробуем получить результат выполнения выбранного задания
      button3_Click(button3, null);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      // показываем результат выполнения задания в отдельном окне
      if (listBox1.SelectedItem == null)
      {
        MessageBox.Show("Task is not selected. Select task in list and try again.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        // MessageBox.Show("Задание не выбрано", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      WebItem itm = (WebItem)listBox1.SelectedItem;

      if (itm.State == WebItem.StateList.OK)
      {
        Form2 frm = new Form2();
        frm.richTextBox1.Text = itm.GetResult();
        frm.Show();
      }
      else if (itm.State == WebItem.StateList.Error)
      {
        MessageBox.Show(itm.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        // MessageBox.Show("В процессе выполнения задания произошла ошибка: " + itm.Message, "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      else if (itm.State == WebItem.StateList.Process)
      {
        MessageBox.Show("The task runs...", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        // MessageBox.Show("Задание находится в состоянии выполнения...", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      else if (itm.State == WebItem.StateList.Unknow)
      {
        MessageBox.Show("Task is waiting for their turn to run...", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        // MessageBox.Show("Задание ждет своей очереди на выполнение...", "Ой!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
    }

  }

}