using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_professors")]
  public class ProfessorDbo
  {
    public ProfessorDbo(string name, string department)
    {
      Name = name;
      Department = department;
    }

    [Key]
    [Column("id_professor")]
    public int Id { get; set; }

    [Column("name_professor")]
    public string Name { get; set; }

    [Column("department_professor")]
    public string Department { get; set; }
  }
}


