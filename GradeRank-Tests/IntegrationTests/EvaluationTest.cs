using GradeRank_API.Controllers;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GradeRank_API.Tests.Controllers
{
  public class EvaluationControllerTests
  {
    private readonly Mock<IEvaluationService> _evaluationServiceMock;
    private readonly EvaluationController _controller;

    public EvaluationControllerTests()
    {
      _evaluationServiceMock = new Mock<IEvaluationService>();
      _controller = new EvaluationController(_evaluationServiceMock.Object);
    }

    [Fact]
    public async Task GetEvaluationsPerIdUser_ValidId_ReturnsOkResult()
    {
      // Arrange
      int idUser = 1;
      var evaluations = new List<EvaluationComponentResponse> { new EvaluationComponentResponse() };
      _evaluationServiceMock.Setup(s => s.GetEvaluationsPerIdUser(idUser)).ReturnsAsync(evaluations);

      // Act
      var result = await _controller.GetEvaluationsPerIdUser(idUser);

      // Assert
      Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetEvaluationsPerIdUser_InvalidId_ReturnsNotFoundResult()
    {
      // Arrange
      int idUser = 1;
      _evaluationServiceMock.Setup(s => s.GetEvaluationsPerIdUser(idUser)).ReturnsAsync((List<EvaluationComponentResponse>)null);

      // Act
      var result = await _controller.GetEvaluationsPerIdUser(idUser);

      // Assert
      Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetEvaluationsPerIdUser_ExceptionThrown_ReturnsConflictResult()
    {
      // Arrange
      int idUser = 1;
      string errorMessage = "Error message";
      _evaluationServiceMock.Setup(s => s.GetEvaluationsPerIdUser(idUser)).ThrowsAsync(new GradeRankException(errorMessage));

      // Act
      var result = await _controller.GetEvaluationsPerIdUser(idUser);

      // Assert
      var conflictResult = Assert.IsType<ConflictObjectResult>(result);
      Assert.Equal(errorMessage, conflictResult.Value);
    }

    [Fact]
    public async Task CreateNewEvaluation_ValidData_ReturnsOkResult()
    {
      // Arrange
      var evaluation = new EvaluationComponentRequest();
      _evaluationServiceMock.Setup(s => s.CreateNewEvaluation(evaluation)).Returns(Task.CompletedTask);

      // Act
      var result = await _controller.CreateNewEvaluation(evaluation);

      // Assert
      Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task CreateNewEvaluation_ExceptionThrown_ReturnsConflictResult()
    {
      // Arrange
      var evaluation = new EvaluationComponentRequest();
      string errorMessage = "Error message";
      _evaluationServiceMock.Setup(s => s.CreateNewEvaluation(evaluation)).ThrowsAsync(new GradeRankException(errorMessage));

      // Act
      var result = await _controller.CreateNewEvaluation(evaluation);

      // Assert
      var conflictResult = Assert.IsType<ConflictObjectResult>(result);
      Assert.Equal(errorMessage, conflictResult.Value);
    }

    [Fact]
    public async Task UpdateEvaluation_ValidData_ReturnsOkResult()
    {
      // Arrange
      var evaluation = new EvaluationComponentRequest();
      _evaluationServiceMock.Setup(s => s.UpdateEvaluation(evaluation)).Returns(Task.CompletedTask);

      // Act
      var result = await _controller.UpdateEvaluation(evaluation);

      // Assert
      Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateEvaluation_ExceptionThrown_ReturnsConflictResult()
    {
      // Arrange
      var evaluation = new EvaluationComponentRequest();
      string errorMessage = "Error message";
      _evaluationServiceMock.Setup(s => s.UpdateEvaluation(evaluation)).ThrowsAsync(new GradeRankException(errorMessage));

      // Act
      var result = await _controller.UpdateEvaluation(evaluation);

      // Assert
      var conflictResult = Assert.IsType<ConflictObjectResult>(result);
      Assert.Equal(errorMessage, conflictResult.Value);
    }

    [Fact]
    public async Task DeleteEvaluation_ValidIdAndCourse_ReturnsOkResult()
    {
      // Arrange
      int id = 1;
      int idCourse = 1;
      _evaluationServiceMock.Setup(s => s.DeleteEvaluation(id, idCourse)).Returns(Task.CompletedTask);

      // Act
      var result = await _controller.DeleteEvaluation(id, idCourse);

      // Assert
      Assert.IsType<OkResult>(result);
    }
  }
}
