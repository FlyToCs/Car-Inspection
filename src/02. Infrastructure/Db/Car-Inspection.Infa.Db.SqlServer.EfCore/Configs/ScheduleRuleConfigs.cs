using Car_Inspection.Domain.Core.ScheduleRule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class ScheduleRuleConfigs : IEntityTypeConfiguration<ScheduleRule>
{
    public void Configure(EntityTypeBuilder<ScheduleRule> builder)
    {
        builder.ToTable("ScheduleRules");
        builder.HasKey(sr => sr.Id);
        builder.Property(sr => sr.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

        builder.HasOne(sr => sr.Company)
               .WithMany(c => c.ScheduleRules)
               .HasForeignKey(sr => sr.CompanyId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            // ---------------- سایپا (CompanyId = 1) - روزهای فرد ----------------
            new ScheduleRule { Id = 1, DayOfWeek = DayOfWeek.Saturday, DefaultCapacity = 20, CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
            new ScheduleRule { Id = 2, DayOfWeek = DayOfWeek.Monday, DefaultCapacity = 20, CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
            new ScheduleRule { Id = 3, DayOfWeek = DayOfWeek.Wednesday, DefaultCapacity = 20, CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
            new ScheduleRule { Id = 4, DayOfWeek = DayOfWeek.Friday, DefaultCapacity = 20, CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },

            // --------------- ایران خودرو (CompanyId = 2) - روزهای زوج ----------------
            new ScheduleRule { Id = 5, DayOfWeek = DayOfWeek.Sunday, DefaultCapacity = 20, CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
            new ScheduleRule { Id = 6, DayOfWeek = DayOfWeek.Tuesday, DefaultCapacity = 20, CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
            new ScheduleRule { Id = 7, DayOfWeek = DayOfWeek.Thursday, DefaultCapacity = 20, CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) }
        );
    }
}