Imports System.Xml

Module Module1

  Sub Main()
    Dim doc2 As New XmlDocument()

    'load xml from url
    'получаем xml по url
    doc2.Load("http://feeds.feedburner.com/kbyte-ru")

    'select one note
    'один конкретный элемент
    Console.WriteLine(doc2.SelectSingleNode("/rss/channel/title").InnerXml)

    'select atrribute of single node
    'атрибуты конкретного элемента
    For Each attr As XmlAttribute In doc2.SelectSingleNode("/rss").Attributes
      Console.WriteLine("{0} = {1}", attr.Name, attr.InnerText)
    Next

    'get all nodes
    'листаем список элементов
    For Each n As XmlNode In doc2.SelectNodes("/rss/channel/item")
      Console.WriteLine(n("title").InnerText)
    Next

    Console.ReadKey()
  End Sub

End Module
