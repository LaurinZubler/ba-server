using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ba_server.Models.Configuration;
using ba_server.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ba_server.Services;

public class SecretsService(IOptions<AzureOptions> azureOptions) : ISecretsService
{
  private readonly AzureOptions _azureOptions = azureOptions.Value;

  private static readonly SecretClientOptions Options = new()
  {
    Retry =
    {
      Delay= TimeSpan.FromSeconds(2),
      MaxDelay = TimeSpan.FromSeconds(16),
      MaxRetries = 5,
      Mode = RetryMode.Exponential
    }
  };

  public async Task<string> Get(string key)
  {
    TokenCredential credentials = new DefaultAzureCredential();
    SecretClient client = new(new Uri(_azureOptions.KeyVaultUrl), credentials, Options);
    KeyVaultSecret secret = await client.GetSecretAsync(key);

    return secret.Value;
  }
}