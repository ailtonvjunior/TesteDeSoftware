using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
    public class QuestionService : IQuestionService
  {
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
      _questionRepository = questionRepository;
      _mapper = mapper;
    }

    public async Task<List<QuestionResponse>> GetQuestionsListAsync()
    {
      var question = await _questionRepository.GetQuestionsList();
      return _mapper.Map<List<QuestionResponse>>(question); 
    }
  }
}
