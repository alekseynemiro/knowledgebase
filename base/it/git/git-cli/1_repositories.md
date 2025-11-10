---
slug: /git/cli/repositories
description: Работа с репозиториями через интерфейс командной строки Git.
tags:
  - Git
  - FAQ
---

# Репозитории

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

## Что такое `origin`?

`origin` — имя удаленного репозитория по умолчанию.
