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
}