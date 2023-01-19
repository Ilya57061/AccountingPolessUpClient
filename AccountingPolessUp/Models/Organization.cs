
using StudentAccountin.Model.DatabaseModels;

namespace StudentAccounting.Model.DataBaseModels
{
    public class Organization
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public string? WebSite { get; set; } = string.Empty;
        public DateTime? FoundationDate { get; set; }
        public List<Department>? Departments { get; set; } = new();
        public List<Regulation>? Regulations { get; set; } = new();
        public List<Rang>? Rangs { get; set; } = new();
    }
}
