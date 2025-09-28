---
description: Решение проблем с TypeORM.
tags:
  - TypeORM
  - Troubleshooting
  - FAQ
---

# Проблемы и решения

## Ошибка "Column type for TableName#ColumnName is not defined and cannot be guessed"

> ColumnTypeUndefinedError: Column type for TableName#ColumnName is not defined and cannot be guessed. Make sure you have turned on an "emitDecoratorMetadata": true option in tsconfig.json. Also make sure you have imported "reflect-metadata" on top of the main entry file in your application (before any entity imported).If you are using JavaScript instead of TypeScript you must explicitly provide a column type.

Проблема может проявляться даже если включен параметр `emitDecoratorMetadata`, установлен и импортирован пакет `reflect-metadata`, и у полей явно указан стандартный тип.

Это связано с тем, что **TypeORM** не может определить тип.

Чтобы подобных проблем не было, лучше всегда явно указывать тип для колонок, а не надеяться на магию угадывания типов.

```diff
@Entity({ name: 'Users' })
export class User {
- @PrimaryColumn({ name: 'Id' })
+ @PrimaryColumn({ name: 'Id', type: 'text' })
  public id: string

- @Column({ name: 'Name', nullable: false })
+ @Column({ name: 'Name', type: 'text', nullable: false })
  public name: string
}
```
