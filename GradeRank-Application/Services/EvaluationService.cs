using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Domain.Extensions;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace GradeRank_Application.UseCases
{
  public class EvaluationService : IEvaluationService
  {
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public EvaluationService(IEvaluationRepository evaluationRepository, IMapper mapper, IUnitOfWork unitOfWork, IProfessorRepository professorRepository, ICourseRepository courseRepository)
    {
      _evaluationRepository = evaluationRepository;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _professorRepository = professorRepository;
      _courseRepository = courseRepository;
    }

    public async Task<List<EvaluationComponentResponse>> GetEvaluationsPerIdUser(int idUser)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUser(idUser);

      //remove duplicatas devido a segundos de diferença na inserção
      var distinctEvaluationDbo = evaluationDbo.GroupBy(e => e.IdCourse).Select(g => g.First()).ToList();


      if (evaluationDbo.Count == 0)
      {
        throw new GradeRankException("Este usuário não realizou nenhuma avaliação");
      }

      var evaluationComponentResponse = _mapper.Map<List<EvaluationComponentResponse>>(distinctEvaluationDbo);

      var professors = await _professorRepository.GetProfessorsList();
      var courses = await _courseRepository.GetCoursesList();

      EvaluationComponentResponseExtension.FullfillProfessorNames(evaluationComponentResponse, professors);
      EvaluationComponentResponseExtension.FullfillCourseName(evaluationComponentResponse, courses);

      return evaluationComponentResponse;
    }

    public async Task CreateNewEvaluation(EvaluationComponentRequest evaluation)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUserAndIdCourse(evaluation.IdUser, evaluation.IdCourse);
      if (evaluationDbo is not null && evaluationDbo.Count != 0 ) 
      {
        throw new GradeRankException("O usuário já possui uma avaliação para esta disciplina");
      }

      var evaluationDboList = _mapper.Map<List<EvaluationDbo>>(evaluation);
      foreach (var item in evaluationDboList)
      {
        await _evaluationRepository.InsertEvaluation(item);
      }
      await _unitOfWork.Save();
    }
    
    public async Task UpdateEvaluation(EvaluationComponentRequest evaluation)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUserAndIdCourse(evaluation.IdUser, evaluation.IdCourse);
      if (evaluationDbo.Count == 0) 
      {
        throw new GradeRankException("O usuário não possui avaliação para esta disciplina");
      }

      var evaluationDboList = _mapper.Map<List<EvaluationDbo>>(evaluation);
      foreach (var item in evaluationDboList)
      {
        await _evaluationRepository.UpdateEvaluation(item);
      }
      await _unitOfWork.Save();
    }

    public async Task DeleteEvaluation(int idUser, int idCourse)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUserAndIdCourse(idUser, idCourse);

      foreach (var item in evaluationDbo)
      {
        _evaluationRepository.DeleteEvaluation(item);
      }
      await _unitOfWork.Save();
    }
  }
}
