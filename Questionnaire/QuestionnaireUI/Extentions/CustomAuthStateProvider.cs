using Microsoft.AspNetCore.Components.Authorization;
using System.Data;
using System.Security.Claims;

namespace QuestionnaireUI.Extentions
{
    public class CustomAuthStateProvider
    {

        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthStateProvider(AuthenticationStateProvider authenticationStateProvider, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetUserName()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();

            return state.User.Identity.Name ?? string.Empty;
        }

        public string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAdmin()
        {
            return GetUserRole() == "Admin";
        }
        private string GetUserRole()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            return principal.FindFirstValue(ClaimTypes.Role);
        }
    }
}
