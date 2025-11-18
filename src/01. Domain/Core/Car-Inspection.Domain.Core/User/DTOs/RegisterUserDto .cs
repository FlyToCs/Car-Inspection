using System.Data;

namespace Car_Inspection.Domain.Core.User.DTOs;

public class RegisterUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? ImgUrl { get; set; }
}