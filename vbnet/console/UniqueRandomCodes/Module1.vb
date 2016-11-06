'Unique codes
'Copyright © 2014, Aleksey Nemiro

'Пример генератора большого количества уникальных кодов
'http://kbyte.ru/ru/Forums/Show.aspx?id=16261
'Алексей Немиро, 19.02.2014

Module Module1

  Private _Alias As New Dictionary(Of String, String())
  Private _Rnd As New Random(Now.Millisecond)

  Sub Main()
    _Alias.Add("A", {"L", "Y", "J"})
    _Alias.Add("B", {"V", "M", "S"})
    _Alias.Add("C", {"W", "H", "P"})
    _Alias.Add("D", {"Q", "T", "U"})
    _Alias.Add("E", {"K", "N", "X"})
    _Alias.Add("F", {"Z", "R", "G"})

    Console.Title = "Kbyte.Ru: Random code generator"

    Console.WriteLine("Welcome to the random code generator!")
    'Console.WriteLine("Вас приветствует генератор непонятных чисел!")
    'Threading.Thread.Sleep(500)

    Console.WriteLine("To get started, relax.")
    'Console.WriteLine("Чтобы начать работу, расслабьтесь.")
    'Threading.Thread.Sleep(500)

    Console.WriteLine("--------------------------------------------")
    'Threading.Thread.Sleep(500)

    'Beep()

    Console.WriteLine("ENTER NUMBER OF NECESSARY CODES")
    'Console.WriteLine("ВВЕДИТЕ ЧИСЛО НЕОБХОДИМЫХ НОМЕРОВ")

    Dim count As Integer = 0

    While count <= 0
      Console.WriteLine("Valid only integers:")
      'Console.WriteLine("Допускаются только целые числа, без пробелов:")
      Integer.TryParse(Console.ReadLine(), count)
    End While

    'Console.WriteLine("Введите длину номера")
    Dim length As Integer = 9

    'While length <= 0
    ' Console.WriteLine("Допускаются только целые числа, без пробелов:")
    ' Integer.TryParse(Console.ReadLine(), length)
    'End While

    'Console.WriteLine("ВВЕДИТЕ НАБОР СИМВОЛОВ, КОТОРЫЕ ДОПУСТИМО ИСПОЛЬЗОВАТЬ")
    'Console.WriteLine("Все символы на одной строке, без разделителе. Например: 1234567890")
    'Dim chars As String = ""
    'While String.IsNullOrEmpty(chars) OrElse chars.Length < 5
    ' Console.WriteLine("Необходимо ввести не менее пяти символов:")
    ' chars = Console.ReadLine()
    'End While

    Dim sw As New Stopwatch()
    sw.Start()

    Dim dup As Integer = 0
    Dim result As New HashSet(Of String)

    Try
      For i As Integer = 1 To count
        Dim num As String = GetNumber(length) 'Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 14)
        While result.Contains(num)
          Console.BackgroundColor = ConsoleColor.Red
          Console.ForegroundColor = ConsoleColor.Yellow
          Console.Write("x")
          'Beep()
          dup += 1
          num = GetNumber(length)
        End While
        result.Add(num)
        If (result.Count Mod 100000) = 0 Then
          Console.BackgroundColor = ConsoleColor.Green
          Console.Write(" ")
        ElseIf (result.Count Mod 10000) = 0 Then
          Console.BackgroundColor = ConsoleColor.Yellow
          Console.Write(" ")
        ElseIf (result.Count Mod 1000) = 0 Then
          Console.BackgroundColor = ConsoleColor.White
          Console.Write(" ")
        End If
      Next
    Catch ex As OutOfMemoryException
      Console.WriteLine()
      Console.BackgroundColor = ConsoleColor.Black
      Console.ForegroundColor = ConsoleColor.Red
      Console.WriteLine(ex.Message)
      'Console.WriteLine("Недостаточно памяти для завершения операции!")
      Beep()
    Catch ex As Exception
      Console.WriteLine()
      Console.BackgroundColor = ConsoleColor.Black
      Console.ForegroundColor = ConsoleColor.Red
      Console.WriteLine(ex.Message)
      'Console.WriteLine("Ошибка: {0}", ex.Message)
      Beep()
    End Try

    sw.Stop()

    Console.WriteLine()
    Console.BackgroundColor = ConsoleColor.Black
    Console.ForegroundColor = ConsoleColor.Gray
    Console.WriteLine("Generated {0} for {1}. Prevent duplicate: {2}", result.Count, sw.Elapsed.ToString(), dup)
    Console.WriteLine("Select the path to save the results.")
    'Console.WriteLine("Сгенерировано номеров {0} за {1}. Зафиксировано дубликатов: {2}", result.Count, sw.Elapsed.ToString(), dup)
    'Console.WriteLine("Укажите путь сохранения результатов.")

    Dim sfd As New System.Windows.Forms.SaveFileDialog()
    sfd.Filter = "Text files (*.txt)|*.txt"
    'sfd.Filter = "Текстовые файлы (*.txt)|*.txt"
    sfd.FileName = "result.txt"

    If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
      Console.WriteLine("Writing...")
      'Console.WriteLine("Запись в файл...")

      sw.Restart()

      Using fs As New System.IO.FileStream(sfd.FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.ReadWrite)
        Using w As New System.IO.StreamWriter(fs)
          For Each s As String In result
            w.WriteLine(s)
          Next
        End Using
      End Using

      sw.Stop()

      Console.WriteLine("The data was successfully written to the {0} for {1}", System.IO.Path.GetFileName(sfd.FileName), sw.Elapsed.ToString())
      'Console.WriteLine("Данные успешно записаны в файл {0} за {1}", System.IO.Path.GetFileName(sfd.FileName), sw.Elapsed.ToString())

      result = Nothing
    Else
      Console.WriteLine("The user does not want to save the results.")
      'Console.WriteLine("Пользователь не захотел сохранять результаты.")
    End If

    Console.WriteLine("Press any key to exit.")
    'Console.WriteLine("Работа завершена. Нажмите любую клавишу, чтобы выйти из приложения.")
    Console.ReadKey()
  End Sub

  Private Function GetNumber(length As Integer) As String
    Dim result As String = Guid.NewGuid().ToString().ToUpper().Replace("-", "")
    While result.Length < length
      result &= Guid.NewGuid().ToString().ToUpper().Replace("-", "")
    End While

    result = result.Substring(0, length - 1)

    For i As Integer = 0 To result.Length - 1
      If Char.IsLetter(result(i)) Then
        Dim idx As Integer = _Rnd.Next(0, 4)
        If idx > 0 Then
          Dim ch As Char = result(i)
          result = result.Remove(i, 1)
          result = result.Insert(i, _Alias(ch)(idx - 1))
        End If
      End If
    Next

    Return "F" & result

    'Dim rnd As New Random(Now.Millisecond)
    'For i As Integer = 1 To length
    ' result &= chars.Substring(Rnd.Next(0, chars.Length), 1)
    'Next
    'Return result
  End Function

End Module
