---
slug: /git/cli/branches
description: Working with branches through the Git command line interface.
tags:
  - Git
  - FAQ
---

# Branches

:::warning
This document has been translated using machine translation without human review.
:::

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

## How to delete a branch?

```git title="Delete a local branch"
git branch -d <branch_name>
```

```git title="Delete a remote branch"
git push -d origin <branch_name>
```

For forced deletion, you can use the `-f` flag.

## How to restore a deleted branch?

If the branch was merged with the main branch, you can easily find the required commit:

```git
$ git log --merges --oneline --all

c58d979 Merge pull request #109 from alekseynemiro/MDSWTCH-108
b166f35 Merge pull request #107 from alekseynemiro/MDSWTCH-106
698a6ea Merge pull request #105 from alekseynemiro/MDSWTCH-104
436435d Merge pull request #102 from alekseynemiro/MDSWTCH-97
```

Using the `git show` command, you can get the hashes of the branches that participated in the merge.

In the following example, `13eeb27` is the branch into which the data was merged (usually `master`), and `05215eb` is the branch being merged (the branch that needs to be restored).

```git
$ git show b166f35

commit b166f3556519970b1a42b306aa459a465eb9790f
Merge: 13eeb27 05215eb
Author: Aleksey Nemiro <aleksey@kbyte.ru>
Date:   Fri Oct 13 18:10:45 2023 +0300

    Merge pull request #107 from alekseynemiro/MDSWTCH-106

    106_to_v1.2: Cannot read property 'backdrop' of undefined
```

To restore the branch, it is enough to create it from the found hash.

In the following example, the `MDSWTCH-106` branch will be restored:

```git
git checkout -b MDSWTCH-106 05215eb
```
