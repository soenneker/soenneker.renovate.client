using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Renovate.Client.Registrars;

/// <summary>
/// A .NET HTTP client for Mend Renovate operations
/// </summary>
public static class RenovateClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IRenovateClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRenovateClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IRenovateClient, RenovateClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IRenovateClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRenovateClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IRenovateClient, RenovateClient>();

        return services;
    }
}