namespace ba_server.Models.Configuration;

public class AzureOptions
{
  public const string Azure = "Azure";

  public string KeyVaultUrl { get; set; } = string.Empty;
  public string PrivateKeyName { get; set; } = string.Empty;
  public string InfuraApiKeyName { get; set; } = string.Empty;
}