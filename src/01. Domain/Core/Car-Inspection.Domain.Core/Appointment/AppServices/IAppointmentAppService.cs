using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.Appointment.DTOs;

namespace Car_Inspection.Domain.Core.Appointment.AppServices;

public interface IAppointmentAppService
{
    Result<bool> Create(CreateAppointmentDto appointmentDto);
    List<AppointmentDto> GetAll();
    List<AppointmentDto> GetAllPending();
    Result<bool> Confirm(int appointmentId);
    Result<bool> Reject(int appointmentId);
    Result<bool> Delete(int appointmentId);
    List<AppointmentDto> GetAllFiltered(DateOnly? date, string? companyName);
}