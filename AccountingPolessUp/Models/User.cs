
namespace AccountingPolessUp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
