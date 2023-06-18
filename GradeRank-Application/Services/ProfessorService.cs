using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorService(IProfessorRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ProfessorDbo> GetProfessorsList()
        {
            return _courseRepository.GetProfessorsList().Result;
        }
    
        public ProfessorDbo? GetProfessorById(int id)
        {
            return _courseRepository.GetProfessorById(id).Result;
        }
    }
}