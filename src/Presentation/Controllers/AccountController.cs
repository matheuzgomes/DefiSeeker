using DefiSeeker.Domain.Entities;
using DefiSeeker.Domain.Interfaces;


namespace DefiSeeker.Presentation.Controllers;

public static class AccountController
{
    public static void MapAccountsEndpoints(this WebApplication app)
    {
        app.MapGet("/accounts/{stakeAddress}", async (string stakeAddress, IAccountAppService accountAppService) =>
        {
            var result = await accountAppService.GetSpecificAccountAsync(stakeAddress);

            if (result.IsFailed)
            {
                return Results.BadRequest(result.Errors);
            }

            return Results.Ok(result.Value);
        })
        .WithName("GetAccount")
        .Produces<SpecificAccount>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}