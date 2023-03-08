using Common.Enums;
using Common.Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Common.Models.ViewModels.Questionnaire
{
    public class UpdateQuestionnaireViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
    }
}
