using Common.Models.ViewModels.Questionnaire;
using System.ComponentModel.DataAnnotations;

namespace Common.Models.Helpers
{
    public class ValidStartDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var startDate = Convert.ToDateTime(value);
            if (validationContext.ObjectInstance is ValidationQuestionnaireViewModel)
            {
                var model = (ValidationQuestionnaireViewModel)validationContext.ObjectInstance;
                var initialModel = model.InitialViewModel;
                var initialStartDate = initialModel.StartDate;
                
                if (startDate < initialStartDate)
                {
                    return new ValidationResult("No retroactive changes! Start date cannot be changed to earlier");
                }
            }

            if (startDate < DateTime.Now)
            {
                return new ValidationResult("Start date is required to be in the future");
            }else
            return ValidationResult.Success;
        }
    }
}
