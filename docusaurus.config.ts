import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

// This runs in Node.js - Don't use client-side code here (browser APIs, JSX...)

const config: Config = {
  title: 'Aleksey Nemiro\'s knowledge base',
  favicon: 'favicon.ico',
  url: 'https://kb.nemiro.net',
  // Set the /<baseUrl>/ pathname under which your site is served
  // For GitHub pages deployment, it is often '/<projectName>/'
  baseUrl: '/',
  organizationName: 'alekseynemiro',
  projectName: 'knowledgebase',

  onBrokenLinks: 'throw',

  markdown: {
    hooks: {
      onBrokenMarkdownImages: 'throw',
      onBrokenMarkdownLinks: 'throw',
    },
  },

  i18n: {
    defaultLocale: 'ru',
    locales: ['ru', 'en'],
  },

  plugins:  [
    [
      require.resolve('docusaurus-lunr-search'),
      {
        languages: ['ru', 'en'],
      },
    ],
    [
      require.resolve('docusaurus-plugin-yandex-metrica'),
      {
        counterID: '99756525',
      },
    ]
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
        gtag: {
          trackingID: 'G-G587X9CKF1',
          anonymizeIP: true,
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
        {
          type: 'localeDropdown',
          position: 'left',
        },
      ],
    },
    footer: {
      style: 'dark',
      copyright: `Created by human for humans and machines.<br />Copyright © 2016-2025 Aleksey Nemiro, CC BY 4.0<br /><small>Built with Docusaurus on: ${new Date().toISOString()}</small>`,
    },
    prism: {
      theme: prismThemes.github,
      darkTheme: prismThemes.dracula,
      additionalLanguages: [
        'docker',
        'csharp',
        'python',
        'javascript',
        'typescript',
        'go',
        'sql',
        'plsql',
        'css',
        'scss',
        'bash',
        'batch',
        'powershell',
        'diff',
        'git',
        'json',
        'yaml',
        'http',
      ],
    },
  } satisfies Preset.ThemeConfig,
};

export default config;
