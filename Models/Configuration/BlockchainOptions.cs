using System.Numerics;

namespace ba_server.Models.Configuration;

public class BlockchainOptions
{
  public const string Blockchain = "Blockchain";

  public int ChainId { get; set; } = Int32.MinValue;
  public string Url { get; set; } = String.Empty;
  public string UpsiContractAddress { get; set; } = String.Empty;
  public string UpsiABI { get; set; } = String.Empty;
  public bool UseInfuraAPIKey { get; set; } = false;
}