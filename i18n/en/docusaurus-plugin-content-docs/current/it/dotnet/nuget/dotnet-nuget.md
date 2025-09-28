---
title: dotnet nuget
description: Command-line interface for NuGet in .NET.
tags:
  - nuget
  - dotnet nuget
  - dotnet
  - .NET
  - FAQ
---

# dotnet nuget

:::warning
This document has been translated using machine translation without human review.
:::

**dotnet nuget** — represents the integration of **NuGet** into **dotnet**.

## How to add a NuGet package source?

```bash title="Remote source"
dotnet nuget add source https://example.org --name "Source name"
```

```bash title="Source with authentication"
dotnet nuget add source https://example.org --name "Source name" -u "username" -p "password"
```

```bash title="Local folder"
dotnet nuget add source "C:\packages" --name "Source name"
```

## How to view the list of sources?

```bash
dotnet nuget list source
```

## How to disable package signature verification?

To disable **NuGet** package signature verification, you can use the environment variable `DOTNET_NUGET_SIGNATURE_VERIFICATION`:

```bash title="Windows"
set DOTNET_NUGET_SIGNATURE_VERIFICATION=false
dotnet restore
```

```bash title="Linux"
export DOTNET_NUGET_SIGNATURE_VERIFICATION=false && dotnet restore
```

## How to clear the NuGet cache?

```bash
dotnet nuget locals all --clear
```

## How to restore packages?

```bash
dotnet restore
```

## How to view package dependencies?

```bash
dotnet nuget why <PROJECT_OR_SOLUTION_FILE> <PACKAGE_NAME>
```

## How to add a NuGet package to a project?

```bash
dotnet package add <PACKAGE_NAME>
```

## How to remove a NuGet package from a project?

```bash
dotnet package remove <PACKAGE_NAME>
```
