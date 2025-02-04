---
slug: /git/cli
title: Git CLI
description: Git command-line interface
tags:
  - Git
  - FAQ
---

# Git CLI

## How to create a new repository in a folder?

```bash
git init
```

## How to clone a remote repository?

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

```bash title="Current branch"
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

```bash title="Current branch"
git pull
```

```bash title="Specific branch"
git pull origin <branch_name>
```

## How to make a commit?

In most cases, it is enough to simply commit all changes:

```bash title="Commit changes"
git commit -m "Commit message"
```

If you need to add changes to the index:

```bash title="Add changes to index"
git add <file_or_dir_path>
```

* `<file_or_dir_path>` - you can use wildcard. For example, `git add *.ts`.

```bash title="Add all changes and ignore new files"
git add -A .
```

## How to push changes to a remote repository?

```bash title="Current branch"
git push
```

```bash title="Specific target branch"
git push origin <target_branch_name>
```

If the target branch does not exist, it will be created automatically.  
To tracking branch, use the `-u` flag:

```bash
git push -u origin <target_branch_name>
```

## How to delete a branch?

```bash title="Delete local branch"
git branch -d <branch_name>
```

```bash title="Delete remote brach"
git push -d origin <branch_name>
```

You can use flag `-f` to force delete.

## How to create and push a tag?

The following example creates and pushes a "v1.0" tag to the latest commit:

```bash
git tag v1.0 && git push origin tag v1.0
```

```bash title="With a message"
git tag -a <tag_name> -m '<tag_message>'
git push origin tag <tag_name>
```

## How to delete a tag?

```bash title="Delete from local"
git tag -d <tag_name>
```

```bash title="Delete from remote repository"
git push origin -d <tag_name>
```

## What is `origin`?

`origin` is the default name for the remote repository.

## How to get the latest commit hash, date and branch name in one line?

This can be useful for generating a version number.

```bash
git log -1 --pretty='%H;%aI;%D'
```
