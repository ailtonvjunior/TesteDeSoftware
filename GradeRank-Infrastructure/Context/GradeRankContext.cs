using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace GradeRank_Infrastructure.Context
{
  public class GradeRankContext : DbContext
  {

    private IDbConnection _connection;
    public IDbConnection Connection
    {
      get
      {
        if (_connection.State == ConnectionState.Open) return _connection;

        _connection.Open();

        while (_connection.State == ConnectionState.Connecting) { }

        return _connection;
      }
      private set => _connection = value;
    }

    public virtual DbSet<HealthStatusDbo> HealthStatus { get; set; }
    public virtual DbSet<UserDbo> Users { get; set; }
    public virtual DbSet<CourseDbo> Courses { get; set; }
    public virtual DbSet<ProfessorDbo> Professors { get; set; }
    public virtual DbSet<QuestionDbo> Questions { get; set; }
    public virtual DbSet<EvaluationDbo> Evaluations { get; set; }

    public GradeRankContext()
    {

    }

    public GradeRankContext(DbContextOptions<GradeRankContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GradeRankContext).Assembly);
      
    }
  }
}