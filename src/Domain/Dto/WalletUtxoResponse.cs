using System.Text.Json.Serialization;

namespace DefiSeeker.Domain.Dto;

public sealed record WalletUtxoResponse
{
    public required string Address { get; init; }

    [JsonPropertyName("received_sum")]
    public required List<CurrencyAmount> ReceivedSum { get; set; }

    [JsonPropertyName("sent_sum")]
    public required List<CurrencyAmount> SentSum { get; set; }

    [JsonPropertyName("tx_count")]
    public required int TxCount { get; init; }
}