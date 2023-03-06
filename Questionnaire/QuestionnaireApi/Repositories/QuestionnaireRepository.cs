using Common.Enums;
using Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using QuestionnaireApi.Common;
using QuestionnaireApi.Data;
using QuestionnaireApi.Data.Entities;
using QuestionnaireApi.Models.Dtos;
using System.Linq;

namespace QuestionnaireApi.Repositories
{
    public class QuestionnaireRepository: IQuestionnaireRepository
    {
        private readonly AppDbContext _dbContext;
        public QuestionnaireRepository(AppDbContext context) {
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

            if (questionnaire != null)
            {
                return new QuestionnaireDto(questionnaire);
            }
            else
            {
                throw new Exception("Questionnaire not found");
            }
        }

        public QuestionnaireDto CreateQuestionnaire(CreateQuestionnaireDto dto)
        {
            var entity = dto.ToEntity();
            entity.Status = StatusEnum.Concept;

            var createdEntity = _dbContext.Questionnaires.Add(entity).Entity;
            _dbContext.SaveChanges();

            return new QuestionnaireDto(createdEntity);
        }

        public QuestionnaireDto UpdateQuestionnaire(UpdateQuestionnaireDto dto)
        {
            var entity = dto.ToEntity();
            return new QuestionnaireDto(_dbContext.Questionnaires.Update(entity).Entity);
        }
    }
}
