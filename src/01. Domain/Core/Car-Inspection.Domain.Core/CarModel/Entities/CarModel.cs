using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Inspection.Domain.Core.CarModel.Entities;

public class CarModel
{

    public string Name { get; set; } 


    public int CompanyId { get; set; } 
    public virtual Company.Entities.Company Company { get; set; }

    public List<Appointment.Entities.Appointment> Appointments { get; set; } = [];
    public List<RejectedAppointment.Entities.RejectedAppointment> RejectedLogs { get; set; } = [];
}