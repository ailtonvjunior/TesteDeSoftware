using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Request
{
    public class CourseRequest
    {
        public CourseRequest(string name, string department, string code, int professor)
        {
            Name = name;
            Department = department;
            Code = code;
            Professor = professor;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Code { get; set; }
        public int Professor { get; set; }
    }
}
