using ba_server.Models.Requests;
using ba_server.Models.Responses;

namespace ba_server.Services.Interfaces;

public interface IUpsiContractService
{
  Task<EmitInfectionEventResponse> EmitInfectionEventAsync(EmitInfectionEventRequest emitInfectionEventRequest);
}