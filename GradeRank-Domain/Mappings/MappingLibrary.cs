using AutoMapper;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Models.Request;
using System.Diagnostics.CodeAnalysis;

namespace GradeRank_Domain.Mappings
{
  [ExcludeFromCodeCoverage]
  public class MappingLibrary : Profile
  {
    public MappingLibrary()
    {
      MappingUser();
      MappingQuestion();
      MappingEvaluation();
      MappingCourse();
    }

    private void MappingUser()
    {
      CreateMap<UserRequest, UserDbo>();
    }

    private void MappingQuestion()
    {
      CreateMap<QuestionDbo, QuestionResponse>();
    }

    private void MappingEvaluation()
    {
      CreateMap<EvaluationComponentRequest, List<EvaluationDbo>>()
          .AfterMap((src, dest, context) =>
          {
            foreach (var evaluationRequest in src.EvaluationRequest)
            {
              var evaluationDbo = context.Mapper.Map<EvaluationRequest, EvaluationDbo>(evaluationRequest);
              evaluationDbo.IdCourse = src.IdCourse;
              evaluationDbo.IdUser = src.IdUser;
              dest.Add(evaluationDbo);
            }
          });

      CreateMap<EvaluationRequest, EvaluationDbo>()
          .ForMember(dest => dest.EvaluationDate, opt => opt.MapFrom(src => DateTime.Now));

      CreateMap<EvaluationDbo, EvaluationComponentResponse>()
            .AfterMap((src, dest) =>
            {
              dest.IdCourse = src.IdCourse;
              dest.EvaluationDate = src.EvaluationDate;
            });

    }
    private void MappingCourse()
    {
      CreateMap<CourseDbo, CourseResponse>()
          .ForMember(dest => dest.IdProfessor, opt => opt.MapFrom(src => src.Professor));
    }

  }
}
