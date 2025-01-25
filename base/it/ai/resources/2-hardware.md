---
slug: hardware
title: Hardware
description: Notes on hardware for creating and using AI.
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

# Hardware

There are two main areas of work with LLMs: **[Inference](llm/glossary.md)** and **[Fine-Tuning](llm/glossary.md)**.

If for Inference the amount of resources has a greater impact on the comfortable speed and accuracy of the models,
then for Fine-Tuning the requirements are higher, especially for the GPU.

[llama.cpp](llm/llama.cpp) allows to use CPU and RAM if GPU resources are insufficient.

GPUs preferred over CPUs.

In all cases, the more resources the better.

Ideally, use professional hardware. Because it is a more reliable solution.

## GPU (Graphics processing unit)

As of 2025, NVIDIA products are preferable in all cases.

Pay attention to the following:

* Tensor cores - are specially cores that enable dynamic calculations and mixed-precision computing.
* CUDA (Compute Unified Device Architecture) cores - are specialized cores designed for parallel computing.
* Video Random Access Memory (VRAM) - 16/24 GB or more.

Also pay attention to the following:

* Power consumption.
* Heat dissipation system.
