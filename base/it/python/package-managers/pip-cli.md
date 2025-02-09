---
title: Pip CLI
description: Pip command-line interface.
tags:
  - pip
  - Python
  - FAQ
---

**Pip** is the standard package management tool for Python, used to install and manage libraries from the PyPI (Python Package Index).

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

## How to get detailed information about a specific package?

```bash
pip show package_name
```

## How to restore packages from a requirements.txt file?

```bash
pip install -r requirements.txt
```

## How to create requirements.txt file?

```bash
pip freeze > requirements.txt
```

:::note
Note that this command will list all installed packages, including those that are probably not used.
:::
