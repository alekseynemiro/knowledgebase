---
tags:
  - Docker
  - Docker Compose
  - Virtualization
  - CI/CD
  - DevOps
  - Виртуализация
  - Развертывание
  - Автоматизация
---

# docker-compose.yaml

```yaml
version: '3.7'

networks:
  default:
    driver: bridge

services:
  some-service-name:
    container_name: some-container-name
    dockerfile: /path/to/Dockerfile
    deploy:
      resources:
        memory: 2048M
    ports:
      - "8080:80"
    environment:
      - DOTNET_ENVIRONMENT: Developing
    restart: always
    volumes:
      - type: bind
        source: /some/path
        target: /app/some/target/path
        read_only: true
    networks:
      - default
  nginx-service:
    container_name: some-nginx-container-name
    image: nginx:latest
    volumes:
      - ./nginx.conf:/etc/nginx/nginx.conf
    ports:
      - "8083:443"
    restart: always
    networks:
      - default
```
