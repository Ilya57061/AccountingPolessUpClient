

using AccountingPolessUp.Models;
using System;

namespace AccountingPolessUp.Models
{
    public class RegistrationForCourses
    {
        public int Id { get; set; }
        public DateTime DateEntry { get; set; }
        public int ParticipantsId { get; set; }
        public Participants Participants { get; set; }
        public int TrainingCoursesId { get; set; }
        public TrainingCourses TrainingCourses { get; set; }
       

    }
}
