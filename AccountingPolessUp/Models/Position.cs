﻿namespace AccountingPolessUp.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
