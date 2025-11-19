using Car_Inspection.Domain.Core.Appointment.Entities;
using Car_Inspection.Domain.Core.Appointment.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.Configs;

public class AppointmentConfigs : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.LicensePlate).IsRequired().HasMaxLength(20);
        builder.Property(a => a.ProductionYear).IsRequired();
        builder.Property(a => a.OwnerMobile).IsRequired().HasMaxLength(15);
        builder.Property(a => a.OwnerNationalId).IsRequired().HasMaxLength(10);
        builder.Property(a => a.OwnerAddress).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Status).IsRequired();
        builder.Property(a => a.RejectionReason).HasMaxLength(200);
        builder.Property(a => a.OwnerFirstName).HasMaxLength(100);
        builder.Property(a => a.OwnerLastName).HasMaxLength(100);

        builder.HasOne(a => a.CarModel)
            .WithMany(cm => cm.Appointments)
            .HasForeignKey(a => a.CarModelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasData(
          new Appointment
          {
              Id = 1,
              AppointmentDate = new DateOnly(2025, 11, 20),
              LicensePlate = "11ب12345",
              ProductionYear = 2021,
              OwnerFirstName = "محمد",
              OwnerLastName = "حسینی",
              OwnerMobile = "09121234567",
              OwnerNationalId = "0012345678",
              OwnerAddress = "تهران، میدان آزادی",
              Status = AppointmentStatus.Pending,
              CarModelId = 1,
              UserId = 4,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 2,
              AppointmentDate = new DateOnly(2025, 11, 21),
              LicensePlate = "22ج54321",
              ProductionYear = 2020,
              OwnerFirstName = "فاطمه",
              OwnerLastName = "شفیعی",
              OwnerMobile = "09129876543",
              OwnerNationalId = "0098765432",
              OwnerAddress = "اصفهان، پل خواجو",
              Status = AppointmentStatus.Approved,
              CarModelId = 2,
              UserId = 5,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 3,
              AppointmentDate = new DateOnly(2018, 5, 10),
              LicensePlate = "33د67890",
              ProductionYear = 2017,
              OwnerFirstName = "لیلا",
              OwnerLastName = "نرده ای",
              OwnerMobile = "09123456789",
              OwnerNationalId = "0023456789",
              OwnerAddress = "شیراز، حافظیه",
              Status = AppointmentStatus.Rejected,
              RejectionReason = "سال تولید پایین",
              CarModelId = 3,
              UserId = 4,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 4,
              AppointmentDate = new DateOnly(2025, 11, 22),
              LicensePlate = "44هـ11223",
              ProductionYear = 2019,
              OwnerFirstName = "علی",
              OwnerLastName = "رضایی",
              OwnerMobile = "09121112233",
              OwnerNationalId = "0031122334",
              OwnerAddress = "مشهد، حرم امام رضا",
              Status = AppointmentStatus.Pending,
              CarModelId = 4,
              UserId = 5,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 5,
              AppointmentDate = new DateOnly(2016, 7, 12),
              LicensePlate = "55و44556",
              ProductionYear = 2015,
              OwnerFirstName = "سنا",
              OwnerLastName = "محمدی",
              OwnerMobile = "09124445566",
              OwnerNationalId = "0044455667",
              OwnerAddress = "تبریز، بازار",
              Status = AppointmentStatus.Rejected,
              RejectionReason = "سال تولید پایین",
              CarModelId = 5,
              UserId = 4,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 6,
              AppointmentDate = new DateOnly(2025, 11, 23),
              LicensePlate = "66ز77889",
              ProductionYear = 2022,
              OwnerFirstName = "نیما",
              OwnerLastName = "شاد",
              OwnerMobile = "09127778899",
              OwnerNationalId = "0056677889",
              OwnerAddress = "کرج، عظیمیه",
              Status = AppointmentStatus.Approved,
              CarModelId = 6,
              UserId = 5,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 7,
              AppointmentDate = new DateOnly(2020, 3, 15),
              LicensePlate = "77ح33445",
              ProductionYear = 2018,
              OwnerFirstName = "مینا",
              OwnerLastName = "رسولی",
              OwnerMobile = "09123334455",
              OwnerNationalId = "0063344556",
              OwnerAddress = "رشت، میدان شهرداری",
              Status = AppointmentStatus.Rejected,
              RejectionReason = "سال تولید پایین",
              CarModelId = 7,
              UserId = 4,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 8,
              AppointmentDate = new DateOnly(2025, 11, 24),
              LicensePlate = "88ط55667",
              ProductionYear = 2021,
              OwnerFirstName = "حسین",
              OwnerLastName = "اکبری",
              OwnerMobile = "09125566778",
              OwnerNationalId = "0075566778",
              OwnerAddress = "قم، حرم",
              Status = AppointmentStatus.Pending,
              CarModelId = 8,
              UserId = 5,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 9,
              AppointmentDate = new DateOnly(2025, 11, 25),
              LicensePlate = "99ی88990",
              ProductionYear = 2020,
              OwnerFirstName = "زهرا",
              OwnerLastName = "شالی",
              OwnerMobile = "09128899001",
              OwnerNationalId = "0088899001",
              OwnerAddress = "اهواز، پل سفید",
              Status = AppointmentStatus.Approved,
              CarModelId = 9,
              UserId = 4,
              CreatedAt = new DateTime(2025, 1, 1)
          },
          new Appointment
          {
              Id = 10,
              AppointmentDate = new DateOnly(2017, 9, 5),
              LicensePlate = "00ک11223",
              ProductionYear = 2016,
              OwnerFirstName = "رامین",
              OwnerLastName = "کاظمی",
              OwnerMobile = "09121122334",
              OwnerNationalId = "0091122334",
              OwnerAddress = "کرمان، بازار",
              Status = AppointmentStatus.Rejected,
              RejectionReason = "سال تولید پایین",
              CarModelId = 10,
              UserId = 5,
              CreatedAt = new DateTime(2025, 1, 1)
          }
      );
    }
}