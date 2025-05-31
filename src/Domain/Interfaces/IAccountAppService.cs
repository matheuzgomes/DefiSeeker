using FluentResults;
using DefiSeeker.Domain.Entities;

namespace DefiSeeker.Domain.Interfaces;

public interface IAccountAppService
{
    Task<Result<SpecificAccount>> GetSpecificAccountAsync(string stakeAddress);
}