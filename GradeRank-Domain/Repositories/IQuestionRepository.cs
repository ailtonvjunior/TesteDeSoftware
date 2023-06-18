

using GradeRank_Domain.Models.DBO;

namespace GradeRank_Domain.Repositories
{
  public interface IQuestionRepository
  {
    Task<List<QuestionDbo>> GetQuestionsList();
  }
}
