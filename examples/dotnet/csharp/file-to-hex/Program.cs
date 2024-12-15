/*
 * Copyright © 2014, Aleksey Nemiro
 * https://github.com/alekseynemiro
 * http://aleksey.nemiro.ru
 * Licensed under the MIT license
 */
using System;
using System.Linq;

namespace FileToHex
{

  class Program
  {

    static void Main(string[] args)
    {
      // dec => bin
      byte[] data = System.IO.File.ReadAllBytes(@"C:\Windows\System32\calc.exe");
      
      // easy way
      // string hex = String.Join(" ", data.Select(itm => itm.ToString("X2")).ToArray());
      // Console.WriteLine(hex);

      int row = 0;

      Console.Title = "FileToHex - Kbyte.Ru";
      Console.ForegroundColor = ConsoleColor.Gray;

      Console.Write("{0:D6}: ", row);

      // output by blocks
      for (int i = 0; i < data.Length; i++)
      {
        // 16 byte in row
        // 16 байт в одной строке
        if (i != 0 && (i % 16) == 0)
        {
          Console.WriteLine();
          row++;

          if (row != 0 && (row % Console.WindowHeight) == 0)
          {
            Console.ReadKey();
            Console.ForegroundColor = (Console.ForegroundColor == ConsoleColor.Gray ? ConsoleColor.White : ConsoleColor.Gray);
          }

          Console.Write("{0:D6}: ", row);
        }

        Console.Write("{0:X2} ", data[i]);
      }

      Console.ReadKey();
    }

  }

}