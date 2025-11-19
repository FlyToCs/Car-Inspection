using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.Appointment.Services;
using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;
using Car_Inspection.Domain.Core.RejectedAppointment.Services;

namespace Car_Inspection.Domain.AppService;

public class AppointmentAppService(IAppointmentService appointmentService,
    IRejectedAppointmentService rejectedAppointmentService) : IAppointmentAppService
{
    public Result<bool> Create(CreateAppointmentDto appointmentDto)
    {
        var carAge = DateTime.Now.Year - appointmentDto.ProductionYear;

        if (carAge > 5)
        {
            rejectedAppointmentService.Create(new CreateRejectedAppointmentDto
            {
                LicensePlate = appointmentDto.LicensePlate,
                ProductionYear = appointmentDto.ProductionYear,
                OwnerMobile = appointmentDto.OwnerMobile,
                OwnerNationalId = appointmentDto.OwnerNationalId,
                CarModelId = appointmentDto.CarModelId,
                Reason = "Car is older than 5 years"
            });

            return Result<bool>.Failure("خودرو شما بیشتر از 5 سالشه از پذیرش خوردو هاس سالمند معذوریم");
        }

        appointmentService.Create(appointmentDto);
        return Result<bool>.Success("عملیات با موفقیت انجام شد",true);
    }


    public List<AppointmentDto> GetAll()
    {
        return appointmentService.GetAll();
    }

    public List<AppointmentDto> GetAllPending()
    {
        return appointmentService.GetAllPending();
    }
}