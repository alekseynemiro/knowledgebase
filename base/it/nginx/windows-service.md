---
title: Windows Service
description: Installing NGINX on Windows as a Service.
tags:
  - nginx
  - Windows
  - Web server
---

# Installing NGINX on Windows as a Service

1. [Download NGINX](https://nginx.org/en/download.html)
2. `choco install nssm`
3. `nssm install nginx`
4. ![nssm](assets/nssm-nginx.png)
5. Enjoy!

## Restart service

```bash
net stop nginx && net start nginx
```
