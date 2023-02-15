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
using AccountingPolessUp.Helpers;
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
        public ObservableCollection<Bonus> Bonuses { get; set; }
        public PageInfoBonus()
        {
            InitializeComponent();
            Bonuses =new ObservableCollection<Bonus>(_bonusService.Get());
            DataContext = Bonuses;
            FilterComboBox.SetBoxRank(BoxRank);
        }
        public PageInfoBonus(int rankId)
        {
            InitializeComponent();
            ButtonBack.Visibility = Visibility.Visible;
            Bonuses = new ObservableCollection<Bonus>(_bonusService.Get(rankId));
            DataContext = Bonuses;
            FilterComboBox.SetBoxRank(BoxRank);
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(this, Bonuses, BonusName.Text, BoxRank.Text, BonusDescription.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(filter);
            DataContext = Bonuses;
        }
        private void MouseWheel(object sender, MouseWheelEventArgs e)
        {
            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
