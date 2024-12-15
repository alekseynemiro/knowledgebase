/*
 * Простой пример использования асинхронных сокетов 
 * для запросов методом GET по протоколу HTTP
 * 
 * Автор: Алексей Немиро
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * Copyright © Aleksey Nemiro, 2012
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace HttpViaSocket
{

  public class HttpSocket
  {

    private static int _SentBytes = 0;
    private static int _LastReceivedBytes = 0;
    private static long _TotalReceivedBytes = 0;
    private static long _ContentReceivedBytes = 0;
    private int _PackSize = 256;
    private HTTP.Parser _Http = new HTTP.Parser();
    private string _TempFilePath = "";
    private FileStream _FileStream = null;
    private BinaryWriter _BinaryWriter = null;

    public HttpSocket(string url)
    {
      CreateSocket(new Uri(url));
    }

    private void CreateSocket(Uri url)
    {
      // создаем сокет
      Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

      // инициализируем обработчик асихронных операций
      SocketAsyncEventArgs se = new SocketAsyncEventArgs();
      // подключаем обработчики событий асинхронных запросов
      se.Completed += new EventHandler<SocketAsyncEventArgs>(Socket_Send);

      // цепляем точку доступа
      if (false)
      { // в этом месте можно направить трафик через прокси
        IPAddress addr = new IPAddress(new byte[] { 127, 0, 0, 1 });
        se.RemoteEndPoint = new IPEndPoint(addr, 8888);
      }
      else
      {
        IPHostEntry hostEntry = Dns.GetHostEntry(url.Host);//
        se.RemoteEndPoint = new IPEndPoint(hostEntry.AddressList[0], (url.Port <= 0 ? 80 : url.Port));
      }

      se.UserToken = url;

      Console.WriteLine("Соединение...");

      // создаем асихронное подключение
      mySocket.ConnectAsync(se);
    }

    /// <summary>
    /// Метод формирует и отправляет HTTP-запрос
    /// </summary>
    private void SendHTTPRequest(Socket s, SocketAsyncEventArgs e, Uri url)
    {
      // формируем HTTP-запрос
      string request = "GET " + url.PathAndQuery + " HTTP/1.0\r\nHost: " + url.Host + (url.Port != 80 ? ":" + url.Port.ToString() : "");

      // TODO: если для домена есть куки, добавляем
      /*List<string> c = null;
      if (_Cookies != null && (c = _Cookies.Get(url.Host)) != null)
      {
        request += String.Format("\r\nCookie: {0}", cstr);
      }*/

      request += "\r\nConnection: Close\r\n\r\n";
      Byte[] buffer = Encoding.ASCII.GetBytes(request);
      e.SetBuffer(buffer, 0, buffer.Length);

      _SentBytes = buffer.Length;

      Console.WriteLine("Запрос...");

      // отправляем асинхронный запрос
      s.SendAsync(e);
    }

    private void Socket_Send(object sender, SocketAsyncEventArgs e)
    {
      Socket s = sender as Socket;

      // выводим информацию о текущей операции и результатах её выполнения
      if (e.SocketError != SocketError.Success)
      {
        Console.WriteLine("Ошибка {1} при выполнении операции {0}...", e.LastOperation, e.SocketError);
        return;
      }
      // --

      Uri url = e.UserToken as Uri;

      byte[] pack = new byte[_PackSize];

      // делаем что-нибудь, в зависимости от типа выполненной операции
      switch (e.LastOperation)
      {
        case SocketAsyncOperation.Connect:
          // формируем запрос
          Console.WriteLine("Соединение открыто.");
          SendHTTPRequest(s, e, url);
          break;

        case SocketAsyncOperation.Send: // первоначальный запрос
          // получаем ответ от удаленного сервера
          e.SetBuffer(pack, 0, pack.Length);
          _TotalReceivedBytes = _LastReceivedBytes = 0; //сбрасываем счетчик полученных байт
          Console.WriteLine("Начало сеанса.");
          // получаем ответ пачками
          s.ReceiveAsync(e);
          break;

        case SocketAsyncOperation.Receive:
          // смотрим, если нет HTTP-заголовков, то пытаемся их найти
          byte[] buffer = e.Buffer;
          int contentSize = e.BytesTransferred;
          _LastReceivedBytes = e.BytesTransferred;

          Console.WriteLine("Получено {0} байт", e.BytesTransferred);


          // прибавляем счетчик полученных байт
          _TotalReceivedBytes += _LastReceivedBytes;

          #region поиск http-заголовков
          if (!_Http.IsParsed)
          {
            // ищем первое вхождение пары байт 13 10
            string str = Encoding.UTF8.GetString(buffer);
            int httpHeadersTail = 0;
            if ((httpHeadersTail = str.IndexOf("\r\n\r\n")) != -1)
            { // граница найдена
              _Http.Append(str.Substring(0, httpHeadersTail));

              // если размер полученных данных больше или равен размеру буфура
              if (e.BytesTransferred > httpHeadersTail)
              {
                // отделяем содержимое от заголовков
                byte[] buffer2 = new byte[e.BytesTransferred - (httpHeadersTail + 4)];
                Array.Copy(buffer, httpHeadersTail + 4, buffer2, 0, e.BytesTransferred - (httpHeadersTail + 4));
                buffer = buffer2;
                contentSize = buffer.Length;
              }
              else
              {
                // только заголовки
                buffer = null;
              }

              // парсим заголовки
              _Http.ParseMe(url.Scheme, url.Host);

              // куки
              //_Cookies.AddItem(url.Host, _Http.Cookies);

              if (_Http.StatusCode == 301 || _Http.StatusCode == 302)
              {
                // редирект, добавляем полученную ссылку в очередь
                //_UrlsTurn.AddItem(_Level, _Http.Location.Scheme, _Http.Location.Host, _Http.Location.ToString());
              }
              Console.WriteLine("Найдены заголовки HTTP на {0} позиции.", _Http.Source.Length);
              Console.WriteLine("HTTP-статус: {0}, тип содержимого: {1}, размер содержимого: {2} байт", _Http.StatusCode, _Http.ContentType.Value, (_Http.Items.ContainsKey("Content-Length") ? _Http.Items["Content-Length"].Value : 0));
            }
            else
            { // граница не найдена, добавляем
              _Http.Append(str);
            }
          }
          #endregion

          // слудующая пачка данных, если есть
          if (e.BytesTransferred > 0)
          {
            // добавляем полученные данные в файл
            if (_Http.IsParsed && _Http.StatusCode == 200)
            {
              // Можно сохранять и в память, то если запросы будут на большие данные,
              // памяти может не хватить.
              if (_FileStream == null)
              {
                _TempFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data.dat");
                if (File.Exists(_TempFilePath)) File.Delete(_TempFilePath);
                _FileStream = new FileStream(_TempFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite | FileShare.Delete);
                _BinaryWriter = new BinaryWriter(_FileStream, _Http.ContentType.Charset);
              }
              if (buffer != null)
              {
                _BinaryWriter.Write(buffer, 0, contentSize);
                _ContentReceivedBytes += contentSize;
              }
            }

            // нужно обнулить буфер, иначе куски данных могут попасть в следующий ответ
            e.SetBuffer(pack, 0, pack.Length);
            s.ReceiveAsync(e);
            return;
          }
          else if (e.BytesTransferred <= 0 && (_Http.IsParsed && _Http.StatusCode == 200))
          {
            // TODO: если нужно
            // обрабатываем данные, если это текст
            if (_Http.ContentType != null && _Http.ContentType.ValueAsString.ToLower().StartsWith("text"))
            {
              _FileStream = new FileStream(_TempFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
              string page = "";
              using (StreamReader sr = new StreamReader(_FileStream, _Http.ContentType.Charset))
              {
                page = sr.ReadToEnd();
              }
              // TODO: тело html-данных будет в переменной page

              // Кстати, данные можно вывести в консоль
              // Console.WriteLine(page);
              page = Regex.Replace(page, "[\r\n\t]+", "");
              page = Regex.Replace(page, "\x20{2,}", "");
              page = Regex.Replace(page, "(<script(.*?)>(.*?)</script>)|(<(.+?)>)", "");
              Console.WriteLine(page);
            }
          }
          // отключаемся
          if (s != null) s.Close();

          // закрываем файл
          if (_BinaryWriter != null) _BinaryWriter.Close();
          if (_FileStream != null) _FileStream.Close();

          Console.WriteLine("Соединение завершено.");

          // TODO: превращаем временный файл в постоянный, если нужно

          break;
      }
    }

  }

}