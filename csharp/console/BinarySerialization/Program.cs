using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* Пример к ответу на вопрос на тему бинарной сериализации/десериализации
 * Автор: Алексей Немиро 
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * 
 * Ветка:
 * http://kbyte.ru/ru/Forums/Show.aspx?id=12921
 */

namespace BinarySerialization
{

  class Program
  {

    static void Main(string[] args)
    {
      string[] rows_to_write = new string[4];

      rows_to_write[0] = "123";
      rows_to_write[1] = "hello";
      rows_to_write[2] = "test";
      rows_to_write[3] = "kbyte.ru";

      // serialization of an array of strings
      // сериализация массива строк
      // открытие потока создание файла,режим записи
      using (FileStream fs = new FileStream("123.bin", FileMode.Create, FileAccess.Write))
      {
        // create BinaryFormatter
        // конвертер для преобразования в бинарный формат
        BinaryFormatter sw = new BinaryFormatter();
        // serialization
        // сериализация
        sw.Serialize(fs, rows_to_write);
      } // закрытие потока, освобождение ресурсов

      // deserialization
      // десериализация
      string[] rows_readed = null;
      using (FileStream fs = new FileStream("123.bin", FileMode.Open, FileAccess.Read))
      {
        // create BinaryFormatter
        // конвертер для преобразования в бинарный формат
        BinaryFormatter sw = new BinaryFormatter();
        // deserialization
        // десериализация
        rows_readed = sw.Deserialize(fs) as string[];
      }

      // вывод прочитанных из файла данных
      foreach (string s in rows_readed)
      {
        Console.WriteLine(s);
      }

      Console.ReadKey();
    }

  }

}