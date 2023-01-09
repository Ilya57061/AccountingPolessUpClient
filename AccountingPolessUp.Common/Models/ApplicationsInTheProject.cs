﻿
using AccountingPolessUp.Common.Models;

namespace AccountingPolessUp.Common.Models
{
    public class ApplicationsInTheProject
    {
        public int Id { get; set; }
        public string WorkStatus { get; set; } = string.Empty;
        public DateTime DataEntry { get; set; }
        public Participants? Participants { get; set; }
        public int ParticipantsId { get; set; }
        public Vacancy? Vacancy { get; set; }
        public int VacancyId { get; set; }
    }
}
