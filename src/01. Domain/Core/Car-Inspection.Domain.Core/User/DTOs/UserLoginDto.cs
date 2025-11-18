using Car_Inspection.Domain.Core.User.Enums;

namespace Car_Inspection.Domain.Core.User.DTOs;

public class UserLoginDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? ImgUrl { get; set; }
    public RoleEnum Role { get; set; }

}