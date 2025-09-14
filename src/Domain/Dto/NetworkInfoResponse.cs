using DefiSeeker.Domain.Utils;

namespace DefiSeeker.Domain.Dto;


public sealed class NetworkInfoResponse
{
    public SupplyInfo? Supply { get; set; }
    public StakeInfo? Stake { get; set; }


    public static NetworkInfoResponse Build(NetworkInfoResponse source)
    {
        return new NetworkInfoResponse
        {
            Supply = new SupplyInfo
            {
                Max = source.Supply?.Max?.ToAda(),
                Total = source.Supply?.Total?.ToAda(),
                Circulating = source.Supply?.Circulating?.ToAda(),
                Locked = source.Supply?.Locked,
                Treasury = source.Supply?.Treasury,
                Reserves = source.Supply?.Reserves
            },
            Stake = new StakeInfo
            {
                Live = source.Stake?.Live?.ToAda(),
                Active = source.Stake?.Active?.ToAda()
            }
        };
    }
}

public sealed class SupplyInfo
{
    public string? Max { get; set; }
    public string? Total { get; set; }
    public string? Circulating { get; set; }
    public string? Locked { get; set; }
    public string? Treasury { get; set; }
    public string? Reserves { get; set; }
}

public sealed class StakeInfo
{
    public string? Live { get; set; }
    public string? Active { get; set; }
}