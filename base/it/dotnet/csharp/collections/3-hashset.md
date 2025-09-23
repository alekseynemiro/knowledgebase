---
slug: hashset
description: Работа с HashSet<T> в C#.
tags:
  - dotnet
  - .NET
  - csharp
  - FAQ
---

# Хэш-списки

## Как сделать AddRange в HashSet&lt;T&gt;?

Для добавления множества элементов в `HashSet<T>` можно использовать метод `UnionWith`:

```csharp
var hashSet = new HashSet<string>();
var arr = ["hello", "world", "!"];

hashSet.UnionWith(arr);
```
