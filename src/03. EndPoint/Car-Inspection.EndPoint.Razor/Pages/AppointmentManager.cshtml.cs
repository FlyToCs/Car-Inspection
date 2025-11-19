
using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AppointmentManagerModel(IAppointmentAppService appointmentAppService): PageModel
{

    public List<AppointmentDto> Appointments { get; set; }

    public void OnGet()
    {
        // Call GetAll and assign to property
        Appointments = appointmentAppService.GetAll();
    }
}