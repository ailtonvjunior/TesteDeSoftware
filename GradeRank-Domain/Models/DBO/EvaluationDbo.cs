using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_evaluations")]
  public class EvaluationDbo
  {
    public EvaluationDbo()
    {

    }

    [Key]
    [Column("id_evaluation")]
    public int IdEvaluation { get; set; }

    [Column("id_course")]
    public int IdCourse { get; set; }

    [Column("id_question")]
    public int IdQuestion { get; set; }

    [Column("id_user")]
    public int IdUser { get; set; }

    [Column("vlr_evaluation")]
    public int ValueEvaluation { get; set; }

    [Column("date_evaluation")]
    public DateTime? EvaluationDate { get; set; }
  }
}


