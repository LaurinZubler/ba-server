using Microsoft.AspNetCore.Mvc;
using ba_server.Models.Entity;
using ba_server.Services;

namespace ba_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfectionEventController : ControllerBase
{
  private readonly ILogger<InfectionEventController> _logger;

  public InfectionEventController(ILogger<InfectionEventController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  public async Task<IActionResult> EmitInfectionEvent([FromBody] EmitInfectionEventRequest emitInfectionEventRequest, [FromServices] IInfectionEventService infectionEventService)
  {
    try
    {
      var result = await infectionEventService.EmitInfectionEventAsync(emitInfectionEventRequest);
      return Ok(result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Internal Server Error: " + ex.Message);
    }
  }
}