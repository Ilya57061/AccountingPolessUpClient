using System;
using System.Collections.Generic;

namespace AccountingPolessUp.Models
{
    public class TrainingCourses
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string LectorFIO { get; set; } = string.Empty;
        public string LectorDescription { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsActive { get; set; }
        public List<RegistrationForCourses> RegistrationForCourses { get; set; }
        public List<ScheduleOfСlasses> ScheduleOfСlasses { get; set; }
    }
}
