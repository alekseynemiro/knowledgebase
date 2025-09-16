---
slug: hardware
title: Hardware for AI
description: Brief notes on hardware for creating and using AI.
tags:
  - Hardware
  - AI
  - LLM
  - Large Language Models
  - Machine Learning
  - GPU
  - CPU
  - RAM
  - VRAM
  - HDD
  - SSD
---

# Hardware for AI

:::warning
This document has been translated using machine translation without human review.
:::

There are two main areas of work with large language models (LLM): **[Inference](../llm/glossary.md)** (generation, inference) and **[Fine-Tuning](../llm/glossary.md)** (fine-tuning, training).

If for generation (inference) the amount of resources affects the comfortable speed and accuracy of models more, then for **Fine-Tuning** the requirements are much higher, especially for **GPU**.

[llama.cpp](../llm/llama-cpp) allows using the processor (**CPU**) and random access memory (**RAM**) if the resources of the graphics processing unit (**GPU**) are insufficient.

GPU is preferable to CPU. In all cases, the more resources, the better.

Ideally, it is better to use professional equipment because it is designed for long-term, trouble-free operation under high loads.

## GPU (Graphics processing unit)

As of 2025, **NVIDIA** products will be preferable in all cases.

Special attention should be paid to the following points:

* **Tensor cores** — special cores that provide dynamic computations and mixed-precision computations.
* **CUDA** (**Compute Unified Device Architecture**) cores — specialized cores designed for parallel computing.
* **Video Random Access Memory** (**VRAM**) — 16/24 GB or more.

Also pay attention to the following:

* Power consumption.
* Heat dissipation system.
