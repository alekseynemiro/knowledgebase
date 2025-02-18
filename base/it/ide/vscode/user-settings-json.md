---
title: User settings
description: Questions related to VS Code configuration.
tags:
  - VS Code
  - IDE
  - FAQ
---

# User settings (JSON)

## How to open a settings file in JSON format?

`Ctrl + Shift + P` => Preferences: Open User Settings (JSON)

![Preferences: Open User Settings (JSON)](assets/user-settings.png)

## How to enable/disable autosave?

```json
"files.autoSave": "onFocusChange",
```

## How to set newline character?

```json
"files.eol": "\n",
```

## How to enable the removal of trailing spaces?

```json
"files.trimTrailingWhitespace": true,
```

## How to prevent trailing spaces from being removed for Markdown files?

```json
"[markdown]": {
    "files.trimTrailingWhitespace": false
},
```

## How to remove the yellow frame highlighting of Russian letters (Unicode characters)?

Add `ru` locale to the allowed list:

```json
"editor.unicodeHighlight.allowedLocales": {
    "_os": true,
    "_vscode": true,
    "ru": true
}
```

Or add chars to the `allowedCharacters` list:

```json
"editor.unicodeHighlight.allowedCharacters": {
    "а": true, "б": true, "в": true, "г": true, "д": true,
    "е": true, "ё": true, "ж": true, "з": true, "и": true,
    "й": true, "к": true, "л": true, "м": true, "н": true,
    "о": true, "п": true, "р": true, "с": true, "т": true,
    "у": true, "ф": true, "х": true, "ц": true, "ч": true,
    "ш": true, "щ": true, "ъ": true, "ы": true, "ь": true,
    "э": true, "ю": true, "я": true,
    "А": true, "Б": true, "В": true, "Г": true, "Д": true,
    "Е": true, "Ё": true, "Ж": true, "З": true, "И": true,
    "Й": true, "К": true, "Л": true, "М": true, "Н": true,
    "О": true, "П": true, "Р": true, "С": true, "Т": true,
    "У": true, "Ф": true, "Х": true, "Ц": true, "Ч": true,
    "Ш": true, "Щ": true, "Ъ": true, "Ы": true, "Ь": true,
    "Э": true, "Ю": true, "Я": true
}
```

Or disable the feature:

```json
"editor.unicodeHighlight.ambiguousCharacters": false
```
