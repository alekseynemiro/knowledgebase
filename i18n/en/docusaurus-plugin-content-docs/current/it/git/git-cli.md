---
slug: /git/cli
title: Git CLI
description: Git command-line interface
tags:
  - Git
  - FAQ
---

# Git CLI

:::warning
This document has been translated using machine translation without human review.
:::

## How to create a new repository in the current folder?

```bash
git init
```

## How to link a local repository to a remote one?

```bash
git remote add origin https://git.exmple.org/repo.git
```

## How to clone/fetch a remote repository?

```bash title="Clone the master branch"
git clone https://github.com/alekseynemiro/knowledgebase.git
```

```bash title="Clone a specific branch"
git clone -b <branch_name> <repo_url>
```

## How to get a list of branches from a remote repository?

```bash
git fetch --all
```

## How to check the status of the current branch?

```bash
git status
```

## How to display the name of the current branch?

```bash title="Current branch name"
git branch --show-current
```

```bash title="List of all branches"
git branch
```

## How to create a new branch?

```bash title="Create a new branch"
git branch <branch_name>
```

```bash title="Create a new branch and switch to it"
git checkout -b <branch_name>
```

## How to switch to a branch?

```bash
git checkout <branch_name>
```

## How to get changes from a remote repository?

```bash title="From the current branch"
git pull
```

```bash title="From a specific branch"
git pull origin <branch_name>
```

## How to commit changes?

In most cases, it is enough to simply commit all changes:

```bash title="Commit changes"
git commit -m "Commit message"
```

If you need to add changes to the index:

```bash title="Add a file or folder to the index"
git add <file_or_dir_path>
```

* `<file_or_dir_path>` — it is acceptable to use a wildcard pattern. For example — `git add *.ts`.

```bash title="Add all changes and ignore new files"
git add -A .
```

## How to send changes to a remote repository?

```bash title="Send to the current branch"
git push
```

```bash title="Send to a specific branch"
git push origin <target_branch_name>
```

If the target branch does not exist, it will be created automatically.  
To track the branch, use the `--set-upstream` (`-u`) flag:

```bash
git push --set-upstream origin <target_branch_name>
```

Send changes for all branches and set up tracking for these branches:

```bash
git push --all --set-upstream origin
```

## How to delete a branch?

```bash title="Delete a local branch"
git branch -d <branch_name>
```

```bash title="Delete a remote branch"
git push -d origin <branch_name>
```

For forced deletion, you can use the `-f` flag.

## How to create a tag?

The following examples show creating a tag for the last commit:

```bash title="Create a new tag"
git tag v1.0
```

```bash title="Create a new tag with a message"
git tag -a <tag_name> -m '<tag_message>'
```

## How to send a tag to a remote server?

```bash title="Send tag v1.0"
git push origin tag v1.0
```

## How to delete a tag?

```bash title="Delete a tag locally"
git tag -d <tag_name>
```

```bash title="Delete a tag from a remote repository"
git push origin -d <tag_name>
```

## How to rename a tag?

There is no direct way to rename tags in **git**. There is a workaround — create a new tag referencing the old one and then delete the old tag:

```bash
git tag new old
git tag -d old
git push origin new
git push origin -d old
```

## How to delete tags from the local repository that do not exist in the remote repository?

```bash
git fetch --prune-tags
```

## What is `origin`?

`origin` is the default name of the remote repository.

## How to get the hash of the last commit, date, and branch name in one line?

This can be useful for generating a version number.

```bash
git log -1 --pretty='%H;%aI;%D'
```

## How to check if a commit has a signature (gpg)?

```bash
git verify-commit <commit_hash>
```

```bash
git log --show-signature
```
