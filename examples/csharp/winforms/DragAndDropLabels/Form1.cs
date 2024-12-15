// http://kbyte.ru/ru/Forums/Show.aspx?id=17702
using System;
using System.Windows.Forms;
using System.Drawing;

namespace DragAndDropLabels
{

  public partial class Form1 : Form
  {

    private Label DraggingLabel = null;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // allow drop labels
      // разрешаем перетаскивание
      label1.AllowDrop = true;
      label2.AllowDrop = true;
      label3.AllowDrop = true;

      // add handlers
      // обработчик нажатия кнопок мышки
      label1.MouseDown += label_MouseDown;
      label2.MouseDown += label_MouseDown;
      label3.MouseDown += label_MouseDown;

      // обработчик при перетаскивании объекта в пределы label
      label1.DragEnter += label_DragEnter;
      label2.DragEnter += label_DragEnter;
      label3.DragEnter += label_DragEnter;

      // обработчик завершения перетаскивания
      label1.DragDrop += label_DragDrop;
      label2.DragDrop += label_DragDrop;
      label3.DragDrop += label_DragDrop;
    }

    private void label_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        // remember a reference to the element that drag
        // запоминаем ссылку на элемент, который тащим
        this.DraggingLabel = (Label)sender;
        this.DraggingLabel.ForeColor = Color.Red;

        // start dragging
        // начинаем перетаскивание
        this.DoDragDrop(this.DraggingLabel.Text, DragDropEffects.Copy);
      }
    }

    private void label_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.Text))
      {
        e.Effect = DragDropEffects.Copy;
      }
    }

    private void label_DragDrop(object sender, DragEventArgs e)
    {
      // get current label
      // куда притащили
      var currentLabel = (Label)sender;

      // change places
      // просто меняем два label местами
      var location = this.DraggingLabel.Location;
      this.DraggingLabel.Location = currentLabel.Location;
      currentLabel.Location = location;

      this.DraggingLabel.ForeColor = SystemColors.ControlText;
    }

  }

}