---
tags:
  - Docker
  - Docker Compose
  - Virtualization
  - CI/CD
  - DevOps
  - FAQ
---

# Docker Compose CLI

:::warning
This document has been translated using machine translation without human review.
:::

**Docker Compose** is a tool for running multi-container applications.

**Docker Compose** configuration is defined in a **YAML** file. By default — [docker-compose.yaml](docker-compose-yaml).

By default, `docker compose` commands should be run in the directory where the configuration file is located.

## How to start a container?

```bash
docker compose run -d --name MY_CONTAINER -p 80:8080 -p 443:8443 -e ASPNETCORE_URLS="http://+:5080;https://+:5443"
```

* `-d`, `--detach` — background mode;
* `-e`, `--env` — allows setting environment variables;
* `-p`, `--publish` — forwards ports (`host_port:container_port`);
* `--name` — sets the container name;

## How to start/restart/stop container services?

The easiest way is to use the `up` and `down` commands:

```bash
docker compose up -d
```

* `-d`, `--detach` — background mode;
* `--no-build` — prohibits image creation;
* `--no-recreate` — prohibits container recreation if it already exists;
* `--no-start` - prohibits starting services after creation;
* `-w`, `--watch` - allows automatic container restart when configuration changes;

```bash
docker compose down
```

* `--rmi` — remove images used by services (`all`|`local`).

You can also use standard commands: `start`, `restart` and `stop`:

```bash
docker compose restart
```

## How to get a list of containers?

```bash
docker compose ls
```

* `-a`, `--all` — include stopped containers;
* `--format` — `table` (default) or `json`;

The standard `ps` command is also available:

```bash
docker compose ps --all --no-trunc
```

## How to remove containers?

```bash
docker compose rm
```

* `-f`, `--force` — remove without additional questions;
* `-s`, `--stop` — stop before removal.
