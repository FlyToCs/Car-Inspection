using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.CarModel.AppServices;
using Car_Inspection.Domain.Core.CarModel.DTOs;
using Car_Inspection.Domain.Core.Company.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Car_Inspection.EndPoint.Razor.Services.File;

namespace Car_Inspection.EndPoint.Razor.Pages
{
    public class IndexModel(
        IAppointmentAppService appointmentAppService,
        ICarModelAppService carModelAppService,
        ICompanyAppService companyAppService,
        IFileUploaderService fileUploaderService) : PageModel
    {
        [BindProperty]
        public CreateAppointmentDto Appointment { get; set; }

        [BindProperty]
        public List<IFormFile> CarImages { get; set; } = new List<IFormFile>();

        public List<CarModelDto> CarModels { get; set; }
        public List<AppointmentDto> Appointments { get; set; }

        public void OnGet()
        {
            CarModels = carModelAppService.GetAll();
            Appointments = appointmentAppService.GetAll();
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    CarModels = carModelAppService.GetAll();
            //    return Page();
            //}

           
            const string folder = "car_inspection_uploads";
            List<string> imgUrls = fileUploaderService.UploadImages(CarImages, folder);
            Appointment.CarImgUrls = imgUrls;
            var result = appointmentAppService.Create(Appointment);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message!);
                CarModels = carModelAppService.GetAll();
                return Page();
            }

            TempData["Success"] = result.Message;
            return RedirectToPage();
        }
    }
}