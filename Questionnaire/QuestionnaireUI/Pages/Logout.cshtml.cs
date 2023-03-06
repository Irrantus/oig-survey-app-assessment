using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace QuestionnaireUI.Pages
{
    public class LogoutModel : PageModel
    {
        [Authorize]
        public async Task OnGet()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                 .WithRedirectUri("/")
                 .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
