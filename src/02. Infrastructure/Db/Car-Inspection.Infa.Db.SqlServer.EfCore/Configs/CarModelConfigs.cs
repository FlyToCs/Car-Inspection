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

        builder.HasData(
           // ------------------ سایپا (CompanyId = 1) ------------------
           new CarModel { Id = 1, Name = "پراید 111", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 2, Name = "پراید 131", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 3, Name = "پراید 132", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 4, Name = "پراید 151", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 5, Name = "تیبا صندوقدار", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 6, Name = "تیبا 2", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 7, Name = "ساینا", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 8, Name = "ساینا S", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 9, Name = "کوییک", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 10, Name = "شاهین", CompanyId = 1, CreatedAt = new DateTime(2024, 1, 1) },

           // ------------------ ایران خودرو (CompanyId = 2) ------------------
           new CarModel { Id = 11, Name = "سمند LX", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 12, Name = "سمند EF7", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 13, Name = "پژو 206 تیپ 2", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 14, Name = "پژو 206 تیپ 5", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 15, Name = "پژو 206 صندوقدار", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 16, Name = "پژو 207 اتومات", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 17, Name = "پژو پارس", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 18, Name = "رانا", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 19, Name = "دنا معمولی", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) },
           new CarModel { Id = 20, Name = "دنا پلاس", CompanyId = 2, CreatedAt = new DateTime(2024, 1, 1) }
       );
    }
}