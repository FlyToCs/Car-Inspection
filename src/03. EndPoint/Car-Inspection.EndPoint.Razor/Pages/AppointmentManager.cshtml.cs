using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.DTOs;
using Car_Inspection.Domain.Core.CarModel.AppServices;
using Car_Inspection.Domain.Core.Company.AppServices;
using Car_Inspection.Domain.Core.Company.DTOs;
using Car_Inspection.EndPoint.Razor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace Car_Inspection.EndPoint.Razor.Pages;

[Authorize(Roles = "Admin,Operator")]
public class AppointmentManagerModel(
    IAppointmentAppService appointmentAppService,
    ICarModelAppService carModelAppService,
    ICompanyAppService companyAppService,
    IPersianDateConverterService persianDateConverterService) : PageModel
{


    [BindProperty(SupportsGet = true)]
    public string? FilterDate { get; set; } 

    [BindProperty(SupportsGet = true)]
    public string? FilterCompanyName { get; set; } 

    public List<AppointmentDto> Appointments { get; set; }
    public List<CompanyDto> Companies { get; set; }
    public Dictionary<int, string> CarModelNames { get; set; } = new Dictionary<int, string>();


    public void OnGet()
    {
   
        DateOnly? filterGregorianDate = persianDateConverterService.ToGregorianDate(FilterDate);

        Appointments = appointmentAppService.GetAllFiltered(filterGregorianDate, FilterCompanyName);

        Companies = companyAppService.GetAll();
        var allCarModels = carModelAppService.GetAll();
        CarModelNames = allCarModels.ToDictionary(m => m.Id, m => m.Name);
    }


    public IActionResult OnPostConfirm(int id)
    {
        var result = appointmentAppService.Confirm(id); 

        if (result.IsSuccess)
            TempData["Success"] = $"نوبت با شناسه {id} با موفقیت تایید شد.";
        else
            TempData["Error"] = $"خطا در تایید نوبت: {result.Message}";

        return RedirectToPage();
    }


    public IActionResult OnPostReject(int id)
    {
        var result = appointmentAppService.Reject(id); 

        if (result.IsSuccess)
            TempData["Success"] = $"نوبت با شناسه {id} رد شد.";
        else
            TempData["Error"] = $"خطا در رد نوبت: {result.Message}";

        return RedirectToPage();
    }


    public IActionResult OnPostDelete(int id)
    {
        var result = appointmentAppService.Delete(id); 

        if (result.IsSuccess)
            TempData["Success"] = $"نوبت با شناسه {id} حذف شد.";
        else
            TempData["Error"] = $"خطا در حذف نوبت: {result.Message}";

        return RedirectToPage();
    }
}