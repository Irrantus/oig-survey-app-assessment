using Common.Enums;
using Common.Models;
using QuestionnaireApi.Common;
using QuestionnaireApi.Data;
using QuestionnaireApi.Models.Dtos;

namespace QuestionnaireApi.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly AppDbContext _dbContext;
        public QuestionnaireRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<QuestionnaireDto> GetQuestionnaires(SortParams sortParams)
        {
            var questionnaires = new List<QuestionnaireDto>();
            if (sortParams != null && !string.IsNullOrEmpty(sortParams.SortBy))
            {
                try
                {
                    questionnaires = _dbContext.Questionnaires
                        .OrderByPropertyOrField(sortParams.SortBy, sortParams.SortDirection)
                        .Select(q => new QuestionnaireDto(q))
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return questionnaires;
                }
            }
            else
            {
                questionnaires = _dbContext.Questionnaires
                    .Select(q => new QuestionnaireDto(q))
                    .ToList();
            }

            return questionnaires;
        }

        public QuestionnaireDto GetQuestionnaireById(int id)
        {
            var questionnaire = _dbContext.Questionnaires
                .FirstOrDefault(q => q.Id == id);

            if (questionnaire.StartDate.ToLocalTime() < DateTime.Now
                && questionnaire.Status != StatusEnum.Concept
                && questionnaire.Status != StatusEnum.Completed)
            {
                if (questionnaire.EndDate.ToLocalTime() > DateTime.Now)
                {
                    questionnaire.Status = StatusEnum.Active;
                }
                else
                {
                    questionnaire.Status = StatusEnum.Completed;
                }
                _dbContext.SaveChanges();
            }

            if (questionnaire != null)
            {
                return new QuestionnaireDto(questionnaire);
            }
            else
            {
                throw new Exception("Questionnaire not found");
            }
        }

        public int GetQuestionnairesCountByOwnerId(string ownerId)
        {
            return _dbContext.Questionnaires.Count(q => q.OwnerId == ownerId);
        }

        public QuestionnaireDto CreateQuestionnaire(CreateQuestionnaireDto dto)
        {
            var entity = dto.ToEntity();

            _dbContext.Questionnaires.Add(entity);
            _dbContext.SaveChanges();

            return new QuestionnaireDto(entity);
        }

        public QuestionnaireDto UpdateQuestionnaire(UpdateQuestionnaireDto dto)
        {
            var entity = _dbContext.Questionnaires.FirstOrDefault(q => q.Id == dto.Id);

            if (entity != null)
            {
                entity.StartDate = dto.StartDate.ToUniversalTime();
                entity.EndDate = dto.EndDate.ToUniversalTime();
                entity.Status = dto.Status;

                _dbContext.Questionnaires.Update(entity);

                _dbContext.SaveChanges();

                return new QuestionnaireDto(entity);
            }
            else
            {
                throw new Exception("Questionnaire not found");
            }
        }

        public bool CloseQuestionnaire(int id)
        {
            var entity = _dbContext.Questionnaires.FirstOrDefault(q => q.Id == id);

            if (entity == null)
            {
                return false;
            }

            entity.Status = StatusEnum.Completed;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
