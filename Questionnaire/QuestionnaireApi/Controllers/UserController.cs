using Auth0.ManagementApi.Models;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireApi.Services;

namespace QuestionnaireApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }
    }
}
