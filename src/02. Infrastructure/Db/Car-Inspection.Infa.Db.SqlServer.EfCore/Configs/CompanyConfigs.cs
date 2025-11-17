using Car_Inspection.Domain.Core.Company.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class CompanyConfigs : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

        builder.HasMany(c => c.CarModels)
            .WithOne(cm => cm.Company)
            .HasForeignKey(cm => cm.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.ScheduleRules)
               .WithOne(sr => sr.Company)
               .HasForeignKey(sr => sr.CompanyId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.DateOverrides)
               .WithOne(d => d.Company)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}