---
title: Hugging Face
description: AI community.
tags:
  - Hugging Face
  - huggingface.co
  - huggingface-cli
  - LLM
  - Machine Learning
  - AI
  - Большие языковые модели
  - ИИ
---

# :hugs: Hugging Face

**Hugging Face** — американская компания, разработавшая архитектуру Transformer и активно продвигающая машинное обучение в массы.

Является разработчиком портала [huggingface.co](https://huggingface.co/), который содержит много информации о машинном обучении, наборы данных, модели и т.д.

## huggingface-cli

**huggingface-cli** представляет собой интерфейс командной строки (CLI) для работы с [huggingface.co](https://huggingface.co/).

:::note
Информация актуальна для **huggingface-cli v0.27.1**.
:::

1. Для установки модуля `huggingface-cli` выполните команду:

    ```bash
    pip install -U "huggingface_hub[cli]"
    ```

    :::note
    Необходим Python - https://www.python.org/downloads/
    :::

2. Убедитесь, что приложение установлено:

    ```bash
    huggingface-cli --help
    ```

3. Если все нормально, можно использовать приложение. Например, можно скачать gguf-файл модель [phi-4-gguf](https://huggingface.co/microsoft/phi-4-gguf/tree/main):

    ```bash
    huggingface-cli download microsoft/phi-4-gguf phi-4-q4.gguf --local-dir "D:\Downloads"
    ```

   или репозиторий модели целиком:

    ```bash
    huggingface-cli download microsoft/phi-4-gguf --local-dir "D:\Downloads"
    ```
