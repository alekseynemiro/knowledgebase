---
title: Date & Time
description: Operations with dates and time in Python.
tags:
  - Python
  - FAQ
---

# Python: Date & Time

## How to get date in JSON format (ISO 8601)?

```python
from datetime import datetime

print(f"{datetime.now().strftime('%Y-%m-%dT%H:%M:%S.%f'}")
```

## How to convert seconds to TimeSpan?

```python
from datetime import timedelta

seconds_value = 123
timespan = str(timedelta(seconds=seconds_value))

print(timespan)
```
