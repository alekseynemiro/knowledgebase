---
title: "LLM: Glossary"
description: Glossary of terms related to LLM.
tags:
  - Glossary
  - LLM
  - Large Language Models
  - Machine Learning
  - AI
---

# LLM: Glossary

:::warning
This document has been translated using machine translation without human review.
:::

* **ALBERT** (A Lite BERT) — a reduced version of BERT, optimized for more efficient training while maintaining performance.
* **Accuracy** — a metric that measures the frequency of correct outcome predictions by the model. It is calculated as the ratio of the number of correctly predicted cases to the total number of cases in the dataset.
* **Action** — a decision made by an agent based on the current state of the environment.
* **Agent** — an entity that interacts with a large language model and evaluates the correctness of the received response. If necessary, it adjusts the model to achieve the desired result.
* **Annotated Dataset** — a type of text dataset that contains special markup, allowing models to understand how to interpret the data.
* **BERT** (Bidirectional Encoder Representations from Transformers) — a type of large language model based on the transformer architecture, which relies on the principle of pre-training the model on large text corpora for subsequent fine-tuning for specific tasks.
* **Beginning Of Sentence** (BOS) — a special token denoting the beginning of a sentence. For models of the Llama family — `<s>`.
* **Code Dataset** — a type of dataset containing code examples and comments on them.
* **Corpus** — a large and structured collection of texts used to train large language models.
* **Dataset** — a collection of ordered data. Datasets can be presented in various formats, such as tables (e.g., CSV files), databases, or specialized data formats.
* **Dialogue Dataset** — a type of dataset containing conversations between two or more participants.
* **ELECTRA** — a type of large language model that uses a discriminative approach to learning instead of masking tokens (words).
* **Embedding** — embedding data into a model.
* **End Of Sentence** (EOS) — a special token denoting the end of a sentence. For models of the Llama family — `</s>`.
* **Environment** — the external world with which an agent interacts.
* **F1 Score** — a metric used to evaluate the effectiveness of a classification model, especially for imbalanced datasets; it is the harmonic mean of precision and recall.
* **FAISS** (Facebook AI Similarity Search) — a lightweight vector database developed by Facebook.
* **Fine-Tuning** — the process of adapting a pre-trained language model. See also IFT.
* **GGUF** (GGML Universal File) — a binary file format for storing tensors and model metadata for llama.cpp.
* **GPT** (Generative Pre-trained Transformer) — a type of large language model based on the Transformer deep learning architecture, pre-trained on large datasets and capable of generating human-like content.
* **Goal** — a long-term objective that an agent strives to achieve.
* **HNSW** (Hierarchical Navigable Small World) — a data structure for efficiently performing approximate nearest neighbor search.
* **IFT** (Instruction Fine-Tuning) — the process of adapting a pre-trained language model to perform specific instructions or tasks, which improves its performance on these tasks.
* **IVF** (Inverted Index, or Inverted File) — a data structure used in information retrieval that allows for efficient searching of documents containing specific words.
* **IVFPQ** (IVF with Product Quantization) — a composite index that combines an inverted file index (IVF) and product quantization (PQ) to reduce storage volume and improve efficiency.
* **Inference** — the process of obtaining predictions using a trained model. Simply put, it is the real-time generation of text by the model.
* **Instructional Dataset** (instruct) — a type of dataset containing commands or instructions for the model.
* **LLM** (Large Language Model) — a type of neural network designed to understand, generate, and process natural language by predicting the probability of word sequences.
* **LangChain** — a set of Python solutions for integrating large language models (LLMs). There is also a wrapper implementation for Node.js.
* **LangGraph** — a set of Python solutions for developing workflows using LLMs. Workflows are implemented as graphs. It is a continuation of the development of the LangChain library. A Node.js wrapper exists.
* **Llama** (Large Language Model Meta AI, aka LLaMA) — a family of autoregressive large language models (LLMs) released by Meta AI since February 2023.
* **Llama.cpp** — open-source software for working with large language models, such as Llama.
* **Min P** — a sampling method that considers including words with a probability not less than `P`. Used as a supplement to **Top K** and **Top P**.
* **NLP** (Natural Language Processing) — a field of artificial intelligence focused on the interaction between computers and humans through natural language, enabling machines to understand, interpret, and generate human languages.
* **PEFT** (Parameter-Efficient Fine-Tuning) — a method for adapting pre-trained models with minimal changes to the model's parameters, making fine-tuning more efficient and less resource-intensive.
* **Padding** (PAD) — a special token for standardizing sequence length in a batch. Most models require the text size in the sequence to be the same; this token helps solve this problem.
* **Parallel Corpora** — a type of dataset containing records in different languages. Used for training machine translation models.
* **Parameters** — variables of a neural network that define the model's behavior during training.
* **Perplexity** — a unit of measurement that shows how well a language model predicts. The lower the perplexity value, the better the model reflects the given text.
* **Policy** — an agent's strategy that determines which actions it chooses depending on the state of the environment.
* **Precision** — a metric that evaluates what proportion of all objects classified by the algorithm as positive are actually positive.
* **Prompt Engineering** — the process of structuring or creating instructions to get the best result from large language models.
* **Prompt Tuning** — an approach to tuning model behavior by changing the prompt text.
* **Prompt** — represents the input data - an instruction that sets the context and behavior of the model.
* **Quantization** — in language models, this is the process of limiting number rounding to reduce the amount of RAM consumed. The smaller the value, the faster the work, but the less accurate the result.
* **RAG** (Relative-Augmented Generation) — a method that provides generative AI models with information retrieval capabilities by integrating external search systems, improving their context and relevance.
* **Recall** — a metric that measures the proportion of actual positive cases that were correctly identified by the model.
* **Reinforcement Learning Environment** (RL, Reinforcement Learning) — an area of machine learning where an agent learns to interact with the environment to achieve a specific goal based on feedback in the form of rewards.
* **Reward** — feedback that an agent receives after performing an action. It can be a positive (for correct actions) or negative (for incorrect actions) value.
* **RoBERTa** (A Robustly Optimized BERT Pre-training Approach) — a type of large language model, an improved version of BERT, with stricter and optimized training conditions.
* **RoPE** (Rotary Position Embedding) — a method for adding positional information to data sequences, used in transformer models.
* **SFT** (Supervised Fine-Tuning) — the process of adapting a pre-trained model based on labeled data to improve its performance for solving specific tasks by fine-tuning it using supervised learning methods.
* **Sampling** — used to reduce data volumes without losing information.
* **Separator** (SEP) - a special token for separating text fragments within a single example. To some extent, it can be called a paragraph.
* **Supervised Learning Dataset** — a training dataset.
* **T5** (Text-to-Text Transfer Transformer) — a family of large language models from Google for converting text to text. For example, the model can be used for summarization, classification, translation from one language to another, etc.
* **Temperature** — a parameter used in text generation to control the degree of diversity. It adjusts the probability distribution of possible next words: lower temperatures make the model more deterministic and conservative, while higher temperatures encourage diversity and creativity in the results, making less likely predictions more probable. Using values of `0.0` and `1.0` is not recommended, as the result may be unexpected.
* **Text corpora** — a large collection of textual data brought together, typically used to train models in the early stages of their life.
* **Token** (code, marker, token) — the basic unit of input and output in a language model. A token usually represents a word, part of a word, or a character.
* **Top K** — a sampling method that limits the selection of predicted words to only the most probable options from the distribution. The smaller the value, the worse the result.
* **Top P** (nucleus sampling) — a sampling method that includes all words with a cumulative probability greater than or equal to a given threshold `P`. The lower the value, the worse the result.
* **Transfer Learning** — training a model based on previous experience.
* **Transformer** — a deep learning architecture developed by Google and based on the multi-headed attention mechanism. Text is converted into numerical representations called tokens, and each token is converted into a vector through a lookup in a word embedding table.
* **Unknown** (UNK) — a special token representing an unknown or rarely encountered word. In practice, it is rarely used. For models of the Llama family - `<unk>`.
* **Vectorization** — the process of converting text into numerical vectors, which can then be indexed and used for fast search.
* **Weight** — numerical coefficients describing the operation of each neuron in the network.
