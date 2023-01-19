
namespace StudentAccounting.Model.DataBaseModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Project>? Projects { get; set; } = new();
    }
}
