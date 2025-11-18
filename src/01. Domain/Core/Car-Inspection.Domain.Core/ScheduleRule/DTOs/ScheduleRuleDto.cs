namespace Car_Inspection.Domain.Core.ScheduleRule.DTOs;

public class ScheduleRuleDto
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int DefaultCapacity { get; set; }
    public int CompanyId { get; set; }
}