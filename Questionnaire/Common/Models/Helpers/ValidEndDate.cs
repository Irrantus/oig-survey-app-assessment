using Common.Models.ViewModels.Questionnaire;
using System.ComponentModel.DataAnnotations;

namespace Common.Models.Helpers
{
    public class ValidEndDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var endDate = Convert.ToDateTime(value);
            DateTime startDate;
            if (validationContext.ObjectInstance is CreateQuestionnaireViewModel)
            {
                var model = (CreateQuestionnaireViewModel)validationContext.ObjectInstance;
                startDate = model.StartDate;
            }
            else
            {
                var model = (ValidationQuestionnaireViewModel)validationContext.ObjectInstance;
                startDate = model.StartDate;
                var initialModel = model.InitialViewModel;
                var initialEndDate = initialModel.EndDate;

                if (endDate < initialEndDate)
                {
                    return new ValidationResult("No retroactive changes! End date cannot be changed to earlier");
                }
            }

            if (startDate > endDate)
            {
                return new ValidationResult("End date cannot be less than Start date");
            }
            else if (endDate < startDate.AddHours(1))
            {
                return new ValidationResult("End date is required to be greater than Start date at least for an hour");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
