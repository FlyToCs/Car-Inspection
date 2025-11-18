using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.User.DTOs;

namespace Car_Inspection.Domain.Core.User.AppServices;

public interface IUserAppService
{
    Result<bool> Register(RegisterUserDto registerUserDto);
    Result<UserDto> Login(string username , string password);
    List<UserDto> GetAll();
    Result<UserDto> GetById(int userId);
    Result<UserDto> GetByUserName(string username);
}