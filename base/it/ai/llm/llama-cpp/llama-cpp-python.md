---
description: Python bindings for llama.cpp
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

Python bindings for [llama.cpp](./).

* [https://llama-cpp-python.readthedocs.io/](https://llama-cpp-python.readthedocs.io/)
* [https://github.com/abetlen/llama-cpp-python](https://github.com/abetlen/llama-cpp-python)

## How to install a package?

```bash
pip install llama-cpp-python
```

## How to enable CUDA?

To use CUDA, you need to install the **NVIDIA CUDA Toolkit**.

And then, you need to install the **llama-cpp-python** package with the flag that includes CUDA:

```bash title="Windows"
set CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

```bash title="Linux"
export CMAKE_ARGS="-DGGML_CUDA=on" && pip install llama-cpp-python --upgrade --force-reinstall --no-cache-dir
```

## How to use the library?

```python
from llama_cpp import Llama

llm = Llama(
  model_path="C:/models/Meta-Llama-3.1-8B-Instruct-Q8_0.gguf",
  # n_gpu_layers=-1, # Uncomment to use GPU acceleration
  # seed=1337, # Uncomment to set a specific seed
  # n_ctx=2048, # Uncomment to increase the context window
);

response = llm(
    "Q: What do you know about planet Earth? One short sentence, please. A:", # Prompt
    max_tokens=42, # Generate up to 42 tokens, set to None to generate up to the end of the context window
    stop=["Q:", "\n"], # Stop generating just before the model would generate a new question
    echo=True, # Echo the prompt back in the output
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
      'text': 'Q: What do you know about planet Earth? One short sentence, please. A: It is the third planet in our solar system.', 
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
