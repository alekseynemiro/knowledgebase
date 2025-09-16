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

:::warning
This document has been translated using machine translation without human review.
:::

## How to restart a POD?

To restart a **POD**, you need to delete it, it will be restarted automatically:

```bash
kubectl delete pods ${POD_NAME}
```

## How to view the log of the specified POD?

```bash
kubectl logs ${POD_NAME}
```

```bash
kubectl logs ${POD_NAME} -c ${CONTAINER_NAME}
```

## How to view the list of services?

```bash
kubectl get services
```

## How to view the list of modules (PODs)?

```bash
kubectl get pods
```

## How to view the list of deployments?

```bash
kubectl get deployments
```

## How to execute a command in a container?

```bash
kubectl exec --stdin --tty ${POD_NAME} -- /bin/sh
```
