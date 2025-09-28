---
title: "Python: Installation"
description: Python installation guide.
tags:
  - Python
  - FAQ
---

# Python: Installation

:::warning
This document has been translated using machine translation without human review.
:::

## How to install Python from source?

Guide to installing **Python** from source in **Ubuntu**.

1\. Install required packages:

```bash
sudo apt-get update
sudo apt-get install -y build-essential libssl-dev zlib1g-dev libncurses5-dev libncursesw5-dev libreadline-dev libsqlite3-dev libgdbm-dev libdb5.3-dev libbz2-dev libexpat1-dev liblzma-dev tk-dev libffi-dev wget
```

2\. Download source code for the required **Python** version: [https://www.python.org/ftp/python/](https://www.python.org/ftp/python/)

```bash
cd /usr/src
sudo wget https://www.python.org/ftp/python/3.13.0/Python-3.13.0.tgz
sudo tar xzf Python-3.13.0.tgz
cd Python-3.13.0
```

3\. Build and install **Python**:

```bash
sudo ./configure --enable-optimizations --with-ensurepip=install
sudo make -j $(nproc)
sudo make altinstall
```

:::note
Use `make altinstall` instead of `make install` to avoid overwriting the standard **Python**.
:::

4\. Add an alias for convenience:

```bash
echo "alias python13='python3.13'" >> ~/.bashrc
source ~/.bashrc
```

5\. Enjoy!

```bash
python3.13 --version
```
