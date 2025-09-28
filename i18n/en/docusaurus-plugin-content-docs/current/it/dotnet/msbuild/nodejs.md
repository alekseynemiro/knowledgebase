---
description: Setting up Node.js build using MSBuild.
tags:
  - msbuild
  - dotnet
  - .NET
  - Node.js
  - FAQ
---

# Integration with Node.js

:::warning
This document has been translated using machine translation without human review.
:::

## How to run a Node.js script?

The following example shows running a **Node.js** script before building the main project:

```xml title="props (optional)"
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
    <Error Condition=" '$(NodeJsPath)' == '' " Code="NODEJS_PATH_REQUIRED" Text="Please specify the path to Node.js in the NodeJsPath property in the *.csproj.user file, or set the NodeJsPath environment variable." />
    <Message Condition=" '$(NpmRestore.ToLowerInvariant())' == 'true' " Importance="normal" Text="Restoring npm packages..." />
    <Exec Condition=" '$(NpmRestore.ToLowerInvariant())' == 'true' " Command="&quot;$(NodeJsPath)\npm&quot; ci" ConsoleToMSBuild="true">
      <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
    </Exec>
    <Message Importance="normal" Text="Building npm..." />
    <Exec Command="&quot;$(NodeJsPath)\npm&quot; run $(NpmScript)" ConsoleToMSBuild="true">
      <Output TaskParameter="ConsoleOutput" PropertyName="OutputOfExec" />
    </Exec>
  </Target>
</Project>
```

## How to determine the location of Node.js/npm?

The following example shows a cross-platform solution for determining the location of **Node.js** in the system:

```xml title="props (optional)"
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
    <Message Importance="normal" Text="Searching for npm..." />

    <Exec Condition=" '$(OS)' == 'Windows_NT' " Command="where node" ConsoleToMsBuild="true" ContinueOnError="WarnAndContinue">
      <Output TaskParameter="ConsoleOutput" PropertyName="NodePathAuto" />
    </Exec>

    <Exec Condition=" '$(OS)' == 'Unix' " Command="which node" ConsoleToMsBuild="true" ContinueOnError="WarnAndContinue">
      <Output TaskParameter="ConsoleOutput" PropertyName="NodePathAuto" />
    </Exec>

    <Message Condition=" '$(NodePathAuto)' == '' " Importance="normal" Text="Failed to detect Node.js." />
    <Message Condition=" '$(NodePathAuto)' != '' " Importance="normal" Text="Node.js detected: $([System.IO.Path]::GetDirectoryName('$(NodePathAuto)'))" />

    <PropertyGroup>
      <NodePath Condition=" '$(NodePathAuto)' != '' ">$([System.IO.Path]::GetDirectoryName('$(NodePathAuto)'))</NodePath>
    </PropertyGroup>
  </Target>
</Project>
```

As a result of executing the target task, the `NodePathAuto` variable will contain the full physical path to the **Node.js** executable file, and the `NodePath` variable will contain the path to the **Node.js** directory.

`NodePath` can be used in other target tasks, for example, to run a script:

```xml title="props (optional)"
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

    <Error Condition=" '$(NodePath)' == '' " Text="Failed to find the path to Node.js. Specify the NodePath parameter in the .csproj.user file, or in the environment variable, or in the dotnet command call arguments (for example, dotnet build --property:NodePath=/usr/bin/node)." />

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

    <Message Condition=" '$(NodePath)' != '' AND '$(NpmRestore.ToLowerInvariant())' == 'true' " Importance="high" Text="Restoring npm packages..." />

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

    <Message Condition=" '$(NodePath)' != '' " Importance="high" Text="Executing npm script..." />

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
