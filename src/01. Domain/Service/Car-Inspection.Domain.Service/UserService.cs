using Car_Inspection.Domain.Core.User.Data;
using Car_Inspection.Domain.Core.User.DTOs;
using Car_Inspection.Domain.Core.User.Services;

namespace Car_Inspection.Domain.Service;

public class UserService(IUserRepository userRepo) : IUserService
{
    public bool Create(RegisterUserDto registerUserDto)
    {
        return userRepo.Create(registerUserDto);
    }

    public List<UserDto> GetAll()
    {
        return userRepo.GetAll();
    }

    public UserDto? GetById(int userId)
    {
        return userRepo.GetById(userId);
    }

    public UserDto? GetByUserName(string username)
    {
        return userRepo.GetByUserName(username);
    }

    public UserLoginDto? GetByUserNameForLogin(string username)
    {
       return userRepo.GetByUserNameForLogin(username);
    }
}