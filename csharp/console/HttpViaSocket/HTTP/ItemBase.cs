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

  class  ItemBase
  {

    private object _Value = null;
    private string _Source = String.Empty;
    private ParametersCollection _Parameters = new ParametersCollection();

    /// <summary>
    /// Значение заголовка в исходном виде
    /// </summary>
    public string Source
    {
      get
      {
        return _Source;
      }
    }

    /// <summary>
    /// Значение заголовка
    /// </summary>
    public object Value
    {
      get
      {
        return _Value;
      }
    }

    /// <summary>
    /// Значение заголовка в виде строки
    /// </summary>
    public string ValueAsString
    {
      get
      {
        if (_Value == null) return String.Empty;
        return _Value.ToString();
      }
    }

    /// <summary>
    /// Значение заголовка в виде List<string>
    /// </summary>
    public List<string> ValueAsCollection
    {
      get
      {
        if (_Value == null) return null;
        return _Value as List<string>;
      }
    }

    /// <summary>
    /// Дополнительные параметры
    /// </summary>
    public ParametersCollection Parameters
    {
      get
      {
        return _Parameters;
      }
    }

    public ItemBase(string source)
    {
      if (String.IsNullOrEmpty(source)) return;

      _Source = source;

      // ищем в источнике первое вхождение точки с запятой
      int typeTail = source.IndexOf(";");
      if (typeTail == -1)
      { // все содержимое источника является значением заголовка
        _Value = source;
        return; // параметров нет, выходим
      }

      // есть параметры, значит до вхождения - это значение
      _Value = source.Substring(0, typeTail);
      // парсим параметры
      string p = source.Substring(typeTail + 1, source.Length - typeTail - 1);
      Regex myReg = new Regex(@"(?<key>.+?)=((""(?<value>.+?)"")|((?<value>[^\;]+)))[\;]{0,1}", RegexOptions.Singleline);
      MatchCollection mc = myReg.Matches(p);
      foreach (Match m in mc)
      {
        if (!_Parameters.ContainsKey(m.Groups["key"].Value))
        {
          _Parameters.Add(m.Groups["key"].Value.Trim(), m.Groups["value"].Value);
        }
      }

    }

    public void AddValueItem(string value)
    {
      if (_Value != null && _Value.GetType() == typeof(string))
      {
        string v = _Value.ToString();
        _Value = new List<string>();
        ((List<string>)_Value).Add(v);
      }
      ((List<string>)_Value).Add(value);
    }

  }

}