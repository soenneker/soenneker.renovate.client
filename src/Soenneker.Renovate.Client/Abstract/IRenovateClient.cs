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
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}