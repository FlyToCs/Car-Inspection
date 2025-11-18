namespace Car_Inspection.Domain.Core.RejectedAppointment.DTOs;

public class CreateRejectedAppointmentDto
{
    public string LicensePlate { get; set; }
    public int ProductionYear { get; set; }
    public string OwnerMobile { get; set; }
    public string OwnerNationalId { get; set; }
    public int CarModelId { get; set; }
    public string? Reason { get; set; }
}