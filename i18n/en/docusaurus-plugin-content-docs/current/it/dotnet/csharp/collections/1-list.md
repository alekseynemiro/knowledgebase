---
slug: list
description: Working with lists in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - FAQ
---

# Lists

:::warning
This document has been translated using machine translation without human review.
:::

## List&lt;T&gt; - How to set list capacity and why is it needed?

List capacity (`Capacity`) is the number of elements that can be placed in the list without increasing the array dimension.

Specifying capacity allows you to optimize memory allocation for the list and improve performance.

`List<T>` internally consists of a regular array. Arrays are more efficient to work with if their size is known in advance.
If the size is unknown, the array has to be recreated and this incurs certain overhead costs.

```csharp
// initialize a list with a size of three elements
var list = new List<string>(3);

// add three elements
list.Add("one");
list.Add("two");
list.Add("three");

Console.WriteLine($"Capacity: {list.Capacity}"); // Capacity: 3

// if we add more, the list will have to recreate the internal array by doubling its size
list.Add("four");
list.Add("five");

Console.WriteLine($"Capacity: {list.Capacity}"); // Capacity: 6
```
