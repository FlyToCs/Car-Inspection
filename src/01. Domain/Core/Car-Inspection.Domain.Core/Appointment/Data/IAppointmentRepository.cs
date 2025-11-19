using Car_Inspection.Domain.Core.Appointment.DTOs;

namespace Car_Inspection.Domain.Core.Appointment.Data;

public interface IAppointmentRepository
{
    bool Create(CreateAppointmentDto appointmentDto);
    List<AppointmentDto> GetAll();
    List<AppointmentDto> GetAllPending();
}