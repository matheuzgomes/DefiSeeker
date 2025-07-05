using FluentResults;
using DefiSeeker.Domain.Dto;
using DefiSeeker.Domain.Interfaces;
using DefiSeeker.Domain.Interfaces.HttpClient;
using Microsoft.Extensions.Logging;
using DefiSeeker.Shared;

namespace DefiSeeker.Application.AppServices;

public sealed class WalletAppService(
    IBlockFrostApiClient blockFrostApiClient,
    ILogger<WalletAppService> logger) : IWalletAppService
{
    private readonly ILogger<WalletAppService> _logger = logger;
    private readonly IBlockFrostApiClient _blockFrostApiClient = blockFrostApiClient;

    public async Task<Result<StakeAddressInfoResponse>> GetWalletByStakeAddressAsync(string stakeAddress)
    {
        try
        {
            var result = await _blockFrostApiClient.GetStakeAccountInformationAsync(stakeAddress);

            if (RequestChecker.IsSuccessful(result))
            {
                _logger.LogInformation(
                    "Successfully fetched wallet information for stake address: {StakeAddress}",
                    stakeAddress);

                return Result.Ok(result.Content!);
            }

            _logger.LogError(
                "Failed to fetch wallet information for stake address: {StakeAddress}. Status code: {StatusCode}. Error: {Error}",
                stakeAddress,
                result.StatusCode,
                result.Error?.Message ?? "Unknown error");

            return Result.Fail("Failed to fetch wallet information");
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

    public async Task<Result<WalletInfoResponse>> GetWalletByAddressAsync(string address)
    {
        try
        {
            var result = await _blockFrostApiClient.GetAccountInformationAsync(address);


            if (RequestChecker.IsSuccessful(result))
            {
                _logger.LogInformation(
                    "Successfully fetched wallet information for address: {Address}",
                    address);

                return Result.Ok(result.Content!);
            }

            _logger.LogError(
                "Failed to fetch wallet information for address: {Address}. Status code: {StatusCode}. Error: {Error}",
                address,
                result.StatusCode,
                result.Error?.Message ?? "Unknown error");

            return Result.Fail("Failed to fetch wallet information");
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

    public async Task<Result<WalletUtxoResponse>> GetAddressDetailAsync(string address)
    {
        try
        {
            var result = await _blockFrostApiClient.GetAddressDetailAsync(address);


            if (RequestChecker.IsSuccessful(result))
            {
                _logger.LogInformation(
                    "Successfully fetched wallet information for address: {Address}",
                    address);

                return Result.Ok(result.Content!);
            }

            _logger.LogError(
                "Failed to fetch wallet details for address: {Address}. Status code: {StatusCode}. Error: {Error}",
                address,
                result.StatusCode,
                result.Error?.Message ?? "Unknown error");

            return Result.Fail("Failed to fetch wallet details");
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while fetching the account details with address: {address}",
                address);

            return Result.Fail("An error occurred while fetching the account details");
        }
    }
}