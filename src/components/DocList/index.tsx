import React, { type ReactNode } from 'react';
import clsx from 'clsx';
import {
  useCurrentSidebarCategory,
  filterDocCardListItems,
  findFirstSidebarItemLink,
} from '@docusaurus/plugin-content-docs/client';
import type { Props } from '@theme/DocCardList';

function DocListForCurrentSidebarCategory({className}: Props) {
  const category = useCurrentSidebarCategory();

  return (
    <DocList items={category.items} className={className} />
  );
}

export default function DocList(props: Props): ReactNode {
  const { items, className } = props;

  if (!items) {
    return (
      <DocListForCurrentSidebarCategory {...props} />
    );
  }

  const filteredItems = filterDocCardListItems(items);

  return (
    <ul className={clsx(className)}>
      {
        filteredItems.map((item, index) => {
          const href = findFirstSidebarItemLink(item);

          return (
            <li key={index}>
              <a href={href}>
                {(item as any).label}
              </a>
            </li>
          );
        })
      }
    </ul>
  );
}
