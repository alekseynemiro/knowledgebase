---
description: Working with errors and exceptions in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Exceptions

:::warning
This document has been translated using machine translation without human review.
:::

## General rules for exceptions

* [x] The fewer exception catches, the better.
* [x] The higher (closer to the output) the exception is caught, the better.
* [x] It is strictly forbidden to hide exceptions! Any exception must be logged somewhere.
* [x] Replace/substitute an exception only if it is really necessary.
* [x] In most cases, the user does not need to know the technical details of exceptions. This is unnecessary, incomprehensible information that, in some cases, can compromise security. For users, it is better to show simpler and more understandable (user friendly) error messages.
* [x] The `NotImplementedException` exception is equivalent to TODO, i.e., it implies that this will need to be implemented in the future. You should not use this type of exception for functionality that will never be implemented; it is better to use something like `NotSupportedException`.

## How to catch an exception?

```csharp
try
{
  Processing = true;
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}");
  throw; // re-throw the current exception "as is"
}
finally
{
  // this block will always execute,
  // regardless of the presence or absence of an exception
  Processing = false;
}
```

## How to throw an exception?

```csharp
throw new Exception("In most cases, it's better to create your own exception type.");
```

## How to create a custom exception type?

```csharp title="Custom exception in modern C#"
public class IncredibleException : Exception("An incredible error occurred.");
```

```csharp title="Custom exception in ancient Greek C#"
public class IncredibleException : Exception
{
  public IncredibleException() : base("An incredible error occurred.")
  {
  }
}
```

```csharp title="Using a custom exception"
try
{
  const int one = 1, two = 2, three = 3;

  if (one + one == three - one)
  {
    throw new IncredibleException();
  }
}
catch (IncredibleException ex)
{
  Console.WriteLine(ex.Message);
}
```

## What is the difference between `throw` and `throw ex`?

* `throw;` — used when you need to re-throw the current exception, unchanged, preserving the original stack trace.
* `throw ex;` — creates a new exception object and overwrites the stack trace, which can make it difficult to find the true cause of the problem.

For most cases, it is recommended to use `throw;`.

```csharp
try
{
  int x = 1, y = 0;
  Console.WriteLine(x / y);
}
catch
{
  throw;
}
```
