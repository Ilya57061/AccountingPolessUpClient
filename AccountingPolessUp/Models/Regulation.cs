
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccountin.Model.DatabaseModels
{
    public class Regulation
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Organization? Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}
