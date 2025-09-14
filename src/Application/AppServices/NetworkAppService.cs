using DefiSeeker.Application.Interfaces;
using DefiSeeker.Domain.Dto;
using DefiSeeker.Infastructure.HttpClient;
using DefiSeeker.Shared;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace DefiSeeker.Application.AppServices;

public sealed class NetworkAppService(
    IBlockFrostApiClient blockFrostApiClient,
    ILogger<NetworkAppService> logger) : INetworkAppService
{
    private readonly IBlockFrostApiClient _blockFrostApiClient = blockFrostApiClient;
    private readonly ILogger<NetworkAppService> _logger = logger;

    public async Task<Result<NetworkInfoResponse>> GetNetworkInformationAsync()
    {
        try
        {
            var result = await _blockFrostApiClient.GetNetworkInformationAsync();

            if (result.IsFailed())
            {
                _logger.LogError(
                    "Failed to fetch network information. Status code: {StatusCode}. Error: {Error}",
                    result.StatusCode,
                    result.Error?.Message ?? "Unknown error");

                return Result.Fail("Failed to fetch network information");
            }

            _logger.LogInformation("Successfully fetched network information");

            return Result.Ok(NetworkInfoResponse.Build(result.Content!));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the network information");

            return Result.Fail("An error occurred while fetching the network information");
        }
    }
}
