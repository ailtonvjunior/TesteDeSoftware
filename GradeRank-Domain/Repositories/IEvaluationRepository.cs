

using GradeRank_Domain.Models.DBO;

namespace GradeRank_Domain.Repositories
{
  public interface IEvaluationRepository
  {
    Task InsertEvaluation(EvaluationDbo evaluation);
    Task UpdateEvaluation(EvaluationDbo evaluation);
    Task<List<EvaluationDbo?>?> GetEvaluationsByIdUserAndIdCourse(int idUser, int idCourse);
    Task<List<EvaluationDbo>> GetEvaluationsByIdCourseList(int idCourse);
    void DeleteEvaluation(EvaluationDbo evaluation);
    int GetNumberOfEvaluationsByIdCourse(int idCourse);
    Task<List<EvaluationDbo>> GetEvaluationsByIdUser(int idUser);
    Task<int> GetEvaluationsByIdCourse(int idCourse);
    List<CourseEvaluationDto> GetNumberOfEvaluations();
  }
}
