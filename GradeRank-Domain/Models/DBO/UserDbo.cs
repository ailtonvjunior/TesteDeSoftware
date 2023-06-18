using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_users")]
  public class UserDbo
  {
    public UserDbo(string name, string registration, string email, string password)
    {
      Name = name;
      Registration = registration;
      Email = email;
      Password = password;
    }

    [Key]
    [Column("id_user")]
    public int Id { get; set; }

    [Column("name_user")]
    public string Name { get; set; }

    [Column("registration_user")]
    public string Registration { get; set; }

    [Column("email_user")]
    public string Email { get; set; }

    [Column("pwd_user")]
    public string Password { get; set; }
  }
}


