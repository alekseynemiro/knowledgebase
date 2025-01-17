---
slug: cli
tags:
  - Docker
---

# Docker CLI

## What is the difference between buildx and just build?

`buildx` is a command that uses **BuildKit**, a new, more powerful builder.

## How to run multiple containers?

Use [Docker Compose](docker-compose-cli).

## How to build an image?

Image parameters are defined in the [Dockerfile](dockerfile).

The "Dockerfile" name is used by default.

By default, the Dockerfile from the current working directory will be used.

```bash
docker build .
```

Set image name:

```bash
docker build . --tag repo_name:image_name
```

Set build time variables:

```bash
docker build . --build-arg ARG_1_NAME=ARG_1_VALUE --build-arg ARG_2_NAME=ARG_2_VALUE
```

Custom name of Dockerfile:

```bash
docker build -f some/path/MyDockerfile
```

Other useful options:

* `--progress=plain` - output full log;
* `--no-cache` - disable cache;
* `--rm` -- remove intermediate containers after a successful build;
* `-q`, `--quiet` - quiet mode, if successful the output will be the image identifier;

## How to display full log when building image?

```bash
docker build . --progress=plain
```

## How to disable cache when building an image?

```bash
docker build . --no-cache
```

## How to manage (start/pause/restart/stop) a container?

```bash
docker run -d --name MY_CONTAINER -p 80:5080 -p 443:5443 -e ASPNETCORE_URLS="http://+:5080;https://+:5443" %IMAGE_ID_OR_NAME%
```

* `-d`, `--detach` - background mode;
* `-e`, `--env` - set environment variables;
* `-p`, `--publish` - forward container port(s) on host (`host_port:container_port`);
* `--name` - assign container name;

To `start`, `pause`, `restart`, and `stop` of the container there are commands with the same name:

```bash
docker start %CONTAINER_NAME_OR_ID%
```

## How to view container logs?

```bash
docker logs %CONTAINER_NAME_OR_ID%
```

* `--details` - show extra data;
* `-n`, `--tail` - show number of lines from end of log;

## How to remove a container?

```bash
docker rm %CONTAINER_NAME_OR_ID%
```

* `-f`, `--force` - stop and remove;

## How to get a list of containers?

```bash
docker ps
```

All containers:

```bash
docker ps -a
```

Latest created containers:

```bash
docker ps -l
```

Without truncation of long strings:

```bash
docker ps --no-trunc
```

It is possible to use `grep` to filter the output:

```bash
docker ps -a | grep %SEARCH_STRING%
```

## How to get a list of images?

```bash
docker image list --all
```

* `-a`, `--all` - show all images;
* `--no-trunc` - without truncation of long strings;

## How to view image history?

```bash
docker image history %IMAGE_NAME_OR_ID%
```

## How to remove an image?

```bash
docker rmi %image_id%
```

## How to view the creator of the image?

```bash
docker inspect %IMAGE_NAME_OR_ID%
```

## How to view a container files?

```bash
docker create --name="%CONTAINER_NAME_OR_ID%" %IMAGE_NAME_OR_ID%
docker export %CONTAINER_NAME_OR_ID% | tar -t
docker rm %CONTAINER_NAME_OR_ID%
```

## How to export a container to a file?

```bash
docker export %CONTAINER_NAME_OR_ID% > output.tar
```

## How to execute a command in a container?

```bash
docker run --name %CONTAINER_NAME_OR_ID% -d -i -t %IMAGE_NAME_OR_ID% /bin/sh
```

```bash
docker exec -it %CONTAINER_NAME_OR_ID% /bin/bash
```

```bash
docker exec -it %CONTAINER_NAME_OR_ID% /bin/sh
```

## How to clear resources?

```bash title="Remove unused images, containers, and networks"
docker system prune
```

```bash title="Stop and remove ALL, ALL, ALL"
docker system prune -a
```

```bash title="Remove only unused images"
docker image prune
```

```bash title="Remove only stopped containers"
docker container prune
```

```bash title="Remove only unused volumes"
docker volume prune
```

```bash title="Remove only unused networks"
docker network prune
```
