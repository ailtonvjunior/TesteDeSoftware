using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GradeRank_Domain.Models.DBO;


namespace GradeRank_Domain.Models.Request
{
    public class CourseEvaluationQuestionRequest
    {
        public CourseEvaluationQuestionRequest(string question, double value)
        {
            Question = question;
            Value = value;
        }
        public string Question { get; set; }
        public double Value { get; set; }
        public string NameProfessor { get; set; }
  }
}
