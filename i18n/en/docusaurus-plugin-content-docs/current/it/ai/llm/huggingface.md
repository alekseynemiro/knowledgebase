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
---

# :hugs: Hugging Face

:::warning
This document has been translated using machine translation without human review.
:::

**Hugging Face** is an American company that developed the Transformer architecture and actively promotes machine learning to the masses.

It is the developer of the [huggingface.co](https://huggingface.co/) portal, which contains a lot of information about machine learning, datasets, models, etc.

## huggingface-cli

**huggingface-cli** is a command-line interface (CLI) for working with [huggingface.co](https://huggingface.co/).

:::note
Information is current for **huggingface-cli v0.27.1**.
:::

1. To install the `huggingface-cli` module, run the command:

    ```bash
    pip install -U "huggingface_hub[cli]"
    ```

    :::note
    Python is required - https://www.python.org/downloads/
    :::

2. Verify that the application is installed:

    ```bash
    huggingface-cli --help
    ```

3. If everything is okay, you can use the application. For example, you can download the gguf file of the [phi-4-gguf](https://huggingface.co/microsoft/phi-4-gguf/tree/main) model:

    ```bash
    huggingface-cli download microsoft/phi-4-gguf phi-4-q4.gguf --local-dir "D:\Downloads"
    ```

   or the entire model repository:

    ```bash
    huggingface-cli download microsoft/phi-4-gguf --local-dir "D:\Downloads"
    ```
