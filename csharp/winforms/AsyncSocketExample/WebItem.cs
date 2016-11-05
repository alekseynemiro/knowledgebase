using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace AsyncSocketExample
{

  // You can make own class.
  // Подобный класс нужно сделать самому в зависимости от потребностей. 
  // В этом классе может быть все что угодно.
  public class WebItem
  {

    /// <summary>
    /// <para>List of state.</para>
    /// <para lang="ru">Перечисления состояний выполнения запроса.</para>
    /// </summary>
    public enum StateList
    {
      /// <summary>
      /// <para>Success</para>
      /// <para lang="ru">Запрос успешно выполнен</para>
      /// </summary>
      OK,
      /// <summary>
      /// <para>Error</para>
      /// <para lang="ru">Ошибка</para>
      /// </summary>
      Error,
      /// <summary>
      /// <para>Request processing</para>
      /// <para lang="ru">Идет работа, нет не мозга, а процесс получения данных</para>
      /// </summary>
      Process,
      /// <summary>
      /// <para>Unknow</para>
      /// <para lang="ru">Нет данных, возможно еще не было команды запроса</para>
      /// </summary>
      Unknow
    }


    /// <summary>
    /// <para>The event takes place after the successful completion of the request.</para>
    /// <para lang="ru">Событие происходит после успешного завершения выполнения запроса.</para>
    /// </summary>
    public event EventHandler Completed;

    // request result
    // локальная переменная, в нее будет загружаться ответ
    private StringBuilder _Result = null;

    // current url
    // переменная, в которой будет содержаться текущий url
    private string _Url = String.Empty;

    /// <summary>
    /// <para>Gets current URL.</para>
    /// <para lang="ru">Содержит текущий URL (только для чтения).</para>
    /// </summary>
    public string Url
    {
      get { return _Url; }
    }

    private StateList _State = StateList.Unknow;

    /// <summary>
    /// <para>Gets request status.</para>
    /// <para lang="ru">Состояние выполнения запроса.</para>
    /// </summary>
    public StateList State
    {
      get { return _State; }
    }

    private string _Message = String.Empty;

    /// <summary>
    /// <para>Gets last message. For debugging.</para>
    /// <para lang="ru">Последнее сообщение выполнения запроса, для отладки.</para>
    /// </summary>
    public string Message
    {
      get { return _Message; }
    }

    private double _ReceivedBytes = 0;

    /// <summary>
    /// <para>Gets the number of bytes received.</para>
    /// <para lang="ru">Получено байт.</para>
    /// </summary>
    public double ReceivedBytes
    {
      get { return _ReceivedBytes; }
    }

    /// <summary>
    /// <para>Initializes a new instance of the class.</para>
    /// <para lang="ru">Инициализирует новый экземпляр класса.</para>
    /// </summary>
    /// <param name="url">The URL to which you want to run a request.</param>
    /// <param name="url" lang="ru">Адрес страницы, которую нужно получить.</param>
    public WebItem(string url)
    {
      if (!url.ToLower().StartsWith("http://")) url = "http://" + url;
      _Url = url;
    }

    /// <summary>
    /// <para>Runs a web request.</para>
    /// <para lang="ru">Основной метод, запускает процесс получения данных с удаленного сервера</para>
    /// </summary>
    public void Execute()
    {
      // port - default 80 (HTTP)
      int port = 80; // по умолчанию порт 80
      Uri u = new Uri(_Url);

      // create socket
      // создаем сокет
      Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

      // инициализируем обработчик асихронных операций
      SocketAsyncEventArgs se = new SocketAsyncEventArgs();

      // add handler
      // подключаем обработчики событий асинхронных запросов
      se.Completed += new EventHandler<SocketAsyncEventArgs>(OnSend);

      // set end point
      // цепляем точку доступа
      IPHostEntry hostEntry = Dns.GetHostEntry(u.Host);
      se.RemoteEndPoint = new IPEndPoint(hostEntry.AddressList[0], port);

      // set status
      // ставим флаг, что работа идет
      _State = StateList.Process;

      // connect
      // создаем асихронное подключение
      s.ConnectAsync(se);
    }

    /// <summary>
    /// <para>Returns requrest results.</para>
    /// <para lang="ru">Возвращает полученные данные.</para>
    /// </summary>
    public string GetResult()
    {
      if (_Result == null) return String.Empty;
      return _Result.ToString();
    }

    private void OnSend(object sender, SocketAsyncEventArgs e)
    {
      Socket s = (Socket)sender; // в sender будет передаваться экземпляр сокета, вызвавшего это событие

      // выводим информацию о текущей операции и результатах её выполнения
      if (e.SocketError != SocketError.Success)
      {
        // ставим сообщение об ошибке
        _Message = String.Format("Error: {1}. Last operation: {0}.", e.LastOperation, e.SocketError);
        // _Message = String.Format("Ошибка {1} при выполнении операции {0}...", e.LastOperation, e.SocketError);
        // ставим состояние - ошибка
        _State = StateList.Error;
        // выходим
        return;
      }
      // --

      // размер пакета 4 кб
      byte[] buffer = new byte[4096];

      // делаем что-нибудь, в зависимости от типа выполненной операции
      switch (e.LastOperation)
      {
        case SocketAsyncOperation.Connect:
          // отправляем запрос
          SendRequest(s, e);
          break;

        case SocketAsyncOperation.Send:
          // получаем ответ от удаленного сервера
          e.SetBuffer(buffer, 0, buffer.Length);
          // аннулируем предыдущий результат, если был
          _Result = new StringBuilder();// создаем StringBuilder
          _ReceivedBytes = 0;//сбрасываем счетчик полученных байт
          // получаем пачку ответа
          s.ReceiveAsync(e);
          break;

        case SocketAsyncOperation.Receive:
          // добавляем полученные данные в переменную с результатом
          _Result.Append(Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred));
          // прибавляем счетчик полученных байт
          _ReceivedBytes += e.BytesTransferred;
          // говорим, что все нормально
          _Message = String.Format("Операция {0} успешно выполнена! Получено {1} байт, всего {2} байт", e.LastOperation, e.BytesTransferred, _ReceivedBytes);

          // слудующая пачка данных, если есть
          if (e.BytesTransferred > 0)
          {
            // нужно обнулить буфер, иначе куски данных могут попасть в следующий ответ
            e.SetBuffer(buffer, 0, buffer.Length);
            s.ReceiveAsync(e);
          }
          else
          {
            // нет данных, отключаемся
            s.Close();
            // ставим флаг, что работа успешно завершена
            _State = StateList.OK;
            // кстати, у класса можно сделать какое-нибудь событие, которое будет происходить по завершению получения данных,
            // и генерить это событие в этом месте, можно прям вместо этого комментария.
            // для ошибок тоже можно сделать событие.
            // события позволят оперативно реагировать на изменение статуса выполнения запросов
            // ...
            // ладно, я сегодня добрый, одно событие с меня :)
            EventHandler hnd = Completed;
            if (hnd != null) { hnd(this, null); }
          }
          break;
      }
    }

    // sends web request
    // метод отправляет запрос
    private void SendRequest(Socket s, SocketAsyncEventArgs e)
    {
      // make HTTP requres
      // формируем HTTP-запрос
      Uri u = new Uri(_Url); // ну или this.Url
      string request = "GET " + u.PathAndQuery + " HTTP/1.1\r\nHost: " + u.Host + "\r\nConnection: Close\r\n\r\n";
      Byte[] buffer = Encoding.ASCII.GetBytes(request);
      e.SetBuffer(buffer, 0, buffer.Length);

      // send request
      // отправляем асинхронный запрос
      s.SendAsync(e);
    }

  }

}