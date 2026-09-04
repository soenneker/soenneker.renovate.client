using Soenneker.Renovate.Client.Abstract;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Renovate.Client;

/// <inheritdoc cref="IRenovateClient" />
public sealed class RenovateClient : IRenovateClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly bool _ownsCachedClient;

    private const string _clientId = nameof(RenovateClient);

    public RenovateClient(IHttpClientCache httpClientCache) : this(httpClientCache, true)
    {
    }

    internal RenovateClient(IHttpClientCache httpClientCache, bool ownsCachedClient)
    {
        _httpClientCache = httpClientCache;
        _ownsCachedClient = ownsCachedClient;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: static lambda with no state needed
        return _httpClientCache.Get(_clientId, static () => new HttpClientOptions
        {
            UseCookieContainer = true
        }, cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        if (_ownsCachedClient)
            _httpClientCache.RemoveSync(_clientId);
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _ownsCachedClient ? _httpClientCache.Remove(_clientId) : ValueTask.CompletedTask;
    }
}
