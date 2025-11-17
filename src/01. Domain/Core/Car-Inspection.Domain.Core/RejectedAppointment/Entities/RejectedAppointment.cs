using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Car_Inspection.Domain.Core._common;

namespace Car_Inspection.Domain.Core.RejectedAppointment.Entities;

public class RejectedAppointment : BaseEntity
{

    public string LicensePlate { get; set; } 
    public int ProductionYear { get; set; } 
    public string? OwnerMobile { get; set; }
    public string? OwnerNationalId { get; set; }
    public string Reason { get; set; }


    public int? CarModelId { get; set; } 
    public virtual CarModel.Entities.CarModel CarModel { get; set; }
}