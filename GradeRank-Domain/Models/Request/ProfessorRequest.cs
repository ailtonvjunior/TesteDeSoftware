using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GradeRank_Domain.Models.DBO;


namespace GradeRank_Domain.Models.Request
{
    public class ProfessorRequest
    {
        public ProfessorRequest(string name, string department, string code, int numEvaluations)
        {
            Name = name;
            Department = department;
            Code = code;
            NumEvaluations = numEvaluations;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Code { get; set; }
        public int NumEvaluations { get; set; } 
    }
}
