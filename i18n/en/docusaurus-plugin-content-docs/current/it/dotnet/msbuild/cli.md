---
description: MSBuild command-line interface.
tags:
  - msbuild
  - dotnet
  - .NET
  - FAQ
---

# MSBuild CLI

:::warning
This document has been translated using machine translation without human review.
:::

:::warning
Using `dotnet` is preferable to `msbuild` in most cases.
:::

## How to run msbuild?

The easiest way is to use **Developer Command Prompt for Visual Studio**.

## How to build a project/solution?

```batch title="Building a solution with msbuild"
msbuild MySolution.sln
```

```batch title="Building a project with msbuild"
msbuild MyProject.csproj
```

## How to specify configuration when building a project/solution?

```batch
msbuild MyProject.csproj /property:Configuration=Release /property:Platform=x64
```

## How to execute a target task?

You can specify the target name using the `/target:` (`/t:`) parameter. If you need to execute multiple targets, you can specify them separated by commas.

```batch
msbuild MyProject.csproj /target:Clean,Build
```

## How to enable detailed output during build?

```batch
msbuild MyProject.csproj /verbosity:diagnostic
```

```batch
msbuild MyProject.csproj /v:diag
```

Possible values:

* quiet (q)
* normal (n)
* minimal (m)
* detailed (d)
* diagnostic (diag)
