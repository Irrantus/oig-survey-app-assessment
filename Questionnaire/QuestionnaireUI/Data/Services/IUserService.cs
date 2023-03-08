using Common.Models.ViewModels;

namespace QuestionnaireUI.Data.Services
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetUsersAsync();
    }
}
