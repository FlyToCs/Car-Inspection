
using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.User.Enums;

namespace Car_Inspection.Domain.Core.User.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public RoleEnum Role { get; set; }

    public List<Appointment.Entities.Appointment> Appointments { get; set; }
}