---
slug: cli
title: Kubernetes CLI
description: Kubernetes command-line interface
tags:
  - Kubernetes
  - CI/CD
  - DevOps
---

# Kubernetes CLI

## How to restart Pod?

You need to delete the POD and it will be automatically created again:

```bash
kubectl delete pods ${POD_NAME}
```

## How to view pod logs?

```bash
kubectl logs ${POD_NAME}
```

```bash
kubectl logs ${POD_NAME} -c ${CONTAINER_NAME}
```

## How to display a list of services?

```bash
kubectl get services
```

## How to display a list of pods?

```bash
kubectl get pods
```

## How to display a list of deployments?

```bash
kubectl get deployments
```

## How to execute a command in a container?

```bash
kubectl exec --stdin --tty ${POD_NAME} -- /bin/sh
```
