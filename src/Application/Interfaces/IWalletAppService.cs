using FluentResults;
using DefiSeeker.Domain.Dto;

namespace DefiSeeker.Application.Interfaces;

public interface IWalletAppService
{
    Task<Result<StakeAddressInfo>> GetStakeAccountInformationAsync(string stakeAddress);
    Task<Result<AccountAddressInfo>> GetAccountInformationAsync(string address);
}