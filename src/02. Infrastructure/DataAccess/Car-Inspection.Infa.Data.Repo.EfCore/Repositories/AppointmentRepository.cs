using Car_Inspection.Domain.Core.Appointment.Data;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.Appointment.Entities;
using Car_Inspection.Domain.Core.Appointment.Enums;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;
using Microsoft.EntityFrameworkCore;

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
            UserId = appointmentDto.UserId,
            Status = AppointmentStatus.Pending,
            CarImgUrls = appointmentDto.CarImgUrls
                .Select(url => new CarImg { ImgUrl = url })
                .ToList()
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
            UserId = a.UserId,
            CarImgUrls = a.CarImgUrls.Select(ci => ci.ImgUrl).ToList()
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
                UserId = a.UserId,
                CarImgUrls = a.CarImgUrls.Select(ci => ci.ImgUrl).ToList()
            }).ToList();
    }

    public int GetCountByDate(DateOnly date)
    {
        return context.Appointments
            .Count(a => a.AppointmentDate == date);
    }

    public bool ChangeStatusToConfirmed(int appointmentId)
    {
       var result =  context.Appointments.Where(a => a.Id == appointmentId).ExecuteUpdate(setter => setter.SetProperty(
            a => a.Status, AppointmentStatus.Approved
        ));
        return result > 0;
    }

    public bool ChangeStatusToRejected(int appointmentId)
    {
        var result = context.Appointments.Where(a => a.Id == appointmentId).ExecuteUpdate(setter => setter.SetProperty(
            a => a.Status, AppointmentStatus.Rejected
        ));
        return result > 0;
    }

    public bool Delete(int appointmentId)
    {
        var result = context.Appointments.Where(a => a.Id == appointmentId).ExecuteDelete();
        return result > 0;
    }

    public List<AppointmentDto> GetAllFiltered(DateOnly? date, string? companyName)
    {
        var query = context.Appointments.AsQueryable();
        if (date.HasValue)
        {
            query = query.Where(a => a.AppointmentDate == date.Value);
        }
        if (!string.IsNullOrEmpty(companyName))
        {
            query = query.Where(a => a.CarModel.Company.Name.Contains(companyName));
        }
        return query.Select(a => new AppointmentDto()
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
            UserId = a.UserId,
            CarImgUrls = a.CarImgUrls.Select(ci => ci.ImgUrl).ToList()
        }).ToList();
    }

    public DateOnly? GetLastAppointmentDateByLicensePlate(string licensePlate)
    {
        return  context.Appointments
            .AsNoTracking()
            .Where(a => a.LicensePlate == licensePlate)
            .OrderByDescending(a => a.AppointmentDate)
            .Select(a => a.AppointmentDate)
            .FirstOrDefault(); 
    }
}