---
title: Datasets
description: A few words about datasets in the world of LLMs.
tags:
  - Glossary
  - LLM
  - Large Language Models
  - Machine Learning
  - AI
  - Datasets
---

# Datasets

Dataset is a collection of organized data. Datasets can be represented in various formats, such as tables (e.g. CSV files), databases, or specialized data formats.

## Data format

I see that the most common formats used for storing data are **Text Plain**, **Markdown**, **JSONL** and **Parquet**.

JSONL is a text file, it is the simplest.  
Parquet is a binary data storage.

[Judging by the number of datasets](https://huggingface.co/datasets?modality=modality:text&sort=trending), the Parquet format is in the lead for text data.

For example, below are two dataset structures in JSONL format:

```json title="Conversational format"
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
```

```json title="Instruction format"
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
```

## Special tokens

* **Beginning Of Sentence** (bos) - is a special token that marks the beginning of a sentence. For Llama realm models is `<s>`.
* **End Of Sentence** (eos) - is a special token that marks the end of a sentence. For Llama realm models is `</s>`.
* **Padding** (pad) - special token for unifying the length of a sequence in a batch.
* **Unknown** (unk) - a special token that represents an unknown or rarely encountered word. For Llama family is `<unk>`.

```text title="Example"
<s>Lorem ipsum dolor sit amet, consectetur adipiscing elit,
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</s>
<s>Ut enim ad minim veniam, quis nostrud exercitation ullamco
laboris nisi ut aliquip ex ea commodo consequat.</s>
<s>Duis aute irure dolor in reprehenderit in voluptate velit
esse cillum dolore eu fugiat nulla pariatur.</s>
<s>Excepteur sint occaecat cupidatat non proident,
sunt in culpa qui officia deserunt mollit anim id est laborum.</s>
```

## Dataset types

### Instructional Dataset (instruct)

It is a type of dataset that contains commands or instructions for a model to perform a specific actions.

```text
<s>[INST]
Who is Aleksey Nemiro?
[/INST]

This is a Russian developer, author of articles and projects in the field of information technology.
</s>
```

```text
<s>[INST]
Show an example of a "Hello, world!" program in Python
[/INST]

This is an example of implementing the "Hello, world!" program in Python, which prints the phrase of the same name to the console:

'''python
print('Hello, world!')
'''

You can save this code to a file and execute it with the command 'python helloworld.py'.
</s>
```

### Dialogue Dataset

It is a type of dataset that contains conversations between two or more participants.

```json
{
  "messages": [
    { 
      "role": "system", 
      "content": "You are..."
    },
    {
      "role": "user", 
      "content": "..."
    },
    {
      "role": "assistant",
      "content": "..."
    }
  ]
}
```

```text
<s>System: You are the supreme being, you have no equal in the Universe, you have incredible power.
User: Hello! Who are you?
Assistant: I am the supreme being, I have no equal.
User: Wow!
Assistant: I'm in shock myself.</s>
```

### Parallel Corpora

It is a type of dataset that contains records in different languages. It is used to train machine translation models.

```text
Source: Привет, мир!
Target: Hello, world!
```

```json
{
  "source": "Привет, мир!",
  "target": "Hello, world!"
}
```

### Code Dataset

Is is a type of dataset that contains code examples and comments about them.

```text
<s>Language: Python
User: Show an example of searching for a string in an array
Assistant: a = ["C#", "TypeScript", "Python"]

if 'Python' in a:
    print("String found!")
else:
    print("String not found!")</s>
```

## Links

* [Datasets on Hugging Face](https://huggingface.co/datasets)
* [Apache Parquet](https://parquet.apache.org/)
