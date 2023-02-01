using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.ViewModels
{
    public class UserToken
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
