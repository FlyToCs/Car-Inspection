using Car_Inspection.Domain.Core.ScheduleRule.Data;
using Car_Inspection.Domain.Core.ScheduleRule.DTOs;
using Car_Inspection.Domain.Core.ScheduleRule.Services;

namespace Car_Inspection.Domain.Service;

public class ScheduleRuleService(IScheduleRuleRepository scheduleRuleRepo) : IScheduleRuleService
{
    public bool Create(CreateScheduleRuleDto scheduleRuleDto)
    {
        return scheduleRuleRepo.Create(scheduleRuleDto);
    }

    public List<ScheduleRuleDto> GetAll()
    {
        return scheduleRuleRepo.GetAll();
    }

    public bool IsCarModelAllowedOnDay(int carModelId, DayOfWeek dayOfWeek)
    {
        return scheduleRuleRepo.IsCarModelAllowedOnDay(carModelId, dayOfWeek);
    }

    public bool IsCompanyAllowedOnDay(int companyId, DayOfWeek appointmentDayOfWeek)
    {
        return scheduleRuleRepo.IsCompanyAllowedOnDay(companyId, appointmentDayOfWeek);
    }
}