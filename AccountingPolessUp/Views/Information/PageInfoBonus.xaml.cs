using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoBonus.xaml
    /// </summary>
    public partial class PageInfoBonus : Page
    {
        BonusService _bonusService = new BonusService();
        public PageInfoBonus()
        {
            InitializeComponent();
            BonusGrid.ItemsSource = _bonusService.Get();
        }
        public PageInfoBonus(int RankId)
        {

        }
    }
}
