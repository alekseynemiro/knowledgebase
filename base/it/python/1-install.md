---
title: "Python: Установка"
description: Руководство по установке Python.
tags:
  - Python
  - FAQ
---

# Python: Установка

## Как установить Python из исходного кода?

Руководство по установке **Python** из исходного кода в **Ubuntu**.

1\. Установите необходимые пакеты:

```bash
sudo apt-get update
sudo apt-get install -y build-essential libssl-dev zlib1g-dev libncurses5-dev libncursesw5-dev libreadline-dev libsqlite3-dev libgdbm-dev libdb5.3-dev libbz2-dev libexpat1-dev liblzma-dev tk-dev libffi-dev wget
```

2\. Скачайте исходный кода нужной версии **Python**: [https://www.python.org/ftp/python/](https://www.python.org/ftp/python/)

```bash
cd /usr/src
sudo wget https://www.python.org/ftp/python/3.13.0/Python-3.13.0.tgz
sudo tar xzf Python-3.13.0.tgz
cd Python-3.13.0
```

3\. Соберите и установите **Python**:

```bash
sudo ./configure --enable-optimizations --with-ensurepip=install
sudo make -j $(nproc)
sudo make altinstall
```

:::note
Используйте `make altinstall`, вместо `make install`, чтобы не перезаписывать стандартный **Python**.
:::

4\. Добавьте псевдоним для удобства:

```bash
echo "alias python13='python3.13'" >> ~/.bashrc
source ~/.bashrc
```

5\. Наслаждайтесь!

```bash
python3.13 --version
```
