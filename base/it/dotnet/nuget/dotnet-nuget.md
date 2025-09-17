---
title: dotnet nuget
description: Интерфейс командной строки для NuGet в .NET.
tags:
  - nuget
  - dotnet nuget
  - dotnet
  - .NET
  - FAQ
---

# dotnet nuget

**dotnet nuget** — представляет собой интеграцию **NuGet** в **dotnet**.

## Как добавить источник пакетов NuGet?

```bash title="Удалённый источник"
dotnet nuget add source https://example.org --name "Имя источника"
```

```bash title="Источник с авторизацией"
dotnet nuget add source https://example.org --name "Имя источника" -u "username" -p "password"
```

```bash title="Локальная папка"
dotnet nuget add source "C:\packages" --name "Имя источника"
```

## Как посмотреть список источников?

```bash
dotnet nuget list source
```

## Как отключить проверку подписи пакетов?

Для отключения проверки подписи пакетов **NuGet** можно использовать переменную окружения `DOTNET_NUGET_SIGNATURE_VERIFICATION`:

```bash title="Windows"
set DOTNET_NUGET_SIGNATURE_VERIFICATION=false
dotnet restore
```

```bash title="Linux"
export DOTNET_NUGET_SIGNATURE_VERIFICATION=false && dotnet restore
```

## Как очистить кэш NuGet?

```bash
dotnet nuget locals all --clear
```

## Как восстановить пакеты?

```bash
dotnet restore
```

## Как посмотреть зависимости пакета?

```bash
dotnet nuget why <PROJECT_OR_SOLUTION_FILE> <PACKAGE_NAME>
```

## Как добавить NuGet-пакет в проект?

```bash
dotnet package add <PACKAGE_NAME>
```

## Как удалить NuGet-пакет из проекта?

```bash
dotnet package remove <PACKAGE_NAME>
```
