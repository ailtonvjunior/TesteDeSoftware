using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Response
{
  public class QuestionResponse
  {
    public int IdQuestion { get; set; }
    public string Question { get; set; }
    public bool IsCourseQuestion { get; set; }
    public bool IsProfessorQuestion { get; set; }


  }
}



