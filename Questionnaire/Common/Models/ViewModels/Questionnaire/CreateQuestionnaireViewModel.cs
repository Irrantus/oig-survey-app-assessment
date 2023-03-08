using Common.Enums;
using Common.Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Common.Models.ViewModels.Questionnaire
{
    public class CreateQuestionnaireViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [ValidStartDate]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [ValidEndDate]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string OwnerId { get; set; } = string.Empty;
        public StatusEnum Status { get; set; }
    }
}
