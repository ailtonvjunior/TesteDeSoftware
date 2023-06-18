using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class LoginController : Controller
  {
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
      _userService = userService;
    }

    [Route("api/[controller]")]
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateNewUser([FromBody] UserRequest user)
    {
      try
      {
        await _userService.CreateNewUser(user);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }

    [Route("api/Auth")]
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AuthenticateUser([FromBody] UserRequest user)
    {
      var authenticatedUser = _userService.AuthenticateUser(user.Email, user.Password);
      if (authenticatedUser != null) return Ok(authenticatedUser);
      return Unauthorized();
    }
  }
}
