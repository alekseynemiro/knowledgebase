using System;
using System.Text;
using System.Net;

namespace ConstReadonlyFieldsAndProperties
{

  class Toster
  {

    // public const
    // публична константа, доступ через Toster
    public const string ProjectName = "Тостер";

    // local const
    // локальная константа, доступна только в рамках это класса
    const string CounterPattern = "<span class=\"section-header__counter\" role=\"answers_counter\">";

    // readonly fields
    // публичные поля только для чтения
    // значение может быть установлено в конструкторе
    public readonly string Title = "Нет данных";
    public readonly int Id = 0;

    // readonly property
    // свойство только для чтения
    // значение может меняться в процессе жизни экземпляра класса
    private int _AnswersCount = 0;

    public int AnswersCount
    {
      get
      {
        return _AnswersCount;
      }
    }

    // it's just a timer
    // это просто таймер
    private System.Timers.Timer Timer = null;

    // constructor
    // а это конструктор<s>, но не Lego</s>
    public Toster(int id)
    {
      if (id <= 0) { return; }

      // execute web request
      // получаем вопрос
      var web = new WebClient();
      web.Encoding = Encoding.UTF8;
      var result = web.DownloadString(String.Format("https://toster.ru/q/{0}", id));

      // set readonly fields
      // устанавливаем значения для полей
      this.Id = id;
      this.Title = WebUtility.HtmlDecode
      (
        result.Substring
        (
          result.IndexOf("<title>") + "<title>".Length,
          result.IndexOf("</title>") - result.IndexOf("<title>") - "<title>".Length
        )
      );

      // parse server response
      // выдергиваем число ответов на вопрос
      this.ParseAnswersCount(result);

      // start monitoring
      // запускаем периодическую проверку <s>Менделева</s>
      Timer = new System.Timers.Timer(10000);
      Timer.Elapsed += Timer_Elapsed;
    }

    // timer handler
    // обработчик истечения интервала времени 
    private void Timer_Elapsed(object sender, EventArgs e)
    {
      var web = new WebClient();
      web.Encoding = Encoding.UTF8;
      var result = web.DownloadString(String.Format("https://toster.ru/q/{0}", this.Id));
      this.ParseAnswersCount(result);
    }

    // server response parser
    // выдергиватель количества ответов
    private void ParseAnswersCount(string value)
    {
      int startstart = value.IndexOf("Ответы на вопрос");
      int start = value.IndexOf(CounterPattern, startstart) + CounterPattern.Length;
      int len = value.IndexOf("</span>", start) - start;
      _AnswersCount = Convert.ToInt32(value.Substring(start, len));
    }

  }

}