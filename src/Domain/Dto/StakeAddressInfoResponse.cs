using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public sealed class StakeAddressInfoResponse
{
    [JsonPropertyName("stake_address")]
    public string? StakeAddress { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("active_epoch")]
    public int ActiveEpoch { get; set; }

    [JsonPropertyName("controlled_amount")]
    public string? ControlledAmount { get; set; }

    [JsonPropertyName("rewards_sum")]
    public string? RewardsSum { get; set; }

    [JsonPropertyName("withdrawals_sum")]
    public string? WithdrawalsSum { get; set; }

    [JsonPropertyName("reserves_sum")]
    public string? ReservesSum { get; set; }

    [JsonPropertyName("treasury_sum")]
    public string? TreasurySum { get; set; }

    [JsonPropertyName("withdrawable_amount")]
    public string? WithdrawableAmount { get; set; }

    [JsonPropertyName("pool_id")]
    public string? PoolId { get; set; }

    [JsonPropertyName("drep_id")]
    public string? DrepId { get; set; }
}