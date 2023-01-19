
namespace StudentAccounting.Model.DataBaseModels
{
    public class Bonus
    {
        public int Id { get; set; }
        public string BonusName { get; set; } = string.Empty;
        public string BonusDescription { get; set; } = string.Empty;
        public int RangId { get; set; }
        public Rang? Rang { get; set; }
    }
}
