using Car_Inspection.Domain.Core.User.Entities;
using Car_Inspection.Domain.Core.User.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class UserConfigs : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(250);
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();
        builder.Property(u => u.ImgUrl).HasMaxLength(100);

        builder.HasMany(u=>u.Appointments).WithOne(a=>a.User).HasForeignKey(a=>a.UserId);

        builder.HasData(
            // Admin
            new User
            {
                Id = 1,
                FirstName = "محمدحسین",
                LastName = "دهقانی",
                UserName = "admin",
                PasswordHash = "Ntbi9dzykpCIkY2SS2CsAA==:1ILjnLtYlBsO6QJDJ4qOlh7Ul7z1ws3SIBUEW62MEjU=",
                Role = RoleEnum.Admin,
                ImgUrl = null,
                CreatedAt = new DateTime(2024, 1, 1)
            },

            // Operators
            new User
            {
                Id = 2,
                FirstName = "مهدی",
                LastName = "کریمی",
                UserName = "operator1",
                PasswordHash = "Ntbi9dzykpCIkY2SS2CsAA==:1ILjnLtYlBsO6QJDJ4qOlh7Ul7z1ws3SIBUEW62MEjU=",
                Role = RoleEnum.Operator,
                ImgUrl = null,
                CreatedAt = new DateTime(2024, 1, 1)
            },
            new User
            {
                Id = 3,
                FirstName = "سارا",
                LastName = "موسوی",
                UserName = "operator2",
                PasswordHash = "Ntbi9dzykpCIkY2SS2CsAA==:1ILjnLtYlBsO6QJDJ4qOlh7Ul7z1ws3SIBUEW62MEjU=",
                Role = RoleEnum.Operator,
                ImgUrl = null,
                CreatedAt = new DateTime(2024, 1, 1)
            },

            // Members
            new User
            {
                Id = 4,
                FirstName = "علی",
                LastName = "محمودی",
                UserName = "member1",
                PasswordHash = "Ntbi9dzykpCIkY2SS2CsAA==:1ILjnLtYlBsO6QJDJ4qOlh7Ul7z1ws3SIBUEW62MEjU=",
                Role = RoleEnum.Customer,
                ImgUrl = null,
                CreatedAt = new DateTime(2024, 1, 1)
            },
            new User
            {
                Id = 5,
                FirstName = "زهرا",
                LastName = "احمدی",
                UserName = "member2",
                PasswordHash = "Ntbi9dzykpCIkY2SS2CsAA==:1ILjnLtYlBsO6QJDJ4qOlh7Ul7z1ws3SIBUEW62MEjU=",
                Role = RoleEnum.Customer,
                ImgUrl = null,
                CreatedAt = new DateTime(2024, 1, 1)
            }
        );

    }
}