---
slug: cli
description: Kubernetes command-line interface.
tags:
  - Kubernetes
  - CI/CD
  - DevOps
  - Развертывание
  - Автоматизация
---

# Kubernetes CLI

## Как перезапустить POD?

Для перезапуска **POD** его необходимо удалить, он будет перезапущен автоматически:

```bash
kubectl delete pods ${POD_NAME}
```

## Как посмотреть журнал указанного POD?

```bash
kubectl logs ${POD_NAME}
```

```bash
kubectl logs ${POD_NAME} -c ${CONTAINER_NAME}
```

## Как посмотреть список сервисов?

```bash
kubectl get services
```

## Как посмотреть список модулей (PODs)?

```bash
kubectl get pods
```

## Как посмотреть список развертываний?

```bash
kubectl get deployments
```

## Как выполнить команду в контейнере?

```bash
kubectl exec --stdin --tty ${POD_NAME} -- /bin/sh
```
