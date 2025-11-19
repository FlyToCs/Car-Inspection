using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;

// توجه: این کلاس فرض می‌کند که شما Authentication Scheme را در Program.cs تنظیم کرده‌اید.
public class CookieManagementService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    public CookieManagementService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// ذخیره هویت کاربر در کوکی به‌صورت سنکرون.
    /// ⚠️ هشدار: در محیط‌های وب، استفاده از .GetAwaiter().GetResult() توصیه نمی‌شود و ممکن است باعث Deadlock شود.
    /// </summary>
    public void SignIn(int userId, string username, string userRole, bool isPersistent)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, userRole),
        };

        var claimsIdentity = new ClaimsIdentity(claims, AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = isPersistent,
            ExpiresUtc = isPersistent ? DateTimeOffset.UtcNow.AddDays(30) : (DateTimeOffset?)null
        };

        // اجرای سنکرون متد ناهمزمان
        _httpContextAccessor.HttpContext.SignInAsync(
            AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties).GetAwaiter().GetResult();
    }

    // متدهای دیگر
    public void SignOut()
    {
        _httpContextAccessor.HttpContext.SignOutAsync(AuthenticationScheme).GetAwaiter().GetResult();
    }

    public ClaimsPrincipal? GetCurrentUser()
    {
        return _httpContextAccessor.HttpContext?.User;
    }
}