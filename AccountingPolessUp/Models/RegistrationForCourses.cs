
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model.DatabaseModels
{
    public class RegistrationForCourses
    {
        public int Id { get; set; }
        public DateTime DateEntry { get; set; }
        public int ParticipantsId { get; set; }
        public Participants? Participants { get; set; }
        public int TrainingCousresId { get; set; }
        public TrainingCourses? TrainingCourses { get; set; }
       

    }
}
