---
description: Working with arrays in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Arrays

:::warning
This document has been translated using machine translation without human review.
:::

## How to create an array?

```csharp
// simple array
int[] numbers = new int[3];
Console.WriteLine(numbers[0]); // 0
Console.WriteLine(numbers[1]); // 0
Console.WriteLine(numbers[2]); // 0

numbers[0] = 123;
numbers[1] = 456;
numbers[2] = 789;

Console.WriteLine(numbers[0]); // 123
Console.WriteLine(numbers[1]); // 456
Console.WriteLine(numbers[2]); // 789

// preset values
string[] cities = { "Vladivostok", "Saint Petersburg", "Yoshkar-Ola" };
Console.WriteLine(cities[0]); // Vladivostok
Console.WriteLine(cities[1]); // Saint Petersburg
Console.WriteLine(cities[2]); // Yoshkar-Ola

// preset values - new syntax
string[] names = ["Aleksey", "Ekaterina"];
Console.WriteLine(names[0]); // Aleksey
Console.WriteLine(names[1]); // Ekaterina

// multidimensional array
int[,] multi = new int[2, 3];

multi[0, 0] = 1;
multi[0, 1] = 2;
multi[0, 2] = 3;

multi[1, 0] = 4;
multi[1, 1] = 5;
multi[1, 2] = 6;

Console.WriteLine(multi[0, 0]); // 1
Console.WriteLine(multi[0, 1]); // 2
Console.WriteLine(multi[0, 2]); // 3
Console.WriteLine(multi[1, 2]); // 6
```

## How to change the array size?

:::warning
Changing the array size requires creating a new array and transferring values from the old array to the new one.
:::

```csharp
int[] numbers = new int[5];
Console.WriteLine(numbers.Length); // 5

Array.Resize(ref numbers, 10);
Console.WriteLine(numbers.Length); // 10
```

## How to select elements from the end of the array?

```csharp
string[] cities = ["Vladivostok", "Saint Petersburg", "Yoshkar-Ola", "Kazan", "Moscow"];

Console.WriteLine(cities[0]);  // Vladivostok
Console.WriteLine(cities[^1]); // Moscow
Console.WriteLine(cities[^2]); // Kazan
```

## How to select an array slice?

```csharp title="ArraySegment"
string[] cities = ["Vladivostok", "Saint Petersburg", "Yoshkar-Ola", "Kazan", "Moscow"];
var segment = new ArraySegment<string>(cities, 2, 2);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Yoshkar-Ola, Kazan

segment = new ArraySegment<string>(cities, 2, 3);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Yoshkar-Ola, Kazan, Moscow

segment = new ArraySegment<string>(cities, 0, 2);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Vladivostok, Saint Petersburg
```

```csharp title="LINQ"
string[] cities = ["Vladivostok", "Saint Petersburg", "Yoshkar-Ola", "Kazan", "Moscow"];
var segment = cities.Skip(2).Take(2).ToArray();
Console.WriteLine(string.Join(", ", segment)); // Yoshkar-Ola, Kazan
```

## What's better, arrays or collections?

Arrays are good when the size is known in advance. This provides better performance.

Collections essentially consist of arrays, but they are much more convenient to work with, though you have to pay for this with performance.

To change the array size, it needs to be recreated with values preserved. That is, at the moment of recreation, a new array is created next to the old one, then data from the old array is transferred to the new one, and the old array is destroyed. When **the collection size changes, the internal array may be recreated**, if there is a lot of data, this may require a significant amount of RAM. Array recreation **may not occur**, because collections have internal **optimization mechanisms** for these processes.

What to use where depends on specific tasks.
It's a bad idea to read a file byte by byte and use a collection for this.
It's a good idea to use a collection for forming a list of messages.

In web programming, in 90% of cases you have to work with collections.
