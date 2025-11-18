using Car_Inspection.Domain.Core.User.Data;
using Car_Inspection.Domain.Core.User.DTOs;
using Car_Inspection.Domain.Core.User.Entities;
using Car_Inspection.Domain.Core.User.Enums;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public bool Create(RegisterUserDto registerUserDto)
    {
        var user = new User()
        {
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Role = RoleEnum.Customer,
            PasswordHash = registerUserDto.Password,
            UserName = registerUserDto.Username,
        }; 
        
        context.Add(user);
        return context.SaveChanges()>0;
    }

    public List<UserDto> GetAll()
    {
       return context.Users.Select(u => new UserDto()
        {
            FirstName = u.FirstName,
            Id = u.Id,
            LastName = u.LastName,
            ImgUrl = u.ImgUrl,
            Role = u.Role,
            Username = u.UserName
        }).ToList();
    }

    public UserDto? GetById(int userId)
    {
        return context.Users.Where(u => u.Id == userId).Select(u => new UserDto()
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Username = u.UserName,
            Id = u.Id,
            ImgUrl = u.ImgUrl,
            Role = u.Role
        }).FirstOrDefault();
    }

    public UserDto? GetByUserName(string username)
    {
        return context.Users.FirstOrDefault(u => u.UserName == username) is not User user ? null : new UserDto()
        {
            FirstName = user.FirstName,
            Id = user.Id,
            LastName = user.LastName,
            ImgUrl = user.ImgUrl,
            Role = user.Role,
            Username = user.UserName
        };
    }

    public UserLoginDto? GetByUserNameForLogin(string username)
    {
        return context.Users.FirstOrDefault(u => u.UserName == username) is not User user ? null : new UserLoginDto()
        {
            FirstName = user.FirstName,
            Id = user.Id,
            LastName = user.LastName,
            ImgUrl = user.ImgUrl,
            Role = user.Role,
            Username = user.UserName,
            Password = user.PasswordHash
        };
    }
}