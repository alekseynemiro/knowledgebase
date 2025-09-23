---
description: Работа с датами и временем в C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Дата и время

## Как получить дату и время в формате JSON (ISO 8601)?

```csharp
Console.WriteLine(DateTime.UtcNow.ToString("o"));
Console.WriteLine(DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK"));
```

## Как разобрать дату в строгом формате?

```csharp
string dateString = "2025-09-23T23:59:00";
var date = DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
```

## Как вычесть одну дату из другой?

```csharp
var start = new DateTime(2025, 9, 23);
var end = new DateTime(2025, 9, 25);

TimeSpan difference = end - start;
Console.WriteLine($"Количество дней: {difference.TotalDays}");
```

## Как получить Unix Time?

```csharp
long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
Console.WriteLine($"Unix time: {unixTime}");
```
