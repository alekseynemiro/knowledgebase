---
tags:
  - Docker
  - Docker Compose
  - Virtualization
  - CI/CD
  - DevOps
---

# Docker Compose CLI

Docker Compose is a tool for defining and running multi-container applications.

Docker Compose configuration is defined in a YAML file. By default, [docker-compose.yaml](docker-compose-yaml).

By default, `docker compose` commands must be run in the directory where the configuration file is located.

## How to run services?

```bash
docker compose run -d --name MY_CONTAINER -p 80:8080 -p 443:8443 -e ASPNETCORE_URLS="http://+:5080;https://+:5443"
```

* `-d`, `--detach` - background mode;
* `-e`, `--env` - set environment variables;
* `-p`, `--publish` - forward container port(s) on host (`host_port:container_port`);
* `--name` - assign container name;

## How to start/restart/stop services?

The easiest way is to use the `up` and `down` commands:

```bash
docker compose up -d
```

* `-d`, `--detach` - background mode;
* `--no-build` - don't build an image;
* `--no-recreate` - don't recreate container if it already exists;
* `--no-start` - don't start the services after creating them;
* `-w`, `--watch` - automatically restart containers when configuration changes;

```bash
docker compose down
```

* `--rmi` - remove images used by services (`all`|`local`).

It is also possible to use the standard commands: `start`, `restart`, and `stop`:

```bash
docker compose restart
```

## How to get a list of containers?

```bash
docker compose ls
```

* `-a`, `--all` - include stopped containers;
* `--format` - `table` (default) or `json`;

The `ps` command is also available:

```bash
docker compose ps --all --no-trunc
```

## How to remove service containers?

```bash
docker compose rm
```

* `-f`, `--force` - remove without confirmation;
* `-s`, `--stop` - stop before removing;
