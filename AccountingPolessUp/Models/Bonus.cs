
namespace AccountingPolessUp.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public string BonusName { get; set; } = string.Empty;
        public string BonusDescription { get; set; } = string.Empty;
        public int RankId { get; set; }
        public Rank Rank { get; set; }
    }
}
