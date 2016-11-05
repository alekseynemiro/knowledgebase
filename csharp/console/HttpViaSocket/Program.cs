using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpViaSocket
{

  class Program
  {

    static void Main(string[] args)
    {
      HttpSocket s = new HttpSocket("http://habrahabr.ru/post/172129/");
      Console.ReadKey();
    }

  }

}