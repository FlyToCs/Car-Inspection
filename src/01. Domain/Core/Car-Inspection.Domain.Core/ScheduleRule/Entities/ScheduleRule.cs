using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.ScheduleRule.Entities;

public class ScheduleRule : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; } 
    public int DefaultCapacity { get; set; } 

    public int CompanyId { get; set; } 
    public Company.Entities.Company Company { get; set; }
}