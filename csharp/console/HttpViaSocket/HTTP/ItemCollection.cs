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

namespace HttpViaSocket.HTTP
{

  class ItemCollection : Dictionary<string, ItemBase>
  {

    public ItemCollection() : base(StringComparer.CurrentCultureIgnoreCase) { }

    public new void Add(string key, string source)
    {
      switch (key.ToLower())
      {
        case "content-type":
          this.Add(key, new ContentType(source));
          break;

        case "content-disposition":
          this.Add(key, new ContentDisposition(source));
          break;

        default:
          this.Add(key, new ItemBase(source));
          break;
      }
    }

    public override string ToString()
    {
      string result = "";
      foreach (string k in this.Keys)
      {
        ItemBase itm = this[k];
        if (!String.IsNullOrEmpty(result)) result += "\r\n";
        result += String.Format("{0}: {1}", k, itm.Source);
      }
      return result;
    }
  }

}