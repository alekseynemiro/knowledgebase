---
title: Glossary
description: Glossary of terms related to LLMs.
tags:
  - Glossary
  - LLM
  - Large Language Models
  - Machine Learning
  - AI
---

# Glossary

* **Accuracy** - is a metric that measures how often a machine learning model correctly predicts the outcome.  
  It is calculated as the ratio of correctly predicted instances to the total number of instances in the dataset.
* **ALBERT** (A Lite BERT) - type of large language model, smaller version of **BERT** that is optimized to train more efficiently while maintaining performance.
* **BERT** (Bidirectional Encoder Representations from Transformers) - type of large language model on the transformer architecture, which is based on the principle of preliminary training of the model on large text corpora for subsequent fine-tuning for specific tasks.
* **Corpus** - is a large and structured set of texts used to train large language models.
* **Dataset** - is a collection of organized data. Datasets can be represented in various formats, such as tables (e.g. CSV files), databases, or specialized data formats.
* **ELECTRA** - type of large language model, instead of masking tokens (words) like BERT, it uses a discriminative learning approach for more efficient pre-training.
* **Embedding** - vector representations of words, phrases, or sentences that capture their meanings and are used in various natural language processing tasks.
* **F1 Score** - a metric used to evaluate the performance of a classification model, especially for imbalanced datasets; it is the harmonic mean of precision and recall.
* **FAISS** (Facebook AI Similarity Search) - an efficient similarity search and clustering library developed by Facebook for finding similar vectors in large datasets.
* **Fine-Tuning** - the process of adapting a pre-trained language model. See also IFT.
* **GGUF** (GGML Universal File) - binary file format to store tensors and model metadata for llama.cpp.
* **GPT** (Generative Pre-trained Transformer) - type of large language model based on the transformer deep learning architecture, pre-trained on large data sets, and able to generate novel human-like content.
* **HNSW** (Hierarchical Navigable Small World) - a data structure to efficiently perform approximate nearest neighbor searches in high dimensions.
* **IFT** (Instruction Fine-Tuning) - the process of adapting a pre-trained language model to follow specific instructions or tasks, improving its performance on those tasks.
* **Inference** - the process of obtaining predictions from a trained model. Simply put, it is communication with the model.
* **IVF** (Inverted Index, or Inverted File) - a data structure used in information retrieval that allows for efficient searching of documents containing specific words.
* **IVFPQ** (IVF with Product Quantization) - is a composite index that combines inverted file index (IVF) and product quantization (PQ) for reducing storage and increasing efficiency.
* **Llama** (Large Language Model Meta AI, aka **LLaMA**) - is a family of autoregressive large language models (LLMs) released by Meta AI starting in February 2023.
* **llama.cpp** - open source software library that performs inference on various large language models such as Llama.
* **LLM** (Large Language Model) - a type of neural network designed to understand, generate, and manipulate human language by predicting the likelihood of sequences of words. Typically, large models use large datasets obtained from publicly sources, including the Internet.
* **NLP** (Natural Language Processing) - a field of artificial intelligence focused on the interaction between computers and humans through natural language, enabling machines to understand, interpret, and generate human languages.
* **Parameters** - the variables that the model learns during training.
* **PEFT** (Parameter-Efficient Fine-Tuning) - is a method for adapting pre-trained models with minimal changes to model parameters, making fine-tuning more efficient and less resource-intensive.
* **Perplexity** - measures how well a language model predicts a text sample. The lower the perplexity value, the better the model reflects the specified text.
* **Precision** - is a metric that estimates what proportion of all objects that the algorithm classified as positive are actually positive.
* **Prompt** - represents the stimulus or input provided to the model to generate a response or text.
  Prompt can contain context that will help the model better understand what is being said.
* **Quantization** - in language models, this is the process of limiting the rounding of numbers to reduce the amount of RAM consumed.
  The lower the value, the faster the work, but the less accurate the result.
* **RAG** (Relative-Augmented Generation) - is a technique that grants generative artificial intelligence models information retrieval capabilities by integrating external retrieval systems, improving their context and relevance.
* **Recall** - a metric that measures the proportion of actual positive cases that were correctly identified by the model. 
* **RoBERTa** (A Robustly Optimized BERT Pre-training Approach) - type of large language model, improved version of **BERT**, with more rigorous and optimized training conditions.
* **RoPE** (Rotary Position Embedding) - method for adding positional information to data sequences, used in transformer models.
* **Sampling** - used to reduce data volumes without losing information:
  * **Top K** - method limits the choice of predicted words to only the most probable variants from the distribution. The lower the value, the worse the result.
  * **Top P** (nucleus sampling) - the method includes all words with a cumulative probability greater than or equal to a given threshold P. The lower the value, the worse the result.
  * **Min P** - method considers the possibility of including words with a probability of at least P. Used as a complement to Top K and Top P.
* **SFT** (Supervised Fine-Tuning) - the process of adapting a pre-trained model on labeled data to improve its performance for specific tasks by fine-tuning it with supervised learning techniques.
* **Token** (code) - the basic unit of input and output in a language model. Token typically represent word, subword, or character.
* **Transfer Learning** - training a model based on previous experience.
* **Transformer** - deep learning architecture that was developed by researchers at Google and is based on the multi-head attention mechanism.
  Text is converted to numerical representations called tokens, and each token is converted into a vector via lookup from a word embedding table.
* **Vectorization** - the process of converting text into numerical vectors that can then be indexed and used for fast searching.
* **Weight** - numerical coefficients describing the work of each neuron in the network.
