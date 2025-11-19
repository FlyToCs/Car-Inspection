using Car_Inspection.Domain.Core.Appointment.Data;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.Appointment.Services;

namespace Car_Inspection.Domain.Service;

public class AppointmentService(IAppointmentRepository appointmentRepo) : IAppointmentService
{
    public bool Create(CreateAppointmentDto appointmentDto)
    {
        return appointmentRepo.Create(appointmentDto);
    }

    public List<AppointmentDto> GetAll()
    {
        return appointmentRepo.GetAll();
    }

    public List<AppointmentDto> GetAllPending()
    {
        return appointmentRepo.GetAllPending();
    }

    public int GetCountByDate(DateOnly date)
    {
        return appointmentRepo.GetCountByDate(date);
    }

    public bool ChangeStatusToConfirmed(int appointmentId)
    {
        return appointmentRepo.ChangeStatusToConfirmed(appointmentId);
    }

    public bool ChangeStatusToRejected(int appointmentId)
    {
        return appointmentRepo.ChangeStatusToRejected(appointmentId);
    }

    public bool Delete(int appointmentId)
    {
        return appointmentRepo.Delete(appointmentId);
    }
}