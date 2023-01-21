
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model.DatabaseModels
{
    public class EducationalPortals
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Link { get; set; } = string.Empty;

    }
}
