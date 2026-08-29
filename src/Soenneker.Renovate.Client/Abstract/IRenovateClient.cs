using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Renovate.Client.Abstract;

/// <summary>
/// A .NET HTTP client for Mend Renovate operations
/// </summary>
public interface IRenovateClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Renovate Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
