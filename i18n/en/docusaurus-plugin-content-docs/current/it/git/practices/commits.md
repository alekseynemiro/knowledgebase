---
description: Recommendations for writing commit messages in Git.
tags:
  - Git
  - Guide
---

# Writing Git Commit Messages

:::warning
This document has been translated using machine translation without human review.
:::

This document contains general recommendations for writing commit messages in **Git**.  
These recommendations are based on well-known practices, as well as personal experience with teamwork and automation.

:::note

* **Subject** — this is the first line of the comment, a brief description.
* **Body** — the subsequent lines that may contain more detailed information.

:::

## Include the task number in the subject line

* This will help automate the process of tracking and analyzing completed work for the task.
* This will help find the task and understand what happened when the need arises. In large projects and during teamwork, this happens more often than it might seem.

| :heavy_check_mark: Good Example  | :no_entry: Bad Example |
|------------------------------------|--------------------------|
| JIRA-1725: Add README.md file | Added README.md file   |

## Use the imperative mood in the subject line

In English, this primarily solves the problem of incorrect tense usage and, in general, makes the text simpler.

In Russian, the imperative mood also works quite well. The comment sounds like a command. When reviewing history or applying individual commits, this looks quite logical, like executing a script that performs certain actions, and the commit message is the action being performed.

| :heavy_check_mark: Good Example           | :no_entry: Bad Example                  |
|---------------------------------------------|-------------------------------------------|
| ISSUE-5217: Add CHANGELOG.md                 | ISSUE-5217: Added CHANGELOG.md             |
| ISSUE-5217: Update external service call  | ISSUE-5217: Updated external service call |
| ISSUE-5217: Remove arguments from method Foo  | ISSUE-5217: Removed arguments from method Foo |

## Do not put a period at the end of the subject line

The first line of the comment should not end with a period. This is the subject of the message. A subject cannot end with a period.

| :heavy_check_mark: Good Example           | :no_entry: Bad Example                  |
|---------------------------------------------|-------------------------------------------|
| EXMPL-1925: Add upload method         | EXMPL-1925: Add upload method.      |

## The subject should be as short and informative as possible

The first line of the commit message should be as **short** as possible.

At the same time, the first line should contain the **maximum amount of useful information** so that it is clear what exactly changed in the code.

This is necessary for the convenience and speed of reviewing history. Moreover, it will be convenient both when viewing via the command line interface and in clients with a graphical interface.

On average, it is recommended to use **no more than 50 characters**.

| :heavy_check_mark: Good Example             | :no_entry: Bad Example                                                           |
|-----------------------------------------------|------------------------------------------------------------------------------------|
| MYLLM-7841: Add MCP client configuration | MYLLM-7841: Add address, port, and token to settings for connecting to the MCP server |

## Separate the subject and body with a blank line

If the comment is multi-line, a blank line should be placed between the subject and the body.

This will make the text easier to read.

<table>
  <thead>
    <tr>
      <th>:heavy_check_mark: Good Example</th>
      <th>:no_entry: Bad Example</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>DATA-2078: Delete Users table<br /><br />
      The customer is against storing users in the database. We will now use an external cloud storage.</td>
      <td>DATA-2078: Delete Users table<br />
      The customer is against storing users in the database. We will now use an external cloud storage.</td>
    </tr>
  </tbody>
</table>

## The body should answer the question "why was all this done"

A good message body should explain *why* the changes were made.

<table>
  <thead>
    <tr>
      <th>:heavy_check_mark: Good Example</th>
      <th>:no_entry: Bad Example</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>AWESOME-2356: Add exclude argument<br /><br />
      This will allow excluding unnecessary data from the selection.</td>
      <td>AWESOME-2356: Add exclude argument<br /><br />
      Change function logic. Minor refactoring.</td>
    </tr>
  </tbody>
</table>

## Variety

Do not write identical commit messages. Such messages are difficult to work with and do not carry any useful load.

| :heavy_check_mark: Good Example                            | :no_entry: Bad Example                              |
|--------------------------------------------------------------|-------------------------------------------------------|
| MYPROJECT-2518: Create message sending service            | MYPROJECT-2518: Implementation of message sending service |
| MYPROJECT-2518: Create tests for message sending service | MYPROJECT-2518: Implementation of message sending service |
