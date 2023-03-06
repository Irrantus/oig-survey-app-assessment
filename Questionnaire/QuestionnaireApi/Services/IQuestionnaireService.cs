using Common.Models;
using Common.Models.ViewModels;
using QuestionnaireApi.Common;
using QuestionnaireApi.Models.Dtos;

namespace QuestionnaireApi.Services
{
    public interface IQuestionnaireService
    {
        public IEnumerable<QuestionnaireViewModel> GetQuestionnaires(SortParams sortParams);
        public QuestionnaireViewModel GetQuestionnaireById(int id);
        public QuestionnaireViewModel CreateQuestionnaire(CreateQuestionnaireViewModel dto);
        public QuestionnaireViewModel UpdateQuestionnaire(UpdateQuestionnaireViewModel dto);
    }
}
