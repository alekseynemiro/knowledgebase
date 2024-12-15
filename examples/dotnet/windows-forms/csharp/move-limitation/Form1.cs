using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoveLimitation
{

  public partial class Form1 : Form
  {

    private int x, y;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // Properties.Resources.kbyte_blk160x70px - изображение из ресурсов программы

      // starting position - the center form
      // начальная позиция - по центру формы
      x = (this.ClientSize.Width - Properties.Resources.kbyte_blk160x70px.Width) / 2;
      y = (this.ClientSize.Height - Properties.Resources.kbyte_blk160x70px.Height) / 2;
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // change position
      if (e.KeyCode == Keys.Left)
      {
        // изменяем позицию по x на минус 10 пикселей относительно текущей
        x -= 10;
      }
      else if (e.KeyCode == Keys.Right)
      {
        // изменяем позицию по x на плюс 10 пикселей относительно текущей
        x += 10;
      }
      else if (e.KeyCode == Keys.Up)
      {
        // изменяем позицию по y на минус 10 пикселей относительно текущей
        y -= 10;
      }
      else if (e.KeyCode == Keys.Down)
      {
        // изменяем позицию по y на плюс 10 пикселей относительно текущей
        y += 10;
      }
      else if (e.KeyCode == Keys.Escape)
      {
        this.Close();
      }

      // if less than zero, set zero, so that the image is not hidden behind the outside forms
      // если меньше нуля, то ставим ноль, чтобы изображение не пропало с экрана
      if (x < 0) { x = 0; }
      if (y < 0) { y = 0; }
      
      // если позиция больше размера формы, то уменьшаем позицию до границ формы
      if (x > this.ClientSize.Width - Properties.Resources.kbyte_blk160x70px.Width)
      {
        x = this.ClientSize.Width - Properties.Resources.kbyte_blk160x70px.Width;
      }

      if (y > this.ClientSize.Height - Properties.Resources.kbyte_blk160x70px.Height)
      {
        y = this.ClientSize.Height - Properties.Resources.kbyte_blk160x70px.Height;
      }

      // команда на прорисовку
      this.Refresh();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      // get Graphics of the form
      // берем текущий Graphics
      Graphics g = e.Graphics;

      // get text and calculate size
      string text = "Use the arrow keys on your keyboard to move the logo\n\n";
      text += "Используйте клавиши ВВЕРХ, ВЛЕВО, ВПРАВО и ВНИЗ, чтобы переместить логотип";

      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      
      SizeF textSize = g.MeasureString(text, this.Font, this.ClientSize, format);

      // draw text
      g.DrawString(text, this.Font, Brushes.Black, this.ClientSize.Width / 2, 50, format);

      // draw image
      // рисуем логотип
      g.DrawImage(Properties.Resources.kbyte_blk160x70px, new Rectangle(x, y, Properties.Resources.kbyte_blk160x70px.Width, Properties.Resources.kbyte_blk160x70px.Height), new Rectangle(0, 0, Properties.Resources.kbyte_blk160x70px.Width, Properties.Resources.kbyte_blk160x70px.Height), GraphicsUnit.Pixel);
    }
    
  }

}