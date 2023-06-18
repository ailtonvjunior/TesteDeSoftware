using GradeRank_Domain.Models;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
  public class QuestionRepository : IQuestionRepository
  {
    private readonly GradeRankContext _context;

    public QuestionRepository(GradeRankContext context)
    {
      _context = context;
    }
    public async Task<List<QuestionDbo>> GetQuestionsList()
    {
      var questionsList = await _context.Questions.ToListAsync();
      return questionsList;
    }
  
  }
}