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
        public List<Employment> Employments { get; set; }
    }
}
