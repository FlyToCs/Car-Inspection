using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.ScheduleRule.AppServices;
using Car_Inspection.Domain.Core.ScheduleRule.DTOs;
using Car_Inspection.Domain.Core.ScheduleRule.Services;

namespace Car_Inspection.Domain.AppService;

public class ScheduleRuleAppService(IScheduleRuleService scheduleRuleService) : IScheduleRuleAppService
{
    public Result<bool> Create(CreateScheduleRuleDto scheduleRuleDto)
    {

        var result = scheduleRuleService.Create(scheduleRuleDto);
        if (!result)
        {
            return Result<bool>.Failure("عملیات ثبت قانون زمان بندی با خطا مواجه شد");

        }
        return Result<bool>.Success("", result);
    }

    public List<ScheduleRuleDto> GetAll()
    {
        return scheduleRuleService.GetAll();
    }
}