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

At the moment I have not found any clear information on the structure of datasets for large language models (LLMs).

I see that the most common formats used for storing data are **JSONL** and **Parquet**.

JSONL is a text file, it is the simplest.  
Parquet is a binary data storage.

[Judging by the number of datasets](https://huggingface.co/datasets?modality=modality:text&sort=trending), the Parquet format is in the lead for text data.

I see that two datasets structures in JSONL format are used:

* conversational format;
* instruction format.

## JSONL

### Conversational format

```json
{"messages":[{"role": "system", "content": "You are..."}, {"role": "user", "content": "..."}, {"role": "assistant", "content": "..."}]}
```

### Instruction format

```json
{"prompt": "<prompt text>", "completion": "<ideal generated text>"}
```

## Links

* [Datasets on Hugging Face](https://huggingface.co/datasets)
* [Apache Parquet](https://parquet.apache.org/)
