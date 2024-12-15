/*
 * Пример к статье «Разработка прокси-сервера»
 * http://kbyte.ru/ru/Programming/Articles.aspx?id=66&mode=art
 * Автор: Алексей Немиро
 * http://aleksey.nemiro.ru
 * Специально для Kbyte.Ru
 * http://kbyte.ru
 * Copyright © Aleksey Nemiro, 2011
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HttpViaSocket.HTTP
{

  class ContentType : ItemBase
  {

    /// <summary>
    /// Кодировка
    /// </summary>
    public Encoding Charset
    {
      get
      {
        if (!base.Parameters.ContainsKey("charset")) return Encoding.UTF8;
        try
        {
          return Encoding.GetEncoding(base.Parameters["charset"]);
        }
        catch
        {
          return Encoding.UTF8;
        }
      }
    }

    public ContentType(string source) : base(source) { }

  }

}