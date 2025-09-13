---
title: cURL
description: Вопросы и ответы по использованию cURL.
tags:
  - cURL
  - FAQ
---

# cURL

**cURL** (Client for URL) — инструмент командной строки для передачи данных, указанных с помощью синтаксиса URL.

* [https://curl.se](https://curl.se)
* [https://github.com/curl/curl](https://github.com/curl/curl)

## Как делать запросы с помощью cURL?

```bash title="GET"
curl https://example.org
```

```bash title="GET с авторизацией"
curl --header "Authorization: Bearer <TOKEN HERE>" https://example.org
```

```bash title="POST json"
curl --header "Content-Type: application/json" \
     --request POST \
     --data "{}" \
     https://example.org
```
