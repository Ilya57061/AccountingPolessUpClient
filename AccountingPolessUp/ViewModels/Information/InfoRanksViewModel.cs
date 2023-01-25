using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.ViewModels.Information
{
    public class InfoRanksViewModel
    {
        public ObservableCollection<Organization> Organizations { get; set; } = new ObservableCollection<Organization>();
    }

}
