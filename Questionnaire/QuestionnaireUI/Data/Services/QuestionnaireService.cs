using Common.Models;
using Common.Models.ViewModels.Questionnaire;
using QuestionnaireUI.Data.Helpers;

namespace QuestionnaireUI.Data.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        IApiService _apiService;

        private const string QUESTIONNAIRE_API_CONTROLLER_ENDPOINT = "Questionnaire";

        public QuestionnaireService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<QuestionnaireViewModel>> GetQuestionnairesAsync(SortParams? sortParams = null)
        {
            var uri = QUESTIONNAIRE_API_CONTROLLER_ENDPOINT;

            if (sortParams != null)
            {
                uri += $"?{nameof(SortParams.SortBy)}={sortParams.SortBy}&&{nameof(SortParams.SortDirection)}={sortParams.SortDirection}";
            }

            return await _apiService.GetAsync<List<QuestionnaireViewModel>>(uri);
        }

        public async Task<QuestionnaireViewModel> GetQuestionnaireById(int id)
        {
            return await _apiService.GetAsync<QuestionnaireViewModel>(QUESTIONNAIRE_API_CONTROLLER_ENDPOINT + $"/GetById/{id}");
        }

        public async Task<QuestionnaireViewModel> CreateQuestionnaire(CreateQuestionnaireViewModel data)
        {
            return await _apiService.PostAsync<CreateQuestionnaireViewModel, QuestionnaireViewModel>(QUESTIONNAIRE_API_CONTROLLER_ENDPOINT, data);
        }

        public async Task<QuestionnaireViewModel> UpdateQuestionnaire(UpdateQuestionnaireViewModel data)
        {
            return await _apiService.PutAsync<UpdateQuestionnaireViewModel, QuestionnaireViewModel>(QUESTIONNAIRE_API_CONTROLLER_ENDPOINT, data);
        }

        public async Task<bool> CloseQuestionnaire(int id)
        {
            return await _apiService.PatchAsync<bool>(QUESTIONNAIRE_API_CONTROLLER_ENDPOINT + $"/Close/{id}");
        }
    }
}
