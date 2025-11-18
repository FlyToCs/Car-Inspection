using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.RejectedAppointment.AppServices;
using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;
using Car_Inspection.Domain.Core.RejectedAppointment.Services;

namespace Car_Inspection.Domain.AppService;

public class RejectedAppointmentAppService(IRejectedAppointmentService rejectedAppointmentService) :IRejectedAppointmentAppService
{
    public Result<bool> Create(CreateRejectedAppointmentDto createRejectedAppointment)
    {
       var result =  rejectedAppointmentService.Create(createRejectedAppointment);
       if (!result)
       {
           Result<bool>.Failure("ثبت درخواست معیوب با خطا مواجه شد");
       }

       return Result<bool>.Success("", result);
    }

    public List<RejectedAppointmentDto> GetAll()
    {
        return rejectedAppointmentService.GetAll();
    }
}