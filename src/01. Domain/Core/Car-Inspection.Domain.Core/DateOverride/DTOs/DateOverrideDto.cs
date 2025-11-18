namespace Car_Inspection.Domain.Core.DateOverride.DTOs;

public class DateOverrideDto
{
    public int Id { get; set; }
    public DateOnly SpecificDate { get; set; }
    public int NewCapacity { get; set; }
    public bool IsClosed { get; set; } = false;
    public string? Reason { get; set; }


    public int CompanyId { get; set; }
}