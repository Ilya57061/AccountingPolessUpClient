
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccountin.Model.DatabaseModels
{
    public class Employment
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool Status { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public int? IdMentor { get; set; }
        public Participants? Participants { get; set; }
        public int ParticipantsId { get; set; }
        public List<TrainingCourses>? TrainingCourses { get; set; } = new();
        public List<FinalProject>? FinalProjects { get; set; } = new();
        public Position? Position { get; set; }
        public int PositionId { get; set; }
    }
}
