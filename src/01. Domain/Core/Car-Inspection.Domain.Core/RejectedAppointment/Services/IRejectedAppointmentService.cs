using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;

namespace Car_Inspection.Domain.Core.RejectedAppointment.Services;

public interface IRejectedAppointmentService
{
    bool Create(CreateRejectedAppointmentDto createRejectedAppointment);
    List<RejectedAppointmentDto> GetAll();
}