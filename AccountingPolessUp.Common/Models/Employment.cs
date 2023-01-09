


namespace AccountingPolessUp.Common.Models
{
    public class Employment
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public int IdMentor { get; set; }
        public Participants? Participants { get; set; }
        public int ParticipantsId { get; set; }
        public TrainingCourses? TrainingCourses { get; set; }
        public int TrainingCoursesId { get; set; }
        public FinalProject? FinalProject { get; set; }
        public int FinalProjectId { get; set; }
        public Position? Position { get; set; }
        public int PositionId { get; set; }
    }
}
