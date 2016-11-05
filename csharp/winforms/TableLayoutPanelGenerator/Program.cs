/*
 * Copyright © 2016, Aleksey Nemiro
 * https://github.com/alekseynemiro
 * http://nemiro.developer.cards
 * Licensed under the MIT license
 */
using System;
using System.Windows.Forms;

namespace TableLayoutPanelGenerator
{

  static class Program
  {

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }

  }

}