---
tags:
  - Docker
  - Dockerfile
  - Virtualization
  - CI/CD
  - DevOps
  - FAQ
---

# Dockerfile

:::warning
This document has been translated using machine translation without human review.
:::

## Basic Information

| Instruction | Description                                             |
|-------------|---------------------------------------------------------|
| `COPY`      | Copies files and directories.                           |
| `ENTRYPOINT`| Sets the default executable file.                       |
| `ENV`       | Sets an environment variable.                           |
| `EXPOSE`    | Specifies the ports that the application listens on.    |
| `FROM`      | Creates a new build stage based on a base image.        |
| `LABEL`     | Adds labels to the image.                               |
| `RUN`       | Executes a command.                                     |
| `WORKDIR`   | Sets the working directory.                             |

## Dockerfile Checklist

- [x] Use UPPERCASE for instructions
- [x] Use multiple small build stages instead of one large one
- [x] Use clear names for each stage
- [x] Combine multiple `RUN` blocks into one if possible
- [x] Use backslash (`\`) to split multi-line commands
- [x] Use `.dockerignore` to exclude unnecessary files

## How to run an ASP.NET Core application?

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

## How to build a Node.js project, pass files to an ASP.NET Core project and run it?

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

## How to set culture and encoding for an ASP.NET Core application in Dockerfile?

1. Install the `locales` and `locales-all` packages.
2. Set the `LC_ALL`, `LANG`, and `LANGUAGE` environment variables.

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
