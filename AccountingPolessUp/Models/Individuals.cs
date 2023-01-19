
namespace StudentAccounting.Model.DataBaseModels
{
    public class Individuals
    {
        public int Id { get; set; }
        public string FIO { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Mail { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string SocialNetwork { get; set; } = string.Empty;
        public Participants? Participants { get; set; }
        public Student? Student { get; set; }
    }
}
