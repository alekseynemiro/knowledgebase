---
title: Glossary
description: Glossary of terms related to LLM.
---

# Glossary

* **Parameters** - the variables that the model learns during training.
* **RoPE** (Rotary Position Embedding) - method for adding positional information to data sequences, used in transformer models.
* **Quantization** - in language models, this is the process of limiting the rounding of numbers to reduce the amount of RAM consumed.
  The lower the value, the faster the work, but the less accurate the result.
* **Sampling** - used to reduce data volumes without losing information:
  * **Top K** - method limits the choice of predicted words to only the most probable variants from the distribution. The lower the value, the worse the result.
  * **Top P** (nucleus sampling) - the method includes all words with a cumulative probability greater than or equal to a given threshold P. The lower the value, the worse the result.
  * **Min P** - method considers the possibility of including words with a probability of at least P. Used as a complement to Top K and Top P.
* **Token** (code) - the basic unit of input and output in a language model. Token typically represent word, subword, or character.
* **Transfer Learning** - training a model based on previous experience.
* **Weight** - numerical coefficients describing the work of each neuron in the network.
