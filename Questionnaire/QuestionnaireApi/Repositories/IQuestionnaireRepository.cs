using Common.Models;
using QuestionnaireApi.Models.Dtos;

namespace QuestionnaireApi.Repositories
{
    public interface IQuestionnaireRepository
    {
        public IEnumerable<QuestionnaireDto> GetQuestionnaires(SortParams sortParams);
        public QuestionnaireDto GetQuestionnaireById(int id);
        public int GetQuestionnairesCountByOwnerId(string ownerId);
        public QuestionnaireDto CreateQuestionnaire(CreateQuestionnaireDto entity);
        public QuestionnaireDto UpdateQuestionnaire(UpdateQuestionnaireDto entity);
        public bool CloseQuestionnaire(int id);
    }
}
