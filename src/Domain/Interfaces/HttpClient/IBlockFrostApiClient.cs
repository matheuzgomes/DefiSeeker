using Refit;
using DefiSeeker.Domain.Dto;
using Microsoft.Extensions.Logging;

namespace DefiSeeker.Domain.Interfaces.HttpClient;

public interface IBlockFrostApiClient
{
    [Get("/accounts/{stake_address}")]
    Task<IApiResponse<StakeAddressInfoResponse>> GetStakeAccountInformationAsync([AliasAs("stake_address")] string stakeAddress);

    [Get("/addresses/{address}")]
    Task<IApiResponse<WalletInfoResponse>> GetAccountInformationAsync(string address);

    [Get("/addresses/{address}/total")]
    Task<IApiResponse<WalletUtxoResponse>> GetAddressDetailAsync(string address);
}


public class BlockFrostMessageHandler(ILogger<BlockFrostMessageHandler> logger) : DelegatingHandler
{
    private readonly ILogger<BlockFrostMessageHandler> _logger = logger;
    private readonly string _projectId = Environment.GetEnvironmentVariable("BLOCKFROST_PROJECT_ID")
        ?? throw new InvalidOperationException("BLOCKFROST_PROJECT_ID environment variable is not set.");

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Project_id", _projectId);

        var response = await base.SendAsync(request, cancellationToken);

        _logger.LogInformation("Response received from BlockFrost API: {StatusCode}", response.StatusCode);

        return response;
    }
}