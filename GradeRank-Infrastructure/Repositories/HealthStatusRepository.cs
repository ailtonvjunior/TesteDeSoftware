using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
    public class HealthStatusRepository : IHealthStatusRepository
  {
    private readonly GradeRankContext _context;

    public HealthStatusRepository(GradeRankContext context)
    {
      _context = context;
    }
    public async Task<HealthStatusDbo?> GetHealthStatus()
    {
      var healthStatus = await _context.HealthStatus
        .FirstOrDefaultAsync();

      return healthStatus;
    }
  }
}
