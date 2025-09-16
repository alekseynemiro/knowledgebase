---
title: WSL
description: Windows Subsystem for Linux
tags:
  - WSL
  - Windows
  - Linux
  - FAQ
---

# WSL (Windows Subsystem for Linux)

:::warning
This document has been translated using machine translation without human review.
:::

## How to get a list of available distributions for installation?

```bash
wsl --list --online
```

## How to install a distribution?

```bash
wsl --install --distribution Ubuntu
```

## How to check the default distribution and WSL version?

```bash
wsl --status
```

## How to change the WSL version for a distribution?

```bash title="Set WSL version for distribution"
wsl --set-version ${DISTR_NAME} 2
```

```bash title="Set default WSL version"
wsl --set-default-version 2
```

`2` - version number.

## How to get a list of WSL versions?

```bash
wsl --list --verbose
```

## How to update the Linux kernel component?

```bash
wsl --update
```

## How to remove a distribution?

```bash
wsl --unregister ${DISTR_NAME}
```

## Error code: Wsl/Service/CreateVm/HCS/HCS_E_SERVICE_NOT_AVAILABLE

Install and enable **Hyper-V**.
