using Common.Models.ViewModels;

namespace QuestionnaireUI.Data.Helpers
{
    public interface IApiService
    {
        public Task<T> GetAsync<T>(string uri);
        public Task<TReturn> PostAsync<TInput, TReturn>(string uri, TInput data);
        public Task<TReturn> PutAsync<TInput, TReturn>(string uri, TInput data);
        public Task<TReturn> PatchAsync<TReturn>(string uri);
        public Task<TReturn> DeleteAsync<TReturn>(string uri);
    }
}
