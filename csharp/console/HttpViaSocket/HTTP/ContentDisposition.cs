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
using System.Text.RegularExpressions;

namespace HttpViaSocket.HTTP
{

  /// <summary>
  /// Объектное представление Content-Disposition
  /// </summary>
  class ContentDisposition : ItemBase
  {

    /// <summary>
    /// Имя файла
    /// </summary>
    public string FileName
    {
      get
      {
        if (base.Parameters.ContainsKey("filename"))
        {
          return this.Parameters["filename"];
        }
        return String.Empty;
      }
    }

    public ContentDisposition(string source) : base(source) 
    { 
    }

  }

}