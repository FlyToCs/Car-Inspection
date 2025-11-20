using System.Reflection.Metadata.Ecma335;
using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.Appointment.Enums;

namespace Car_Inspection.Domain.Core.Appointment.Entities;

public class Appointment : BaseEntity
{
    public DateOnly AppointmentDate { get; set; }
    public string LicensePlate { get; set; }
    public int ProductionYear { get; set; }
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public string OwnerMobile { get; set; }
    public string OwnerNationalId { get; set; }
    public string OwnerAddress { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? RejectionReason { get; set; }

    public int CarModelId { get; set; }
    public CarModel.Entities.CarModel CarModel { get; set; }

    public int? UserId { get; set; }
    public User.Entities.User User { get; set; }

    public List<CarImg> CarImgUrls { get; set; }

}