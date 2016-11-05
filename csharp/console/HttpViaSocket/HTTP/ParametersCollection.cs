/*
 * Пример к статье: Получение почты по протоколу POP3 и обработка MIME
 * Автор: Алексей Немиро
 * http://aleksey.nemiro.ru
 * Специально для Kbyte.Ru
 * http://kbyte.ru
 * 27 августа 2011 года
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpViaSocket.HTTP
{

  class ParametersCollection : Dictionary<string, string>
  {

    // StringComparer.CurrentCultureIgnoreCase - указывает не то, что в коллекции регистр символов учитываться не будет
    public ParametersCollection() : base(StringComparer.CurrentCultureIgnoreCase) { }

  }

}