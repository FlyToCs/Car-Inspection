using Car_Inspection.Domain.Core.Company.Entities;
using Car_Inspection.Domain.Core.DateOverride.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class DateOverrideConfigs : IEntityTypeConfiguration<DateOverride>
{
    public void Configure(EntityTypeBuilder<DateOverride> builder)
    {
        builder.ToTable("DateOverrides");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.SpecificDate).IsRequired();
        builder.Property(d => d.Reason).HasMaxLength(250);
        builder.Property(d => d.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

        builder.HasOne(d => d.Company)
               .WithMany(c => c.DateOverrides)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}