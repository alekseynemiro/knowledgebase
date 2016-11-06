
''' <summary>
''' Интерфейс, описывающий свойства, события, методы и функции плагина
''' </summary>
''' <remarks>
''' Aleksey Nemiro, 28.11.2007
''' http://kbyte.ru - лучший русскоязычный сайт для программистов и разработчиков
''' http://aleksey.nemiro.ru
''' </remarks>
Public Interface IPlugin

  ReadOnly Property Name() As String
  ReadOnly Property Version() As Version
  ReadOnly Property Description() As String
  ReadOnly Property AuthorName() As String

  Sub Initialize(ByVal MainContainer As Object)
  Sub Dispose()

End Interface