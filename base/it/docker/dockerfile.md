---
tags:
  - Docker
  - Dockerfile
  - Virtualization
  - CI/CD
  - DevOps
---

# Dockerfile

## Basic instructions

| Instruction  | Description                                     |
|--------------|-------------------------------------------------|
| `COPY`       | Copy files and directories.                     |
| `ENTRYPOINT` | Specify default executable.                     |
| `ENV`        | Set environment variables.                      |
| `EXPOSE`     | Set the ports on which the application listens. |
| `FROM`       | Create a new build stage from a base image.     |
| `LABEL`      | Add metadata to an image.                       |
| `RUN`        | Execute build commands.                         |
| `WORKDIR`    | Set working directory.                          |

## Checklist for Dockerfile

- [x] Use UPPERCASE for instructions
- [x] Use multiple small build stages instead of one large one
- [x] Use clear names for each stage
- [x] Combine multiple `RUN` blocks into one if possible
- [x] Use slash (`\`) to split multiline commands
- [x] Use `.dockerignore` to exclude unnecessary files

## How to run ASP.NET application?

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

## How to build a separate Node.js and ASP.NET projects?

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
