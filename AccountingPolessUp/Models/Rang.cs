
using System.Collections.Generic;
using System.Security.AccessControl;

namespace AccountingPolessUp.Models
{
    public class Rang
    {
        public int Id { get; set; }
        public string RangName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MaxMmr { get; set; }
        public int MinMmr { get; set; }
        public List<Bonus> Bonus { get; set; } 
        public int OrganizationId { get; set; }
        public Organization Organizations { get; set; }
    }
}
