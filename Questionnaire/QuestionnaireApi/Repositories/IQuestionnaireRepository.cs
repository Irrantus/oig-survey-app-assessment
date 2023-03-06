using Common.Models;
using QuestionnaireApi.Data.Entities;
using QuestionnaireApi.Models.Dtos;

namespace QuestionnaireApi.Repositories
{
    public interface IQuestionnaireRepository
    {
        public IEnumerable<QuestionnaireDto> GetQuestionnaires(SortParams sortParams);
        public QuestionnaireDto GetQuestionnaireById(int id);
        public QuestionnaireDto CreateQuestionnaire(CreateQuestionnaireDto entity);
        public QuestionnaireDto UpdateQuestionnaire(UpdateQuestionnaireDto entity);
    }
}
