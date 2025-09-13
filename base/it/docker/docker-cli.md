---
slug: cli
tags:
  - Docker
  - Virtualization
  - CI/CD
  - DevOps
  - FAQ
  - Виртуализация
  - Развертывание
  - Автоматизация
---

# Docker CLI

## В чем разница между buildx и просто build?

`buildx` — это команда, которая использует **BuildKit**, новый, более мощный конструктор.

## Как запустить несколько контейнеров?

Используйте [Docker Compose](docker-compose-cli).

## Как собрать образ?

Параметры образа задаются в файле [Dockerfile](dockerfile).

По умолчанию используется имя «Dockerfile».

```bash
docker build .
```

Задать имя образа:

```bash
docker build . --tag repo_name:image_name
```

Задать аргументы запуска:

```bash
docker build . --build-arg ARG_1_NAME=ARG_1_VALUE --build-arg ARG_2_NAME=ARG_2_VALUE
```

Использовать собственное имя для `Dockerfile`:

```bash
docker build -f some/path/MyDockerfile
```

Другие полезные параметры:

* `--progress=plain` — выводить весь отчёт;
* `--no-cache` — отключить кэширование;
* `--rm` — удалить промежуточные контейнеры после успешной сборки;
* `-q`, `--quiet` — тихий режим, в случае успеха на выходе будет только идентификатор образа;

## Как отобразить полный журнал при создании образа?

```bash
docker build . --progress=plain
```

## Как отключить кэш при создании образа?

```bash
docker build . --no-cache
```

## Как управлять контейнером (запускать/приостанавливать/перезапускать/останавливать)?

```bash
docker run -d --name MY_CONTAINER -p 80:5080 -p 443:5443 -e ASPNETCORE_URLS="http://+:5080;https://+:5443" ${IMAGE_ID_OR_NAME}
```

* `-d`, `--detach` — запуск в фоновом режиме;
* `-e`, `--env` — позволяет установить переменные окружения;
* `-p`, `--publish` — перенаправляет порты (`host_port:container_port`);
* `--name` — задаёт имя контейнера;

Доступны типовые команды `start`, `pause`, `restart` и `stop`:

```bash
docker start ${CONTAINER_NAME_OR_ID}
```

## Как посмотреть логи контейнера?

```bash
docker logs ${CONTAINER_NAME_OR_ID}
```

* `--details` — показать расширенные данные;
* `-n`, `--tail` — показать N строк с конца журнала;

## Как удалить контейнер?

```bash
docker rm ${CONTAINER_NAME_OR_ID}
```

* `-f`, `--force` — остановить и удалить, не задавать никаких вопросов;

## Как получить список контейнеров?

```bash
docker ps
```

Все контейнеры, включая остановленные:

```bash
docker ps -a
```

Недавно созданные контейнеры:

```bash
docker ps -l
```

Запретить обрезание длинных строк:

```bash
docker ps --no-trunc
```

Для фильтрации вывода можно использовать `grep` (только в системах **Linux**):

```bash
docker ps -a | grep ${SEARCH_STRING}
```

## Как получить список образов?

```bash
docker image list --all
```

* `-a`, `--all` - все образы;
* `--no-trunc` - отключить обрезание длинных строк;

## Как посмотреть историю образа?

```bash
docker image history ${IMAGE_NAME_OR_ID}
```

## Как удалить образ?

```bash
docker rmi ${IMAGE_NAME_OR_ID}
```

## Как получить имя автора образа?

```bash
docker inspect ${IMAGE_NAME_OR_ID}
```

## Как посмотреть файлы контейнера?

```bash
docker create --name="${CONTAINER_NAME_OR_ID}" ${IMAGE_NAME_OR_ID}
docker export ${CONTAINER_NAME_OR_ID} | tar -t
docker rm ${CONTAINER_NAME_OR_ID}
```

## Как экспортировать контейнер в файл?

```bash
docker export ${CONTAINER_NAME_OR_ID} > output.tar
```

## Как выполнить команду в контейнере?

```bash
docker run --name ${CONTAINER_NAME_OR_ID} -d -i -t ${IMAGE_NAME_OR_ID} /bin/sh
```

```bash
docker exec -it ${CONTAINER_NAME_OR_ID} /bin/bash
```

```bash
docker exec -it ${CONTAINER_NAME_OR_ID} /bin/sh
```

## Как очистить ресурсы?

```bash title="Удалить неиспользуемые образы, контейнеры и сети"
docker system prune
```

```bash title="Остановить и удалите ВСЁ, ВСЁ, ВСЁ"
docker system prune -a
```

```bash title="Удалить только неиспользуемые образы"
docker image prune
```

```bash title="Удалить только остановленные контейнеры"
docker container prune
```

```bash title="Удалить только неиспользуемые тома"
docker volume prune
```

```bash title="Удалить только неиспользуемые сети"
docker network prune
```
