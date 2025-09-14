namespace DefiSeeker.Domain.Utils;

public static class LovelaceConverter
{
    private const decimal LovelaceInAda = 1_000_000m;

    public static string ToAda(this string lovelaceAmount)
    {
        if (decimal.TryParse(lovelaceAmount, out var lovelace))
        {
            return (lovelace / LovelaceInAda).ToString();
        }

        throw new ArgumentException("Invalid lovelace amount", nameof(lovelaceAmount));
    }
}