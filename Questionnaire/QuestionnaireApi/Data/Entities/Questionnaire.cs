using System.ComponentModel.DataAnnotations;
using Common.Enums;
using QuestionnaireApi.Common;

namespace QuestionnaireApi.Data.Entities
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
        public string OwnerId { get; set; } = string.Empty;
    }
}
