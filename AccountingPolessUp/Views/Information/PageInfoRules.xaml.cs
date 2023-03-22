using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

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
        private void TextBlock_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
