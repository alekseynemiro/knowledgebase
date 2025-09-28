---
description: Настройка сборки Node.js с использованием MSBuild.
tags:
  - msbuild
  - dotnet
  - .NET
  - Node.js
  - FAQ
---

# Интеграция с Node.js

## Как запустить скрипт Node.js?

В следующем примере показан запуск скрипта **Node.js** перед выполнением сборки основного проекта:

```xml title="props (опционально)"
<Project>
  <PropertyGroup>
    <NpmScript Condition=" '$(NpmScript)' == '' AND $(Configuration) != 'Release'">build-dev</NpmScript>
    <NpmScript Condition=" '$(NpmScript)' == '' AND $(Configuration) == 'Release'">build-prod</NpmScript>
    <NpmRestore>true</NpmRestore>
  </PropertyGroup>
</Project>
```

```xml title="target"
<Project>
  <Target Name="NpmBuild" BeforeTargets="Build">
    <Error Condition=" '$(NodeJsPath)' == '' " Code="NODEJS_PATH_REQUIRED" Text="Пожалуйста, укажите путь к Node.js в свойстве NodeJsPath в файл *.csproj.user, либо задайте переменную окружения NodeJsPath." />
    <Message Condition=" '$(NpmRestore.ToLowerInvariant())' == 'true' " Importance="normal" Text="Восстановление пакетов npm..." />
    <Exec Condition=" '$(NpmRestore.ToLowerInvariant())' == 'true' " Command="&quot;$(NodeJsPath)\npm&quot; ci" ConsoleToMSBuild="true">
      <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
    </Exec>
    <Message Importance="normal" Text="Сборка npm..." />
    <Exec Command="&quot;$(NodeJsPath)\npm&quot; run $(NpmScript)" ConsoleToMSBuild="true">
      <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
    </Exec>
  </Target>
</Project>
```

## Как определить путь расположения Node.js/npm?

В следующем примере показано кросс-платформенное решение для определения расположения **Node.js** в системе:

```xml title="props (опционально)"
<Project>
  <PropertyGroup>
    <NpmBuild>true</NpmBuild>
    <NodePath />
  </PropertyGroup>
</Project>
```

```xml title="target"
<Project>
  <Target Name="WHERE_NODEJS" BeforeTargets="BeforeBuild" Condition=" '$(NpmBuild.ToLowerInvariant())' == 'true' AND '$(NodePath)' == '' ">
    <Message Importance="normal" Text="Поиск npm..." />

    <Exec Condition=" '$(OS)' == 'Windows_NT' " Command="where node" ConsoleToMsBuild="true" ContinueOnError="WarnAndContinue">
      <Output TaskParameter="ConsoleOutput" PropertyName="NodePathAuto" />
    </Exec>

    <Exec Condition=" '$(OS)' == 'Unix' " Command="which node" ConsoleToMsBuild="true" ContinueOnError="WarnAndContinue">
      <Output TaskParameter="ConsoleOutput" PropertyName="NodePathAuto" />
    </Exec>

    <Message Condition=" '$(NodePathAuto)' == '' " Importance="normal" Text="Не удалось обнаружить Node.js." />
    <Message Condition=" '$(NodePathAuto)' != '' " Importance="normal" Text="Обнаружен Node.js: $([System.IO.Path]::GetDirectoryName('$(NodePathAuto)'))" />

    <PropertyGroup>
      <NodePath Condition=" '$(NodePathAuto)' != '' ">$([System.IO.Path]::GetDirectoryName('$(NodePathAuto)'))</NodePath>
    </PropertyGroup>
  </Target>
</Project>
```

В результате выполнения целевой задачи в переменной `NodePathAuto` будет полный физический путь к исполняемому файлу **Node.js**, а в переменной `NodePath` — путь к каталогу **Node.js**.

`NodePath` можно использовать в других целевых задачах, например, для запуска скрипта:

```xml title="props (опционально)"
<Project>
  <PropertyGroup>
    <NpmBuild>true</NpmBuild>
    <NpmRestore>auto</NpmRestore>
    <NodePath />
    <NpmScriptName />
  </PropertyGroup>
</Project>
```

```xml title="target"
<Project>
  <Target Name="NPM_BUILD" AfterTargets="WHERE_NODEJS" Condition=" '$(NpmBuild.ToLowerInvariant())' == 'true' ">
    <PropertyGroup>
      <NodeModulesPath>$(MSBuildProjectDirectory)\node_modules</NodeModulesPath>
      <NpmScriptName Condition=" '$(NpmScriptName)' == '' AND '$(Configuration)' != 'Release' ">build:dev</NpmScriptName>
      <NpmScriptName Condition=" '$(NpmScriptName)' == '' AND '$(Configuration)' == 'Release' ">build:prod</NpmScriptName>
    </PropertyGroup>

    <Error Condition=" '$(NodePath)' == '' " Text="Не удалось найти путь к Node.js. Укажите параметр NodePath в файле .csproj.user, либо в переменной окружения, либо в аргументах вызова команды dotnet (например, dotnet build --property:NodePath=/usr/bin/node)." />

    <Exec
      Condition=" '$(OS)' == 'Windows_NT' AND '$(NodePath)' != '' "
      Command="&quot;$(NodePath)\node&quot; --version"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NodeVersionResult"  />
    </Exec>

    <Exec
      Condition=" '$(OS)' == 'Unix' AND '$(NodePath)' != '' "
      Command="PATH=$PATH:$(NodePath) &amp;&amp; $(NodePath)/node --version"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NodeVersionResult"  />
    </Exec>

    <Message Condition=" '$(NodePath)' != '' AND '$(NpmRestore.ToLowerInvariant())' == 'true' " Importance="high" Text="Восстановление пакетов npm..." />

    <Exec
      Condition=" '$(OS)' == 'Windows_NT' AND '$(NodePath)' != '' AND ('$(NpmRestore.ToLowerInvariant())' == 'true' OR ('$(NpmRestore.ToLowerInvariant())' == 'auto' AND '$(Configuration)' == 'Debug' AND !Exists('$(NodeModulesPath)')) OR ('$(NpmRestore.ToLowerInvariant())' == 'auto' AND '$(Configuration)' == 'Release')) "
      Command="&quot;$(NodePath)\npm&quot; ci"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NpmCiResult" />
    </Exec>

    <Exec
      Condition=" '$(OS)' == 'Unix' AND '$(NodePath)' != '' AND ('$(NpmRestore.ToLowerInvariant())' == 'true' OR ('$(NpmRestore.ToLowerInvariant())' == 'auto' AND '$(Configuration)' == 'Debug' AND !Exists('$(NodeModulesPath)')) OR ('$(NpmRestore.ToLowerInvariant())' == 'auto' AND '$(Configuration)' == 'Release')) "
      Command="PATH=$PATH:$(NodePath) &amp;&amp; $(NodePath)/npm ci"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NpmCiResult" />
    </Exec>

    <Message Condition=" '$(NodePath)' != '' " Importance="high" Text="Выполнение скрипта npm..." />

    <Exec
      Condition=" '$(OS)' == 'Windows_NT' AND '$(NodePath)' != '' "
      Command="&quot;$(NodePath)\npm&quot; run $(NpmScriptName)"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NpmRunDevResult" />
    </Exec>

    <Exec
      Condition=" '$(OS)' == 'Unix' AND '$(NodePath)' != '' "
      Command="PATH=$PATH:$(NodePath) &amp;&amp; $(NodePath)/npm run $(NpmScriptName)"
    >
      <Output TaskParameter="ConsoleOutput" PropertyName="NpmRunDevResult" />
    </Exec>
  </Target>
</Project>
```
