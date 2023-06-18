using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Response
{
  public class CourseResponse
  {
    public CourseResponse()
    {

    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Code { get; set; }
    public int IdProfessor { get; set; }
    public string NameProfessor { get; set; }
    public int EvaluationTimes { get; set; }
  }
}


