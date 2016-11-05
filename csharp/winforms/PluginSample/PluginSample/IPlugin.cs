using System;
using System.Collections.Generic;
using System.Text;

namespace PluginSample
{

  /// <summary>
  /// <para>Interface, describing the properties, methods and events of plug-ins.</para>
  /// <para lang="ru">Интерфейс, описывающий свойства, события, методы и функции плагина.</para>
  /// </summary>
  /// <remarks>
  /// Aleksey Nemiro, 28.11.2007
  /// http://kbyte.ru - лучший русскоязычный сайт для программистов и разработчиков
  /// http://aleksey.nemiro.ru
  /// </remarks>
  public interface IPlugin
  {

    string Name { get; }

    Version Version { get; }

    string Description { get; }

    string AuthorName { get; }

    void Initialize(object MainContainer);

    void Dispose();

  }

}