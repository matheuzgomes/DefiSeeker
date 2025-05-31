using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Entities;

public sealed class SpecificAccount
{
    [JsonPropertyName("stake_address")]
    public string? StakeAddress { get; init; }

    [JsonPropertyName("active")]
    public bool Active { get; init; }

    [JsonPropertyName("active_epoch")]
    public int ActiveEpoch { get; init; }

    [JsonPropertyName("controlled_amount")]
    public string? ControlledAmount { get; init; }

    [JsonPropertyName("rewards_sum")]
    public string? RewardsSum { get; init; }

    [JsonPropertyName("withdrawals_sum")]
    public string? WithdrawalsSum { get; init; }

    [JsonPropertyName("reserves_sum")]
    public string? ReservesSum { get; init; }

    [JsonPropertyName("treasury_sum")]
    public string? TreasurySum { get; init; }

    [JsonPropertyName("withdrawable_amount")]
    public string? WithdrawableAmount { get; init; }

    [JsonPropertyName("pool_id")]
    public string? PoolId { get; init; }

    [JsonPropertyName("drep_id")]
    public string? DrepId { get; init; }
}