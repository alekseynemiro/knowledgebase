---
description: Working with dates and time in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Date and Time

:::warning
This document has been translated using machine translation without human review.
:::

## How to get date and time in JSON format (ISO 8601)?

```csharp
Console.WriteLine(DateTime.UtcNow.ToString("o"));
Console.WriteLine(DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK"));
```

## How to parse a date in a strict format?

```csharp
string dateString = "2025-09-23T23:59:00";
var date = DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
```

## How to subtract one date from another?

```csharp
var start = new DateTime(2025, 9, 23);
var end = new DateTime(2025, 9, 25);

TimeSpan difference = end - start;
Console.WriteLine($"Number of days: {difference.TotalDays}");
```

## How to get Unix Time?

```csharp
long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
Console.WriteLine($"Unix time: {unixTime}");
```
