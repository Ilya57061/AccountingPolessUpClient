﻿
using AccountingPolessUp.Common.Models;

namespace AccountingPolessUp.Common.Models
{
    public class StagesOfProject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<Vacancy> Vacancy { get; set; } = new();
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
    }
}
