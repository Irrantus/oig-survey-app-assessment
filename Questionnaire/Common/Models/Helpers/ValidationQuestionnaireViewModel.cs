using Common.Models.ViewModels.Questionnaire;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Models.Helpers
{
    public class ValidationQuestionnaireViewModel: UpdateQuestionnaireViewModel
    {
        [Required]
        [ValidStartDate]
        public new DateTime StartDate { get; set; }
        [Required]
        [ValidEndDate]
        public new DateTime EndDate { get; set; }
        public QuestionnaireViewModel InitialViewModel { get; set; }
        public ValidationQuestionnaireViewModel(QuestionnaireViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Status = model.Status;
            InitialViewModel = model;
        }
        
        public UpdateQuestionnaireViewModel ToUpdateViewModel()
        {
            return new UpdateQuestionnaireViewModel
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
