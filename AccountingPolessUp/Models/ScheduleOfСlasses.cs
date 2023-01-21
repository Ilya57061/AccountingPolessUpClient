
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.Model.DatabaseModels
{
    public class ScheduleOfСlasses
    {
        public int Id { get; set; }
        public string? Description { get; set; } = String.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? WorkSpaceLink { get; set; }
        public int TrainingCoursesId { get; set; }
        public TrainingCourses? TrainingCourses { get; set; }
    }
}
