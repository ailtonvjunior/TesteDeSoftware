using GradeRank_Domain.Models;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly GradeRankContext _context;

    public UserRepository(GradeRankContext context)
    {
      _context = context;
    }
    public async Task InsertUser(UserDbo user)
    {
      await _context.Users.AddAsync(user);
    }
    public async Task<bool> VerifyIfUserExistsByLogin(string registration, string email)
    {
      var userExists = await _context.Users.AnyAsync(u => u.Registration == registration || u.Email == email);
      return userExists;
    }
    
    public async Task<UserDbo?> AuthenticateUser(string email, string pwd)
    {
      var authenticated = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pwd);
      return authenticated;
    }
  }
}
