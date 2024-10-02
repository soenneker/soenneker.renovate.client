using Soenneker.Renovate.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Utils.HttpClientCache.Abstract;
using Soenneker.Utils.HttpClientCache.Dtos;

namespace Soenneker.Renovate.Client;

/// <inheritdoc cref="IRenovateClient"/>
public class RenovateClient: IRenovateClient
{
    private readonly IHttpClientCache _httpClientCache;

    private readonly HttpClientOptions _options = new() { UseCookieContainer = true };

    public RenovateClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(RenovateClient), _options, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(RenovateClient));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(RenovateClient));
    }
}
