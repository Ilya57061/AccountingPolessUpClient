
using AccountingPolessUp.Common.Models;

namespace AccountingPolessUp.Common.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public int IndividualsId { get; set; }
        public Individuals? Individuals { get; set; }
        public int RangId { get; set; }
        public Rang? Rang { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime DateExit { get; set; }
        public string Status { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
        public List<ApplicationsInTheProject> ApplicationsInTheProjects { get; set; } = new();
        public List<Employment> Employments { get; set; } = new();
    }
}
