using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Streamlabs.SocketClient.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStreamlabsClient(
        this IServiceCollection collection,
        Action<StreamlabsOptions> configureOptions
    )
    {
        collection.AddSingleton<IStreamlabsClient, StreamlabsClient>();
        collection.Configure(configureOptions);
        return collection;
    }

    public static IServiceCollection AddStreamlabsClient(
        this IServiceCollection collection,
        IConfigurationSection config
    )
    {
        collection.AddSingleton<IStreamlabsClient, StreamlabsClient>();
        collection.Configure<StreamlabsOptions>(config);
        return collection;
    }
}
