using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public class AccountAddressInfo
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("amount")]
    public List<AccountAmount>? Amount { get; set; }

    [JsonPropertyName("stake_address")]
    public string? StakeAddress { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("script")]
    public bool Script { get; set; }
}

public class AccountAmount
{
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }
}