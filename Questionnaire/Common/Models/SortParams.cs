using Common.Enums;

namespace Common.Models
{
    public class SortParams
    {
        public string SortBy { get; set; } = string.Empty;
        public SortDirectionEnum SortDirection { get; set; }

    }
}
