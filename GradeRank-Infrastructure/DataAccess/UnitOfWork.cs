using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;

namespace GradeRank_Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
      private readonly GradeRankContext _gradeRankContext;

      public UnitOfWork(GradeRankContext gradeRankContext) => this._gradeRankContext = gradeRankContext;

      public async Task<int> Save()
      {
        try
        {
          int affectedRows = await this._gradeRankContext
              .SaveChangesAsync();
          return affectedRows;
        }

        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw new GradeRankException("Erro ao salvar no banco de dados");
        }
      }
    }
}

