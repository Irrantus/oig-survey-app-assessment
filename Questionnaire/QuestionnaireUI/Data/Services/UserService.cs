using Common.Models.ViewModels;
using QuestionnaireUI.Data.Helpers;

namespace QuestionnaireUI.Data.Services
{
    public class UserService : IUserService
    {
        IApiService _apiService;

        private const string User_API_CONTROLLER_ENDPOINT = "User";

        public UserService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return await _apiService.GetAsync<List<UserViewModel>>(User_API_CONTROLLER_ENDPOINT);
        }
    }
}
