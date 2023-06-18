using GradeRank_Domain.Models;
using GradeRank_Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeRank_Domain.Models.DBO;

namespace GradeRank_Application.Interfaces
{
    public interface IProfessorService
  {
    List<ProfessorDbo> GetProfessorsList(); 
    ProfessorDbo? GetProfessorById(int id);
  }
}
