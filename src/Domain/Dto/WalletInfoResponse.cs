using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public class WalletInfoResponse
{
    public string? Address { get; set; }

    public List<CurrencyAmount>? Amount { get; set; }

    [JsonPropertyName("stake_address")]
    public string? StakeAddress { get; set; }

    public string? Type { get; set; }

    public bool Script { get; set; }
}