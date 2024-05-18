using Microsoft.AspNetCore.Mvc;
using ba_server.Models.Requests;
using ba_server.Services.Interfaces;

namespace ba_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpsiContractController : ControllerBase
{
  private readonly ILogger<UpsiContractController> _logger;

  public UpsiContractController(ILogger<UpsiContractController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  [Route("InfectionEvent")]
  public async Task<IActionResult> EmitInfectionEvent([FromBody] EmitInfectionEventRequest emitInfectionEventRequest, [FromServices] IUpsiContractService upsiContractService)
  {
    try
    {
      var result = await upsiContractService.EmitInfectionEventAsync(emitInfectionEventRequest);
      return Ok(result);
    }
    catch (Exception ex)
    {
      return StatusCode(500, "Internal Server Error: " + ex.Message);
    }
  }
}