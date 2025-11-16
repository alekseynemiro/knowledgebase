---
description: Python bindings for llama.cpp.
tags:
  - llama-cpp-python
  - llama.cpp
  - llama
  - LLM
  - Machine Learning
  - AI
  - FAQ
---

# llama-cpp-python

:::warning
This document has been translated using machine translation without human review.
:::

**llama-cpp-python** is a Python binding for the **[llama.cpp](./)** library.

The package can be used directly as is, but it's better to use the **[LangChain](/it/ai/llm/langchain)** or **[LangGraph](/it/ai/llm/langgraph)** libraries.

* [https://llama-cpp-python.readthedocs.io/](https://llama-cpp-python.readthedocs.io/)
* [https://github.com/abetlen/llama-cpp-python](https://github.com/abetlen/llama-cpp-python)

## How to install llama-cpp-python?

```bash
pip install llama-cpp-python
```

## How to enable CUDA support when using llama-cpp-python?

If you have an **NVIDIA** graphics card with **CUDA** cores, you need to install the **NVIDIA CUDA Toolkit** to use them effectively.

Then you need to install/reinstall the **llama-cpp-python** package with a flag that enables **CUDA** usage:

```bash title="Windows"
set CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

```bash title="Linux"
export CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

## How to use llama-cpp-python?

```python
from llama_cpp import Llama

llm = Llama(
  model_path="C:/models/Meta-Llama-3.1-8B-Instruct-Q8_0.gguf",
  # seed=1337, # sets the initial context value
  # n_ctx=2048, # sets the context window size, in this case 2048 tokens
);

response = llm(
    "Q: What do you know about planet Earth? Please write one short sentence. A:", # instruction (prompt)
    max_tokens=42, # generate no more than 42 tokens
    stop=["Q:", "\n"], # stop generation before the model generates a new question
    echo=True, # return the prompt in the output
)

print(response)
```

```json title="Result"
{
  'id': 'cmpl-dba56ef6-214c-4ced-b4e7-db813798ef0f', 
  'object': 
  'text_completion', 
  'created': 1737831941, 
  'model': 'C:/models/Meta-Llama-3.1-8B-Instruct-Q8_0.gguf', 
  'choices': [
    {
      'text': 'Q: What do you know about planet Earth? Please write one short sentence. A: It is the third planet in our Solar System.', 
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
