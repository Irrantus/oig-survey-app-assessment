using Auth0.ManagementApi.Models;
using Common.Models.ViewModels;

namespace QuestionnaireApi.Services
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetUsersAsync();
    }
}
