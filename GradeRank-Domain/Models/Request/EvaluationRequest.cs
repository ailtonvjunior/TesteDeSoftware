using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Request
{
  public class EvaluationRequest
  {
    public int IdQuestion { get; set; }
    public int ValueEvaluation { get; set; }

  }
}


