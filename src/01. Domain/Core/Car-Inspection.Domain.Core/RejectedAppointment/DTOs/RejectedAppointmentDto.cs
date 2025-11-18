namespace Car_Inspection.Domain.Core.RejectedAppointment.DTOs;

public class RejectedAppointmentDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string LicensePlate { get; set; }
    public int ProductionYear { get; set; }
    public string OwnerMobile { get; set; }
    public string OwnerNationalId { get; set; }
    public string? Reason { get; set; }
    public int CarModelId { get; set; }
}