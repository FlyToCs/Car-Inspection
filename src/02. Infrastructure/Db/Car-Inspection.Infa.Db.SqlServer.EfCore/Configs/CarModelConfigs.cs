using Car_Inspection.Domain.Core.CarModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class CarModelConfigs : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("CarModels");
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(cm => cm.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

        builder.HasOne(cm => cm.Company)
            .WithMany(c => c.CarModels)
            .HasForeignKey(cm => cm.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(cm => cm.Appointments)
            .WithOne(c => c.CarModel)
            .HasForeignKey(cm=>cm.CarModelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(cm => cm.RejectedLogs)
            .WithOne(r => r.CarModel)
            .HasForeignKey(r => r.CarModelId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}