---
slug: dictionary
description: Работа со словарями в C#.
tags:
  - dotnet
  - .NET
  - csharp
  - FAQ
---

# Словари

## Как создать экземпляр Dictionary&lt;TKey, TValue&gt; с предустановленными значениями?

```csharp title="Классический вариант"
var dic = new Dictionary<string, string> 
{
  { "key 1", "value 1" },
  { "key 2", "value 2" },
  { "key 3", "value 3" },
};
```

```csharp title="C# 6.0 и выше"
var dic = new Dictionary<string, string> 
{
  ["key 1"] = "value 1",
  ["key 2"] = "value 2",
  ["key 3"] = "value 3",
};
```

## Как сделать ключи не чувствительные к регистру?

```csharp
var dic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
```

## Как объединить два словаря?

```csharp
var dictionaryA = new Dictionary<string, string>
{
  { "key_1", "value_1" },
  { "key_2", "value_2" },
};

var dictionaryB = new Dictionary<string, string>
{
  { "key_3", "value_3" },
  { "key_4", "value_4" },
};

var merged = dictionaryA.Concat(dictionaryB).ToDictionary(x => x.Key, x => x.Value);

Console.WriteLine(merged["key_1"]); // value_1
Console.WriteLine(merged["key_4"]); // value_4
```

## Что лучше Dictionary или Hashtable?

В подавляющем большинстве случаев рекомендуется использовать `Dictionary<TKey, TValue>`.

`Dictionary<TKey, TValue>` проще, надежней и работает быстрее.
