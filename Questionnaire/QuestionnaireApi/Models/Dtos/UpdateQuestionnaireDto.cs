using Common.Enums;
using Common.Models.ViewModels.Questionnaire;
using QuestionnaireApi.Data.Entities;

namespace QuestionnaireApi.Models.Dtos
{
    public class UpdateQuestionnaireDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
        public UpdateQuestionnaireDto() { }
        public UpdateQuestionnaireDto(UpdateQuestionnaireViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Status = model.Status;
        }

        public bool Valid(QuestionnaireDto questionnaire)
        {
            if (Status == StatusEnum.Completed || Status == StatusEnum.Active)
            {
                return false;
            }

            if (StartDate < questionnaire.StartDate || EndDate < questionnaire.EndDate)
            {
                return false;
            }

            return true;
        }
    }
}
