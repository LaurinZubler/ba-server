using ba_server.Models.Entity;
using ba_server.Models.Response;

namespace ba_server.Services;

public class InfectionEventService : IInfectionEventService
{
  public async Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest emitInfectionEventRequest)
  {
    return new EmitInfectionEventResponse { Text = "whueppa" };
  }
}