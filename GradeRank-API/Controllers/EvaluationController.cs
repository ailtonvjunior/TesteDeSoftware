using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class EvaluationController : Controller
  {
    private readonly IEvaluationService _evaluationService;

    public EvaluationController(IEvaluationService evaluationService)
    {
      _evaluationService = evaluationService;
    }

    [AllowAnonymous]
    [HttpGet("/api/{idUser}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEvaluationsPerIdUser([FromRoute] int idUser)
    {
      try
      {
        var evaluations = await _evaluationService.GetEvaluationsPerIdUser(idUser);
        if (evaluations == null) return NotFound();

        return Ok(evaluations);

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }

    [Route("api/[controller]")]
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateNewEvaluation([FromBody] EvaluationComponentRequest evaluation)
    {
      try
      {
        await _evaluationService.CreateNewEvaluation(evaluation);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }
    
    [Route("api/[controller]")]
    [AllowAnonymous]
    [HttpPut]
    public async Task<IActionResult> UpdateEvaluation([FromBody] EvaluationComponentRequest evaluation)
    {
      try
      {
        await _evaluationService.UpdateEvaluation(evaluation);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }

    [AllowAnonymous]
    [HttpDelete ("/api/{idUser}/{idCourse}")]
    public async Task<IActionResult> DeleteEvaluation([FromRoute] int idUser,int idCourse)
    {
      try
      {
        await _evaluationService.DeleteEvaluation(idUser, idCourse);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Problem(ex.Message);
      }
    }
  }
}
