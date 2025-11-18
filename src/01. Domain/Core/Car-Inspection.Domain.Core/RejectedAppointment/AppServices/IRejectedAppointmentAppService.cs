using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;

namespace Car_Inspection.Domain.Core.RejectedAppointment.AppServices;

public interface IRejectedAppointmentAppService
{
    Result<bool> Create(CreateRejectedAppointmentDto createRejectedAppointment);
    List<RejectedAppointmentDto> GetAll();
}