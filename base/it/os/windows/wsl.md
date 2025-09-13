---
title: WSL
description: Windows Subsystem for Linux
tags:
  - WSL
  - Windows
  - Linux
  - FAQ
---

# WSL (Windows Subsystem for Linux)

## Как получить список доступных для установки версий дистрибутивов?

```bash
wsl --list --online
```

## Как установить дистрибутив?

```bash
wsl --install --distribution Ubuntu
```

## Как проверить дистрибутив по умолчанию и версию WSL?

```bash
wsl --status
```

## Как изменить версию WSL для дистрибутива?

```bash title="Задать версию WSL для дистрибутива"
wsl --set-version ${DISTR_NAME} 2
```

```bash title="Задать версию WSL по умолчанию"
wsl --set-default-version 2
```

`2` - version number.

## Как получить список версий WSL?

```bash
wsl --list --verbose
```

## Как обновить компонент ядра Linux?

```bash
wsl --update
```

## Как удалить дистрибутив?

```bash
wsl --unregister ${DISTR_NAME}
```

## Error code: Wsl/Service/CreateVm/HCS/HCS_E_SERVICE_NOT_AVAILABLE

Установите и включите **Hyper-V**.
