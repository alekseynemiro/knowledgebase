Module Module1

  Sub Main()
    'show all time zones
    'список часовых зон
    'For Each tz As TimeZoneInfo In TimeZoneInfo.GetSystemTimeZones()
    'Console.WriteLine(tz.Id)
    'Next

    'show Vladivostok time
    'который час во Владивостоке
    Console.WriteLine("Vladivostok: {0}", ConvertTime(Now, 10))
    'Console.WriteLine(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Now, "Vladivostok Standard time"))

    'New York
    Console.WriteLine("New York: {0}", ConvertTime(Now, -5))

    'London
    Console.WriteLine("London: {0}", ConvertTime(Now, 0))

    'Moscow
    Console.WriteLine("Moscow: {0}", ConvertTime(Now, 3))

    Console.ReadKey()
  End Sub

  Function ConvertTime(value As Date, offset As Integer) As Date
    Dim tz As TimeZoneInfo = TimeZoneInfo.GetSystemTimeZones().First(Function(zone) zone.BaseUtcOffset.Hours = offset)
    Return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(value, tz.Id)
  End Function

End Module