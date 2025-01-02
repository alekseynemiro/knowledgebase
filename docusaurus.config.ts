import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

// This runs in Node.js - Don't use client-side code here (browser APIs, JSX...)

const config: Config = {
  title: 'Aleksey Nemiro\'s knowledge base',
  favicon: 'img/favicon.ico',
  url: 'https://knowledgebase.nemiro.net',
  // Set the /<baseUrl>/ pathname under which your site is served
  // For GitHub pages deployment, it is often '/<projectName>/'
  baseUrl: '/',
  organizationName: 'alekseynemiro',
  projectName: 'knowledgebase',

  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',

  i18n: {
    defaultLocale: 'en',
    locales: ['en'],
  },

  plugins:  [
    [
      require.resolve('docusaurus-lunr-search'),
      {
        languages: ['en', 'ru'],
      },
    ],
  ],

  presets: [
    [
      'classic',
      {
        docs: {
          path: './base',
          sidebarPath: './sidebars.ts',
          routeBasePath: '/',
          // editUrl: 'https://github.com/alekseynemiro/knowledgebase/tree/master',
        },
        theme: {
          customCss: './styles.css',
        },
      } satisfies Preset.Options,
    ],
  ],

  themeConfig: {
    // Replace with your project's social card
    image: 'img/docusaurus-social-card.jpg',
    navbar: {
      title: 'ANKB',
      logo: {
        alt: 'Aleksey Nemiro\'s knowledge base',
        src: 'img/logo.svg',
      },
      items: [
        {
          href: 'https://github.com/alekseynemiro/knowledgebase',
          label: 'GitHub',
          position: 'right',
        },
        /* TODO: localization
        {
          type: 'localeDropdown',
          position: 'left',
        },*/
      ],
    },
    footer: {
      style: 'dark',
      copyright: `Copyright © 2016-2025 Aleksey Nemiro. Built with Docusaurus.`,
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
    },
  } satisfies Preset.ThemeConfig,
};

export default config;