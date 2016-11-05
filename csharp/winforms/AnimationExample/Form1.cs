using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimationExample
{

  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    // [DllImport("winmm.dll")] 
    // private static extern long mciSendString(string strCommand,StringBuilder strReturn,int iReturnLength, IntPtr hwndCallback);

    private void Form1_Load(object sender, EventArgs e)
    {
      pictureBox1.BackColor = Color.White;
      timer1.Interval = 200; // speed / скорость обновления прорисовки
      timer1.Enabled = true;
      
      // music
      // музыка, чтобы было не скучно
      // mciSendString("open \"" + System.IO.Path.Combine(Application.StartupPath, "SATISFACTION.MP3") + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
      // mciSendString("play MediaFile", null, 0, IntPtr.Zero);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      // make bitmap
      // холст
      Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
      // get graphics
      Graphics g = Graphics.FromImage(bmp);

      // calculate output positions
      // рисовать будет по центру PictureBox
      int x = (pictureBox1.Width - Properties.Resources.kbyte_blk160x70px.Width) / 2;
      int y = (pictureBox1.Height - Properties.Resources.kbyte_blk160x70px.Height) / 2;

      // random position of blocks
      // позиция прорисовки по y будет выбрана случайно
      Random r = new Random(DateTime.Now.Millisecond);

      // get part of source image
      // берем фрагмент картинки с логотипа и рисуем имя kbyte.ru
      g.DrawImage(Properties.Resources.kbyte_blk160x70px, new Rectangle(x, y, Properties.Resources.kbyte_blk160x70px.Width, 37), new Rectangle(0, 0, Properties.Resources.kbyte_blk160x70px.Width, 37), GraphicsUnit.Pixel);

      // draw blocks
      // рисуем квадратики циклом, всего их 5
      for (int i = 0; i <= 4; i++)
      {
        // 8 - позиция по x первого квадратика в источнике
        // 29 - шаг расположения квадратиков в источнике по x
        // 28 - ширина и высотка одного квадратика в источнике, но вообще размер квадратика 25-26 пикселей, для подобоных вещей важна точность, мне просто лень было рисовать новый логотип
        // 38 - позиция квадратиков в источнике по y 

        // 42 - чило с потолка, так же как и 20

        g.DrawImage(Properties.Resources.kbyte_blk160x70px, new Rectangle(x + ((i * 29) + 8), r.Next(y + 42, y + 42 + 20), 25, 25), new Rectangle((i * 29) + 8, 38, 28, 28), GraphicsUnit.Pixel);

      }

      pictureBox1.Image = bmp;
    }
  }

}