using Car_Inspection.Domain.Core.ScheduleRule.DTOs;

namespace Car_Inspection.Domain.Core.ScheduleRule.Data;

public interface IScheduleRuleRepository
{
    bool Create(CreateScheduleRuleDto scheduleRuleDto);
    List<ScheduleRuleDto> GetAll();
    bool IsCompanyAllowedOnDay(int companyId, DayOfWeek dayOfWeek);
    bool IsCarModelAllowedOnDay(int carModelId, DayOfWeek dayOfWeek);
}