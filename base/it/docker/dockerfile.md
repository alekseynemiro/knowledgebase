---
tags:
  - Docker
  - Dockerfile
  - Virtualization
  - CI/CD
  - DevOps
  - FAQ
  - Виртуализация
  - Развертывание
  - Автоматизация
---

# Dockerfile

## Базовая информация

| Инструкция   | Описание                                              |
|--------------|-------------------------------------------------------|
| `COPY`       | Копирует файлы и директории.                          |
| `ENTRYPOINT` | Задаёт исполняемый файл по умолчанию.                 |
| `ENV`        | Задаёт переменную окружения.                          |
| `EXPOSE`     | Задаёт порты, которые прослушивает приложение.        |
| `FROM`       | Создаёт новый этап сборки на основе базового образа.  |
| `LABEL`      | Добавляет метки к образу.                             |
| `RUN`        | Выполняет команду.                                    |
| `WORKDIR`    | Задаёт рабочую директорию.                            |

## Список проверки для Dockerfile

- [x] Используйте ВЕРХНИЙ регистр для инструкций
- [x] Используйте несколько небольших этапов сборки вместо одного большого
- [x] Используйте понятные названия для каждого этапа
- [x] Объединяйте несколько блоков `RUN` в один, если это возможно
- [x] Для разделения многострочных команд используйте слэш (`\`)
- [x] Используйте `.dockerignore` для исключения ненужных файлов

## Как запустить приложение ASP.NET Core?

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
LABEL project="My ASP.NET project" \
      version="1.0"
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS build
WORKDIR /src

COPY ["nuget.config", "."]
COPY ["MyAspNetProject/MyAspNetProject.csproj", "MyAspNetProject/"]

RUN dotnet restore

COPY . .
WORKDIR "/src/MyAspNetProject"

RUN dotnet build "MyAspNetProject.csproj" \
    --configuration Release \
    --output "/app/build"

FROM build AS publish
ARG VERSION
RUN dotnet publish "MyAspNetProject.csproj" --configuration Release \
    --output "/app/publish" \
    --property:Version=$(VERSION)

FROM base AS final
ENV ASPNETCORE_URLS="http://+:8081"
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyAspNetProject.dll"]
```

## Как выполнить сборку проекта Node.js, передать файлы в проект ASP.NET Core и запустить его?

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8081

FROM node:20 AS npm-build
WORKDIR /build
COPY ["MyFrontendProject/src", "."]
RUN npm ci && npm run build

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS publish
ARG VERSION
WORKDIR /src
COPY . .
COPY --from=npm-build "/build/dist" "./MyAspNetProject/wwwroot/js"
RUN dotnet restore "MyAspNetProject/MyAspNetProject.csproj"
RUN dotnet publish "MyAspNetProject.csproj" \
    --configuration Release \
    --output "/app/publish" \
    --property:Version=$(VERSION)

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyAspNetProject.dll"]
```

## Как установить культуру и кодировку для приложения ASP.NET Core в Dockerfile?

1. Установите пакеты `locales` и `locales-all`.
2. Установите переменные окружения `LC_ALL`, `LANG` и `LANGUAGE`.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:11.0 AS base
LABEL project="My ASP.NET project" \
      version="1.0"
WORKDIR /app
EXPOSE 8081

RUN apt-get update && \
    apt-get install -y locales locales-all

FROM mcr.microsoft.com/dotnet/aspnet:11.0 AS build
WORKDIR /src

COPY ["nuget.config", "."]
COPY ["MyAspNetProject/MyAspNetProject.csproj", "MyAspNetProject/"]

RUN dotnet restore

COPY . .
WORKDIR "/src/MyAspNetProject"

RUN dotnet build "MyAspNetProject.csproj" \
    --configuration Release \
    --output "/app/build"

FROM build AS publish
ARG VERSION
RUN dotnet publish "MyAspNetProject.csproj" --configuration Release \
    --output "/app/publish" \
    --property:Version=$(VERSION)

FROM base AS final
ENV ENV LC_ALL=ru_RU.UTF-8 \
        LANG=ru_RU.UTF-8 \
        LANGUAGE=ru_RU.UTF-8 \
        ASPNETCORE_URLS="http://+:8081"
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyAspNetProject.dll"]
```
