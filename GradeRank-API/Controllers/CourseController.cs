using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class CourseController : Controller
  {
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
      _courseService = courseService;
    }

    [Route("api/[controller]sList")]
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCoursesList()
    {
      var coursesList = _courseService.GetCoursesList();
      return Ok(coursesList);
    }
    
    [Route("api/[controller]")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCourseById(int id)
    {
      var course = _courseService.GetCourseById(id);
      if (course == null) return NotFound();
      return Ok(course);
    }
    
    [Route("api/[controller]Evaluation")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCourseEvaluation(int id)
    {
      var courseEvaluation = _courseService.GetCourseEvaluation(id);
      if (courseEvaluation == null) return NotFound();
      return Ok(courseEvaluation);
    }
  }
}
