using System.ComponentModel.DataAnnotations;

namespace AccountingPolessUp.ViewModels
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
