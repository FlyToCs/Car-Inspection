using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_Inspection.EndPoint.Razor.Pages
{
    public class Index3Model(IAppointmentAppService appointmentAppService) : PageModel
    {



        [BindProperty]
        public CreateAppointmentDto Appointment { get; set; }


        public List<AppointmentDto> Appointments { get; set; }

        public void OnGet()
        {

            Appointments = appointmentAppService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = appointmentAppService.Create(Appointment);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return Page();
            }

            TempData["Success"] = result.Message;
            return RedirectToPage();
        }
    }
}