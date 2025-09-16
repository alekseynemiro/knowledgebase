---
title: Pip CLI
description: Pip command-line interface.
tags:
  - pip
  - Python
  - FAQ
---

# Pip CLI

:::warning
This document has been translated using machine translation without human review.
:::

**Pip** is the standard package management tool in **Python**, used for installing and managing libraries from **PyPI** (**Python Package Index**).

## How to use pip?

```bash
pip --version
```

```bash
python -m pip --version
```

```bash
python3 -m pip --version
```

## How to install a package?

```bash
pip install package_name
```

```bash
pip install package_name --upgrade --force-reinstall --no-cache-dir
```

## How to upgrade a package?

```bash
pip install --upgrade package_name
```

## How to uninstall a package?

```bash
pip uninstall package_name
```

## How to view the list of installed packages?

```bash
pip list
```

## How to get detailed information about a package?

```bash
pip show package_name
```

## How to restore packages from requirements.txt file?

```bash
pip install -r requirements.txt
```

## How to create a requirements.txt file?

```bash
pip freeze > requirements.txt
```

:::note
Note that this command will output a list of all installed packages, including those that are probably not used.
:::
