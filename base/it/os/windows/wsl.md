---
title: WSL
description: Windows Subsystem for Linux
tags:
  - WSL
  - Windows
  - Linux
---

# WSL (Windows Subsystem for Linux)

## How to find a list of available versions of distributions for installation?

```bash
wsl --list --online
```

## How to install distribution?

```bash
wsl --install --distribution Ubuntu
```

## How to check the default distribution and WSL version?

```bash
wsl --status
```

## How to change the WSL version for distribution?

```bash title="Set for distribution"
wsl --set-version ${DISTR_NAME} 2
```

```bash title="Set default"
wsl --set-default-version 2
```

`2` - version number.

## How to find the WSL version for distribution?

```bash
wsl --list --verbose
```

## How to update a Linux kernel component?

```bash
wsl --update
```

## How to remove distribution?

```bash
wsl --unregister ${DISTR_NAME}
```

## Error code: Wsl/Service/CreateVm/HCS/HCS_E_SERVICE_NOT_AVAILABLE

Install and enable Hyper-V.
