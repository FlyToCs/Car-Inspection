using Car_Inspection.Domain.Core.RejectedAppointment.Data;
using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;
using Car_Inspection.Domain.Core.RejectedAppointment.Services;

namespace Car_Inspection.Domain.Service;

public class RejectedAppointmentService(IRejectedAppointmentRepository rejectedAppointmentRepo) : IRejectedAppointmentService
{
    public bool Create(CreateRejectedAppointmentDto createRejectedAppointment)
    {
       return rejectedAppointmentRepo.Create(createRejectedAppointment);
    }

    public List<RejectedAppointmentDto> GetAll()
    {
        return rejectedAppointmentRepo.GetAll();
    }
}