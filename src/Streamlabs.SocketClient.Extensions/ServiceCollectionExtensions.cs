using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Streamlabs.SocketClient.Extensions;

[SuppressMessage("Minor Code Smell", "S2325:Methods and properties that don\'t access instance data should be static")]
public static class ServiceCollectionExtensions
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddStreamlabsClient(Action<StreamlabsOptions> configureOptions)
        {
            collection.AddSingleton<IStreamlabsClient, StreamlabsClient>();
            collection.Configure(configureOptions);
            return collection;
        }

        public IServiceCollection AddStreamlabsClient(IConfigurationSection config)
        {
            collection.AddSingleton<IStreamlabsClient, StreamlabsClient>();
            collection.Configure<StreamlabsOptions>(config);
            return collection;
        }
    }
}
