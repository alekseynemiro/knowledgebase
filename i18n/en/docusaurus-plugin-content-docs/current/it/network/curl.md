---
title: cURL
description: Questions and answers on using cURL.
tags:
  - cURL
  - FAQ
---

# cURL

:::warning
This document has been translated using machine translation without human review.
:::

**cURL** (Client for URL) is a command-line tool for transferring data specified using URL syntax.

* [https://curl.se](https://curl.se)
* [https://github.com/curl/curl](https://github.com/curl/curl)

## How to make requests using cURL?

```bash title="GET"
curl https://example.org
```

```bash title="GET with authorization"
curl --header "Authorization: Bearer <TOKEN HERE>" https://example.org
```

```bash title="POST json"
curl --header "Content-Type: application/json" \
     --request POST \
     --data "{}" \
     https://example.org
```
