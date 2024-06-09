namespace ba_server.Models.Requests;

public class EmitInfectionEventRequest
{
  public required string Infection { get; set; }
  public required List<string> Infectee { get; set; }
  public required string Tester { get; set; }
  public required DateTime testTime { get; set; }
  public required string signature { get; set; }
}