---
title: NuGet CLI
description: NuGet command line interface in .NET Framework.
tags:
  - nuget
  - nuget.exe
  - .NET Framework
  - FAQ
---

# NuGet CLI

:::warning
This document has been translated using machine translation without human review.
:::

:::warning
Most likely you need [dotnet nuget](dotnet-nuget.md).
:::

**NuGet CLI** (nuget.exe) — command line interface provides functionality for installing, creating, publishing and managing packages.

## What are the differences between nuget.exe and dotnet nuget?

* `nuget.exe` — is **NuGet CLI**. Mainly focused on **Windows** and legacy **.NET Framework**. It is a separate application.
* `dotnet nuget` - implementation of command line interface for **NuGet** in **.NET Core**. Included by default in **.NET SDK**. This is a more modern and convenient tool for **.NET**.

## How to install NuGet CLI?

To install **NuGet** command line interface you need to download the `nuget.ext` application:

* **Windows** — [https://dist.nuget.org/win-x86-commandline/latest/nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
* **Linux** — `sudo curl -o /usr/local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe`.  
  Run via `mono`. For convenience, you can add an alias: `echo "alias nuget='mono /usr/local/bin/nuget.exe'" >> ~/.bashrc` (or `~/.bash_aliases`, or `~/.bash_profile`).
