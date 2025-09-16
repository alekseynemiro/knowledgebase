"""
This script translates knowledge base entries into English using LLM.

The MIT License (MIT)

Copyright © 2025, Aleksey Nemiro
"""
import getpass
import os
import multiprocessing
import shutil

from glob import glob

from langchain_community.chat_models import ChatLlamaCpp
from langchain_deepseek import ChatDeepSeek
from langchain_core.prompts import ChatPromptTemplate

from _helpers import compute_file_hash
from _markdown_splitter import MarkdownSplitter

use_local = False
use_splitter = False

current_dir = os.path.dirname(os.path.realpath(__file__))
base_path = os.path.normpath(os.path.join(os.path.dirname(current_dir), "base"))
base_output = os.path.normpath(os.path.join(os.path.dirname(current_dir), "i18n/en/docusaurus-plugin-content-docs/current"))
cache_path = os.path.normpath(os.path.join(current_dir, ".cache"))

print("This script will translate the knowledge base from Russian to English.")
print(f"Source path: {base_path}")
print(f"Output path: {base_output}")
print("WARN: The data in the output directory will be deleted!")

should_continue = input("Continue [Y/n]? ")

if should_continue.strip().lower() == "n":
   exit()

if use_local:
  print("You must specify the path to the model file that will perform the translation.")
  print("PHI-4 does a pretty good job.")

print("------------------------------------------------------------------------------")

if not use_local and not os.getenv("DEEPSEEK_API_KEY"):
    os.environ["DEEPSEEK_API_KEY"] = getpass.getpass("Enter your DeepSeek API key: ")

if use_local:
  model_path = input("Enter path to gguf file: ")

  while not os.path.exists(model_path):
    print(f"File '{model_path}' not found.")
    model_path = input("Enter path to gguf file: ")

warning = (
    ":::warning\n"
    "This document has been translated using machine translation without human review.\n"
    ":::"
)

translator_prompt = (
    "You are a smart assistant. Your task is to read the text in Markdown format in Russian and translate it into English.\n"
    "You receive the text in its original form. Your answer must contain similar text in English in markdown code block format.\n"
    "If the document metadata contains tags in Russian, remove them. Make sure that tags in English are present. Do not add any tags yourself.\n"
    "The formatting of the original text must be completely preserved.\n"
    "Translate the name Алексей Немиро as Aleksey Nemiro.\n"
    "Make sure your answer is accurate and free of errors.\n"
    "Don't comment on anything. Don't invent anything. Don't add anything extra.\n"
    "Your answer must contain only a Markdown code block!\n"
    "\n"
    "Source text:\n"
    "Result:"
)

translator_initial_messages = ChatPromptTemplate.from_messages(
    [
        ("system", translator_prompt),
        ("ai", "I'm ready!"),
        ("human", "{input}"),
    ]
)

if use_local:
    llm = ChatLlamaCpp(
        model_path=model_path,
        n_ctx=32768,
        max_tokens=32768,
        temperature=0.1,
        n_gpu_layers=-1,
        n_threads=multiprocessing.cpu_count() - 1,
        # f16_kv=True,
        cache=False,
        logits_all=True,
        verbose=False,
    )
else:
    llm = ChatDeepSeek(
        model="deepseek-chat",
        temperature=0.1,
        max_tokens=None,
        timeout=None,
        max_retries=2,
    )

# clear output
for item in os.listdir(base_output):
    item_path = os.path.join(base_output, item)
    if os.path.isdir(item_path):
        shutil.rmtree(item_path)
    else:
        os.remove(item_path)

# prepare files list
files = glob(os.path.join(base_path, '**', '*.md'), recursive=True) + glob(os.path.join(base_path, "**", "*.mdx"), recursive=True)

print(f"{len(files)} files found.")

os.makedirs(cache_path, exist_ok=True)

"""
# update cache for all files
for file_path in files:
    file_hash = compute_file_hash(file_path)
    output_path = os.path.join(cache_path, file_path.replace(base_path, "").strip("\\/"))

    os.makedirs(os.path.dirname(output_path), exist_ok=True)

    with open(output_path, "w", encoding="utf-8") as writer:
        writer.write(file_hash)
"""

# translate
splitter = MarkdownSplitter()

for file_path in files:
    print(f"Processing '{file_path}'...")

    file_hash = compute_file_hash(file_path)
    file_hash_path = os.path.join(cache_path, file_path.replace(base_path, "").strip("\\/"))

    if os.path.exists(file_hash_path):
        with open(file_hash_path, "r", encoding="utf-8") as reader:
            cached_file_hash = reader.read().strip()

        if cached_file_hash == file_hash:
           print("Skip because file has not changed since last time.")
           continue

    result_content = None

    with open(file_path, "r", encoding="utf-8") as reader:
        file_content = reader.read()

        if use_splitter:
          file_content_parts = splitter.split(file_content)
        else:
          file_content_parts = [file_content]

        result = []

        for part in file_content_parts:
          print(f"Part {len(result) + 1} of {len(file_content_parts)}")

          if not part.strip():
              result.append("")
              continue

          translator = translator_initial_messages | llm
          response = translator.invoke({"input": f"```\n{part}\n```"})
          result_part = response.content.strip()

          # remove code blocks
          lines = result_part.splitlines()

          if lines and lines[0].strip().startswith('```'):
            lines = lines[1:]

          for i in range(len(lines) - 1, -1, -1):
              if lines[i].strip().startswith('```'):
                  lines = lines[:i]
                  break

          result_part = "\n".join(lines).strip()
          result.append(result_part)

        result_content = "\n".join(result).strip()

        # add warning
        warning_is_append = False
        lines = result_content.splitlines(keepends=True)

        for i, line in enumerate(lines):
            if line.strip().startswith("# "):
                lines.insert(i + 1, "\n" + warning + "\n")
                warning_is_append = True
                result_content = "".join(lines)
                break

        if not warning_is_append:
            result_content = warning + "\n\n" + result_content

        # save
        output_path = os.path.join(base_output, file_path.replace(base_path, "").strip("\\/"))
        os.makedirs(os.path.dirname(output_path), exist_ok=True)
        with open(output_path, "w", encoding="utf-8") as writer:
            writer.write(result_content.strip() + "\n")

        os.makedirs(os.path.dirname(file_hash_path), exist_ok=True)
        with open(file_hash_path, "w", encoding="utf-8") as writer:
            writer.write(file_hash)

    print(f"File '{file_path}' processing completed.")
