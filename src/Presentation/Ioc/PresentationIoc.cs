using DefiSeeker.Presentation.Controllers;

namespace DefiSeeker.Presentation;

public static class PresentationIoc
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddOpenApiDocument(config =>
        {
            config.Title = "DefiSeeker API";
            config.Version = "v1";
            config.Description = "API for blockfrost integration";
        });
        services.AddEndpointsApiExplorer();

        return services;
    }


    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapWalletsEndpoints();

        return app;
    }
}