using System;

namespace AccountingPolessUp.ViewModels
{
    public class DepartmentFilter
    {
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfPeopleFrom { get; set; }
        public int NumberOfPeopleTo { get; set; }
        public int ParticipantsId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
