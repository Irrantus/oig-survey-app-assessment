using Common.Enums;
using Common.Models.ViewModels;
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

        public Questionnaire ToEntity()
        {
            return new Questionnaire            {
                Id = Id,
                Name = Name,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = Status
            };
        }

        public bool Valid(QuestionnaireDto questionnaire)
        {
            if (StartDate < questionnaire.StartDate || EndDate < questionnaire.EndDate)
            {
                return false;
            }

            if (Status == StatusEnum.Completed && questionnaire.EndDate > DateTime.Now)
            {
                return false;
            }

            switch (Status)
            {
                case StatusEnum.Scheduled:
                    if (questionnaire.Status != StatusEnum.Concept)
                    {
                        return false;
                    }
                    break;
                case StatusEnum.Completed:
                    if(questionnaire.Status != StatusEnum.Scheduled)
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }
    }
}
