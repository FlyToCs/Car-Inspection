using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;

namespace Car_Inspection.Domain.Core.RejectedAppointment.Data;

public interface IRejectedAppointmentRepository
{
    bool Create(CreateRejectedAppointmentDto createRejectedAppointment);
    List<RejectedAppointmentDto> GetAll();
}