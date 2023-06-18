

using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;

namespace GradeRank_Domain.Repositories
{
    public interface ICourseRepository
  {
    Task<List<CourseDbo>> GetCoursesList();
    ValueTask<CourseDbo?> GetCourseById(int id);
  }
}
