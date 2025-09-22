---
description: Общие вопросы по разработке приложений Electron.
tags:
  - Electron
  - FAQ
---

# Общие вопросы

## Как включить проверку орфографии?

```typescript
const mainWindow = new BrowserWindow({
  webPreferences: {
    // включаем проверку (начиная с Electron 9 включено по умолчанию)
    spellcheck: true,
  },
});

// добавляем нужные языки
mainWindow.webContents.session.setSpellCheckerLanguages(["ru-RU", "en-US"]);

// используем контекстное меню для предложения вариантов исправления
myWindow.webContents.on("context-menu", (event, params) => {
  const menu = new Menu()

  for (const suggestion of params.dictionarySuggestions) {
    menu.append(new MenuItem({
      label: suggestion,
      click: () => myWindow.webContents.replaceMisspelling(suggestion)
    }));
  }

  if (params.misspelledWord) {
    menu.append(
      new MenuItem({
        label: "Добавить в словарь",
        click: () => myWindow.webContents.session.addWordToSpellCheckerDictionary(params.misspelledWord)
      })
    );
  }

  menu.popup();
});
```

## Как создать новое окно?

:::warning
К созданию новых окон следует подходить осторожно.
В большинстве случаев проще организовать работу в рамках одного окна (использовать страницы, или внутренние модальные окна).
:::

```typescript
import { app, BrowserWindow } from "electron";
import { join } from "path";

function createWindow () {
  const newWindow = new BrowserWindow({
    width: 800,
    height: 600,
    resizable: false,
    autoHideMenuBar: true,
    // menuBarVisible: false,
    // fullScreen: true,
    // fullScreenable: false,
    // minimizable: false,
    // maximizable: false,
    // closable: false,
    // movable: false,
    // focusable: true,
    // shadow: true,
    // excludedFromShownWindowsMenu: true,
    // title: "Hello, world!",
  });

  // newWindow.show();

  newWindow.loadFile(join(__dirname, "../renderer/index.html"));
}
```
