---
tags:
  - GitHub Actions
  - GitHub
  - CI/CD
  - DevOps
---

# GitHub Actions

## How to deploy a Node.js project to GitHub Pages?

There is no need to create additional branches.

- [x] Check `node-version` in `Setup Node.js`
- [x] Check `run` in `Build website`
- [x] Check `path` in `Upload artifact`

```yaml title=".github/workflows/deploy-gh-pages.yaml"
name: Deploy Node.js project

on:
  push:
    branches:
      - master

permissions:
  contents: read
  pages: write
  id-token: write

concurrency:
  group: "pages"
  cancel-in-progress: false

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v4

      - name: Setup Node.js
        uses: actions/setup-node@v3
        with:
          node-version: 18
          cache: npm
          cache-dependency-path: package-lock.json

      - name: Restore packages
        run: npm ci

      - name: Build website
        run: npm run build

      - name: Upload artifact
        uses: actions/upload-pages-artifact@v3
        with:
          path: "./build"

  deploy:
    environment:
      name: github-pages
      url: ${{ steps.deployment.outputs.page_url }}
    runs-on: ubuntu-latest
    needs: build
    steps:
      - name: Deploy to GitHub Pages
        id: deployment
        uses: actions/deploy-pages@v4
```
