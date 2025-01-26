---
description: Simple steps to get started with llama.cpp.
tags:
  - llama.cpp
  - llama-cli
  - llama-server
  - llama
  - LLM
  - Machine Learning
  - AI
  - Step-by-Step
---

# Get started

1. Download the latest release: https://github.com/ggerganov/llama.cpp/releases
   For example, for Windows with GPU: **llama-b4458-bin-win-cuda-cu12.4-x64.zip** + **cudart-llama-bin-win-cu12.4-x64.zip**.

2. Extract files. If you downloaded **cudart**, place the dll files in the **llama.cpp** folder.

3. Find and download the guff files of LLM(s): [https://huggingface.co/models?search=gguf](https://huggingface.co/models?search=gguf).  
   For example, [https://huggingface.co/lmstudio-community/Meta-Llama-3-8B-Instruct-GGUF/tree/main](https://huggingface.co/lmstudio-community/Meta-Llama-3-8B-Instruct-GGUF/tree/main):
   ![Download files from Hugging Face](assets/huggingface-download.png)

4. Launch command prompt and run the following command:

   ```bash
   llama-cli -m model.gguf -p "You are a helpful assistant" -cnv
   ```

5. Enjoy!
