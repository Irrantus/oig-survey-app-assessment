using Common.Models;
using Common.Models.ViewModels.Questionnaire;

namespace QuestionnaireUI.Data.Services
{
    public interface IQuestionnaireService
    {
        public Task<List<QuestionnaireViewModel>> GetQuestionnairesAsync(SortParams? sortParams = null);
        public Task<QuestionnaireViewModel> GetQuestionnaireById(int id);
        public Task<QuestionnaireViewModel> CreateQuestionnaire(CreateQuestionnaireViewModel data);
        public Task<QuestionnaireViewModel> UpdateQuestionnaire(UpdateQuestionnaireViewModel data);
        public Task<bool> CloseQuestionnaire(int id);
    }
}
