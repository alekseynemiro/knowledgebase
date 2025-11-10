---
slug: /git/cli/repositories
description: Working with repositories through the Git command line interface.
tags:
  - Git
  - FAQ
---

# Repositories

:::warning
This document has been translated using machine translation without human review.
:::

## How to create a new repository in the current folder?

```git
git init
```

## How to link a local repository to a remote one?

```git
git remote add origin https://git.exmple.org/repo.git
```

## How to clone/fetch a remote repository?

```git title="Clone the master branch"
git clone https://github.com/alekseynemiro/knowledgebase.git
```

```git title="Clone a specific branch"
git clone -b <branch_name> <repo_url>
```

## What is `origin`?

`origin` is the default name for a remote repository.
