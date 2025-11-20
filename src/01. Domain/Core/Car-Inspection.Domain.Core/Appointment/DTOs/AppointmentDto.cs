using Car_Inspection.Domain.Core.Appointment.Enums;

namespace Car_Inspection.Domain.Core.Appointment.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateOnly AppointmentDate { get; set; }
    public string LicensePlate { get; set; }
    public int ProductionYear { get; set; }
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public string OwnerMobile { get; set; }
    public string OwnerNationalId { get; set; }
    public string OwnerAddress { get; set; }
    public AppointmentStatus Status { get; set; }
    public int CarModelId { get; set; }
    public int? UserId { get; set; }
    public List<string>? CarImgUrls { get; set; } = [];
}