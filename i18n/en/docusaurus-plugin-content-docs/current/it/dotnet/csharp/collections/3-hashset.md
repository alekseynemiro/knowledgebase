---
slug: hashset
description: Working with HashSet<T> in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - FAQ
---

# Hash Sets

:::warning
This document has been translated using machine translation without human review.
:::

## How to make AddRange in HashSet&lt;T&gt;?

To add multiple elements to `HashSet<T>`, you can use the `UnionWith` method:

```csharp
var hashSet = new HashSet<string>();
var arr = ["hello", "world", "!"];

hashSet.UnionWith(arr);
```
