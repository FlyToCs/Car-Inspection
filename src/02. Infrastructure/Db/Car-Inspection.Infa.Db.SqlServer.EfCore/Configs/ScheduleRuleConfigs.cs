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
    }
}