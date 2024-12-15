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
using System.IO.Compression;
using System.IO;

namespace HttpViaSocket.HTTP
{

  class Parser
  {
    private string _HTTPVersion = "1.1";
    private int _StatusCode = 0;
    private string _StatusMessage = string.Empty;

    private ItemCollection _Items = new ItemCollection();

    private StringBuilder _Source = new StringBuilder();
    private bool _IsParsed = false;

    private string _Scheme = "http";
    private string _Host = String.Empty;

    /// <summary>
    /// Заголовки
    /// </summary>
    public ItemCollection Items
    {
      get
      {
        return _Items;
      }
    }

    /// <summary>
    /// Источник данных
    /// </summary>
    public StringBuilder Source
    {
      get
      {
        return _Source;
      }
    }

    /// <summary>
    /// Код состояния (при ответе)
    /// </summary>
    public int StatusCode
    {
      get
      {
        return _StatusCode;
      }
    }

    /// <summary>
    /// Сообщение сервера (при ответе)
    /// </summary>
    public string StatusMessage
    {
      get
      {
        return _StatusMessage;
      }
    }

    /// <summary>
    /// Тип содержимого
    /// </summary>
    public ContentType ContentType
    {
      get
      {
        if (!_Items.ContainsKey("Content-Type"))
        {
          _Items.Add("Content-Type", "");
        }
        return (ContentType)_Items["Content-Type"];
      }
    }

    public ContentDisposition ContentDisposition
    {
      get
      {
        if (_Items.ContainsKey("Content-Disposition"))
        {
          return (ContentDisposition)_Items["Content-Disposition"];
        }
        return null;
      }
    }

    /// <summary>
    /// Перенаправление
    /// </summary>
    public Uri Location
    {
      get
      {
        if (_Items.ContainsKey("Location"))
        {
          try
          {
            string url = _Items["Location"].ValueAsString;

            // удаляем хеш, чтобы по десять раз не грузить одну страницу
            string hash = "";
            if (url.LastIndexOf("#") != -1)
            {
              hash = url.Substring(url.LastIndexOf("#") + 1, url.Length - url.LastIndexOf("#") - 1);
              url = url.Substring(0, url.LastIndexOf("#"));
            }
            // --

            // обрабатываем url
            UriBuilder myUrl = null;
            if (Regex.IsMatch(url, @"^(?<scheme>[^\x3a]+):([\x5C\x2F]{0,2})(.*)$", RegexOptions.Singleline | RegexOptions.IgnoreCase))
            {
              // есть схема, возможно ссылка внешняя
              // выравниваем, если в адресе есть опечатки
              url = Regex.Replace(url, @"^([^\x3a]+)(\:)([\x5C\x2F]{0,2})(.*)$", @"$1://$4", RegexOptions.Singleline | RegexOptions.IgnoreCase);
              url = url.Replace("\\", "/");
              if (!url.ToLower().StartsWith("http")) return null;
              myUrl = new UriBuilder(url);
              if (myUrl.Port == 80) myUrl.Port = -1; // удаляем номер порта из адреса, если порт 80 (HTTP)
            }
            else
            {
              // нет схемы, создаем на основе домена из загруженной ссылки
              myUrl = new UriBuilder();

              myUrl.Scheme = _Scheme;
              myUrl.Host = _Host;

              if (url.IndexOf("?") == -1)
              {
                myUrl.Path = url;
              }
              else
              {
                myUrl.Path = url.Substring(0, url.LastIndexOf("?"));
                myUrl.Query = url.Substring(url.LastIndexOf("?") + 1, url.Length - url.LastIndexOf("?") - 1);
              }
            }
            return myUrl.Uri;
          }
          catch
          {
            return null;
          }
        }
        return null;
      }
    }

    /// <summary>
    /// Куки
    /// </summary>
    public List<string> Cookies
    {
      get
      {
        if (_Items.ContainsKey("Set-Cookie"))
        {
          if (_Items["Set-Cookie"].Value.GetType() == typeof(string))
          {
            List<string> l = new List<string>();
            l.Add(_Items["Set-Cookie"].ValueAsString);
            return l;
          }
          return _Items["Set-Cookie"].ValueAsCollection;
        }
        return null;
      }
    }

    /// <summary>
    /// Данные обработаны или нет
    /// </summary>
    public bool IsParsed
    {
      get { return _IsParsed; }
    }

    /// <summary>
    /// Создает заголовки на основе указанных в источнике данных
    /// </summary>
    public void ParseMe(string scheme, string host)
    {
      _Scheme = scheme; _Host = host;
      if (_Source.Length <= 0)
      {
        _IsParsed = true;
        return;
      }

      _Items = new ItemCollection();

      // преобразуем данные в текст
      string sourceString = _Source.ToString();

      // при запросе
      // первая строка содержит метод запроса, путь и версию HTTP протокола
      int firstLine = sourceString.IndexOf("\r\n");
      string httpInfo = sourceString.Substring(0, firstLine);

      // первая строка содержит код состояния
      Regex myReg = new Regex(@"HTTP/(?<version>[\d\.]+)\s+(?<status>\d+)\s*(?<msg>.*)", RegexOptions.Multiline);
      Match m = myReg.Match(httpInfo);
      int.TryParse(m.Groups["status"].Value, out _StatusCode);
      _StatusMessage = m.Groups["msg"].Value;
      _HTTPVersion = m.Groups["version"].Value;

      // парсим заголовки и заносим их в коллекцию
      myReg = new Regex(@"^(?<key>[^\x3A]+)\:\s{1}(?<value>.+)$", RegexOptions.Multiline);
      MatchCollection mc = myReg.Matches(sourceString.Substring(firstLine + 2, sourceString.Length - firstLine - 2));
      foreach (Match mm in mc)
      {
        string key = mm.Groups["key"].Value;
        if (!_Items.ContainsKey(key))
        {
          // если указанного заголовка нет в коллекции, добавляем его
          _Items.Add(key, mm.Groups["value"].Value.Trim("\r\n ".ToCharArray()));
        }
        else
        {
          // есть, создаем из него коллекцию
          _Items[key].AddValueItem(mm.Groups["value"].Value.Trim("\r\n ".ToCharArray()));
        }
      }

      _IsParsed = true;
    }

    /// <summary>
    /// Добавляет данные к источнику
    /// </summary>
    /// <param name="str">Данные, которые нужно добавить</param>
    public void Append(string str)
    {
      _Source.Append(str);
    }

    public void Clear()
    {
      _Source = new StringBuilder();
      _IsParsed = false;
      _Items = new ItemCollection();
    }

  }

}