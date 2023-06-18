using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using System.Diagnostics.CodeAnalysis;


namespace GradeRank_Domain.Domain.Extensions
{
  [ExcludeFromCodeCoverage]

  public static class EvaluationComponentResponseExtension
  {
    public static void FullfillCourseName(this List<EvaluationComponentResponse> evaluationComponentList, List<CourseDbo> courseList)
    {
      foreach (var evaluationComponent in evaluationComponentList)
      {
        var course = courseList.FirstOrDefault(dto => dto.Id == evaluationComponent.IdCourse);
        if (course != null)
        {
          evaluationComponent.NameCourse = course.Name;
        }
      }
    }

    public static void FullfillProfessorNames(this List<EvaluationComponentResponse> evaluationComponentList, List<ProfessorDbo> professorsList)
    {
      foreach (var evaluationComponent in evaluationComponentList)
      {
        var professor = professorsList.FirstOrDefault(prof => prof.Id == evaluationComponent.IdCourse);
        if (professor != null)
        {
          evaluationComponent.NameProfessor = professor.Name;
        }
      }
    }

  }
}

