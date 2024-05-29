using System.Numerics;

namespace ba_server.Models.Responses;

public class EmitInfectionEventResponse
{
  public string? TransactionHash { get; set; }
  public BigInteger Status { get; set; }
}