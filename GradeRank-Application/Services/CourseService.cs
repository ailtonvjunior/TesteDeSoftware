using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Extensions;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
    public class CourseService : ICourseService
  {
    private readonly ICourseRepository _courseRepository;
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IQuestionRepository _questionRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper, IEvaluationRepository evaluationRepository, IQuestionRepository questionRepository, IProfessorRepository professorRepository)
    {
      _courseRepository = courseRepository;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _evaluationRepository = evaluationRepository;
      _questionRepository = questionRepository;
      _professorRepository = professorRepository;
    }

    public List<CourseResponse> GetCoursesList()
    {
      var courseDbo = _courseRepository.GetCoursesList().Result;
      var courseResponse = _mapper.Map<List<CourseResponse>>(courseDbo);
      var evaluationTimes = _evaluationRepository.GetNumberOfEvaluations();
      var professorsList = _professorRepository.GetProfessorsList().Result;

      CourseResponseExtension.FullfillProfessorNames(courseResponse, professorsList);
      CourseResponseExtension.FullfillvaluationTimes(courseResponse, evaluationTimes);

      return courseResponse;
    }
    
    public CourseResponse? GetCourseById(int id)
    {
      var courseDbo = _courseRepository.GetCourseById(id).Result;
      var professor = _professorRepository.GetProfessorsList().Result.SingleOrDefault(p => p.Id == courseDbo.Professor);
      var courseResponse = _mapper.Map<CourseResponse>(courseDbo);
      courseResponse.NameProfessor = professor.Name;

      return courseResponse;
    }

    public List<CourseEvaluationQuestionRequest> GetCourseEvaluation(int idCourse)
    {
      List<CourseEvaluationQuestionRequest> courseEvaluation = new List<CourseEvaluationQuestionRequest>();
      List<EvaluationDbo> courseEvaluations = _evaluationRepository.GetEvaluationsByIdCourseList(idCourse).Result;
      var courseEvaluationsPerQuestion = courseEvaluations.GroupBy(evaluation => evaluation.IdQuestion);
      List<QuestionDbo> questions = _questionRepository.GetQuestionsList().Result;
      foreach (var evaluation in courseEvaluationsPerQuestion.AsQueryable())
      {
        string questionDescription = questions.Find(question => question.IdQuestion == evaluation.Key).Question;
        double questionAverageValue = evaluation.Average(d => d.ValueEvaluation);
        CourseEvaluationQuestionRequest question = new CourseEvaluationQuestionRequest(questionDescription, questionAverageValue);
        courseEvaluation.Add(question);
      }

      var idProfessor = _courseRepository.GetCourseById(idCourse).Result.Professor;

      var professorsList = _professorRepository.GetProfessorsList().Result;
      CourseResponseExtension.FullfillProfessorNamesOnCourseEvaluationQuestionRequest(courseEvaluation, professorsList, idProfessor);

      return courseEvaluation;
    }
  }
}
