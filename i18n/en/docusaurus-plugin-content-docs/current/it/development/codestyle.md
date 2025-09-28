---
description: Thoughts on coding style.
tags:
  - Guide
  - code-style
---

# Coding Style

:::warning
This document has been translated using machine translation without human review.
:::

## Introduction

The main and only rule is **consistency**.

The codebase of any project should be consistent. Ideally, it should look like **the code was written by one person**.

Every **developer should develop** the **skill of adopting the coding style** and easily switch to the **styles** adopted **in different projects**.

Personal **preferences** — **are not about coding style**. Forget about it and don't tell anyone.

Coding rules **should not kill individuality**. But developers should develop the **elegance** of their individuality in code so that it does not lead to stricter rules.

Every project **does not have to have the same coding style**. Time passes, technologies change, **new** versions of programming languages appear.
Having ten projects with the same coding style from ten years ago is probably convenient, but code from ten years ago, considering the speed of technology development, is not very good. This is stagnation, **lack of development**.

Projects can and should have **individual code writing standards**.

## Why is this important?

* [x] **Fewer questions about how to write code in the project.**

When a programmer opens unfamiliar code to make changes, the first thing they do is look at how that code is written.

If there are no clear rules in the codebase, the analysis will be a waste of time. If in the project every file is written haphazardly, or every file has its own coding style, the programmer will constantly spend time studying the style. In the worst case, the lack of understanding of how to write code can become a blocking factor and, as strange as it may sound, the developer simply won't be able to write code. Even if the inability to write code lasts only a couple of minutes, when there are too many such "couple of minutes", it can ultimately lead to the person burning out, with all the ensuing consequences. Beginner programmers will have it easier in this regard, but the code quality will be corresponding.

* [x] **Fewer merge conflicts.**

Merge conflicts are a problem, the incorrect solution of which can lead to other problems.
If the codebase is written in a consistent style, some conflicts can be resolved automatically.
Following some general recommendations can generally reduce the occurrence of code conflicts.

* [x] **Code search and prediction.**

In large projects and projects with high development dynamics, there is a constant need to add new functionality.
Sometimes you can try to search, maybe the needed functionality has already been added by someone. If you know what the implementation might be, then finding the right code will be quite simple.

The ability to quickly find the right code sample saves a lot of time and effort.

Keeping the codebase in a consistent style facilitates the code reorganization process (refactoring).
It's easier to do an automatic search and replace than to manually and visually go through everything.
This also reduces the number of errors due to inattention.

* [x] **Discipline.**

Discipline, self-control, organization, increased productivity, achieving goals.

## Without Fanaticism

Perfect code does not exist and never will. There is no point in strictly limiting freedom. There is no point in spending a lot of resources on polishing code.

A strict ban on adding code to the codebase that does not meet the requirements, especially with the use of automated tools, is a path to losing people. It can also slow down problem solving and goal achievement. In the worst case, it can kill the project.

It is necessary to maintain a balance between freedom and quality.

## How to make a codebase consistent?

The first step is to configure **[.editorconfig](https://editorconfig.org/)**. The rest will depend on the programming languages and technologies used.

In some cases, you can configure automatic error correction and make the code consistent.
For example, in **JavaScript/TypeScript** you can configure **[ESLint](https://eslint.org/)**. In **C#** projects you can use **[dotnet format](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-format)**.

## Is it worth spending time maintaining a unified codebase style in home (pet) projects?

Yes. Training is never superfluous.

## General Recommendations

The following recommendations are based on experience in team work in commercial development and experience working on open source projects.

### Spaces or Tabs?

In the world of **.NET**, **JavaScript**, **TypeScript**, **PHP**, **Python**, **(S|Post)CSS**, preference is given to **spaces**, because they are more predictable.

The problem with tab characters is that the character size can depend on the code editor settings.
This might be convenient to some extent, but when working in a team, it will create problems for team members.

It is necessary for all project participants to use the same settings, otherwise time will have to be spent resolving conflicts with whitespace characters when merging branches.

### Line Endings

The problem of line ending characters is most relevant for cross-platform teams, when team members work under **Windows**, **Linux** or **macOS**.

Most modern development environments and some git clients, by default, can detect confusion in line ending characters, and perhaps this is one of the irritants.

The easiest way is to use the **Unix style** — the `\n` character. But as practice shows, **Windows** users can still **have problems** with line endings. The problem will also manifest itself when using **ordinary text editors** that cannot automatically adjust the coding style according to the rules of `.editorconfig`. In such cases, you can try to **solve the problem at the git level** — the **`core.autocrlf`** parameter.

I usually leave this problem to `.editorconfig`, but I also constantly try to monitor whitespace characters and problems with line endings in my code rarely occur.

### No Extra Indentation

Whitespace characters at the end of lines, empty lines consisting only of whitespace characters — this is garbage.

In some cases, conflicts can arise due to such characters.

To ensure there is no garbage in the code, it is necessary to configure the **IDE** to **remove** such characters (**trailing whitespace**).

I also recommend **enabling the display of whitespace characters** so that you can see that everything is fine in the code or, conversely, requires adjustment.

:::note
However, it should be taken into account that in some languages, trailing spaces can play a certain role.
For example, in **markdown**, two spaces at the end of a line mean that a line break character should be added after the line (usually lines in markdown are separated by empty lines).
:::

### Every File Must End With a Line Break Character

This is a fairly old standard, the roots of which go back to **Unix** systems.

Adding one empty line at the end of the file allows you not to touch the penultimate line when adding new data.

```diff
- File without a line break at the end.
+ File without a line break at the end.
+ New data. Due to the addition of a line break character, the previous line has changed.
```

```diff
File with a line break at the end.
+ New data. The newline character was already there and the previous line was not affected.
+
```

:::note
Adding a new line can be configured via **.editorconfig**, but it should be noted that in rare cases this can create problems.
For example, if the file contains an access key or password and is used entirely as is. In this case, adding a line break will break the secret.
But such exceptions rarely occur in practice, and everything can be configured via **.editorconfig**.
:::

### Sorting

A good practice is to **sort imports/includes/packages in a file**.

This helps **avoid** useless **conflicts** when merging branches.

Sorting is usually done alphabetically.

In some cases, sorting with grouping can be performed.
For example, system namespaces/packages can be separated from internal project elements and sorted individually.
This further reduces the likelihood of merge problems.

Many **IDEs** allow you to **automatically perform sorting**.

You can go further and sort entities in files. For example, local and public members, constants, fields, properties, methods.
This also works well and reduces the likelihood of conflicts, the main thing is that the rules are clear and do not cause inconvenience.

### No Commented-Out Code Blocks

Commented-out code blocks, especially if there is no explanation — this is garbage.

~If~ when the author of such a block forgets about it, then with a high degree of probability, this **garbage will remain in the project forever**.

Ideally, such code should **not get into the main branch** (`master` / `main`) at all.

### Consistent Quotes

In languages that allow the use of different quote options, it is better to **immediately decide which option will be correct**.

This will help **avoid conflicts with quotes**.

Which quotes to use depends on the project, the technologies used, and the team. For example, in a **C#/Java** team, it is preferable to use **double quotes** in **JavaScript** code, because in **C#/Java** single quotes are used only for individual characters (char), while double quotes are used for strings (string).
