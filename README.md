[![](https://img.shields.io/nuget/v/soenneker.renovate.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.renovate.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.renovate.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.client/build-and-test.yml?label=build%20and%20test&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.client/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.renovate.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.renovate.client/actions/workflows/codeql.yml)

# Soenneker.Renovate.Client

Provides a cached, cookie-enabled `HttpClient` for Renovate automation.

## Installation and registration

```bash
dotnet add package Soenneker.Renovate.Client
```

```csharp
using Soenneker.Renovate.Client.Registrars;

services.AddRenovateClientAsScoped();
```

The scoped wrapper uses a singleton HTTP-client cache. Disposing a scope destroys the wrapper but deliberately keeps the shared `HttpClient` and its cookie container alive for later scopes. `AddRenovateClientAsSingleton()` is also available.

## Use

```csharp
using Soenneker.Renovate.Client.Abstract;

HttpClient client = await renovateClient.Get(cancellationToken);

using var request = new HttpRequestMessage(
    HttpMethod.Get,
    "https://developer.mend.io/api/example");

request.Headers.Authorization =
    new AuthenticationHeaderValue("Bearer", token);

using HttpResponseMessage response =
    await client.SendAsync(request, cancellationToken);

response.EnsureSuccessStatusCode();
```

The package does not set a base address, authentication, default headers, or an API-specific contract. Use absolute request URIs and configure each request with the credentials required by the endpoint. Do not dispose the returned `HttpClient`; its cache owns it.
