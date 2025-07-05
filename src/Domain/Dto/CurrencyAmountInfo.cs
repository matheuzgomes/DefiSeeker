using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public class CurrencyAmount
{
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }
}