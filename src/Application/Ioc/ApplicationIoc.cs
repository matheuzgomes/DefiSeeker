using DefiSeeker.Application.Interfaces;
using DefiSeeker.Application.AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace DefiSeeker.Application;

public static class ApplicationIoc
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWalletAppService, WalletAppService>();

        return services;
    }
}