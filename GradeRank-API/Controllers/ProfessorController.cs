using GradeRank_Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class ProfessorController : Controller
  {
    private readonly IProfessorService _courseService;

    public ProfessorController(IProfessorService courseService)
    {
      _courseService = courseService;
    }

    [Route("api/[controller]sList")]
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfessorsList()
    {
      var coursesList = _courseService.GetProfessorsList();
      return Ok(coursesList);
    }
    
    [Route("api/[controller]")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfessorById(int id)
    {
      var course = _courseService.GetProfessorById(id);
      if (course == null) return NotFound();
      return Ok(course);
    }
  }
}
