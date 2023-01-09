
namespace AccountingPolessUp.Common.Models
{
    public class Rang
    {
        public int Id { get; set; }
        public string RangName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Participants> Participants { get; set; } = new();
        public List<Bonus> Bonus { get; set; } = new();
    }
}
