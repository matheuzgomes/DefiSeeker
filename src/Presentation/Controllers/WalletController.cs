using DefiSeeker.Domain.Dto;
using DefiSeeker.Application.Interfaces;


namespace DefiSeeker.Presentation.Controllers;

public static class WalletController
{
    public static void MapWalletsEndpoints(this WebApplication app)
    {
        app.MapGet("/wallets/stake/{stakeAddress}", async (string stakeAddress, IWalletAppService walletAppService) =>
        {
            var result = await walletAppService.GetStakeAccountInformationAsync(stakeAddress);

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetStakeInformation")
        .Produces<StakeAddressInfo>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        app.MapGet("/wallets/{address}", async (string address, IWalletAppService walletAppService) =>
        {
            var result = await walletAppService.GetAccountInformationAsync(address);

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetWalletInformation")
        .Produces<AccountAddressInfo>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}