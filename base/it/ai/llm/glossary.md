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

* **ALBERT** (A Lite BERT) - type of large language model, smaller version of BERT that is optimized to train more efficiently while maintaining performance.
* **Accuracy** - is a metric that measures how often a machine learning model correctly predicts the outcome. It is calculated as the ratio of correctly predicted instances to the total number of instances in the dataset.
* **Action** - an agent's decision based on the current state of the environment.
* **Agent** - an entity that makes a decision based on data received from the environment.
* **Annotated Dataset** - is a type of text dataset that contains special markup so that models understand how to interpret the data.
* **BERT** (Bidirectional Encoder Representations from Transformers) - type of large language model on the transformer architecture, which is based on the principle of preliminary training of the model on large text corpora for subsequent fine-tuning for specific tasks.
* **Beginning Of Sentence** (bos) - is a special token that marks the beginning of a sentence. For Llama realm models is `<s>`.
* **Code Dataset** - is a type of dataset that contains code examples and comments about them.
* **Corpus** - is a large and structured set of texts used to train large language models.
* **Dataset** - is a collection of organized data. Datasets can be represented in various formats, such as tables (e.g. CSV files), databases, or specialized data formats.
* **Dialogue Dataset** - is a type of dataset that contains conversations between two or more participants.
* **ELECTRA** - type of large language model, instead of masking tokens (words) like BERT, it uses a discriminative learning approach for more efficient pre-training.
* **Embedding** - vector representations of words, phrases, or sentences that capture their meanings and are used in various natural language processing tasks.
* **End Of Sentence** (eos) - is a special token that marks the end of a sentence. For Llama realm models is `</s>`.
* **Environment** - this is the world with which the agent interacts, to which the environment provides information about its current state and changes the state in response to the agent's actions.
* **F1 Score** - a metric used to evaluate the performance of a classification model, especially for imbalanced datasets; it is the harmonic mean of precision and recall.
* **FAISS** (Facebook AI Similarity Search) - an efficient similarity search and clustering library developed by Facebook for finding similar vectors in large datasets.
* **Fine-Tuning** - the process of adapting a pre-trained language model. See also IFT.
* **GGUF** (GGML Universal File) - binary file format to store tensors and model metadata for llama.cpp.
* **GPT** (Generative Pre-trained Transformer) - type of large language model based on the transformer deep learning architecture, pre-trained on large data sets, and able to generate novel human-like content.
* **Goal** - a long-term goal that the agent seeks to achieve.
* **HNSW** (Hierarchical Navigable Small World) - a data structure to efficiently perform approximate nearest neighbor searches in high dimensions.
* **IFT** (Instruction Fine-Tuning) - the process of adapting a pre-trained language model to follow specific instructions or tasks, improving its performance on those tasks.
* **IVF** (Inverted Index, or Inverted File) - a data structure used in information retrieval that allows for efficient searching of documents containing specific words.
* **IVFPQ** (IVF with Product Quantization) - is a composite index that combines inverted file index (IVF) and product quantization (PQ) for reducing storage and increasing efficiency.
* **Inference** - the process of obtaining predictions from a trained model. Simply put, it is communication with the model.
* **Instructional Dataset** (instruct) - is a type of dataset that contains commands or instructions for a model to perform a specific actions.
* **LLM** (Large Language Model) - a type of neural network designed to understand, generate, and manipulate human language by predicting the likelihood of sequences of words. Typically, large models use large datasets obtained from publicly sources, including the Internet.
* **LangChain** - is a software framework that helps facilitate the integration of large language models (LLMs) into applications.
* **LangGraph** - is a library for building stateful, multi-actor applications with LLMs, used to create agent and multi-agent workflows.
* **Llama** (Large Language Model Meta AI, aka LLaMA) - is a family of autoregressive large language models (LLMs) released by Meta AI starting in February 2023.
* **Llama.cpp** - open source software library that performs inference on various large language models such as Llama.
* **Min P** - sampling method considers the possibility of including words with a probability of at least P. Used as a complement to Top K and Top P.
* **NLP** (Natural Language Processing) - a field of artificial intelligence focused on the interaction between computers and humans through natural language, enabling machines to understand, interpret, and generate human languages.
* **PEFT** (Parameter-Efficient Fine-Tuning) - is a method for adapting pre-trained models with minimal changes to model parameters, making fine-tuning more efficient and less resource-intensive.
* **Padding** (pad) - special token for unifying the length of a sequence in a batch.
* **Parallel Corpora** - is a type of dataset that contains records in different languages. It is used to train machine translation models.
* **Parameters** - the variables that the model learns during training.
* **Perplexity** - measures how well a language model predicts a text sample. The lower the perplexity value, the better the model reflects the specified text.
* **Policy** - is the agent's strategy, which determines what actions it chooses depending on the state of the environment.
* **Precision** - is a metric that estimates what proportion of all objects that the algorithm classified as positive are actually positive.
* **Prompt Engineering** - is the process of structuring or creating instructions in order to obtain the best possible output from large language models.
* **Prompt Tuning** - is an approach to customizing the behavior of a model by changing the prompt.
* **Prompt** - represents the stimulus or input provided to the model to generate a response or text. Prompt can contain context that will help the model better understand what is being said.
* **Quantization** - in language models, this is the process of limiting the rounding of numbers to reduce the amount of RAM consumed. The lower the value, the faster the work, but the less accurate the result.
* **RAG** (Relative-Augmented Generation) - is a technique that grants generative artificial intelligence models information retrieval capabilities by integrating external retrieval systems, improving their context and relevance.
* **Recall** - a metric that measures the proportion of actual positive cases that were correctly identified by the model.
* **Reinforcement Learning Environment** (RL, Reinforcement Learning) - is an area of ​​machine learning where an agent learns to interact with  environment to achieve a specific goal based on reward feedback.
* **Reward** - feedback that the agent receives after performing an action. This can be either a positive (for correct actions) or a negative (for incorrect actions) value.
* **RoBERTa** (A Robustly Optimized BERT Pre-training Approach) - type of large language model, improved version of BERT, with more rigorous and optimized training conditions.
* **RoPE** (Rotary Position Embedding) - method for adding positional information to data sequences, used in transformer models.
* **SFT** (Supervised Fine-Tuning) - the process of adapting a pre-trained model on labeled data to improve its performance for specific tasks by fine-tuning it with supervised learning techniques.
* **Sampling** - used to reduce data volumes without losing information.
* **Separator** (sep) - a special separator token to separate multiple answer options for the same question.
* **Supervised Learning Dataset** - is Instructional Dataset.
* **T5** (Text-to-Text Transfer Transformer) - type of large language model to transform text into text.
* **Temperature** - is a parameter used during text generation to control randomness. It adjusts the probability distribution over possible next words: lower temperatures make the model more deterministic and conservative, while higher temperatures encourage diversity and creativity in outputs by making less likely predictions more probable. It is not recommended to use the value `0.0` and `1.0`, because the result may be unexpected.
* **Text corpora** - a large collection of text data merged together, which is typically used to train models in the early stages of their lives.
* **Token** (code) - the basic unit of input and output in a language model. Token typically represent word, subword, or character.
* **Top K** - sampling method limits the choice of predicted words to only the most probable variants from the distribution. The lower the value, the worse the result.
* **Top P** (nucleus sampling) - sampling method includes all words with a cumulative probability greater than or equal to a given threshold P. The lower the value, the worse the result.
* **Transfer Learning** - training a model based on previous experience.
* **Transformer** - deep learning architecture that was developed by researchers at Google and is based on the multi-head attention mechanism. Text is converted to numerical representations called tokens, and each token is converted into a vector via lookup from a word embedding table.
* **Unknown** (unk) - a special token that represents an unknown or rarely encountered word. For Llama family is `<unk>`.
* **Vectorization** - the process of converting text into numerical vectors that can then be indexed and used for fast searching.
* **Weight** - numerical coefficients describing the work of each neuron in the network.
