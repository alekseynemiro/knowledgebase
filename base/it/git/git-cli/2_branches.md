---
slug: /git/cli/branches
description: Работа с ветками через интерфейс командной строки Git.
tags:
  - Git
  - FAQ
---

# Ветки

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

## Как удалить ветку?

```git title="Удалить локальную ветку"
git branch -d <branch_name>
```

```git title="Удалить удаленную ветку"
git push -d origin <branch_name>
```

Для принудительного удаления можно использовать флаг `-f`.

## Как восстановить удалённую ветку?

Если ветка была объединена с основной веткой, то можно легко найти нужную фиксацию:

```git
$ git log --merges --oneline --all

c58d979 Merge pull request #109 from alekseynemiro/MDSWTCH-108
b166f35 Merge pull request #107 from alekseynemiro/MDSWTCH-106
698a6ea Merge pull request #105 from alekseynemiro/MDSWTCH-104
436435d Merge pull request #102 from alekseynemiro/MDSWTCH-97
```

С помощью команды `git show` можно получить хэши веток, которые участвовали в слиянии.

В нижеследующем примере `13eeb27` - это ветка, в которую были влиты данные (обычно - `master`), а `05215eb` - вливаемая ветка (ветка, которую нужно восстановить).

```git
$ git show b166f35

commit b166f3556519970b1a42b306aa459a465eb9790f
Merge: 13eeb27 05215eb
Author: Aleksey Nemiro <aleksey@kbyte.ru>
Date:   Fri Oct 13 18:10:45 2023 +0300

    Merge pull request #107 from alekseynemiro/MDSWTCH-106

    106_to_v1.2: Cannot read property 'backdrop' of undefined
```

Чтобы восстановить ветку, достаточно создать её от найденного хэша.

В следующем примере будет восстановлена ветка `MDSWTCH-106`:

```git
git checkout -b MDSWTCH-106 05215eb
```
