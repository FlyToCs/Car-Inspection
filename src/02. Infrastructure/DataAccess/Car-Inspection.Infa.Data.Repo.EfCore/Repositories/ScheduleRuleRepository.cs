using Car_Inspection.Domain.Core.ScheduleRule.Data;
using Car_Inspection.Domain.Core.ScheduleRule.DTOs;
using Car_Inspection.Domain.Core.ScheduleRule.Entities;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class ScheduleRuleRepository(AppDbContext context) : IScheduleRuleRepository
{
    public bool Create(CreateScheduleRuleDto scheduleRuleDto)
    {
        var scheduleRule = new ScheduleRule()
        {
            DayOfWeek = scheduleRuleDto.DayOfWeek,
            DefaultCapacity = scheduleRuleDto.DefaultCapacity,
            CompanyId = scheduleRuleDto.CompanyId
        };
        context.Add(scheduleRule);
        return context.SaveChanges() > 0;
    }

    public List<ScheduleRuleDto> GetAll()
    {
        return context.Set<ScheduleRule>()
            .Select(sr => new ScheduleRuleDto()
            {
                Id = sr.Id,
                DayOfWeek = sr.DayOfWeek,
                DefaultCapacity = sr.DefaultCapacity,
                CompanyId = sr.CompanyId
            }).ToList();
    }
}