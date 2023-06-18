using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Request
{
  public class UserRequest
  {
    public UserRequest(string name, string registration, string email, string password)
    {
      Name = name;
      Registration = registration;
      Email = email;
      Password = password;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Registration { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
