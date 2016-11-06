Imports System.Xml
Imports System.IO

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim doc As New XmlDocument()
    'load file
    'загружаем файл
    doc.Load("Ревва Игорь_Отражения лабиринта_Научная Фантастика.fb2")

    'add namespaces
    'подключаем пространство имен, чтобы был доступ
    Dim ns As New XmlNamespaceManager(doc.NameTable)
    ns.AddNamespace("fb", "http://www.gribuser.ru/xml/fictionbook/2.0") 'см. xml-документ
    ns.AddNamespace("l", "http://www.w3.org/1999/xlink")

    'select coverpage
    'ищем секцию coverpage
    Dim coverLink As XmlNode = doc.SelectSingleNode("fb:FictionBook/fb:description/fb:title-info/fb:coverpage/fb:image", ns)
    If coverLink IsNot Nothing Then
      'select cover body
      'найдена ссылка на обложку, теперь ищем файл обложки
      Dim coverId As String = coverLink.Attributes("l:href").Value.Substring(1) 'не знаю, является стандартом, что первый символ # или нет, в данном случае решется стоит и она не нужна при поиске файла
      Dim coverBody As XmlNode = doc.SelectSingleNode(String.Format("fb:FictionBook/fb:binary[@id='{0}']", coverId), ns)
      If coverBody IsNot Nothing Then
        'decode cover from base64 string to byte array
        'есть обложка, преобразуем в массив байт
        Dim buffer() As Byte = Convert.FromBase64String(coverBody.InnerText)

        'set cover to form
        'ставим как фон формы
        Me.BackgroundImage = Image.FromStream(New MemoryStream(buffer))
      Else
        MessageBox.Show("Cover not found.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'MessageBox.Show("Обложка не найдена.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Else
      MessageBox.Show("Cover not found.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Information)
      'MessageBox.Show("Обложка не найдена.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

End Class