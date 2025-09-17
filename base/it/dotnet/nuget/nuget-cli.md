---
title: NuGet CLI
description: Интерфейс командной строки NuGet в .NET Framework.
tags:
  - nuget
  - nuget.exe
  - .NET Framework
  - FAQ
---

# NuGet CLI

:::warning
Скорее всего вам нужен [dotnet nuget](dotnet-nuget.md).
:::

**NuGet CLI** (nuget.exe) — интерфейс командной строки предоставляет функционал для установки, создания, публикации и управления пакетами.

## В чем отличия nuget.exe от dotnet nuget?

* `nuget.exe` — это **NuGet CLI**. В основном ориентирован на **Windows** и устаревший **.NET Framework**. Является отдельным приложением.
* `dotnet nuget` - реализация интерфейс командной строки для **NuGet** в **.NET Core**. По умолчанию включён в **.NET SDK**. Это более современный и удобный инструмент для **.NET**.

## Как установить NuGet CLI?

Для установки интерфейса командной строки **NuGet** необходимо скачать приложение `nuget.ext`:

* **Windows** — [https://dist.nuget.org/win-x86-commandline/latest/nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
* **Linux** — `sudo curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe`.  
  Запуск через `mono`. Для удобства можно добавить псевдоним: `echo "alias nuget='mono /usr/local/bin/nuget.exe'" >> ~/.bashrc` (или `~/.bash_aliases`, или `~/.bash_profile`).
