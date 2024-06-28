using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Renovate.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Renovate.Client.Registrars;

/// <summary>
/// A .NET HTTP client for Mend Renovate operations
/// </summary>
public static class RenovateClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IRenovateClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddRenovateClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<IRenovateClient, RenovateClient>();
    }

    /// <summary>
    /// Adds <see cref="IRenovateClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddRenovateClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<IRenovateClient, RenovateClient>();
    }
}
