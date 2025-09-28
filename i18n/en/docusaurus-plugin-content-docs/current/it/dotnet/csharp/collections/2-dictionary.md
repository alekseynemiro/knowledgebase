---
slug: dictionary
description: Working with dictionaries in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - FAQ
---

# Dictionaries

:::warning
This document has been translated using machine translation without human review.
:::

## How to create an instance of Dictionary&lt;TKey, TValue&gt; with preset values?

```csharp title="Classic approach"
var dic = new Dictionary<string, string> 
{
  { "key 1", "value 1" },
  { "key 2", "value 2" },
  { "key 3", "value 3" },
};
```

```csharp title="C# 6.0 and above"
var dic = new Dictionary<string, string> 
{
  ["key 1"] = "value 1",
  ["key 2"] = "value 2",
  ["key 3"] = "value 3",
};
```

## How to make keys case-insensitive?

```csharp
var dic = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
```

## How to merge two dictionaries?

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

## What is better: Dictionary or Hashtable?

In the vast majority of cases, it is recommended to use `Dictionary<TKey, TValue>`.

`Dictionary<TKey, TValue>` is simpler, more reliable, and works faster.
