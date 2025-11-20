using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.Appointment.Entities;

public class CarImg : BaseEntity
{
    public string ImgUrl { get; set; }
    public Appointment Appointment { get; set; }
    public int AppointmentId { get; set; }
}