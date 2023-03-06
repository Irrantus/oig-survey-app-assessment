using Common.Models.ViewModels;

namespace QuestionnaireUI.Data
{
    public interface IQuestionnaireService
    {
        public Task<List<QuestionnaireViewModel>> GetQuestionnaires();
    }
}
