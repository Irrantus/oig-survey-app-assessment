using Common.Enums;
using QuestionnaireApi.Data.Entities;
using Common.Models.ViewModels.Questionnaire;

namespace QuestionnaireApi.Models.Dtos
{
    public class QuestionnaireDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
        public string OwnerId { get; set; } = string.Empty;

        public QuestionnaireDto() { }
        public QuestionnaireDto(QuestionnaireViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Status = model.Status;
            OwnerId = OwnerId;
        }

        public QuestionnaireDto(Questionnaire entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            StartDate = entity.StartDate.ToLocalTime();
            EndDate = entity.EndDate.ToLocalTime();
            Status = entity.Status;
            OwnerId = entity.OwnerId;
        }

        public QuestionnaireViewModel ToViewModel()
        {
            return new QuestionnaireViewModel
            {
                Id = Id,
                Name = Name,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = Status,
                OwnerId = OwnerId
            };
        }
    }
}
