---
slug: /git/cli/commits
description: Getting and committing changes via the Git command line interface.
tags:
  - Git
  - FAQ
---

# Changes

:::warning
This document has been translated using machine translation without human review.
:::

## How to get changes from a remote repository?

```git title="From the current branch"
git pull
```

```git title="From a specific branch"
git pull origin <branch_name>
```

## How to commit changes?

In most cases, it's enough to simply commit all changes:

```git title="Committing changes"
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

## How to get the hash of the last commit, date, and branch name in one line?

This can be useful for generating a version number.

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

## How to get a list of all merge commits?

```git
git log --merges --oneline --all
```
