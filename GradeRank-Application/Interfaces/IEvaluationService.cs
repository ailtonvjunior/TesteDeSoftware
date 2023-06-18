using GradeRank_Domain.Models;
using GradeRank_Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeRank_Domain.Models.DBO;

namespace GradeRank_Application.Interfaces
{
  public interface IEvaluationService
  {
    Task CreateNewEvaluation(EvaluationComponentRequest evaluation);
    Task UpdateEvaluation(EvaluationComponentRequest evaluation);
    Task DeleteEvaluation(int idUser, int idCourse);
    Task<List<EvaluationComponentResponse>> GetEvaluationsPerIdUser(int idUser);
  }
}
