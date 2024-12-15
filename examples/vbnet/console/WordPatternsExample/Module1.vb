Imports System.Net
Imports System.Drawing
Imports System.IO

'Making Word document by HTML template
'Copyright © 2013, Aleksey Nemiro

'Простой пример работы с html-шаблонами Word.
'Пример к теме форума: http://kbyte.ru/ru/Forums/Show.aspx?id=14831
'---------------------------------------------------------------------
'Алексей Немиро, 10.07.2013
'http://aleksey.nemiro.ru
'http://kbyte.ru
Module Module1

  Sub Main()
    Console.Title = "Make Word document by template"

    'get template
    'получаем данные шаблона 
    Dim fileData As String = "" ' System.IO.File.ReadAllText("template.htm")' можно так, но лучше как показано ниже
    Dim template As String = "template.htm"

    Using fs As New System.IO.FileStream(template, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read) 'файл будет искаться в одной папке с программой
      Using sr As New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding(1251)) 'важно: кодировка 1251
        fileData = sr.ReadToEnd()
      End Using
    End Using

    'меняем метки

    Console.WriteLine("First name:")
    fileData = fileData.Replace("{firstName}", Console.ReadLine()) 'меняем метку {firstName} на то, что введет пользователь

    Console.WriteLine("Last name:")
    fileData = fileData.Replace("{lastName}", Console.ReadLine()) 'меняем метку {lastName} на то, что введет пользователь

    Console.WriteLine("Birthday:")
    fileData = fileData.Replace("{birthday}", Console.ReadLine()) 'меняем метку {birthday} на то, что введет пользователь

    'save to file
    'сохраняем результат
    'System.IO.File.WriteAllText("result.doc", fileData) 'файл будет сохранен в папку с программой

    '"result.doc" - файл будет сохранен в папку с программой
    'IO.FileMode.Create - если файл с таким именем существует, он будет перезаписан
    Using fs As New System.IO.FileStream("result.doc", IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.ReadWrite)
      Using sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(1251)) 'важно: кодировка 1251
        sw.Write(fileData)
      End Using
    End Using

    'open file in ms word
    'открываем файл в Word
    Process.Start("result.doc") 'файл будет открыт в программе, с которой ассоциировано расширение .doc

    'Console.ReadKey()
  End Sub

End Module