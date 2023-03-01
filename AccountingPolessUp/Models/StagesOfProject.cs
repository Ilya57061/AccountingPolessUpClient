using System;
using System.Collections.Generic;

namespace AccountingPolessUp.Models
{
    public class StagesOfProject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<Vacancy> Vacancy { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
