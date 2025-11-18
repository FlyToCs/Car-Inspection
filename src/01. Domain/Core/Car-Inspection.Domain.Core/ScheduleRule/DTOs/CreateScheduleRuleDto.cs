namespace Car_Inspection.Domain.Core.ScheduleRule.DTOs;

public class CreateScheduleRuleDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public int DefaultCapacity { get; set; }
    public int CompanyId { get; set; }
}