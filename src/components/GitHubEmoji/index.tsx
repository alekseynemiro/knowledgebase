import React, { type ReactNode } from 'react';
import * as emoji from './emoji.json';
import './styles.css';

export default function GitHubEmoji(): ReactNode {
  return (
    <div className="row">
      {
        Object.keys(emoji).map(
          x => {
            return (
              <div key={x} className="col col--2 margin-bottom--md github-emoji-col">
                <img src={emoji[x]} alt={x} />
                <span>
                  :{x}:
                </span>
              </div>
            );
          }
        )
      }

    </div>
  );
}
