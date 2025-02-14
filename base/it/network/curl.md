---
title: cURL
description: Questions and answers about using cURL.
tags:
  - cURL
  - FAQ
---

# cURL

**cURL** (Client for URL) - is a command-line tool for transferring data specified with URL syntax.

* [https://curl.se](https://curl.se)
* [https://github.com/curl/curl](https://github.com/curl/curl)

## How to make requests using cURL?

```bash title="GET"
curl https://example.org
```

```bash title="GET with Authorization"
curl --header "Authorization: Bearer <TOKEN HERE>" https://example.org
```

```bash title="POST json"
curl --header "Content-Type: application/json" \
     --request POST \
     --data "{}" \
     https://example.org
```
