namespace ba_server.Models.Configuration;

public class BlockchainOptions
{
  public const string Blockchain = "Blockchain";

  public int ChainId { get; init; } = int.MinValue;
  public string Url { get; init; } = string.Empty;
  public string UpsiContractAddress { get; init; } = string.Empty;
  public string UpsiABI { get; init; } = string.Empty;
  public string EmitInfectionEventFunctionName { get; init; } = string.Empty;
}