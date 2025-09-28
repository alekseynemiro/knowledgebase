---
description: Отношения в TypeORM.
tags:
  - TypeORM
  - Guide
---

# Отношения

Отношения — это связи между таблицами, которые реализуются за счёт использования внешних ключей.  
В случае с **ORM**, это связи между различными типами объектов, которые соответствуют связям таблиц в базе данных.

## Один к одному (one-to-one, 1:1)

В следующем примере показан класс банковского счёта, у которого может быть только одна валюта.

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

## Один ко многим / Многие к одному (one-to-many / many-to-one, 1:N / N:1)

В следующем примере показан пользователь, у которого может быть множество фотографий.

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

## Многие ко многим (many-to-many, N:M)

В следующем примере показана класс-статья, в которой может быть множество тегов.  
В свою очередь, у каждого тега может быть множество статей.

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
В параметре `referencedColumnName` необходимо указывать **имя поля** в классе-сущности, а **не имя колонки**.
:::
