---
slug: cli
tags:
  - Docker
  - Virtualization
  - CI/CD
  - DevOps
  - FAQ
---

# Docker CLI

:::warning
This document has been translated using machine translation without human review.
:::

## What is the difference between buildx and just build?

`buildx` is a command that uses **BuildKit**, a new, more powerful builder.

## How to run multiple containers?

Use [Docker Compose](docker-compose-cli).

## How to build an image?

Image parameters are specified in the [Dockerfile](dockerfile) file.

By default, the name "Dockerfile" is used.

```bash
docker build .
```

Set the image name:

```bash
docker build . --tag repo_name:image_name
```

Set launch arguments:

```bash
docker build . --build-arg ARG_1_NAME=ARG_1_VALUE --build-arg ARG_2_NAME=ARG_2_VALUE
```

Use a custom name for `Dockerfile`:

```bash
docker build -f some/path/MyDockerfile
```

Other useful parameters:

* `--progress=plain` — output the entire report;
* `--no-cache` — disable caching;
* `--rm` — remove intermediate containers after successful build;
* `-q`, `--quiet` — quiet mode, in case of success only the image identifier will be output;

## How to display the full log when creating an image?

```bash
docker build . --progress=plain
```

## How to disable cache when creating an image?

```bash
docker build . --no-cache
```

## How to manage a container (start/pause/restart/stop)?

```bash
docker run -d --name MY_CONTAINER -p 80:5080 -p 443:5443 -e ASPNETCORE_URLS="http://+:5080;https://+:5443" ${IMAGE_ID_OR_NAME}
```

* `-d`, `--detach` — run in background mode;
* `-e`, `--env` — allows setting environment variables;
* `-p`, `--publish` — redirects ports (`host_port:container_port`);
* `--name` — sets the container name;

Standard commands `start`, `pause`, `restart` and `stop` are available:

```bash
docker start ${CONTAINER_NAME_OR_ID}
```

## How to view container logs?

```bash
docker logs ${CONTAINER_NAME_OR_ID}
```

* `--details` — show extended data;
* `-n`, `--tail` — show N lines from the end of the log;

## How to delete a container?

```bash
docker rm ${CONTAINER_NAME_OR_ID}
```

* `-f`, `--force` — stop and delete, ask no questions;

## How to get a list of containers?

```bash
docker ps
```

All containers, including stopped ones:

```bash
docker ps -a
```

Recently created containers:

```bash
docker ps -l
```

Disable truncation of long lines:

```bash
docker ps --no-trunc
```

To filter the output, you can use `grep` (only on **Linux** systems):

```bash
docker ps -a | grep ${SEARCH_STRING}
```

## How to get a list of images?

```bash
docker image list --all
```

* `-a`, `--all` - all images;
* `--no-trunc` - disable truncation of long lines;

## How to view image history?

```bash
docker image history ${IMAGE_NAME_OR_ID}
```

## How to delete an image?

```bash
docker rmi ${IMAGE_NAME_OR_ID}
```

## How to get the image author's name?

```bash
docker inspect ${IMAGE_NAME_OR_ID}
```

## How to view container files?

```bash
docker create --name="${CONTAINER_NAME_OR_ID}" ${IMAGE_NAME_OR_ID}
docker export ${CONTAINER_NAME_OR_ID} | tar -t
docker rm ${CONTAINER_NAME_OR_ID}
```

## How to export a container to a file?

```bash
docker export ${CONTAINER_NAME_OR_ID} > output.tar
```

## How to execute a command in a container?

```bash
docker run --name ${CONTAINER_NAME_OR_ID} -d -i -t ${IMAGE_NAME_OR_ID} /bin/sh
```

```bash
docker exec -it ${CONTAINER_NAME_OR_ID} /bin/bash
```

```bash
docker exec -it ${CONTAINER_NAME_OR_ID} /bin/sh
```

## How to clean up resources?

```bash title="Delete unused images, containers, and networks"
docker system prune
```

```bash title="Stop and delete EVERYTHING, EVERYTHING, EVERYTHING"
docker system prune -a
```

```bash title="Delete only unused images"
docker image prune
```

```bash title="Delete only stopped containers"
docker container prune
```

```bash title="Delete only unused volumes"
docker volume prune
```

```bash title="Delete only unused networks"
docker network prune
```
