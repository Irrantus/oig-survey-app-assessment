using Common.Models.ViewModels;

namespace QuestionnaireUI.Data.Services
{
    public interface IApiService
    {
        public Task<T> GetAsync<T>(string uri);
    }
}
