---
description: Пакет llama.cpp для Python.
tags:
  - llama-cpp-python
  - llama.cpp
  - llama
  - LLM
  - Machine Learning
  - AI
  - FAQ
  - ИИ
  - Машинное обучение
  - Большие языковые модели
---

# llama-cpp-python

**llama-cpp-python** — это обёртка (bindings) библиотеки **[llama.cpp](./)** на **Python**.

Пакет можно использовать напрямую как есть, но лучше воспользоваться библиотеками **[LangChain](../langchain)** или **[LangGraph](../langgraph)**.

* [https://llama-cpp-python.readthedocs.io/](https://llama-cpp-python.readthedocs.io/)
* [https://github.com/abetlen/llama-cpp-python](https://github.com/abetlen/llama-cpp-python)

## Как установить llama-cpp-python?

```bash
pip install llama-cpp-python
```

## Как включить поддержку CUDA при использовании llama-cpp-python?

Если есть видеокарта от **NVIDIA** с ядрами **CUDA**, то для их эффективного использования необходимо установить **NVIDIA CUDA Toolkit**.

И затем нужно установить/переустановить пакет **llama-cpp-python** с флагом, который включит использование **CUDA**:

```bash title="Windows"
set CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

```bash title="Linux"
export CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

## Как использовать llama-cpp-python?

```python
from llama_cpp import Llama

llm = Llama(
  model_path="C:/models/Meta-Llama-3.1-8B-Instruct-Q8_0.gguf",
  # seed=1337, # задаёт начальное значение контекста
  # n_ctx=2048, # задаёт размер окна контекста, в данном случае 2048 токенов
);

response = llm(
    "Q: Что ты знаешь о планете Земля? Напиши, пожалуйста, одно короткое предложение. A:", # инструкция (prompt)
    max_tokens=42, # сгенерировать не более 42 токенов
    stop=["Q:", "\n"], # остановить генерацию перед тем, как модель сгенерирует новый вопрос
    echo=True, # возвращать подсказку в выводе
)

print(response)
```

```json title="Результат"
{
  'id': 'cmpl-dba56ef6-214c-4ced-b4e7-db813798ef0f', 
  'object': 
  'text_completion', 
  'created': 1737831941, 
  'model': 'C:/models/Meta-Llama-3.1-8B-Instruct-Q8_0.gguf', 
  'choices': [
    {
      'text': 'Q: Что ты знаешь о планете Земля? Напиши, пожалуйста, одно короткое предложение. A: Это третья планета в нашей Солнечной системе.', 
      'index': 0, 
      'logprobs': None, 
      'finish_reason': 'stop'
      }
  ], 
  'usage': {
    'prompt_tokens': 19,
    'completion_tokens': 10,
    'total_tokens': 29
  }
}
```
