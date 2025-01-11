---
title: Hugging Face
tags:
  - Hugging Face
  - huggingface.co
  - huggingface-cli
  - LLM
  - Machine Learning
  - AI
---

# Hugging Face :hugs:

An American company that developed the Transformer architecture and actively promotes machine learning to the masses.

The [huggingface.co](https://huggingface.co/) website contains much information on machine learning, datasets, models, etc.

## huggingface-cli

**huggingface-cli** is a command line interface for working with the [huggingface.co](https://huggingface.co/) website.

1. Use the command line interface to install `huggingface-cli`:

    ```bash
    pip install -U "huggingface_hub[cli]"
    ```

    :::note
    Python is required, [download](https://www.python.org/downloads/) and install it if you don't have it already.
    :::

2. Make sure the app is installed:

    ```bash
    huggingface-cli --help
    ```

3. Now you can, for example, download [phi-4-gguf](https://huggingface.co/microsoft/phi-4-gguf/tree/main) model:

    ```bash
    huggingface-cli download microsoft/phi-4-gguf phi-4-q4.gguf --local-dir "D:\Downloads"
    ```

    or the entire repository:

    ```bash
    huggingface-cli download microsoft/phi-4-gguf --local-dir "D:\Downloads"
    ```
