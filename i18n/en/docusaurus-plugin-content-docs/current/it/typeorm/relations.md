---
description: Relationships in TypeORM.
tags:
  - TypeORM
  - Guide
---

# Relationships

:::warning
This document has been translated using machine translation without human review.
:::

Relationships are connections between tables that are implemented using foreign keys.  
In the case of **ORM**, these are connections between different types of objects that correspond to table relationships in the database.

## One-to-one (1:1)

The following example shows a bank account class that can have only one currency.

```typescript
import { Column, Entity, PrimaryColumn, PrimaryGeneratedColumn, JoinColumn, OneToOne } from "typeorm";

@Entity({ name: "Accounts" })
export class Account {

  // @PrimaryColumn({ name: "Id", type: "text" })
  @PrimaryGeneratedColumn("uuid", { name: "Id", type: "text" })
  public id: string;

  @Column({ name: "Name", type: "text", nullable: false })
  public name: string;

  @OneToOne(() => Currency, x => x.id)
  @JoinColumn({ name: "CurrencyId" })
  public currency: Currency;

}

@Entity({ name: "Currencies" })
export class Currency {

  @PrimaryGeneratedColumn("uuid", { name: "Id", type: "text" })
  public id: string;

  @Column({ name: "Name", type: "text", nullable: false })
  public name: string;

}
```

## One-to-many / Many-to-one (1:N / N:1)

The following example shows a user who can have multiple photos.

```typescript
import { Column, Entity, PrimaryColumn, JoinColumn, OneToMany } from "typeorm";

@Entity({ name: "Users" })
export class User {

  @PrimaryColumn({ name: "Id", type: "text" })
  public id: string;

  @Column({ name: "Name", type: "text", nullable: false })
  public name: string;

  @OneToMany(() => Photo, photo => photo.user)
  public photos?: Photo[]

}

@Entity({ name: "Photos" })
export class Photo {

  @PrimaryColumn({ name: "Id", type: "text" })
  public id: string;

  @Column({ name: "Url", type: "text", nullable: false })
  public url: string;

  @Column({ name: 'UserId', type: 'text', nullable: false })
  public userId: string

  @ManyToOne(() => User, user => user.photos, { nullable: false })
  @JoinColumn({ name: 'UserId' })
  public user: User

}
```

## Many-to-many (N:M)

The following example shows an article class that can have multiple tags.  
In turn, each tag can have multiple articles.

```typescript
import { Column, Entity, PrimaryColumn, PrimaryGeneratedColumn, JoinTable, ManyToMany } from "typeorm";

@Entity({ name: "Articles" })
export class Article {

  // @PrimaryColumn({ name: "Id", type: "integer" })
  @PrimaryGeneratedColumn("increment", { name: "Id", type: "integer" })
  public id: number;

  @Column({ name: "Title", type: "text", nullable: false })
  public title: string;

  @Column({ name: "Content", type: "text", nullable: false })
  public content: string;

  @ManyToMany(() => Tag, { cascade: true })
  @JoinTable({
    name: "ArticlesTags",
    joinColumn: {
      name: "ArticleId",
      referencedColumnName: "id",
    },
    inverseJoinColumn: {
      name: "TagId",
      referencedColumnName: "id",
    },
  })
  public tags?: Tag[];

}

@Entity({ name: "Tags" })
export class Tag {

  @PrimaryGeneratedColumn("increment", { name: "Id", type: "integer" })
  public id: number;

  @Column({ name: "Name", type: "text", nullable: false })
  public name: string;

  @ManyToMany(() => Article, article => article.tags)
  public articles?: Article[];

}
```

:::warning
In the `referencedColumnName` parameter, you must specify the **field name** in the entity class, **not the column name**.
:::
