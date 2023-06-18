using GradeRank_Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  [Route("api/[controller]")]

  public class HealthController : Controller
  {
    private readonly IHealthStatusService _healthStatusUseCase;

    public HealthController(IHealthStatusService healthStatusUseCase)
    {
      _healthStatusUseCase = healthStatusUseCase;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHealthStatus()
    {
      var healthStatus = _healthStatusUseCase.GetStatusService();
      if (healthStatus == null)
        return NotFound();
      return Ok(healthStatus);
    }
  }
}
