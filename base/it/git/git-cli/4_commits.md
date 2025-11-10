---
slug: /git/cli/commits
description: Получение и фиксация изменений через интерфейс командной строки Git.
tags:
  - Git
  - FAQ
---

# Изменения

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

## Как получить список всех слияний (merge commits)?

```git
git log --merges --oneline --all
```
