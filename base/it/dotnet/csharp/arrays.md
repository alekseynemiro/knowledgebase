---
description: Работа с массивами в C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Массивы

## Как создать массив?

```csharp
// простой массив
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

// предустановленные значения
string[] cities = { "Vladivostok", "Saint Petersburg", "Yoshkar-Ola" };
Console.WriteLine(cities[0]); // Vladivostok
Console.WriteLine(cities[1]); // Saint Petersburg
Console.WriteLine(cities[2]); // Yoshkar-Ola

// предустановленные значения - новый синтаксис
string[] names = ["Aleksey", "Ekaterina"];
Console.WriteLine(names[0]); // Aleksey
Console.WriteLine(names[1]); // Ekaterina

// многомерный массив
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

## Как изменить размер массива?

:::warning
Изменение массива потребует создания нового массива и переноса значений из старого массива в новый.
:::

```csharp
int[] numbers = new int[5];
Console.WriteLine(numbers.Length); // 5

Array.Resize(ref numbers, 10);
Console.WriteLine(numbers.Length); // 10
```

## Как выбрать элементы с конца массива?

```csharp
string[] cities = ["Владивосток", "Санкт-Петербург", "Йошкар-Ола", "Казань", "Москва"];

Console.WriteLine(cities[0]);  // Владивосток
Console.WriteLine(cities[^1]); // Москва
Console.WriteLine(cities[^2]); // Казань
```

## Как выбрать срез массива?

```csharp title="ArraySegment"
string[] cities = ["Владивосток", "Санкт-Петербург", "Йошкар-Ола", "Казань", "Москва"];
var segment = new ArraySegment<string>(cities, 2, 2);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Йошкар-Ола, Казань

segment = new ArraySegment<string>(cities, 2, 3);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Йошкар-Ола, Казань, Москва

segment = new ArraySegment<string>(cities, 0, 2);
Console.WriteLine(string.Join(", ", segment.ToArray())); // Владивосток, Санкт-Петербург
```

```csharp title="LINQ"
string[] cities = ["Владивосток", "Санкт-Петербург", "Йошкар-Ола", "Казань", "Москва"];
var segment = cities.Skip(2).Take(2).ToArray();
Console.WriteLine(string.Join(", ", segment)); // Йошкар-Ола, Казань
```

## Что лучше, массивы или коллекции?

Массивы хороши, когда размер заранее известен. Это даёт лучшую производительность.

Коллекции, по сути своей, состоят из массивов, но с ними гораздо удобней работать, правда приходится за это платить производительностью.

Для изменения размера массива требуется его пересоздание с сохранением значений. Т.е. в момент пересоздания, рядом со старым массивом создается новый, затем в новый массив переносятся данных из старого, и старый массив уничтожается. Когда **изменяется размер коллекции, может произойти пересоздание внутреннего массива**, если данных много, это может потребовать ощутимого количества оперативной памяти. Пересоздание массива **может и не произойти**, т.к. коллекции имеют внутренние **механизмы оптимизации** этих процессов.

Что и где использовать — зависит от конкретных задач.
Плохая идея — читать файл по байтам и использовать коллекцию для этого.
Хорошая идея — использовать коллекцию для формирования списка сообщений.

В веб-программировании, в 90% случаев приходится работать с коллекциями.
