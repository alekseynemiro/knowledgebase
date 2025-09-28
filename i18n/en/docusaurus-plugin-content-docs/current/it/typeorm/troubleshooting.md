---
description: Troubleshooting TypeORM issues.
tags:
  - TypeORM
  - Troubleshooting
  - FAQ
---

# Problems and Solutions

:::warning
This document has been translated using machine translation without human review.
:::

## Error "Column type for TableName#ColumnName is not defined and cannot be guessed"

> ColumnTypeUndefinedError: Column type for TableName#ColumnName is not defined and cannot be guessed. Make sure you have turned on an "emitDecoratorMetadata": true option in tsconfig.json. Also make sure you have imported "reflect-metadata" on top of the main entry file in your application (before any entity imported).If you are using JavaScript instead of TypeScript you must explicitly provide a column type.

The problem may occur even if the `emitDecoratorMetadata` parameter is enabled, the `reflect-metadata` package is installed and imported, and the fields have a standard type explicitly specified.

This is because **TypeORM** cannot determine the type.

To avoid such problems, it is better to always explicitly specify the type for columns, rather than relying on type guessing magic.

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
