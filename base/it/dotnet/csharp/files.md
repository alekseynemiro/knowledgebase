---
description: Работа с файлами и папками в C#.
tags:
  - dotnet
  - .NET
  - csharp
  - C#
  - FAQ
---

# Файлы и папки

## Как объединить компоненты пути?

```csharp
Console.WriteLine(Path.Combine("C:\\", "Windows", "System32"));
// Output: C:\Windows\System32
```

## Как нормализовать слэши в пути?

```csharp
public static string NormalizePath(string path) 
{
  return path.Replace('/', Path.DirectorySeparatorChar).Replace('\\', directorySeparatorChar);
}
```

## Как получить текущий рабочий каталог?

```csharp
Console.WriteLine(Directory.GetCurrentDirectory());
```

## Как получить абсолютный путь из относительного?

```csharp
Console.WriteLine(Path.GetFullPath("aleksey/projects/foo"));
```

## Как проверить существование папки?

```csharp
var exists = Directory.Exists(path);

Console.WriteLine($"Папка существует: {exists}");

// только для специалистов
if (exists)
{
  Console.WriteLine("А мог бы делом заняться!");
}
else
{
  Console.WriteLine("А мамка?");
}
```

## Как проверить существование файла?

```csharp
Console.WriteLine($"Файл существует: {File.Exists(path)}");
```

## Как получить список папок?

```csharp
foreach (var dir in Directory.GetDirectories(path))
{
  Console.WriteLine(dir);
}
```

## Как получить список файлов в папке?

```csharp title="Список всех файлов в указанной папке"
var files = Directory.GetFiles(path);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

```csharp title="Рекурсивно по заданному шаблону"
var path = Directory.GetCurrentDirectory();
var pattern = "*.md";
var files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

```csharp title="Постепенное получение, когда файлов очень много"
var path = "C:\\Windows";
var pattern = "*.dll";
var files = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);

foreach (var file in files)
{
  Console.WriteLine(file);
}
```

## Как создать папку?

```csharp
Directory.CreateDirectory(path);
```

## Как удалить папку?

```csharp
Directory.Delete(path);
// рекурсивно
Directory.Delete(path, true);
```

## Как скопировать папку?

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

## Как переместить папку?

```csharp
Directory.Move(sourceDirName, destDirName);
```

## Как создать (перезаписать) текстовой файл?

```csharp title="Ленивый вариант перезаписи текстового файла"
File.WriteAllText(path, content, Encoding.UTF8);
```

Ленивый вариант простой, но может привести к блокировке файлов.
Лучше полностью контролировать этот процесс.

```csharp title="Правильный вариант перезаписи текстового файла"
using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
{
  using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
  {
    writer.Write(content);
  }
}
```

## Как добавить данные в конец текстового файла?

```csharp title="Ленивый вариант добавления данных в текстовой файл"
File.AppendAllText(path, content, Encoding.UTF8);
```

```csharp title="Лениво добавить строку в конец текстового файла"
File.AppendAllLines(path, [line], Encoding.UTF8);
```

```csharp title="Правильный вариант добавления данных в текстовой файл"
using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
{
  using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
  {
    writer.Write(content);
  }
}
```

## Как прочитать текстовой файл?

```csharp title="Ленивый вариант чтения текстового файла"
Console.WriteLine(File.ReadAllText(path));
```

Ленивый вариант может привести к блокировке файлов, лучше контролировать весь процесс работы с файлом самостоятельно.

```csharp title="Правильный вариант чтения текстового файла"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  using (var reader = new StreamReader(fileStream, Encoding.UTF8))
  {
    Console.WriteLine(reader.ReadToEnd());
  }
}
```

## Как прочитать бинарный файл?

```csharp title="Ленивый вариант чтения бинарного файла"
var bytes = File.ReadAllBytes(path);
```

```csharp title="Правильный вариант чтения бинарного файла"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  using (var reader = new BinaryReader(fileStream))
  {
    var bytes = reader.ReadBytes((int)fileStream.Length);
  }
}
```

```csharp title="Постепенное чтение бинарного файла"
using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
{
  int bufferSize = 2048;
  int bytesRead;
  var buffer = new byte[bufferSize];

  while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) > 0)
  {
    var content = string.Join("", buffer.Take(bytesRead).Select(b => b.ToString("x2")));
    Console.WriteLine($"Прочитан пакет {bytesRead} байт: {content}");
  }
}
```

## Как скопировать файл?

```csharp
File.Copy(sourcePath, destinationPath);
```

## Как переместить файл?

```csharp
File.Move(sourcePath, destinationPath);
```

## Как удалить файл?

```csharp title="Обычное удаление файла"
File.Delete(path);
```

```csharp title="Попытка удалить файл"
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
