---
title: "llama.cpp: Быстрый старт"
description: Простые шаги для начала работы с llama.cpp.
tags:
  - llama.cpp
  - llama-cli
  - llama-server
  - llama
  - LLM
  - Machine Learning
  - AI
  - Step-by-Step
  - ИИ
  - Машинное обучение
  - Большие языковые модели
---

# llama.cpp: Быстрый старт

1. Загрузите последнюю версию **llama.cpp** под свою платформу: https://github.com/ggerganov/llama.cpp/releases
   Например, для **Windows** с поддержкой **GPU** необходимо скачать: **llama-b4458-bin-win-cuda-cu12.4-x64.zip** + **cudart-llama-bin-win-cu12.4-x64.zip**.

2. Извлеките файлы из скаченных архивов. Если вы скачали файлы **cudart**, поместите файлы **dll** в папку с распакованными файлами **llama.cpp**.

3. Найдите и скачайте файлы моделей (LLM) в формате **guff**: [https://huggingface.co/models?search=gguf](https://huggingface.co/models?search=gguf).  
   Например, [https://huggingface.co/lmstudio-community/Meta-Llama-3-8B-Instruct-GGUF/tree/main](https://huggingface.co/lmstudio-community/Meta-Llama-3-8B-Instruct-GGUF/tree/main):
   ![Скачивание файлов с сайта Hugging Face](assets/huggingface-download.png)

4. Запустите командную строку в папке **llama.cpp** и выполните следующую команду:

   ```bash
   llama-cli -m model.gguf -p "Ты умный помогатель. Помогай чем только сможешь." -cnv
   ```

5. Наслаждайтесь!
