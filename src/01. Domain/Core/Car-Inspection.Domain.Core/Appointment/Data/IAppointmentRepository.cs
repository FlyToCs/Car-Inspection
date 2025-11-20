using Car_Inspection.Domain.Core.Appointment.DTOs;

namespace Car_Inspection.Domain.Core.Appointment.Data;

public interface IAppointmentRepository
{
    bool Create(CreateAppointmentDto appointmentDto);
    List<AppointmentDto> GetAll();
    List<AppointmentDto> GetAllPending();
    int GetCountByDate(DateOnly date);

    bool ChangeStatusToConfirmed(int appointmentId);
    bool ChangeStatusToRejected(int appointmentId);
    bool Delete(int appointmentId);
    List<AppointmentDto> GetAllFiltered(DateOnly? date, string? companyName);
    DateOnly? GetLastAppointmentDateByLicensePlate(string licensePlate);
}