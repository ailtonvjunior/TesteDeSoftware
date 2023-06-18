using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradeRank_Domain.Models.Request
{
  public class EvaluationComponentResponse
  {
    public int IdCourse { get; set; }
    public string? NameCourse { get; set; }
    public string? NameProfessor { get; set; }
    public DateTime? EvaluationDate { get; set; }
  }
}


