using FluentResults;
using DefiSeeker.Domain.Dto;

namespace DefiSeeker.Domain.Interfaces;

public interface IAccountAppService
{
    Task<Result<StakeAddressInfo>> GetStakeAccountInformationAsync(string stakeAddress);
}