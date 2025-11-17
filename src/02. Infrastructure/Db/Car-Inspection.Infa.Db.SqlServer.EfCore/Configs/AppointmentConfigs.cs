using Car_Inspection.Domain.Core.Appointment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class AppointmentConfigs : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(a => a.Id);
        builder.Property(a=>a.LicensePlate).IsRequired().HasMaxLength(8);
        builder.Property(a=>a.ProductionYear).IsRequired();
        builder.Property(a=>a.OwnerMobile).IsRequired().HasMaxLength(15);
        builder.Property(a => a.OwnerNationalId).IsRequired().HasMaxLength(10);
        builder.Property(a => a.OwnerAddress).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Status).IsRequired();
        builder.Property(a => a.RejectionReason).HasMaxLength(200);

        builder.HasOne(a => a.CarModel)
            .WithMany(cm => cm.Appointments)
            .HasForeignKey(a => a.CarModelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}