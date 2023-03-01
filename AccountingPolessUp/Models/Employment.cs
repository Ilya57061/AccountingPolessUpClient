using System;
using System.Collections.Generic;

namespace AccountingPolessUp.Models
{
    public partial class Employment
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public int? IdMentor { get; set; }
        public Participants Participants { get; set; }
        public int ParticipantsId { get; set; }
        public List<FinalProject> FinalProjects { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }

    }
}
