---
title: "Python: Date & Time"
description: Операции с датами и временем в Python.
tags:
  - Python
  - FAQ
---

# Python: Date & Time

## Как получить дату в формате JSON (ISO 8601)?

```python
from datetime import datetime

print(f"{datetime.now().strftime('%Y-%m-%dT%H:%M:%S.%f'}")
```

## Как преобразовать секунды в TimeSpan?

```python
from datetime import timedelta

seconds_value = 123
timespan = str(timedelta(seconds=seconds_value))

print(timespan)
```
