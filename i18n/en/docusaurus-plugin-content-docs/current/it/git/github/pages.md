---
tags:
  - GitHub Pages
  - GitHub
  - Step-by-Step
---

# GitHub: Pages

:::warning
This document has been translated using machine translation without human review.
:::

## How to connect a custom domain?

1. Configure DNS at the DNS hosting level:
   * Create an `A` record. Use `@` or an empty string. Check the [current list of IP addresses](https://docs.github.com/ru/pages/configuring-a-custom-domain-for-your-github-pages-site/managing-a-custom-domain-for-your-github-pages-site#configuring-an-apex-domain).

    ```plain
    185.199.108.153
    185.199.109.153
    185.199.110.153
    185.199.111.153
    ```

    ![Example of 'A' record](assets/dns-a-record-example.png)

    * Create a `CNAME` record targeting `username.github.io`.

    ![Example of 'CNAME' record](assets/dns-cname-record-example.png)

2. Open Settings => Pages
   * Select a branch.
     ![Branch selection](assets/github-pages-select-branch.png)
   * Add `CNAME` to the "Custom domain" section and click Save.
   * Wait for the verification results.
   * Set the "Enforce HTTPS" option when it becomes available.
     ![Custom domain](assets/github-pages-custom-domain.png)
   * If the domain is unavailable for a long time (several hours), try removing it from **GitHub** and configuring it again.
