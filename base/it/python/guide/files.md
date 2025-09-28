---
title: "Python: Files & Folders"
description: Операции с файлами и папками в Python.
tags:
  - Python
  - FAQ
---

# Python: Операции с файлами и папками

## Как создать пустой файл?

```python
with open("example.txt", "w"):
    pass
```

## Как перезаписать текстовый файл?

```python
with open("example.txt", "w") as file:
    file.write("Data")
```

## Как добавить данные в конец текстового файла?

```python
with open("example.txt", "a") as file:
    file.write("\nNew line of data")
```

## Как проверить существование файла?

```python
import os

if os.path.exists("example.txt"):
    print("The file exists")
else:
    print("The file does not exist")
```

## Как прочитать текстовый файл?

```python
with open("example.txt", "r") as file:
    content = file.read()
    print(content)
```

## Как прочитать большой текстовый файл построчно?

```python
with open("example.txt", "r", encoding="UTF-8") as file:
    while line := file.readline(): # for line in file:
        print(line.rstrip())
```

## Как скопировать файл?

```python
import shutil

shutil.copy('source.txt', 'destination.txt')
```

## Как переместить файл?

```python
import shutil

shutil.move('source.txt', 'destination.txt')
```

## Как удалить файл?

```python
import os

os.remove("example.txt")
```

## Как создать новую папку?

```python
import os

os.mkdir("new_folder")

# recursive
os.makedirs("parent/child/child_2", exist_ok=True)
```

## Как получить список файлов в папке?

```python
import os

files = os.listdir("folder_path")

print(files)
```

```python title="Recursive"
import os

all_files = []

for root, dirs, files in os.walk("folder_path"):
    for file in files:
        all_files.append(os.path.join(root, file))

print(all_files)
```

## Как удалить папку?

```python
import os

os.rmdir("folder_path")
```

```python title="Recursive"
import shutil

shutil.rmtree("folder_path")
```

## Как найти файлы?

```python
import glob

text_files = glob.glob("*.txt")

print(text_files)
```

## Как объединить текстовые файлы в один?

```python
import glob

read_files = glob.glob("./**/*.md", recursive=True)

with open(".output/result.md", "wb") as output:
    for file in files:
        with open(file, "rb") as reader:
            output.write(reader.read())
```

## Как получить текущий рабочий каталог?

```python
import os

print(f"Current work directory: {os.getcwd()}")
print(f"Current file directory: {os.path.dirname(os.path.realpath(__file__))}")
```

## Как получить путь к каталогу из пути?

```python
print(os.path.dirname("/home/aleksey/projects/test.py"))
# output: /home/aleksey/projects
```

## Как объединить компоненты пути?

```python
import os

print(os.path.join("/home/user", "example.txt"))
```

## Как нормализовать слэши в пути?

```python
print(os.path.normpath("C:\\Projects/example/folder"))
```

## Как получить абсолютный путь из относительного?

```python
import os

print(os.path.abspath("../example.txt"))
```
