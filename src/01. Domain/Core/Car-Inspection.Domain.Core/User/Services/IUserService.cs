
using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.User.DTOs;

namespace Car_Inspection.Domain.Core.User.Services;

public interface IUserService
{
    bool Create(RegisterUserDto registerUserDto);
    List<UserDto> GetAll();
    UserDto? GetById(int userId);
    UserDto? GetByUserName(string username);
    UserLoginDto? GetByUserNameForLogin(string username);
}