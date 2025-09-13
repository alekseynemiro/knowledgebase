---
title: "VS Code: User settings"
description: Вопросы, связанные с настройкой VS Code.
tags:
  - VS Code
  - IDE
  - FAQ
---

# User settings (JSON)

## Как открыть файл пользовательских настроек в формате JSON?

`Ctrl + Shift + P` => Preferences: Open User Settings (JSON)

![Preferences: Open User Settings (JSON)](assets/user-settings.png)

## Как включить/отключить автосохранение?

```json
"files.autoSave": "onFocusChange",
```

## Как установить символ перевода строки?

```json
"files.eol": "\n",
```

## Как включить удаление конечных пробелов?

```json
"files.trimTrailingWhitespace": true,
```

## Как предотвратить удаление конечных пробелов в файлах Markdown?

```json
"[markdown]": {
    "files.trimTrailingWhitespace": false
},
```

## Как убрать подсветку жёлтой рамкой русских букв (символов Unicode)?

Добавьте локаль `ru` в список разрешенных локалей:

```json
"editor.unicodeHighlight.allowedLocales": {
    "_os": true,
    "_vscode": true,
    "ru": true
}
```

Либо добавьте конкретные символы в список `allowedCharacters`:

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

Либо просто отключите этот функционал (не рекомендуется):

```json
"editor.unicodeHighlight.ambiguousCharacters": false
```
