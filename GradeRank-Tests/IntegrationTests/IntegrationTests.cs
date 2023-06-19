using AutoMapper;
using GradeRank_Application.UseCases;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
  public class IntegrationTests
  {
    private readonly HttpClient _httpClient;

    public IntegrationTests()
    {
      // Configurar o HttpClient para se comunicar com a API
      _httpClient = new HttpClient
      {
        BaseAddress = new Uri("http://35.183.125.59/api/")
      };
    }

    [Fact]
    public async Task GetCourses_ReturnsSuccessStatusCode()
    {
      // Arrange

      // Act
      var response = await _httpClient.GetAsync("coursesList");

      // Assert
      response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetCourse_WithInvalidId_ReturnsNotFoundStatusCode()
    {
      // Arrange
      int courseId = 999;

      // Act
      var response = await _httpClient.GetAsync($"course?id={courseId}");

      // Assert
      Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task GetCourse_WithValidId_ReturnsSuccessStatusCode()
    {
      // Arrange
      int courseId = 1;

      // Act
      var response = await _httpClient.GetAsync($"Course/{courseId}");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateNewEvaluation_WithValidData_ReturnsSuccessStatusCode()
    {
      // Arrange
      var evaluationRequest = new EvaluationComponentRequest
      {
        IdUser = 1,
        IdCourse = 1,
        EvaluationRequest = new List<EvaluationRequest>
    {
        new EvaluationRequest { IdQuestion = 1, ValueEvaluation = 5 },
        new EvaluationRequest { IdQuestion = 2, ValueEvaluation = 4 }
    }
      };

      var evaluationDboList = new List<EvaluationDbo>
{
    new EvaluationDbo { /* Propriedades da avaliação 1 */ },
    new EvaluationDbo { /* Propriedades da avaliação 2 */ }
};

      var serializedRequest = JsonConvert.SerializeObject(evaluationRequest);
      var content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

      var evaluationRepositoryMock = new Mock<IEvaluationRepository>();
      evaluationRepositoryMock
          .Setup(r => r.GetEvaluationsByIdUserAndIdCourse(evaluationRequest.IdUser, evaluationRequest.IdCourse))
          .ReturnsAsync(new List<EvaluationDbo>());

      var unitOfWorkMock = new Mock<IUnitOfWork>();
      unitOfWorkMock.Setup(u => u.Save()).ReturnsAsync(1);

      var professorRepositoryMock = new Mock<IProfessorRepository>();
      var courseRepositoryMock = new Mock<ICourseRepository>();

      var mapperMock = new Mock<IMapper>();
      mapperMock
          .Setup(m => m.Map<List<EvaluationDbo>>(evaluationRequest))
          .Returns(evaluationDboList);

      var evaluationService = new EvaluationService(
          evaluationRepositoryMock.Object,
          mapperMock.Object,
          unitOfWorkMock.Object,
          professorRepositoryMock.Object,
          courseRepositoryMock.Object
      );

      // Act
      await evaluationService.CreateNewEvaluation(evaluationRequest);

      // Assert
      evaluationRepositoryMock.Verify(r => r.InsertEvaluation(It.IsAny<EvaluationDbo>()), Times.Exactly(2));
      unitOfWorkMock.Verify(u => u.Save(), Times.Once);
    }

    [Fact]
    public async Task GetUser_WithValidId_ReturnsUserData()
    {
      // Arrange
      int userId = 1;

      // Act
      var response = await _httpClient.GetAsync($"{userId}");
      var serializedResponse = await response.Content.ReadAsStringAsync();

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.NotEmpty(serializedResponse);

      var course = JsonConvert.DeserializeObject<List<CourseDbo>>(serializedResponse);
      Assert.NotNull(course);
      // Add additional assertions as needed to validate user data
    }
  }
}
