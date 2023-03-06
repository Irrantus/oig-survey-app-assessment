using Common.Models.ViewModels;
using Common.Enums;
using QuestionnaireApi.Data.Entities;

namespace QuestionnaireApi.Models.Dtos
{
    public class QuestionnaireDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }

        public QuestionnaireDto() { }
        public QuestionnaireDto(QuestionnaireViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Status = model.Status;
        }

        public QuestionnaireDto(Questionnaire entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            StartDate = entity.StartDate;
            EndDate = entity.EndDate;
            Status = entity.Status;
        }

        public QuestionnaireViewModel ToViewModel()
        {
            return new QuestionnaireViewModel
            {
                Id = Id,
                Name = Name,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = Status
            };
        }
    }
}
