using Car_Inspection.Domain.Core.Appointment.Data;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.Appointment.Entities;
using Car_Inspection.Domain.Core.Appointment.Enums;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
{
    public bool Create(CreateAppointmentDto appointmentDto)
    {
        var appointment = new Appointment()
        {
            AppointmentDate = appointmentDto.AppointmentDate,
            LicensePlate = appointmentDto.LicensePlate,
            ProductionYear = appointmentDto.ProductionYear,
            OwnerFirstName = appointmentDto.OwnerFirstName,
            OwnerLastName = appointmentDto.OwnerLastName,
            OwnerMobile = appointmentDto.OwnerMobile,
            OwnerNationalId = appointmentDto.OwnerNationalId,
            OwnerAddress = appointmentDto.OwnerAddress,
            CarModelId = appointmentDto.CarModelId,
            UserId = appointmentDto.UserId
        };
        context.Appointments.Add(appointment);
        return context.SaveChanges() > 0;
    }

    public List<AppointmentDto> GetAll()
    {
        return context.Appointments.Select(a => new AppointmentDto()
        {
            Id = a.Id,
            AppointmentDate = a.AppointmentDate,
            LicensePlate = a.LicensePlate,
            ProductionYear = a.ProductionYear,
            OwnerFirstName = a.OwnerFirstName,
            OwnerLastName = a.OwnerLastName,
            OwnerMobile = a.OwnerMobile,
            OwnerNationalId = a.OwnerNationalId,
            OwnerAddress = a.OwnerAddress,
            Status = a.Status,
            CarModelId = a.CarModelId,
            UserId = a.UserId
        }).ToList();
    }

    public List<AppointmentDto> GetAllPending()
    {
        return context.Appointments
            .Where(a => a.Status == AppointmentStatus.Pending)
            .Select(a => new AppointmentDto()
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                LicensePlate = a.LicensePlate,
                OwnerFirstName = a.OwnerFirstName,
                OwnerLastName = a.OwnerLastName,
                ProductionYear = a.ProductionYear,
                OwnerMobile = a.OwnerMobile,
                OwnerNationalId = a.OwnerNationalId,
                OwnerAddress = a.OwnerAddress,
                Status = a.Status,
                CarModelId = a.CarModelId,
                UserId = a.UserId
            }).ToList();
    }
}