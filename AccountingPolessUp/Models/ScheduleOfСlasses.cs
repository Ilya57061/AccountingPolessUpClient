
using AccountingPolessUp.Models;
using System;

namespace AccountingPolessUp.Models
{
    public class ScheduleOfСlasses
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string WorkSpaceLink { get; set; }
        public int TrainingCoursesId { get; set; }
        public TrainingCourses TrainingCourses { get; set; }
    }
}
