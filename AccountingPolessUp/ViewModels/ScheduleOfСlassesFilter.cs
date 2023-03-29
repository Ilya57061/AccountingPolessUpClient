using System;

namespace AccountingPolessUp.ViewModels
{
    public class ScheduleOfСlassesFilter
    {
        public string Lector { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
