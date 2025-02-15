---
title: Files & Folders
description: Operations with files and folders in Python.
tags:
  - Python
  - FAQ
---

# Python: Operations with files and folders

## How to create an empty file?

```python
with open("example.txt", "w"):
    pass
```

## How to overwrite a text file?

```python
with open("example.txt", "w") as file:
    file.write("Data")
```

## How to append data to the end of a text file?

```python
with open("example.txt", "a") as file:
    file.write("\nNew line of data")
```

## How to check if a file exists?

```python
import os

if os.path.exists("example.txt"):
    print("The file exists")
else:
    print("The file does not exist")
```

## How to read a text file?

```python
with open("example.txt", "r") as file:
    content = file.read()
    print(content)
```

## How to read a large text file line by line?

```python
with open("example.txt", "r", encoding="UTF-8") as file:
    while line := file.readline(): # for line in file:
        print(line.rstrip())
```

## How to copy a file?

```python
import shutil

shutil.copy('source.txt', 'destination.txt')
```

## How to move a file?

```python
import shutil

shutil.move('source.txt', 'destination.txt')
```

## How to delete a file?

```python
import os

os.remove("example.txt")
```

## How to create a new folder?

```python
import os

os.mkdir("new_folder")
```

## How to get a list of files in a folder?

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

## How to delete a folder?

```python
import os

os.rmdir("folder_path")
```

```python title="Recursive"
import shutil

shutil.rmtree("folder_path")
```

## How to find files?

```python
import glob

text_files = glob.glob("*.txt")

print(text_files)
```

## How to merge text files into one?

```python
import glob

read_files = glob.glob("./**/*.md", recursive=True)

with open(".output/result.md", "wb") as output:
    for file in files:
        with open(file, "rb") as reader:
            output.write(reader.read())
```

## How to get current directory?

```python
import os

print(f"Current work directory: {os.getcwd()}")
print(f"Current file directory: {os.path.dirname(os.path.realpath(__file__))}")
```

## How to combine path components?

```python
import os

print(os.path.join("/home/user", "example.txt"))
```

## How to get absolute path from relative?

```python
import os

print(os.path.abspath("../example.txt"))
```
