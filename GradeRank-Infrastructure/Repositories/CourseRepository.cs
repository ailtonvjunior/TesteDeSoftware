using GradeRank_Domain.Models;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
  {
    private readonly GradeRankContext _context;

    public CourseRepository(GradeRankContext context)
    {
      _context = context;
    }
    public Task<List<CourseDbo>> GetCoursesList()
    {
      var coursesList = _context.Courses.ToListAsync();
      return coursesList;
    }
    
    public ValueTask<CourseDbo?> GetCourseById(int id)
    {
      var course = _context.Courses.FindAsync(id);
      return course;
    }
  }
}