---
slug: /git/cli/tags
description: Working with tags through the Git command line interface.
tags:
  - Git
  - FAQ
---

# Tags

:::warning
This document has been translated using machine translation without human review.
:::

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

```git title="Delete tag locally"
git tag -d <tag_name>
```

```git title="Delete tag from remote repository"
git push origin -d <tag_name>
```

## How to rename a tag?

There is no direct way to rename tags in **git**. There is a workaround - create a new tag referencing the old one and then delete the old tag:

```git
git tag new old
git tag -d old
git push origin new
git push origin -d old
```

## How to delete tags from the local repository that don't exist in the remote repository?

```git
git fetch --prune-tags
```
