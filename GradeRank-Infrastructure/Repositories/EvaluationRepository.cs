using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
  public class EvaluationRepository : IEvaluationRepository
  {
    private readonly GradeRankContext _context;

    public EvaluationRepository(GradeRankContext context)
    {
      _context = context;
    }

    public async Task InsertEvaluation(EvaluationDbo evaluation)
    {
      await _context.Evaluations.AddAsync(evaluation);
    }
    
    public async Task UpdateEvaluation(EvaluationDbo evaluation)
    {
      var oldEvaluation = _context.Evaluations.FirstOrDefault(e => e.IdUser == evaluation.IdUser &&
                                                                   e.IdCourse == evaluation.IdCourse &&
                                                                   e.IdQuestion == evaluation.IdQuestion);
      if (oldEvaluation != null)
      {
        oldEvaluation.ValueEvaluation = evaluation.ValueEvaluation;
        _context.SaveChanges();
      }
    }

    public void DeleteEvaluation(EvaluationDbo evaluation)
    {
      _context.Evaluations.Remove(evaluation);
    }

    public async Task<List<EvaluationDbo?>?> GetEvaluationsByIdUserAndIdCourse(int idUser, int idCourse)
    {
      var evaluation = await _context.Evaluations.Where(e => e.IdUser == idUser && e.IdCourse == idCourse).ToListAsync();
      return evaluation;
    }

    public async Task<List<EvaluationDbo>> GetEvaluationsByIdCourseList(int idCourse)
    {
      var evaluation = await _context.Evaluations.Where(e => e.IdCourse == idCourse).ToListAsync();
      return evaluation;
    }

    public async Task<List<EvaluationDbo>> GetEvaluationsByIdUser(int idUser)
    {
      var evaluation = await _context.Evaluations
          .Where(e => e.IdUser == idUser)
          .Select(e => new { IdCourse = e.IdCourse, EvaluationDate = e.EvaluationDate })
          .Distinct()
          .Select(e => new EvaluationDbo { IdCourse = e.IdCourse, EvaluationDate = e.EvaluationDate })
          .ToListAsync();

      return evaluation;
    }

    public async Task<int> GetEvaluationsByIdCourse(int idCourse)
    {
      var evaluation = await _context.Evaluations.FirstOrDefaultAsync(u => u.IdCourse == idCourse);
      if (evaluation == null)
        return 0;
      return evaluation.ValueEvaluation;
    }

    public int GetNumberOfEvaluationsByIdCourse(int idCourse)
    {
      var numRows = _context.Evaluations
        .Select(e => new { e.IdCourse, e.IdUser })
        .Distinct()
        .Count();
      return numRows;
    }

    public List<CourseEvaluationDto> GetNumberOfEvaluations()
    {
      var query = (from t in
                      (from e in _context.Evaluations
                       where e.IdQuestion == 1
                       select new { e.IdCourse, e.IdUser })
                   group t by t.IdCourse into g
                   select new CourseEvaluationDto
                   {
                     IdCourse = g.Key,
                     EvaluationTimes = g.Count()
                   }).ToList();

      return query;
    }


  }
}

