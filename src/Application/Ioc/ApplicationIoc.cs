using DefiSeeker.Application.AppServices;
using Microsoft.Extensions.DependencyInjection;
using DefiSeeker.Application.Interfaces;

namespace DefiSeeker.Application;

public static class ApplicationIoc
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWalletAppService, WalletAppService>();
        services.AddScoped<INetworkAppService, NetworkAppService>();

        return services;
    }
}