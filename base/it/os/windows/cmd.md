---
title: Command Prompt
description: Window Command Prompt
tags:
  - CMD
  - Windows Command Prompt
  - Windows Command Processor
  - Windows
---

# Windows Command Prompt

## How to open a command prompt in any folder?

Just type `cmd` in the address bar of the explorer:

![cmd](assets/cmd.png)

If you hold down the `Shift` key and right-click anywhere, you will be able to launch PowerShell:

![PowerShell](assets/powershell.png)

## How to set environment variable? (for session only)

```bash
set VAR_NAME=VALUE
```

## How to get the hostname of the current machine?

```bash
hostname
```

## How to create a symbolic link?

```bash title="Syntax"
mklink LINK_PATH TARGET_PATH
```

```bash title="Example"
mklink  "C:\Program Files\nodejs" "C:\nvm\v18.16.0" 
```

## How to view the current DNS cache?

```bash title="View cache"
ipconfig /displaydns
```

```bash title="Clear cache"
ipconfig /flushdns
```

## How to find all substrings in command output?

```
dir | findstr git
```

## How to launch the event log?

```bash
eventvwr
```
