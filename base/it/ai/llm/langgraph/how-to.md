---
title: "LangGraph: Вопросы и ответы"
description: Вопросы и ответы по LangGraph на Python.
tags:
  - LangGraph
  - Python
  - LLM
  - Machine Learning
  - AI
  - FAQ
  - Большие языковые модели
  - Машинное обучение
  - ИИ
---

# LangGraph: Вопросы и ответы

:::note
Информация актуальна для **langgraph v0.2.67** и **Python v3.13**.
:::

## Как установить LangGraph?

```bash
pip install langgraph langchain-core
```

## Как создать агента в LangGraph?

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
    Возвращает текущую дату.
    """

    return str(date.today())

def call_node(state: MessagesState):
    messages = [
        SystemMessage(
            content=(
                "Ты умный помощник. Для тебя доступны инструменты, которые могут помочь ответить на вопрос пользователя."
                "Используй инструменты, если это необходимо."
                "Будь краток и лаконичен. Ничего не придумывай."
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
