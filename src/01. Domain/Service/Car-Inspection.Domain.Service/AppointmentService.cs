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
}