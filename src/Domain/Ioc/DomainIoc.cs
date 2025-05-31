


using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DefiSeeker.Domain;


public static class DomainIoc
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddBlockFrostClient(this IServiceCollection services)
    {
        services.AddTransient<BlockFrostMessageHandler>();

        services.AddRefitClient<IBlockFrostApiClient>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(
                    Environment.GetEnvironmentVariable("BLOCKFROST_API_URL") ??
                    throw new InvalidOperationException(
                        "BLOCKFROST_API_URL environment variable is not set."));

                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<BlockFrostMessageHandler>();

        return services;
    }
}