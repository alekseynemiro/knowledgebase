---
title: Flowise
description: Low code LLM Apps Builder.
tags:
  - Flowise
  - LLM
  - Large Language Models
  - Machine Learning
  - AI
  - Step-by-Step
---

# Flowise

Flowise - Low code LLM Apps Builder.

* [https://flowiseai.com/](https://flowiseai.com/)
* [https://github.com/FlowiseAI/Flowise](https://github.com/FlowiseAI/Flowise)

## How to embedding own data into LLM?

This approach does not change the model. User data is attached as if on the side.

It's simple and doesn't require a lot of technical resources, but it may not be as effective as you'd like.

The quality of the data set plays an important role. But absolutely any data will do for testing.

*If something is not clear, try looking at the screenshots at the bottom of the page.*

1. Open Chatflows and Create a new one.
2. Use **LangChain**, as this framework currently has the largest number of components. Add **Conversational Retrieval QA Chain**.
3. Add any **Documents Loader**. For example:
   * **Text File** for a single text file:
     * Upload text file. This can be absolutely any text file.
   * **Json Lines File** for single `.jsonl` file:
     * Upload [dataset](datasets) in JSON Lines format.
     * Specify the name of the key in the JSON that contains the assistant's (model's) response in the **Pointer Extractor** parameter.
   * etc.
4. Add **Text Splitter**, depending on the type of document data. For example,
   * **Markdown Text Splitter** for markdown files;
   * **Recursive Character Text Splitter** for JSON Lines files;
   * etc.
5. Connect **Text Splitter** and **Documents Loader**.
6. Add **LocalAI Embeddings** - this will allow you to integrate your own data into the model:
   * In the **Base Path** parameter, specify the URL to the *embedding* server. For example, if the server from [llama.cpp](llama.cpp) is used:
     * Start embedding server: `llama-server.exe -m "C:\models\Meta-Llama-3.1-8B-Instruct-Q8_0.gguf" --embedding --pooling mean --port 8082 --verbose`. In this case the **Base Path** should be `http://localhost:8082/v1`.
   * Specify any value in the **Model Name** parameter. For example, `test`.
7. Add any **Vector Store**:
   * **In-Memory Vector Store** - easy way to start.
   * **Faiss** - local Vector Storage from Facebook developers, nothing complicated:
     * In the **Base path to load** parameter, specify the path to the folder where the data files will be stored (files are created automatically).
8. Connect the **Documents Loader** and the **Embedding** with the **Vector Store**.
9. Add **ChatLocalAI** - to use local LLM:
   * In the **Base Path** parameter, specify the URL to *inference* server. Use the same model as for the embedding server. For example, if the server from [llama.cpp](llama.cpp) is used:
     * Start inference server: `llama-server.exe -m "C:\models\Meta-Llama-3.1-8B-Instruct-Q8_0.gguf" --port 8080 --verbose`. In this case the **Base Path** should be `http://localhost:8080/v1`.
   * Specify a value for the **Model Name** parameter. This value must match the value in the **LocalAI Embeddings** node.
10. Connect the **ChatLocalAI** and the **Vector Store** with the **Conversational Retrieval QA Chain**.
11. Save the Chatflow.  
    [![Chatflow](assets/flowise-chatflow.png)](assets/flowise-chatflow.png)
12. Make sure you have the **embedding server** and **inference server** running.
13. Click the **Upsert Vector Database** button. Wait for the operation to complete.  
    This may take a long time, depending on the size of the dataset.  
    ![Upsert Vector Database](assets/flowise-upsert-vector-database.png)  
    ![Upsert Vector Database results](assets/flowise-upsert-results.png)
14. Start a new chat to check if everything works correctly.  
    It is a good practice to specify a prompt message to introduce the model into context.
    ![Chatflow work](assets/flowise-chatflow-result.png)
15. Enjoy!
