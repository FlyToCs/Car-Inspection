using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.ScheduleRule.DTOs;

namespace Car_Inspection.Domain.Core.ScheduleRule.AppServices;

public interface IScheduleRuleAppService
{
    Result<bool> Create(CreateScheduleRuleDto scheduleRuleDto);
    List<ScheduleRuleDto> GetAll();
}