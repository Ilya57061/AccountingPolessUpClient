
namespace StudentAccountin.Model.DatabaseModels
{
    public class FinalProject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
        public string Links { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Employment? Employment { get; set; }
        public int EmploymentId { get; set; }
    }
}
