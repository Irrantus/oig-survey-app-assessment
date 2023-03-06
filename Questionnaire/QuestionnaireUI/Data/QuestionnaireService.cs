using Common.Models.ViewModels;
using QuestionnaireUI.Data.Services;

namespace QuestionnaireUI.Data
{
    public class QuestionnaireService : IQuestionnaireService
    {
        IApiService _apiService;

        private const string QUESTIONNAIRE_API_CONTROLLER_ENDPOINT = "Questionnaire";

        public QuestionnaireService(IApiService apiService) {
            _apiService = apiService;
        }
        public async Task<List<QuestionnaireViewModel>> GetQuestionnaires()
        {
            return await _apiService.GetAsync<List<QuestionnaireViewModel>>(QUESTIONNAIRE_API_CONTROLLER_ENDPOINT);
        }
    }
}
