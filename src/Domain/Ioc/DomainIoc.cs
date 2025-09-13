
using DefiSeeker.Domain.Handlers;
using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;
using Refit;

namespace DefiSeeker.Domain;

public static class DomainIoc
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return AddBlockFrostClient(services);
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
            .AddHttpMessageHandler<BlockFrostMessageHandler>()
            .AddStandardResilienceHandler(builder =>
            {
                builder.Retry = new HttpRetryStrategyOptions
                {
                    MaxRetryAttempts = 2,
                    Delay = TimeSpan.FromSeconds(1),
                    UseJitter = true,
                    BackoffType = DelayBackoffType.Exponential
                };

                builder.TotalRequestTimeout = new HttpTimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };
            });

        return services;
    }
}