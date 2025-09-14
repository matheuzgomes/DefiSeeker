using DefiSeeker.Domain.Dto;
using FluentResults;

namespace DefiSeeker.Application.Interfaces;

public interface INetworkAppService
{
    Task<Result<NetworkInfoResponse>> GetNetworkInformationAsync();
}
