using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _userRepository = userRepository;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task CreateNewUser(UserRequest user)
    {
      var userDbo = _mapper.Map<UserDbo>(user);
      if (!_userRepository.VerifyIfUserExistsByLogin(user.Registration, user.Email).Result)
      {
        await _userRepository.InsertUser(userDbo);
        await _unitOfWork.Save();
      }
      else
        throw new GradeRankException("Usuário já cadastrado na base de dados");
    }
    
    public UserDbo? AuthenticateUser(string email, string pwd)
    {
      return _userRepository.AuthenticateUser(email, pwd).Result;
    }
  }
}
