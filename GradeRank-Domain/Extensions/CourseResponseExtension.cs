using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using System.Diagnostics.CodeAnalysis;


namespace GradeRank_Domain.Domain.Extensions
{
  [ExcludeFromCodeCoverage]

  public static class CourseResponseExtension
  {
    public static void FullfillvaluationTimes(this List<CourseResponse> courseResponseList, List<CourseEvaluationDto> evaluationTimes)
    {
      foreach (var courseResponse in courseResponseList)
      {
        var courseEvaluation = evaluationTimes.FirstOrDefault(dto => dto.IdCourse == courseResponse.Id);
        if (courseEvaluation != null)
        {
          courseResponse.EvaluationTimes = courseEvaluation.EvaluationTimes;
        }
      }
    }

    public static void FullfillProfessorNames(this List<CourseResponse> courseResponseList, List<ProfessorDbo> professorsList)
    {
      foreach (var courseResponse in courseResponseList)
      {
        var professor = professorsList.FirstOrDefault(prof => prof.Id == courseResponse.IdProfessor);
        if (professor != null)
        {
          courseResponse.NameProfessor = professor.Name;
        }
      }
    }

    public static void FullfillProfessorNamesOnCourseEvaluationQuestionRequest(this List<CourseEvaluationQuestionRequest> courseResponseList, List<ProfessorDbo> professorsList, int idProfessor)
    {
      foreach (var courseResponse in courseResponseList)
      {
        var professor = professorsList.FirstOrDefault(prof => prof.Id == idProfessor);
        if (professor != null)
        {
          courseResponse.NameProfessor = professor.Name;
        }
      }
    }
  }
}
