using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Renovate.Client.Registrars;

/// <summary>
/// Registers Renovate HTTP-client access.
/// </summary>
public static class RenovateClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IRenovateClient"/> and its HTTP-client cache as singleton services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddRenovateClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IRenovateClient>(provider =>
                    new RenovateClient(provider.GetRequiredService<IHttpClientCache>(), true));

        return services;
    }

    /// <summary>
    /// Adds a scoped <see cref="IRenovateClient"/> backed by a singleton HTTP-client cache.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddRenovateClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IRenovateClient>(provider =>
                    new RenovateClient(provider.GetRequiredService<IHttpClientCache>(), false));

        return services;
    }
}
