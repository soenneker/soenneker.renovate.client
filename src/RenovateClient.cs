using Soenneker.Renovate.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Renovate.Client;

/// <inheritdoc cref="IRenovateClient"/>
public class RenovateClient: IRenovateClient
{
    private readonly IHttpClientCache _httpClientCache;

    public RenovateClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get()
    {
        return _httpClientCache.Get(nameof(RenovateClient), null, true);
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
