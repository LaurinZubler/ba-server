namespace ba_server.Models.Configuration;

public class BlockchainOptions
{
  public const string Blockchain = "Blockchain";

  public int ChainId { get; set; } = int.MinValue;
  public string Url { get; set; } = string.Empty;
  public string UpsiContractAddress { get; set; } = string.Empty;
  public string UpsiABI { get; set; } = string.Empty;
}