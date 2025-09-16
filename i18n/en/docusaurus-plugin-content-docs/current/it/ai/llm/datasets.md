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
  - Embedding
  - RAG
---

# Datasets

:::warning
This document has been translated using machine translation without human review.
:::

*Updated: 2025-09-07*

A dataset is a collection of ordered data. Datasets can be presented in various formats, such as tables (e.g., CSV files), databases, or specialized data formats.

The current knowledge base in its original form is a dataset in markdown format.

## Data Format

Common formats for storing datasets: **plain text**, **Markdown**, **JSONL**, and **Parquet**.

* JSONL is a text file where each line contains a self-contained JSON. This is the simplest text format for large datasets.
* Parquet is a binary data storage (DBMS).

[Judging by the number of text datasets](https://huggingface.co/datasets?modality=modality:text&sort=trending), Parquet is the most popular.

To date, there are no clear standards for data structure. On the one hand, this is a problem because it is unclear in what form to create datasets, on the other hand, it is freedom of choice. Simply put, a dataset can be created in **absolutely any convenient form**.

Nevertheless, there are types of datasets that are popular and it is quite possible that someday they will become a standard.

Below are a couple of examples of datasets in JSONL format with different structures:

```json title="Dialogues (conversational format)"
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
```

```json title="Instructions (instruction format)"
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
```

Large language models work with unstructured text.

Since different **models** have their own **peculiarities**, it is **convenient to store** the dataset in **JSON format or in a database**, and then **transform** it into a text format **adapted for specific models**.

## Special Markers (tokens)

| Marker (Token)              | Description                                                 | GPT              | Llama   | Gemini    | BERT    |
|-----------------------------|----------------------------------------------------------|------------------|---------|-----------|---------|
| Beginning Of Sentence (BOS) | Indicates the beginning of a sentence.                         | `<\|im_start\|>` | `<s>`   | `<bos>`   | `[CLS]` |
| End Of Sentence (EOS)       | Indicates the end of a sentence.                          | `<\|im_end\|>`   | `</s>`  |  `<eos>`  | `[SEP]` |
| Padding (PAD)               | Token for unifying the sequence length in a batch.  | absent      | `<pad>` | `<pad>`   | `[PAD]` |
| Unknown (UNK)               | Token for denoting an unknown word.                | absent      | `<unk>` |  `<unk>`  | `[UNK]` |

```text title="Example for models of the Llama family"
<s>Lorem ipsum dolor sit amet, consectetur adipiscing elit,
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</s>
<s>Ut enim ad minim veniam, quis nostrud exercitation ullamco
laboris nisi ut aliquip ex ea commodo consequat.</s>
<s>Duis aute irure dolor in reprehenderit in voluptate velit
esse cillum dolore eu fugiat nulla pariatur.</s>
<s>Excepteur sint occaecat cupidatat non proident,
sunt in culpa qui officia deserunt mollit anim id est laborum.</s>
```

```text title="Example for models of the Gemini/Gemma family"
<bos>User: Hello!
Assistant: Hello! How can I help you?<eos>
```

## Types of Datasets

### Instructions (instruct)

An instruction set is a pair of question-answer values.

The boundaries of the beginning and end of the question-answer are marked with BOS and EOS tokens.

For models of the Llama family, the question is framed with special tokens `[INST][/INST]`.

```text
<s>[INST]
Who is Aleksey Nemiro?
[/INST]

A Russian developer, author of articles and projects in the field of information technology.
</s>
```

```text
<s>[INST]
Show an example of a "Hello, world!" program in Python
[/INST]

Of course! Here is an example implementation of the "Hello, world!" program in Python:

'''python
print('Hello, world!')
'''

You can save this code in a file and run it using the command 'python helloworld.py'.
</s>
```

### Dialogues

The dialogue type of dataset represents fragments of dialogues that models can use as an example.

Each dialogue **must be self-contained and limited to one question or topic**. The **smaller** the size of the dialogue, the **better**.

When building a dialogue dataset, **it is important to follow the order of roles**. There are three main roles: `system`, `user`, `assistant`.
Some models contain additional roles for working with tools (external functions): `tool` and `function`.

Most models expect a dialogue according to one of the following schemes:

* system, user, assistant
* system, assistant, user, assistant
* user, assistant

Different models have different requirements and capabilities. The universal order for all: `user, assistant` — this will work correctly in all cases.
If the sequence is violated (for example: `user, assistant, assistant, user`) or unsupported roles are used (such as `tool` and `function`), the result may be unpredictable.

```json title="Example of a dialogue in JSON format"
{
  "messages": [
    { 
      "role": "system", 
      "content": "You are a smart assistant."
    },
    {
      "role": "user", 
      "content": "What is the weather in St. Petersburg today?"
    },
    {
      "role": "assistant",
      "content": "To find out what the weather is in St. Petersburg today, I first need to understand what the date is today, for this I can use the external function `today`, then I can call the function `weather` and get the weather forecast."
    }
  ]
}
```

```text title="Example of a dialogue in text format for models of the Llama family"
<s>System: You are a supreme being, you have no equal in the Universe, you possess incredible power.
User: Hi! Who are you?
Assistant: I am a supreme being, I have no equal.
User: Wow!
Assistant: I'm shocked myself.</s>
```

```text title="Example of a dialogue in text format for models of the GPT family"
<|im_start|>system
You are a stupid assistant. You are rude. You pick your nose, know nothing and do nothing.<|im_end|>
<|im_start|>user
Hi! Tell me, what day is it today?<|im_end|>
<|im_start|>assistant
Look at the calendar, I'm not an information desk!<|im_end|>
```

### Parallel Corpora

Parallel corpora are sets of texts where the same content is presented in two or more languages.

This type of dataset is often used to train machine translation models.

```text
Source: Hello, world!
Target: Привет, мир!
```

```json
{
  "source": "Hello, world!",
  "target": "Привет, мир!"
}
```

### Code Datasets

For code examples, a code dataset can be used, which is similar to an instruction set but additionally contains information about the programming language.

```text
<s>Language: Python
User: Show an example of searching for a string in an array
Assistant: a = ["C#", "TypeScript", "Python"]

if 'Python' in a:
    print("String found!")
else:
    print("String not found!")</s>
```

## Dataset Checklist

* [x] Use a structured data format to make it easier to transform into any format.
* [x] The dataset should not contain special tokens, because different models may have different tokens. This should be solved by transforming the structured dataset.
* [x] It is necessary to follow the order of roles (`user, assistant`).
* [x] The `system` role is the law. Do not abuse this role.
* [x] The data must be diverse. Repetition is bad because during the search there can be a lot of identical information that will occupy the context and this can confuse the model (the model may begin to perceive as truth what is not true for the current request).
* [x] A separate block (record) of data should be as small as possible to avoid splitting it into parts.

## Links

* [Dataset catalog on the Hugging Face website](https://huggingface.co/datasets)
* [Apache Parquet](https://parquet.apache.org/)
