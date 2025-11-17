using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.DateOverride.Entities;

public class DateOverride : BaseEntity
{

    public DateOnly SpecificDate { get; set; } 
    public int NewCapacity { get; set; } 
    public bool IsClosed { get; set; } = false; 
    public string? Reason { get; set; } 


    public int CompanyId { get; set; } 
    public Company.Entities.Company Company { get; set; }
}