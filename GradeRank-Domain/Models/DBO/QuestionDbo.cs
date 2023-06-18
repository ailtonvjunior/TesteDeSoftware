using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_questions")]
  public class QuestionDbo
  {
    public QuestionDbo(int idQuestion, string question)
    {
      IdQuestion = idQuestion;
      Question = question;
    }

    [Key]
    [Column("id_question")]
    public int IdQuestion { get; set; }

    [Column("desc_question")]
    public string Question { get; set; }

    [Column("idc_CourseQuestion")]
    public bool IsCourseQuestion { get; set; }

    [Column("idcProfessorQuestion")]
    public bool IsProfessorQuestion { get; set; }
  }
}



