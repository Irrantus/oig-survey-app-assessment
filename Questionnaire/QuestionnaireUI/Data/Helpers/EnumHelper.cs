using Common.Enums;
using System.Diagnostics.Metrics;

namespace QuestionnaireUI.Data.Helpers
{
    public static class EnumHelper
    {
        private static IEnumerable<StatusEnum> managebleQuestionnaireStatuses;
        private static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<StatusEnum> GetManagableQuestionnaireStatuses()
        {
            if (managebleQuestionnaireStatuses == null)
            {
                managebleQuestionnaireStatuses = GetEnumValues<StatusEnum>()
                    .Where(v =>
                        v.ToString() != StatusEnum.Active.ToString()
                        && v.ToString() != StatusEnum.Completed.ToString());
            }
            return managebleQuestionnaireStatuses;
        }
    }
}
