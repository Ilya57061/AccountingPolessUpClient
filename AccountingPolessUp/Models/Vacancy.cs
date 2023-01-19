using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public string Responsibilities { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Budjet { get; set; }
        public List<ApplicationsInTheProject> ApplicationsInTheProjects { get; set; } 
        public StagesOfProject StagesOfProject { get; set; }
        public int StagesOfProjectId { get; set; } 
    }
}
