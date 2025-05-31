using FluentResults;
using DefiSeeker.Domain.Dto;
using DefiSeeker.Application.Interfaces;
using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.Logging;

namespace DefiSeeker.Application.AppServices;

public sealed class WalletAppService(
    IBlockFrostApiClient blockFrostApiClient,
    ILogger<WalletAppService> logger) : IWalletAppService
{
    private readonly ILogger<WalletAppService> _logger = logger;
    private readonly IBlockFrostApiClient _blockFrostApiClient = blockFrostApiClient;

    public async Task<Result<StakeAddressInfo>> GetStakeAccountInformationAsync(string stakeAddress)
    {
        try
        {
            var result = await _blockFrostApiClient.GetStakeAccountInformationAsync(stakeAddress);

            if (result is null)
            {
                _logger.LogWarning(
                    "No account found for the provided stake address: {StakeAddress}",
                    stakeAddress);

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

    public async Task<Result<AccountAddressInfo>> GetAccountInformationAsync(string address)
    {
        try
        {
            var result = await _blockFrostApiClient.GetAccountInformationAsync(address);

            if (result is null)
            {
                _logger.LogWarning(
                    "No account found for the provided address: {address}",
                    address);

                return Result.Fail("Account not found");
            }

            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while fetching the account with address: {address}",
                address);

            return Result.Fail("An error occurred while fetching the account");
        }
    }
}