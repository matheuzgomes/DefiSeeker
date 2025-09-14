using Asp.Versioning.Builder;
using DefiSeeker.Application.Interfaces;
using DefiSeeker.Domain.Dto;

namespace DefiSeeker.Presentation.Controllers;


public static class NetworkController
{
    public static void MapNetworkEndpoints(this WebApplication app, ApiVersionSet apiVersion)
    {
        var networkMapping = app.MapGroup("/api/v{version:apiVersion}/network")
            .WithApiVersionSet(apiVersion)
            .WithTags("Network");

        networkMapping.MapGet("", async (INetworkAppService networkAppService) =>
        {
            var result = await networkAppService.GetNetworkInformationAsync();

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetNetworkInformation")
        .Produces<NetworkInfoResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}