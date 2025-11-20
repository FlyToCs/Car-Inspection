using Car_Inspection.Domain.Core.Appointment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class CarImgConfigs : IEntityTypeConfiguration<CarImg>
{
    public void Configure(EntityTypeBuilder<CarImg> builder)
    {
        builder.ToTable("CarImgUrls");
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.ImgUrl)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(ci => ci.Appointment)
            .WithMany(a => a.CarImgUrls).HasForeignKey(x => x.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}