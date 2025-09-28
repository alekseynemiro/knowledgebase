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

```git
git init
```

## How to link a local repository to a remote one?

```git
git remote add origin https://git.exmple.org/repo.git
```

## How to clone/fetch a remote repository?

```git title="Clone master branch"
git clone https://github.com/alekseynemiro/knowledgebase.git
```

```git title="Clone a specific branch"
git clone -b <branch_name> <repo_url>
```

## How to get a list of branches from a remote repository?

```git
git fetch --all
```

## How to check the status of the current branch?

```git
git status
```

## How to display the name of the current branch?

```git title="Current branch name"
git branch --show-current
```

```git title="List of all branches"
git branch
```

## How to create a new branch?

```git title="Create a new branch"
git branch <branch_name>
```

```git title="Create a new branch and switch to it"
git checkout -b <branch_name>
```

## How to switch to a branch?

```git
git checkout <branch_name>
```

## How to get changes from a remote repository?

```git title="From the current branch"
git pull
```

```git title="From a specific branch"
git pull origin <branch_name>
```

## How to commit changes?

In most cases, it's enough to simply commit all changes:

```git title="Commit changes"
git commit -m "Commit message"
```

If you need to add changes to the index:

```git title="Add a file or folder to the index"
git add <file_or_dir_path>
```

* `<file_or_dir_path>` — wildcard patterns are allowed. For example — `git add *.ts`.

```git title="Add all changes and ignore new files"
git add -A .
```

## How to send changes to a remote repository?

```git title="Send to the current branch"
git push
```

```git title="Send to a specific branch"
git push origin <target_branch_name>
```

If the target branch doesn't exist, it will be created automatically.  
To track the branch, use the `--set-upstream` (`-u`) flag:

```git
git push --set-upstream origin <target_branch_name>
```

Send changes for all branches and set up tracking for these branches:

```git
git push --all --set-upstream origin
```

## How to delete a branch?

```git title="Delete a local branch"
git branch -d <branch_name>
```

```git title="Delete a remote branch"
git push -d origin <branch_name>
```

For forced deletion, you can use the `-f` flag.

## How to create a tag?

The following examples show creating a tag for the last commit:

```git title="Create a new tag"
git tag v1.0
```

```git title="Create a new tag with a message"
git tag -a <tag_name> -m '<tag_message>'
```

## How to send a tag to a remote server?

```git title="Send tag v1.0"
git push origin tag v1.0
```

## How to delete a tag?

```git title="Delete a tag locally"
git tag -d <tag_name>
```

```git title="Delete a tag from a remote repository"
git push origin -d <tag_name>
```

## How to rename a tag?

There is no direct way to rename tags in **git**. There is a workaround — create a new tag referencing the old one and then delete the old tag:

```git
git tag new old
git tag -d old
git push origin new
git push origin -d old
```

## How to remove tags from the local repository that don't exist in the remote repository?

```git
git fetch --prune-tags
```

## What is `origin`?

`origin` — the default name for the remote repository.

## How to get the hash of the last commit, date, and branch name in one line?

This can be useful for generating version numbers.

```git
git log -1 --pretty='%H;%aI;%D'
```

## How to check if a commit has a signature (gpg)?

```git
git verify-commit <commit_hash>
```

```git
git log --show-signature
```
