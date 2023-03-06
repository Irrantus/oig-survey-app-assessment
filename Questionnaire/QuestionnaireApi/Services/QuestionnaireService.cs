using Common.Models;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using QuestionnaireApi.Common;
using QuestionnaireApi.Models.Dtos;
using QuestionnaireApi.Repositories;

namespace QuestionnaireApi.Services
{
    public class QuestionnaireService: IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        public QuestionnaireService(IQuestionnaireRepository questionnaireRepository) {
            _questionnaireRepository = questionnaireRepository;
        }

        public IEnumerable<QuestionnaireViewModel> GetQuestionnaires(SortParams sortParams)
        {
            return _questionnaireRepository.GetQuestionnaires(sortParams)
                .Select(dto => dto.ToViewModel());
        }

        public QuestionnaireViewModel GetQuestionnaireById(int id)
        {
            return _questionnaireRepository.GetQuestionnaireById(id)
                .ToViewModel();
        }

        public QuestionnaireViewModel CreateQuestionnaire(CreateQuestionnaireViewModel createVieModel)
        {
            var createDto = new CreateQuestionnaireDto(createVieModel);
            if (createDto.Valid())
            {
                return _questionnaireRepository.CreateQuestionnaire(createDto)
                    .ToViewModel();
            }
            else
            {
                throw new BadHttpRequestException("Questionnaire data is not valid");
            }
        }

        public QuestionnaireViewModel UpdateQuestionnaire(UpdateQuestionnaireViewModel updateViewModel)
        {
            var updateDto = new UpdateQuestionnaireDto(updateViewModel);
            var entity = _questionnaireRepository.GetQuestionnaireById(updateDto.Id);

            if (entity != null && updateDto.Valid(entity))
            {
                return _questionnaireRepository.UpdateQuestionnaire(updateDto)
                    .ToViewModel();
            }
            else
            {
                throw new BadHttpRequestException("Questionnaire data is not valid");
            }
        }
    }
}
