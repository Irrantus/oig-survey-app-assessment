using Common.Models;
using Common.Models.ViewModels.Questionnaire;

namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireService
    {
        public IEnumerable<QuestionnaireViewModel> GetQuestionnaires(SortParams sortParams);
        public QuestionnaireViewModel GetQuestionnaireById(int id);
        public int GetQuestionnairesCountByOwnerId(string ownerId);
        public QuestionnaireViewModel CreateQuestionnaire(CreateQuestionnaireViewModel dto);
        public QuestionnaireViewModel UpdateQuestionnaire(UpdateQuestionnaireViewModel dto);
        public bool CloseQuestionnaire(int id);
    }
}
