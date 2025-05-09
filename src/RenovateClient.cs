using Soenneker.Renovate.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Renovate.Client;

/// <inheritdoc cref="IRenovateClient"/>
public sealed class RenovateClient : IRenovateClient
{
    private readonly IHttpClientCache _httpClientCache;

    private const string _clientId = nameof(RenovateClient);

    public RenovateClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_clientId, () => new HttpClientOptions
        {
            UseCookieContainer = true
        }, cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClientCache.RemoveSync(_clientId);
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return _httpClientCache.Remove(_clientId);
    }
}