using System;
using System.Threading;

namespace ConstReadonlyFieldsAndProperties
{

  class Program
  {

    static void Main(string[] args)
    {
      // create new instance of Toster
      // создаем экземпляр класса
      var t = new Toster(199065);

      // output global constant value
      // выводим значение константы ProjectName
      // доступ только через Toster
      Console.WriteLine(Toster.ProjectName);

      // there is no access to local constants
      // доступа к локальным константам здесь нет
      // Toster.CounterPattern
      // t.CounterPattern

      // output read-only field value
      // выводим заголовок вопроса
      Console.WriteLine(t.Title);

      // to infinity and beyond!
      // бесконечность - не предел!
      while (true)
      {
        // t.Id = 123;
        // you can not change Id
        // and because of this you will avoid logical errors
        // мы не можем поменять идентификатор
        // следовательно, этот код, логически, будет работать правильно

        // output answer counter
        // выводим число ответов
        Console.WriteLine("Ответов: {0}", t.AnswersCount);

        // t.AnswersCount = 123
        // you can not change readonly property
        // but class may return any value for readonly property
        // мы не можем менять значение readonly свойства,
        // но оно может меняться внутри экземпляра класса

        // pause 10 sec.
        // пауза 10 сек.
        Thread.Sleep(10000);
      }
    }
  }

}