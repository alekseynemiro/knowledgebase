import type { SidebarsConfig } from '@docusaurus/plugin-content-docs';

// This runs in Node.js - Don't use client-side code here (browser APIs, JSX...)

/**
 * Creating a sidebar enables you to:
 - create an ordered group of docs
 - render a sidebar for each doc of that group
 - provide next/previous navigation

 The sidebars can be generated from the filesystem, or explicitly defined here.

 Create as many sidebars as you want.
 */
const sidebars: SidebarsConfig = {
  main: [
    {
      type: 'doc',
      label: 'Home',
      id: 'index',
    },
    {
      type: 'category',
      label: 'Information technology',
      collapsible: true,
      collapsed: false,
      link: {
        type: 'generated-index',
      },
      items: [
        {
          type: 'autogenerated',
          dirName: 'it',
        },
        {
          type: 'link',
          label: 'Examples',
          href: 'https://github.com/alekseynemiro/knowledgebase/tree/master/examples',
        },
      ],
    },
  ],
};

export default sidebars;
