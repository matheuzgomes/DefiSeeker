namespace DefiSeeker.Shared.Settings;


public sealed class Settings
{
    public static readonly string BlockFrostProjectId = GetEnvironmentVariables("BLOCKFROST_PROJECT_ID");

    private static string GetEnvironmentVariables(string key)
    {
        string? value = Environment.GetEnvironmentVariable(key);

        if (string.IsNullOrEmpty(value))
        {
            Console.Error.WriteLine("Variable {key} not found in environment variables.", key);
            return string.Empty;
        }

        return value;
    }
}