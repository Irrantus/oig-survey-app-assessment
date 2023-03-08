using Common.Enums;

namespace Common.Models.ViewModels.Questionnaire
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusEnum Status { get; set; }
        public string StatusString { 
            get{ return Status.ToString(); } 
            set { }
        }
        public string OwnerId { get; set; } = string.Empty;

        public QuestionnaireViewModel() { 
            StartDate = DateTime.Now;
            StartDate = DateTime.Now.AddHours(1);
        }

        public bool IsUpdatable()
        {
            return StartDate > DateTime.Now;
        }

        public bool IsClosable()
        {
            return Status == StatusEnum.Active;
        }
    }
}
