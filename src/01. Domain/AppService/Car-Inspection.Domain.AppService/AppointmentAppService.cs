using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.Appointment.Services;
using Car_Inspection.Domain.Core.CarModel.AppServices;
using Car_Inspection.Domain.Core.CarModel.Services;
using Car_Inspection.Domain.Core.DateOverride.Services;
using Car_Inspection.Domain.Core.RejectedAppointment.Services;
using Car_Inspection.Domain.Core.ScheduleRule.Services;

namespace Car_Inspection.Domain.AppService;

public class AppointmentAppService(
    IAppointmentService appointmentService,        
    IScheduleRuleService scheduleRuleService,
    IDateOverrideService dateOverrideService,
    ICarModelService carModelService
) : IAppointmentAppService
{
    private const int DefaultDailyCapacity = 50;

    public Result<bool> Create(CreateAppointmentDto appointmentDto)
    {
        var carAge = DateTime.Now.Year - appointmentDto.ProductionYear;
        if (carAge > 5)
        {
            return Result<bool>.Failure("خودرو شما بیشتر از 5 سالشه...");
        }

        var appointmentDate = appointmentDto.AppointmentDate;
        var appointmentDayOfWeek = (DayOfWeek)appointmentDate.DayOfWeek;

      
        if (dateOverrideService.IsDateBlocked(appointmentDate))
        {
            return Result<bool>.Failure("تاریخ انتخاب شده، توسط مدیریت مسدود شده است.");
        }

        var companyId = carModelService.GetCompanyIdByCarModelId(appointmentDto.CarModelId);

        if (!scheduleRuleService.IsCompanyAllowedOnDay(companyId, appointmentDayOfWeek))
        {
            return Result<bool>.Failure($"کمپانی سازنده خودروی شما برای ثبت نوبت در روز {appointmentDayOfWeek} مجاز نیست.");
        }

        var maxCapacity = dateOverrideService.GetMaxCapacityForDate(appointmentDate) ?? DefaultDailyCapacity;

       
        var appointmentsCount = appointmentService.GetCountByDate(appointmentDate);

        if (appointmentsCount >= maxCapacity)
        {
            return Result<bool>.Failure($"متأسفانه ظرفیت روز {appointmentDate} تکمیل شده است. (حداکثر ظرفیت: {maxCapacity})");
        }
    
        appointmentService.Create(appointmentDto);
        return Result<bool>.Success("عملیات با موفقیت انجام شد", true);
    }

    public List<AppointmentDto> GetAll()
    {
        return appointmentService.GetAll();
    }

    public List<AppointmentDto> GetAllPending()
    {
        return appointmentService.GetAllPending();
    }



    public Result<bool> Confirm(int appointmentId)
    {
        try
        {
            bool success = appointmentService.ChangeStatusToConfirmed(appointmentId);
            if (success)
            {
                return Result<bool>.Success($"نوبت با شناسه {appointmentId} با موفقیت تایید شد.", true);
            }
            return Result<bool>.Failure($"تایید نوبت با شناسه {appointmentId} با شکست مواجه شد.");
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"خطای سیستمی: {ex.Message}");
        }
    }

    public Result<bool> Reject(int appointmentId)
    {
        bool success = appointmentService.ChangeStatusToRejected(appointmentId);
        if (success)
        {
            return Result<bool>.Success($"نوبت با شناسه {appointmentId} با موفقیت رد شد.", true);
        }
        return Result<bool>.Failure($"رد نوبت با شناسه {appointmentId} با شکست مواجه شد.");

    }

    public Result<bool> Delete(int appointmentId)
    {
    
        bool success = appointmentService.Delete(appointmentId);
        if (success)
        {
            return Result<bool>.Success($"نوبت با شناسه {appointmentId} با موفقیت حذف شد.", true);
        }
        return Result<bool>.Failure($"حذف نوبت با شناسه {appointmentId} با شکست مواجه شد.");

    }
}