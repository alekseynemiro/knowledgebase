using System;

namespace ProcessStart
{

  class Program
  {
    
    private static System.Diagnostics.Process Process = null;

    static void Main(string[] args)
    {
      // start process
      // создаем и запускаем процесс
      Process = System.Diagnostics.Process.Start(@"C:\windows\system32\calc.exe");
      
      // output process info
      // выводим информацию о процессе
      Console.WriteLine("ID: {0}", Process.Id);
      Console.WriteLine("Name: {0}", Process.ProcessName);

      // ждем нажатия на любую клавишу в консоль
      Console.WriteLine("Press any key to exit...");
      // Console.WriteLine("Нажмите на любую клавишу...");
      Console.ReadKey();

      // kill process
      // убиваем процесс, если он жив
      if (!Process.HasExited)
      {
        Process.Kill();
      }
    }

  }

}