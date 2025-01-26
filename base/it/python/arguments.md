---
title: Command Arguments
description: Using command line arguments.
tags:
  - Python
  - FAQ
---

# Python: Command Arguments

## How to add command line parameter processing?

```python
import argparse

parser = argparse.ArgumentParser(description="User Welcome Program")

parser.add_argument(
    "--version",
    "-v",
    action="store_true",
    dest="version",
    help="Display information about the program version."
)

parser.add_argument(
  "--name",
  "-n",
  nargs='+', 
  dest="name",
  help="Specifies the name of the user to greet."
)

args = parser.parse_args()

if args.version:
    print("v1.0")
    exit(0)

if not args.name:
    parser.print_help()
    exit(1)

print(f"Hello {", ".join(args.name)}")
```
