---
description: General questions about Electron application development.
tags:
  - Electron
  - FAQ
---

# General Questions

:::warning
This document has been translated using machine translation without human review.
:::

## How to enable spell checking?

```typescript
const mainWindow = new BrowserWindow({
  webPreferences: {
    // enable spell checking (enabled by default starting from Electron 9)
    spellcheck: true,
  },
});

// add required languages
mainWindow.webContents.session.setSpellCheckerLanguages(["ru-RU", "en-US"]);

// use context menu for correction suggestions
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
        label: "Add to dictionary",
        click: () => myWindow.webContents.session.addWordToSpellCheckerDictionary(params.misspelledWord)
      })
    );
  }

  menu.popup();
});
```

## How to create a new window?

:::warning
Creating new windows should be approached with caution.
In most cases, it's easier to organize work within a single window (use pages or internal modal windows).
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
