using DefiSeeker.Domain.Dto;
using Asp.Versioning.Builder;
using DefiSeeker.Application.Interfaces;

namespace DefiSeeker.Presentation.Controllers;

public static class WalletController
{
    public static void MapWalletsEndpoints(this WebApplication app, ApiVersionSet apiVersion)
    {
        var walletMapping = app.MapGroup("/api/v{version:apiVersion}/wallets")
            .WithApiVersionSet(apiVersion)
            .WithTags("Wallets");

        walletMapping.MapGet("stake/{stakeAddress}", async (string stakeAddress, IWalletAppService walletAppService) =>
        {
            var result = await walletAppService.GetWalletByStakeAddressAsync(stakeAddress);

            if (result.IsFailed)
            {
                var errorMessage = result.Errors.FirstOrDefault()?.Message ?? "Unknown error";

                if (errorMessage.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return Results.NotFound(errorMessage);

                return Results.BadRequest(errorMessage);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetStakeInformation")
        .Produces<StakeAddressInfoResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound);

        walletMapping.MapGet("{address}", async (string address, IWalletAppService walletAppService) =>
        {
            var result = await walletAppService.GetWalletByAddressAsync(address);

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetWalletInformation")
        .Produces<WalletInfoResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        walletMapping.MapGet("{address}/utxo", async (string address, IWalletAppService walletAppService) =>
        {
            var result = await walletAppService.GetAddressDetailAsync(address);

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetWalletDetail")
        .Produces<WalletUtxoResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}