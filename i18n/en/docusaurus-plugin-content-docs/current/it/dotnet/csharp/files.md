---
description: Working with files and folders in C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Files and Folders

:::warning
This document has been translated using machine translation without human review.
:::

## How to combine path components?

```csharp
Console.WriteLine(Path.Combine("C:\\", "Windows", "System32"));
// Output: C:\Windows\System32
```

## How to normalize slashes in a path?

```csharp
public static string NormalizePath(string path) 
{
  return path.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
}
```

## How to get the current working directory?

```csharp
Console.WriteLine(Directory.GetCurrentDirectory());
```

## How to get an absolute path from a relative one?

```csharp
Console.WriteLine(Path.GetFullPath("aleksey/projects/foo"));
```

## How to check if a folder exists?

```csharp
var exists = Directory.Exists(path);

Console.WriteLine($"Folder exists: {exists}");

// only for specialists
if (exists)
{
  Console.WriteLine("Could have done something useful!");
}
else
{
  Console.WriteLine("What about mom?");
}
```

## How to check if a file exists?

```csharp
Console.WriteLine($"File exists: {File.Exists(path)}");
```

## How to get a list of folders?

```csharp
foreach (var dir in Directory.GetDirectories(path))
{
  Console.WriteLine(dir);
}
```

## How to get a list of files in a folder?

```csharp title="List of all files in the specified folder"
var files = Directory.GetFiles(path);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

```csharp title="Recursively by specified pattern"
var path = Directory.GetCurrentDirectory();
var pattern = "*.md";
var files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

```csharp title="Gradual retrieval when there are very many files"
var path = "C:\\Windows";
var pattern = "*.dll";
var files = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

## How to create a folder?

```csharp
Directory.CreateDirectory(path);
```

## How to delete a folder?

```csharp
Directory.Delete(path);
// recursively
Directory.Delete(path, true);
```

## How to copy a folder?

```csharp
public static void CopyDirectory(string sourceDirectory, string destinationDirectory) 
{
  Directory.CreateDirectory(destinationDirectory);

  foreach (var file in Directory.GetFiles(sourceDirectory))
  {
    var destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
    File.Copy(file, destFile);
  }

  foreach (var directory in Directory.GetDirectories(sourceDirectory))
  {
    var nextDestinationDirectory = Path.Combine(destinationDirectory, Path.GetFileName(directory));
    CopyDirectory(directory, nextDestinationDirectory);
  }
}
```

## How to move a folder?

```csharp
Directory.Move(sourceDirName, destDirName);
```

## How to create (overwrite) a text file?

```csharp title="Lazy option for overwriting a text file"
File.WriteAllText(path, content, Encoding.UTF8);
```

The lazy option is simple but can lead to file locks.
It's better to fully control this process.

```csharp title="Correct option for overwriting a text file"
using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
{
  using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
  {
    writer.Write(content);
  }
}
```

## How to append data to the end of a text file?

```csharp title="Lazy option for appending data to a text file"
File.AppendAllText(path, content, Encoding.UTF8);
```

```csharp title="Lazily append a line to the end of a text file"
File.AppendAllLines(path, [line], Encoding.UTF8);
```

```csharp title="Correct option for appending data to a text file"
using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
{
  using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
  {
    writer.Write(content);
  }
}
```

## How to read a text file?

```csharp title="Lazy option for reading a text file"
Console.WriteLine(File.ReadAllText(path));
```

The lazy option can lead to file locks, it's better to control the entire file handling process yourself.

```csharp title="Correct option for reading a text file"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  using (var reader = new StreamReader(fileStream, Encoding.UTF8))
  {
    Console.WriteLine(reader.ReadToEnd());
  }
}
```

## How to read a binary file?

```csharp title="Lazy option for reading a binary file"
var bytes = File.ReadAllBytes(path);
```

```csharp title="Correct option for reading a binary file"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  using (var reader = new BinaryReader(fileStream))
  {
    var bytes = reader.ReadBytes((int)fileStream.Length);
  }
}
```

```csharp title="Gradual reading of a binary file"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  int bufferSize = 2048;
  int bytesRead;
  var buffer = new byte[bufferSize];

  while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
  {
    var content = string.Join("", buffer.Take(bytesRead).Select(b => b.ToString("x2")));
    Console.WriteLine($"Read packet of {bytesRead} bytes: {content}");
  }
}
```

## How to copy a file?

```csharp
File.Copy(sourcePath, destinationPath);
```

## How to move a file?

```csharp
File.Move(sourcePath, destinationPath);
```

## How to delete a file?

```csharp title="Regular file deletion"
File.Delete(path);
```

```csharp title="Attempt to delete a file"
public static async Task DeleteFileAsync(
  string path,
  TimeSpan? accessTimeout = null,
  CancellationToken cancellationToken = default
)
{
  var totalTime = new TimeSpan();
  var interval = TimeSpan.FromMilliseconds(100);

  accessTimeout ??= TimeSpan.FromSeconds(5);

  while (File.Exists(path))
  {
    try
    {
      File.Delete(path);
    }
    catch (IOException)
    {
      await Task.Delay(interval, cancellationToken);
      totalTime += interval;

      if (totalTime > accessTimeout)
      {
        throw;
      }
    }
  }
}
```
