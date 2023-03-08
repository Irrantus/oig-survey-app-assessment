using Common.Enums;
using Common.Models.ViewModels.Questionnaire;
using QuestionnaireApi.Data.Entities;

namespace QuestionnaireApi.Models.Dtos
{
    public class CreateQuestionnaireDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OwnerId { get; set; } = string.Empty;
        public StatusEnum Status { get; set; }

        public CreateQuestionnaireDto() { }
        public CreateQuestionnaireDto(CreateQuestionnaireViewModel model)
        {
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            OwnerId = model.OwnerId;
            Status = model.Status;
        }

        public Questionnaire ToEntity()
        {
            return new Questionnaire
            {
                Name = Name,
                StartDate = StartDate.ToUniversalTime(),
                EndDate = EndDate.ToUniversalTime(),
                OwnerId = OwnerId,
                Status = Status
            };
        }

        public bool Valid()
        {
            if (StartDate < DateTime.Now || EndDate < DateTime.Now)
            {
                return false;
            }

            if (EndDate < StartDate.AddHours(1))
            {
                return false;
            }

            return true;
        }
    }
}
