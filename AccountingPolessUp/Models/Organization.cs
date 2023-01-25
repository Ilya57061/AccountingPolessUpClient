
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;

namespace AccountingPolessUp.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public DateTime FoundationDate { get; set; }
        public List<Department> Departments { get; set; } 
        public List<Regulation> Regulations { get; set; } 
        public List<Rank> Ranks { get; set; } 
    }
}
