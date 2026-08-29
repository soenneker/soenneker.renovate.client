[![](https://img.shields.io/nuget/v/soenneker.renovate.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.renovate.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.client/actions/workflows/codeql.yml)

# Soenneker.Renovate.Client

A .NET HTTP client for Mend Renovate operations.

## Install

```bash
dotnet add package Soenneker.Renovate.Client
```

## Quick start

```csharp
using Soenneker.Renovate.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddRenovateClientAsSingleton();
```

Adds `IRenovateClient` as a singleton service.

## What you get

- `IRenovateClient` — A .NET HTTP client for Mend Renovate operations.
- `RenovateClientRegistrar` — A .NET HTTP client for Mend Renovate operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `RenovateClientRegistrar.AddRenovateClientAsSingleton(services)` | Adds `IRenovateClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `RenovateClientRegistrar.AddRenovateClientAsScoped(services)` | Adds `IRenovateClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
