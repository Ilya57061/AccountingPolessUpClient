
namespace AccountingPolessUp.Common.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public Participants? Participants { get; set; }
    }
}
