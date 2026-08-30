using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Renovate.Client.Abstract;

/// <summary>
/// Provides access to a cached, cookie-enabled HTTP client for Renovate automation.
/// </summary>
public interface IRenovateClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared HTTP client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached HTTP client. Callers must not dispose it.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
