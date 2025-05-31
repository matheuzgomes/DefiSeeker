


using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DefiSeeker.Domain;


public static class DomainIoc
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<BlockFrostMessageHandler>();
        services.AddRefitClient<IBlockFrostApiClient>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://cardano-mainnet.blockfrost.io/api/v0");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<BlockFrostMessageHandler>();

        return services;
    }
}