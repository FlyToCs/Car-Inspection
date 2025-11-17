using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.CarModel.Entities;

public class CarModel : BaseEntity
{
    public string Name { get; set; } 

    public int CompanyId { get; set; } 
    public virtual Company.Entities.Company Company { get; set; }

    public List<Appointment.Entities.Appointment> Appointments { get; set; } = [];
    public List<RejectedAppointment.Entities.RejectedAppointment> RejectedLogs { get; set; } = [];
}