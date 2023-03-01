using System;

namespace AccountingPolessUp.Models
{
    public class ApplicationsInTheProject
    {
        public int Id { get; set; }
        public bool? IsAccepted { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public DateTime DateEntry { get; set; }
        public Participants Participants { get; set; }
        public int ParticipantsId { get; set; }
        public Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }
    }
}
