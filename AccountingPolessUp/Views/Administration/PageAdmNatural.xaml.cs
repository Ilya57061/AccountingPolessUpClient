using AccountingPolessUp.Implementations;
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

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmNatural.xaml
    /// </summary>
    public partial class PageAdmNatural : Page
    {
        IndividualsService _individualsService = new IndividualsService();
        public PageAdmNatural()
        {
            InitializeComponent();
            dataGrid.ItemsSource = _individualsService.Get();
        }
    }
}
