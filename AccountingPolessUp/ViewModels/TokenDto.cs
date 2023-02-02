using AccountingPolessUp.Models;
using System;

namespace AccountingPolessUp.ViewModels
{
    public class TokenDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public User User { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
