using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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
using MaterialDesignThemes.Wpf;

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoRanks.xaml
    /// </summary>
    public partial class PageInfoRanks : Page
    {
        RankService _rankService = new RankService();
       
        public ObservableCollection<Rank> Ranks { get; set; }
        public PageInfoRanks()
        {
            InitializeComponent();
            Ranks = new ObservableCollection<Rank>(_rankService.Get());
            DataContext = Ranks;
            FilterComboBox.SetBoxOrganizations(BoxOrganization);
        }
        private void ButtonOpenBonuses_Click(object sender, RoutedEventArgs e)
        {
            var selectedRank = (Rank)((Button)sender).DataContext;
            this.NavigationService.Content = new PageInfoBonus(selectedRank.Id);
    
        }
   
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(this, Ranks, RankName.Text, Description.Text, BoxOrganization.Text, MinMmr.Text, MaxMmr.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(filter);
            DataContext = Ranks;
        }
        private void Number_PreviewTextInput(object sender, RoutedEventArgs e)
        {

        }
    }

}
