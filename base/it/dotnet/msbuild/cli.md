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
Использование `dotnet` в большинстве случаев предпочтительней, чем `msbuild`.
:::

## Как запустить msbuild?

Проще всего использовать **Development Command Prompt for Visual Studio**.

## Как собрать проект/решение?

```batch title="Сборка решения с помощью msbuild"
msbuild MySolution.sln
```

```batch title="Сборка проекта с помощью msbuild"
msbuild MyProject.csproj
```

## Как указать конфигурацию при сборке проекта/решения?

```batch
msbuild MyProject.csproj /property:Configuration=Release /property:Platform=x64
```

## Как выполнить целевую задачу?

Указать имя цели можно с помощью параметра `/target:` (`/t:`). Если нужно выполнить несколько целей, то можно указать их через запятую.

```batch
msbuild MyProject.csproj /target:Clean,Build
```

## Как включит вывод подробной информации при сборке?

```batch
msbuild MyProject.csproj /verbosity:diagnostic
```

```batch
msbuild MyProject.csproj /v:diag
```

Возможные значения:

* quiet (q)
* normal (n)
* minimal (m)
* detailed (d)
* diagnostic (diag)
