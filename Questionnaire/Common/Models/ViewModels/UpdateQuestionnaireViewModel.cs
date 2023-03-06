using Common.Enums;

namespace Common.Models.ViewModels
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
