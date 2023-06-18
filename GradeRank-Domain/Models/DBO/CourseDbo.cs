using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_courses")]
  public class CourseDbo
  {
    public CourseDbo(string name, string department, string code, int professor)
    {
      Name = name;
      Department = department;
      Code = code;
      Professor = professor;
    }

    [Key]
    [Column("id_course")]
    public int Id { get; set; }

    [Column("name_course")]
    public string Name { get; set; }

    [Column("department_course")]
    public string Department { get; set; }

    [Column("code_course")]
    public string Code { get; set; }
    
    [Column("professor_course")]
    public int Professor { get; set; }
  }
}


