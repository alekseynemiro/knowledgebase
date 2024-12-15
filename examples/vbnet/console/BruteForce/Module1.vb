Imports System.IO
Imports System.Threading

Module Module1

  'list of chars
  'набор символов, который будет использован для перебора
  Private Chars As String = "AQWSZXCDERFVBGTYHNMJUIKLOP1234567890"

  'max string length
  'максимальная длина строки (чем больше, тем дольше будет перебор)
  Private MaxLength As Integer = 5

  'counter
  'счетчик
  Private Total As Long = 0
  'сколько ожидается комбинаций
  Private Pending As Long = 0

  'result collection (only for small data)
  'коллекция, в которую можно помещать результат,
  'но только если комбинацией немного (до 4 знаков)
  Private Result As New List(Of String)

  'file writer
  'поток для записи в файл
  Private Writer As StreamWriter

  Sub Main()
    'rename old file
    'изменяем имя файла с результатами от предыдущей сессии
    If File.Exists("result.txt") Then
      File.Move("result.txt", String.Format("result-{0}-{1}.txt", Now.Ticks, Guid.NewGuid().ToString().Substring(6)))
    End If

    'create new file
    'создаем новый файл для записи результатов
    Writer = New StreamWriter(File.OpenWrite("result.txt"))

    Pending = Chars.Length ^ MaxLength
    Console.WriteLine("Pending: {0:###,###,###,###}", Pending)
    Console.Write("Processed: 0%  ")

    Thread.Sleep(1000)

    Dim sw As New Stopwatch()
    sw.Start()

    'generating all possible combinations
    'перебираем все варианты
    GetCombinations(MaxLength - 1, "", 0)

    sw.Stop()

    'new line
    Console.WriteLine()

    'close file
    'закрываем файл
    Writer.Close()

    'output results
    'выводим на экран информацию о результатах
    Console.WriteLine("Done!")
    Console.WriteLine("Total: {0:###,###,###,###}", Total)
    Console.WriteLine("Elapsed time: {0}", sw.Elapsed.ToString())

    Console.WriteLine("The result can be found in the file:")
    Console.WriteLine(New FileInfo("result.txt").FullName)
    Console.WriteLine("--------------------------------------------")
    Console.WriteLine("Press any key to exit")
    Console.ReadKey()
  End Sub

  Private Sub GetAll(start As String, pos As Integer)
    If pos > MaxLength Then Return

    For i As Integer = pos - 1 To Chars.Length - 1
      Dim ch As Char = Chars(i)
      start = start.Remove(pos - 1, 1).Insert(pos - 1, ch)
      GetAll(start, pos + 1)
    Next
  End Sub

  Private Sub GetCombinations(ByRef x As Long, ByVal pr As String, ByVal por As Long)
    For Each ch As Char In Chars
      If por < x Then
        GetCombinations(x, pr & ch, por + 1)
      Else
        'Result.Add(pr & ch)
        'write to file
        'добавляем вариант в файл
        Writer.WriteLine(pr & ch)
        Total += 1

        'отображаем процент выполнения задачи
        'через Mod, чтобы не сильно снижать скорость работы программы
        If (Total Mod 1000000 = 0) OrElse Total = Pending Then
          Console.Write(StrDup(4, vbBack))
          Dim p As String = CType((Total * 100) / Pending, Integer).ToString()
          Console.Write("{0}%", p)
          Console.Write(StrDup(3 - p.Length, " "))
        End If
      End If
    Next
  End Sub

End Module