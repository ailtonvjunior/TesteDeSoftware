using GradeRank_Domain.Models;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
  {
    private readonly GradeRankContext _context;

    public ProfessorRepository(GradeRankContext context)
    {
      _context = context;
    }
    public Task<List<ProfessorDbo>> GetProfessorsList()
    {
      var professorsList = _context.Professors.ToListAsync();
      return professorsList;
    }
    
    public ValueTask<ProfessorDbo?> GetProfessorById(int id)
    {
      var professor = _context.Professors.FindAsync(id);
      return professor;
    }
  }
}