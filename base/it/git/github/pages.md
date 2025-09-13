---
tags:
  - GitHub Pages
  - GitHub
  - Step-by-Step
---

# GitHub Pages

## Как подключить собственный домен?

1. Настройте DNS на уровне DNS-хостинга:
   * Создайте запись `A`. Используйте `@` или пустую строку. Проверьте [актуальный список адресов IP](https://docs.github.com/ru/pages/configuring-a-custom-domain-for-your-github-pages-site/managing-a-custom-domain-for-your-github-pages-site#configuring-an-apex-domain).

    ```plain
    185.199.108.153
    185.199.109.153
    185.199.110.153
    185.199.111.153
    ```

    ![Пример записи 'A'](assets/dns-a-record-example.png)

    * Создайте запись `CNAME` нацеленную на `username.github.io`.

    ![Пример записи 'CNAME'](assets/dns-cname-record-example.png)

2. Откройте Settings => Pages
   * Выберите ветку.
     ![Выбор ветки](assets/github-pages-select-branch.png)
   * Добавьте `CNAME` в секцию "Custom domain" и нажмите Save.
   * Дождитесь результатов проверки.
   * Установите опцию "Enforce HTTPS", когда она станет доступной.
     ![Собственный домен](assets/github-pages-custom-domain.png)
   * Если домен недоступен в течение длительного времени (несколько часов), попробуйте удалить его из **GitHub** и настроить заново.
