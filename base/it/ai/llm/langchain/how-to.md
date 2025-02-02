---
title: How to...
description: LangChain Questions and Answers in Python.
tags:
  - LangChain
  - Python
  - LLM
  - Machine Learning
  - AI
  - FAQ
---

# LangChain How-to

## How to install LangChain?

```bash
pip install llama-cpp-python
pip install langchain langchain-community langchain-core
```

## How to make a simple chat using LangChain?

```python
from langchain_community.chat_models import ChatLlamaCpp

llm = ChatLlamaCpp(
    model_path="llama-3.2-1b-instruct-q8_0.gguf",
    Verbose=False,
)

while True
    question = input("User: ")

    if question in ("end", "exit", "quit", "stop"):
        exit()

    response = llm.invoke(question)

    print(f"Assistant: {response.content}")
```

## How to create prompt using LangChain?

```python
from langchain_community.chat_models import ChatLlamaCpp
from langchain_core.prompts import ChatPromptTemplate

system_prompt = (
    "You are an assistant who strictly follows the following instructions: "
    "1. If I ask you to turn on the light, you answer 'exec light_on'."
    "2. If I ask you to turn off the light, you answer 'exec light_off'."
    "Don't change the text in quotation marks. Don't add anything extra."
)

prompt = ChatPromptTemplate.from_messages(
    [
        ("system", system_prompt),
        ("ai", "I'm ready!"),
        ("human", "{input}"),
    ]
)

llm = ChatLlamaCpp(
    model_path="llama-3.2-1b-instruct-q8_0.gguf",
    verbose=False
)

chain = prompt | llm

while True:
    question = input("User: ")

    if question in ("end", "exit", "quit", "stop"):
        exit()

    response = chain.invoke({"input": question})

    print(f"Assistant: {response.content}")
```

## How to use local embedding with LangChain?

OpenAI package is required:

```bash
pip install openai
```

:::note
If you encounter an error: `module 'openai' has no attribute 'error'`

Try using an older version of the OpenAI package:

```bash
pip install openai==0.28.1 --upgrade --force-reinstall --no-cache-dir
```

:::

```text title="data.txt"
<s>Earth is the third planet from the Sun and the only astronomical object known to harbor life.
Aleksey Nemiro lives on this planet.</s>
<s>Aleksey Nemiro is a Russian developer, author of articles and projects in the field of information technology.
It has a public knowledge base that contains useful information on various topics.</s>
<s>Aleksey Nemiro's knowledge base is located at https://kb.nemiro.net</s>
<s>More detailed information about Aleksey Nemiro's activities can be found at https://www.nemiro.net</s>
```

Run embedding server:

```bash
llama-server -m "Meta-Llama-3.1-8B-Instruct-Q8_0.gguf" --embedding --pooling cls --port 8082
```

Create and run script:

```python
import os
from langchain_community.document_loaders import TextLoader
from langchain_community.chat_models import ChatLlamaCpp
from langchain_core.prompts import ChatPromptTemplate
from langchain_community.embeddings import LocalAIEmbeddings
from langchain_community.vectorstores import FAISS
from langchain.chains.combine_documents import create_stuff_documents_chain
from langchain.chains import create_retrieval_chain

text_loader = TextLoader("data.txt")
documents = text_loader.load_and_split()

if not os.environ.get("OPENAI_API_BASE"):
    os.environ["OPENAI_API_BASE"] = "http://localhost:8082/v1" # your embedding server address

if not os.environ.get("OPENAI_API_KEY"):
    os.environ["OPENAI_API_KEY"] = "1234567890" # random string here

embeddings = LocalAIEmbeddings()

db = FAISS.from_documents(documents, embeddings)

retriever = db.as_retriever()

system_prompt = (
    "You are an assistant who answers questions using the provided context.\n"
    "\n\n"
    "{context}"
)

prompt = ChatPromptTemplate.from_messages(
    [
        ("system", system_prompt),
        ("ai", "I'm ready!"),
        ("human", "{input}"),
    ]
)

llm = ChatLlamaCpp(
    model_path="Meta-Llama-3.1-8B-Instruct-Q8_0.gguf",
    # n_gpu_layers=32, # to use gpu
    # n_threads=6,
    verbose=False
)

combine_docs_chain = create_stuff_documents_chain(llm=llm, prompt=prompt)
chain = create_retrieval_chain(retriever, combine_docs_chain)

while True:
    question = input("User: ")

    if question in ("end", "exit", "quit", "stop"):
        exit()

    response = chain.invoke({"input": question})
    answer = response["answer"]

    print(f"Assistant: {answer}")
```

## How to load JSON Lines?

```bash
pip install jq
```

```python
from langchain_community.document_loaders import JSONLoader

loader = JSONLoader(
    file_path="my_data.jsonl",
    jq_schema=".completion",
    text_content=False,
    json_lines=True,
)

data = loader.load()

print(data)
```

![Result](assets\langchain.png)
