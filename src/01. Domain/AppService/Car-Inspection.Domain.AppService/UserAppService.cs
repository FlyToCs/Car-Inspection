using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.User.AppServices;
using Car_Inspection.Domain.Core.User.DTOs;
using Car_Inspection.Domain.Core.User.Services;
using Car_Inspection.Framework;

namespace Car_Inspection.Domain.AppService;

public class UserAppService(IUserService userService ) : IUserAppService
{

    public Result<bool> Register(RegisterUserDto registerUserDto)
    {
        if (registerUserDto.FirstName == null!||registerUserDto.LastName == null!||
            registerUserDto.Username == null! || registerUserDto.Password == null!)
        {
            return Result<bool>.Failure("پر کردن تمام فیلد ها ضروری است", false);
        }
        registerUserDto.Password = PasswordHasherSha256.HashPassword(registerUserDto.Password);
        var result = userService.Create(registerUserDto);
        if (!result)
        {
            return Result<bool>.Failure("ثبت نام با شکست مواجه شد");
        }
        
        return Result<bool>.Success("ثبت نام با موفقیت انحام شد", true);
    }

    public Result<UserDto> Login(string username, string password)
    {
        var user = userService.GetByUserNameForLogin(username);
        if (user == null) { 
            return Result<UserDto>.Failure("نام کاربری یا کلمه عبور اشتباه است");
        }
        var passwordCheck = PasswordHasherSha256.VerifyPassword(password, user.Password);
        if (!passwordCheck)
            return Result<UserDto>.Failure("نام کاربری یا رمز عبور اشتباه است");
        var userDto = new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            Username = user.Username,
            ImgUrl = user.ImgUrl,
            Role = user.Role
        };
        return Result<UserDto>.Success("", userDto);
    }


    public List<UserDto> GetAll()
    {
        return userService.GetAll();
    }

    public Result<UserDto> GetById(int userId)
    {
        var user = userService.GetById(userId);
        if (user == null)
        {
            return Result<UserDto>.Failure("کاربر یافت نشد");
        }
        return Result<UserDto>.Success("کاربر با موفقیت یافت شد", user);
    }

    public Result<UserDto> GetByUserName(string username)
    {
        var user = userService.GetByUserName(username);
        if (user == null)
        {
            return Result<UserDto>.Failure("کاربر یافت نشد");
        }
        return Result<UserDto>.Success("کاربر با موفقیت یافت شد", user);
    }
}

