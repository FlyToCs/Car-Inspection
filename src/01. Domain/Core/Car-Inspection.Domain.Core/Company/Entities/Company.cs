

using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.Company.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } 
    public List<CarModel.Entities.CarModel> CarModels { get; set; } = [];
    public List<ScheduleRule.Entities.ScheduleRule> ScheduleRules { get; set; } = [];
    public  List<DateOverride.Entities.DateOverride> DateOverrides { get; set; } = [];
}