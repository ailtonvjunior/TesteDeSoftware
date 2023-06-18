using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  public class CourseEvaluationDto
  {
    public int IdCourse { get; set; }
    public int EvaluationTimes { get; set; }
  }
}


