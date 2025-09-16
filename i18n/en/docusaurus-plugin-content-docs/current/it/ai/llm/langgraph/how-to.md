---
title: "LangGraph: Questions and Answers"
description: Questions and answers about LangGraph in Python.
tags:
  - LangGraph
  - Python
  - LLM
  - Machine Learning
  - AI
  - FAQ
---

# LangGraph: Questions and Answers

:::warning
This document has been translated using machine translation without human review.
:::

:::note
Information is current for **langgraph v0.2.67** and **Python v3.13**.
:::

## How to install LangGraph?

```bash
pip install langgraph langchain-core
```

## How to create an agent in LangGraph?

```python
from datetime import date
from langchain_community.chat_models import ChatLlamaCpp
from langchain_core.messages import HumanMessage, SystemMessage
from langchain_core.tools import tool
from langgraph.graph import StateGraph, START, END, MessagesState
from langchain_core.messages import ToolMessage
from typing import Literal

@tool
def current_date() -> str:
    """
    Returns the current date.
    """

    return str(date.today())

def call_node(state: MessagesState):
    messages = [
        SystemMessage(
            content=(
                "You are a smart assistant. Tools are available to you that can help answer the user's question."
                "Use tools if necessary."
                "Be brief and concise. Don't make anything up."
            )
        )
    ]

    result = {
        "messages": [
            llm_with_tools.invoke(messages + state["messages"])
        ]
    }

    return result

def tool_node(state: dict):
    result = []

    for tool_call in state["messages"][-1].tool_calls:
        tool = tools_by_name[tool_call["name"]]
        observation = tool.invoke(tool_call["args"])
        result.append(ToolMessage(content=observation, tool_call_id=tool_call["id"]))

    return {"messages": result}

def should_continue(state: MessagesState) -> Literal["environment"]:
    messages = state["messages"]
    last_message = messages[-1]

    if last_message.tool_calls:
        return "Action"

    return END

tools = [current_date]
tools_by_name = {tool.name: tool for tool in tools}

llm = ChatLlamaCpp(
    model_path="llama-3.2-1b-instruct-q8_0.gguf",
    n_ctx=2000,
    temperature=0.75,
    verbose=False,
)

llm_with_tools = llm.bind_tools(tools)

agent_builder = StateGraph(MessagesState)

agent_builder.add_node("call", call_node)
agent_builder.add_node("environment", tool_node)

agent_builder.add_edge(START, "call")
agent_builder.add_conditional_edges(
    "call",
    should_continue,
    {
        "Action": "environment",
        END: END,
    },
)
agent_builder.add_edge("environment", "call")
agent = agent_builder.compile()

while True:
    query = input("User: ")

    if query in ("end", "exit", "quit", "stop", "выход", "завершить", "стоп", "хватит"):
        exit()

    messages = [HumanMessage(content=query)]
    response = agent.invoke({"messages": messages})

    print(f"Agent: {response["messages"][-1].content}")
```
