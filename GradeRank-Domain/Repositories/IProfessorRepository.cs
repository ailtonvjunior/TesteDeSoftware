

using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;

namespace GradeRank_Domain.Repositories
{
    public interface IProfessorRepository
  {
    Task<List<ProfessorDbo>> GetProfessorsList();
    ValueTask<ProfessorDbo?> GetProfessorById(int id);
  }
}
