using Car_Inspection.Domain.Core.ScheduleRule.DTOs;

namespace Car_Inspection.Domain.Core.ScheduleRule.Services;

public interface IScheduleRuleService
{
    bool Create(CreateScheduleRuleDto scheduleRuleDto);
    List<ScheduleRuleDto> GetAll();
    bool IsCarModelAllowedOnDay(int carModelId, DayOfWeek dayOfWeek);
    bool IsCompanyAllowedOnDay(int companyId, DayOfWeek appointmentDayOfWeek);
}