---
title: Pip CLI
description: Pip command-line interface.
tags:
  - pip
  - Python
  - FAQ
---

# Pip CLI

**Pip** — стандартный инструмент управления пакетами в **Python**, используемый для установки и управления библиотеками из **PyPI** (**Python Package Index**).

## Как использовать pip?

```bash
pip --version
```

```bash
python -m pip --version
```

```bash
python3 -m pip --version
```

## Как установить пакет?

```bash
pip install package_name
```

```bash
pip install package_name --upgrade --force-reinstall --no-cache-dir
```

## Как обновить пакет?

```bash
pip install --upgrade package_name
```

## Как удалить пакет?

```bash
pip uninstall package_name
```

## Как посмотреть список установленных пакетов?

```bash
pip list
```

## Как получить детальную информацию о пакете?

```bash
pip show package_name
```

## Как восстановить пакеты из файла requirements.txt?

```bash
pip install -r requirements.txt
```

## Как создать файл requirements.txt?

```bash
pip freeze > requirements.txt
```

:::note
Обратите внимание, что эта команда выведет список всех установленных пакетов, включая те, которые, вероятно, не используются.
:::
