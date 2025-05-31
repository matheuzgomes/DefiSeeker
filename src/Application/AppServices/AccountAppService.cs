using FluentResults;
using DefiSeeker.Domain.Entities;
using DefiSeeker.Domain.Interfaces;
using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.Logging;

namespace DefiSeeker.Application.AppServices;

public sealed class AccountAppService(
    IBlockFrostApiClient blockFrostApiClient,
    ILogger<AccountAppService> logger) : IAccountAppService
{
    private readonly ILogger<AccountAppService> _logger = logger;
    private readonly IBlockFrostApiClient _blockFrostApiClient = blockFrostApiClient;

    public async Task<Result<SpecificAccount>> GetSpecificAccountAsync(string stakeAddress)
    {
        try
        {
            var result = await _blockFrostApiClient.GetSpecificAccountAsync(stakeAddress);

            if (result is null)
            {
                return Result.Fail("Account not found");
            }

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while fetching the account with stake address: {StakeAddress}",
                stakeAddress);

            return Result.Fail("An error occurred while fetching the account");
        }
    }
}