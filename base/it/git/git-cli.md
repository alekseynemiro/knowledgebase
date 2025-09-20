---
slug: /git/cli
title: Git CLI
description: Git command-line interface
tags:
  - Git
  - FAQ
---

# Git CLI

## Как создать новый репозиторий в текущей папке?

```git
git init
```

## Как привязать локальный репозиторий к удаленному?

```git
git remote add origin https://git.exmple.org/repo.git
```

## Как клонировать/извлечь удаленный репозиторий?

```git title="Клонировать ветку master"
git clone https://github.com/alekseynemiro/knowledgebase.git
```

```git title="Клонировать определенную ветку"
git clone -b <branch_name> <repo_url>
```

## Как получить список веток из удаленного репозитория?

```git
git fetch --all
```

## Как проверить статус текущей ветки?

```git
git status
```

## Как отобразить название текущей ветки?

```git title="Имя текущей ветки"
git branch --show-current
```

```git title="Список всех веток"
git branch
```

## Как создать новую ветку?

```git title="Создать новую ветку"
git branch <branch_name>
```

```git title="Создать новую ветку и переключиться на неё"
git checkout -b <branch_name>
```

## Как переключиться на ветку?

```git
git checkout <branch_name>
```

## Как получить изменения из удаленного репозитория?

```git title="Из текущей ветки"
git pull
```

```git title="Из определённой ветки"
git pull origin <branch_name>
```

## Как зафиксировать изменения (сделать коммит)?

В большинстве случаев достаточно просто зафиксировать все изменения:

```git title="Фиксация изменений"
git commit -m "Commit message"
```

Если необходимо внести изменения в индекс:

```git title="Добавить файл или папку в индекс"
git add <file_or_dir_path>
```

* `<file_or_dir_path>` — допустимо использовать шаблон в формате wildcard. Например — `git add *.ts`.

```git title="Add all changes and ignore new files"
git add -A .
```

## Как отправить изменения в удаленный репозиторий?

```git title="Отправить в текущую ветку"
git push
```

```git title="Отправить в определённую ветку"
git push origin <target_branch_name>
```

Если целевая ветка не существует, она будет создана автоматически.  
Для отслеживания ветки используйте флаг `--set-upstream` (`-u`):

```git
git push --set-upstream origin <target_branch_name>
```

Отправить изменения для всех веток и подключить отслеживание для этих веток:

```git
git push --all --set-upstream origin
```

## Как удалить ветку?

```git title="Удалить локальную ветку"
git branch -d <branch_name>
```

```git title="Удалить удаленную ветку"
git push -d origin <branch_name>
```

Для принудительного удаления можно использовать флаг `-f`.

## Как создать метку (тег)?

В следующих примерах показано создание метки для последней фиксации (последнего коммита):

```git title="Создать новую метку"
git tag v1.0
```

```git title="Создать новую метку с сообщением"
git tag -a <tag_name> -m '<tag_message>'
```

## Как отправить метку (тег) на удаленный сервер?

```git title="Отправить метку v1.0"
git push origin tag v1.0
```

## Как удалить метку (тег)?

```git title="Удалить метку локально"
git tag -d <tag_name>
```

```git title="Удалить метку из удаленного репозитория"
git push origin -d <tag_name>
```

## Как переименовать метку (тег)?

Изменение имени тегов в **git** как такого нет. Есть обходной путь — создать новую метку со ссылкой на старую и затем удалить старую метку:

```git
git tag new old
git tag -d old
git push origin new
git push origin -d old
```

## Как удалить из локального репозитория несуществующие в удалённом репозитории метки (теги)?

```git
git fetch --prune-tags
```

## Что такое `origin`?

`origin` — имя удаленного репозитория по умолчанию.

## Как получить хэш последнего коммита, дату и имя ветки в одной строке?

Это может быть полезно для генерации номера версии.

```git
git log -1 --pretty='%H;%aI;%D'
```

## Как проверить, имеет ли коммит подпись (gpg)?

```git
git verify-commit <commit_hash>
```

```git
git log --show-signature
```
