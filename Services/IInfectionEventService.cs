using ba_server.Models.Entity;
using ba_server.Models.Response;

namespace ba_server.Services;

public interface IInfectionEventService
{
  Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest emitInfectionEventRequest);
}