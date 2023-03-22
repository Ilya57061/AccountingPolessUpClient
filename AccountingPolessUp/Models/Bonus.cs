
using System.Collections.Generic;

namespace AccountingPolessUp.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public string BonusName { get; set; } = string.Empty;
        public string BonusDescription { get; set; } = string.Empty;
        public List<Rank> Ranks { get; set; }
        public List<RankBonus> RankBonus { get; set; }
    }
}
