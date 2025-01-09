---
title: Glossary
description: Glossary of terms related to LLM.
---

# Glossary

* **ALBERT** (A Lite BERT) - type of large language model, smaller version of **BERT** that is optimized to train more efficiently while maintaining performance.
* **BERT** (Bidirectional Encoder Representations from Transformers) - type of large language model on the transformer architecture, which is based on the principle of preliminary training of the model on large text corpora for subsequent fine-tuning for specific tasks.
* **ELECTRA** - type of large language model, instead of masking tokens (words) like BERT, it uses a discriminative learning approach for more efficient pre-training.
* **GPT** (Generative Pre-trained Transformer) - type of large language model based on the transformer deep learning architecture, pre-trained on large data sets, and able to generate novel human-like content.
* **LLM** (Large Language Model) - is probabilistic model of a natural language. It is based on mechanisms for predicting the appearance of words in certain places.
  Typically, large models use large datasets obtained from publicly sources, including the Internet.
* **Parameters** - the variables that the model learns during training.
* **RoBERTa** (A Robustly Optimized BERT Pre-training Approach) - type of large language model, improved version of **BERT**, with more rigorous and optimized training conditions.
* **RoPE** (Rotary Position Embedding) - method for adding positional information to data sequences, used in transformer models.
* **Quantization** - in language models, this is the process of limiting the rounding of numbers to reduce the amount of RAM consumed.
  The lower the value, the faster the work, but the less accurate the result.
* **Sampling** - used to reduce data volumes without losing information:
  * **Top K** - method limits the choice of predicted words to only the most probable variants from the distribution. The lower the value, the worse the result.
  * **Top P** (nucleus sampling) - the method includes all words with a cumulative probability greater than or equal to a given threshold P. The lower the value, the worse the result.
  * **Min P** - method considers the possibility of including words with a probability of at least P. Used as a complement to Top K and Top P.
* **Token** (code) - the basic unit of input and output in a language model. Token typically represent word, subword, or character.
* **Transfer Learning** - training a model based on previous experience.
* **Transformer** - deep learning architecture that was developed by researchers at Google and is based on the multi-head attention mechanism.
  Text is converted to numerical representations called tokens, and each token is converted into a vector via lookup from a word embedding table.
* **Weight** - numerical coefficients describing the work of each neuron in the network.
