using Car_Inspection.Domain.Core.RejectedAppointment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class RejectedConfigs : IEntityTypeConfiguration<RejectedAppointment>
{
    public void Configure(EntityTypeBuilder<RejectedAppointment> builder)
    {
        builder.ToTable("RejectedAppointments");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Reason)
            .HasMaxLength(250);
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

        builder.HasOne(r => r.CarModel)
            .WithMany(cm => cm.RejectedLogs)
            .HasForeignKey(r => r.CarModelId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}