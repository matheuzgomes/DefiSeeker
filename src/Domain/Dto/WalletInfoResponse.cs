using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public class WalletInfoResponse
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("amount")]
    public List<CurrencyAmount>? Amount { get; set; }

    [JsonPropertyName("stake_address")]
    public string? StakeAddress { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("script")]
    public bool Script { get; set; }
}