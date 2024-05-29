using Nethereum.Hex.HexTypes;

namespace ba_server.Models.Responses;

public class EmitInfectionEventResponse
{
  public string? TransactionHash { get; set; }
  public HexBigInteger Status { get; set; }
}