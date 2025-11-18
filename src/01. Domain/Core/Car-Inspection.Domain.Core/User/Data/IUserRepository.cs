using Car_Inspection.Domain.Core.User.DTOs;

namespace Car_Inspection.Domain.Core.User.Data;

public interface IUserRepository
{
    bool Create(RegisterUserDto registerUserDto);
    List<UserDto> GetAll();
    UserDto? GetById(int userId);
    UserDto? GetByUserName(string username);
    UserLoginDto? GetByUserNameForLogin(string username);

}