using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
  public class HealthStatusService : IHealthStatusService
  {
    private readonly IHealthStatusRepository _healthStatusRepository;

    public HealthStatusService(IHealthStatusRepository healthStatusRepository)
    {
      _healthStatusRepository = healthStatusRepository;
    }

    public String GetStatusService() 
    {
      string healthstatus = _healthStatusRepository.GetHealthStatus().Result.Status;
      return healthstatus;
    }
  }
}
