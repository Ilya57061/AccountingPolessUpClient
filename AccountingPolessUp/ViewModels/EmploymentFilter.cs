using System;

namespace AccountingPolessUp.ViewModels
{
    public class EmploymentFilter
    {
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ExperienceFrom { get; set; }
        public int ExperienceTo { get; set; }
        public int Experience { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
