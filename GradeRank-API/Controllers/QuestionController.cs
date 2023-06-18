using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class QuestionController : Controller
  {
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
      _questionService = questionService;
    }

    [Route("api/[controller]")]
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllQuestions()
    {
      try
      {
        var questions =  await _questionService.GetQuestionsListAsync();
        if (questions.Count == 0) { return  NoContent(); }  
        return Ok(questions);

      }
      catch (GradeRankException ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
