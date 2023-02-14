using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AccountingPolessUp.Models;
using AccountingPolessUp.Implementations;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoRules.xaml
    /// </summary>
    public partial class PageInfoRules : Page
    {
        public ObservableCollection<ObservableCollection<ObservableCollection<Regulation>>> regulations { get; set; }
        RegulationService _regulationService = new RegulationService();

        public PageInfoRules()
        {
            InitializeComponent();
            regulations = new ObservableCollection<ObservableCollection<ObservableCollection<Regulation>>>(
        _regulationService.Get()
        .GroupBy(b => b.Organization.Fullname)
        .Select(g => new ObservableCollection<ObservableCollection<Regulation>>(
        g.GroupBy(b => b.Name)
        .Select(g2 => new ObservableCollection<Regulation>(g2.ToList()))
        .ToList()))
        .ToList());
            DataContext = this;
        }
        private void GetById(object sender, RoutedEventArgs e)
        {
            var id = (sender as Expander)?.Tag as int?;
            if (id.HasValue)
            {
              _regulationService.Get(id.Value);
            }
        }
    }
}
