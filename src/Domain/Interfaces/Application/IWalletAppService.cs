using FluentResults;
using DefiSeeker.Domain.Dto;

namespace DefiSeeker.Domain.Interfaces;

public interface IWalletAppService
{
    Task<Result<StakeAddressInfoResponse>> GetWalletByStakeAddressAsync(string stakeAddress);
    Task<Result<WalletInfoResponse>> GetWalletByAddressAsync(string address);
    Task<Result<WalletUtxoResponse>> GetAddressDetailAsync(string address);
}