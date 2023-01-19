
namespace StudentAccounting.Model.DataBaseModels
{
    public class Department
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<Position>? Positions { get; set; } = new();
        public int OrganizationId { get; set; }
        public Organization? Organizations { get; set; }
    }
}
