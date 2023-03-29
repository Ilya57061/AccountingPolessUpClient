using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.ViewModels
{
    public class ProjectFilter
    {
        public string Position { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
