using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.ViewModels
{
    public class RegisterDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
