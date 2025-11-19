using Car_Inspection.Domain.Core.User.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Car_Inspection.Domain.Core.User.Enums;

namespace Car_Inspection.EndPoint.Razor.Pages
{

    public class LoginInputModel
    {

        [Required(ErrorMessage = "نام کاربری/ایمیل اجباری است.")]
        [Display(Name = "نام کاربری")]
        public string? UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "رمز عبور اجباری است.")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }


    public class LoginModel(
        IUserAppService userAppService,
        CookieManagementService cookieService) : PageModel 
    {

        [BindProperty]
        public LoginInputModel Input { get; set; } = new LoginInputModel();

        public void OnGet()
        {
           
        }

        public IActionResult OnPost() 
        {
  
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var result = userAppService.Login(Input.UsernameOrEmail, Input.Password);

            if (result.IsSuccess)
            {

                string userRole = result.Data.Role.ToString();
                int userId = result.Data.Id; 


                cookieService.SignIn(
                    userId,
                    Input.UsernameOrEmail,
                    userRole,
                    Input.RememberMe);

                if (result.Data.Role == RoleEnum.Admin|| result.Data.Role == RoleEnum.Operator)
                {
                    return RedirectToPage("/AppointmentManager");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "نام کاربری یا رمز عبور اشتباه است.");
                return Page();
            }
        }
    }
}