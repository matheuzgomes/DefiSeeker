using Refit;
using DefiSeeker.Domain.Dto;

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