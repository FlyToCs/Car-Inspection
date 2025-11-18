using Car_Inspection.Domain.Core.User.Entities;
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

    }
}