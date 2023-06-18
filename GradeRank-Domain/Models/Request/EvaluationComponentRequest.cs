using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradeRank_Domain.Models.Request
{
  public class EvaluationComponentRequest
  {
    public int IdUser { get; set; }
    public int IdCourse { get; set; }
    public List<EvaluationRequest>? EvaluationRequest { get; set; }
  }
}


