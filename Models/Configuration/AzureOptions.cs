namespace ba_server.Models.Configuration;

public class AzureOptions
{
  public const string Azure = "Azure";

  public string KeyVaultUrl { get; init; } = string.Empty;
  public string PrivateKeyName { get; init; } = string.Empty;
  public string InfuraApiKeyName { get; init; } = string.Empty;
}