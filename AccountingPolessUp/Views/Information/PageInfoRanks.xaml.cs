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

namespace AccountingPolessUp.Views.Information
{
    /// <summary>
    /// Логика взаимодействия для PageInfoRanks.xaml
    /// </summary>
    public partial class PageInfoRanks : Page
    {
        RankService _RankService = new RankService();
        OrganizationService _organizationService = new OrganizationService();
        BonusService _bonusService = new BonusService();
        IEnumerable<Rank> Ranks;
        List<Organization> organizations;
        public PageInfoRanks()
        {
            InitializeComponent();
            Ranks= _RankService.Get();
            organizations= _organizationService.Get();
            dataGrid.ItemsSource = Ranks;
            ComboORG.ItemsSource = organizations;
        }
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 )
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Rank rank = dataGrid.SelectedItems[i] as Rank;

                    if (rank != null)
                    {
                    this.NavigationService.Content=new PageInfoBonus(rank.Id);

                    }
                }
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            Confirm();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            ComboORG.SelectedItem= null;
            TextBoxMaxMmr.Text= string.Empty;
            TextBoxMinMmr.Text= string.Empty;
            TextBoxSearch.Text=string.Empty;
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = Ranks;
        }
        private void Confirm()
        {
            IEnumerable<Rank> newRanks = Ranks;
            if (ComboORG.SelectedItem!=null)
            {
                newRanks = newRanks.Where(x=>x.OrganizationId== organizations.FirstOrDefault(o=>o== ComboORG.SelectedItem).Id);
            }
            if (TextBoxSearch.Text!="")
            {
                newRanks = newRanks.Where(x=>x.RankName==TextBoxSearch.Text);
            }
            if (TextBoxMinMmr.Text!="")
            {
                newRanks = newRanks.Where(x => x.MinMmr == int.Parse(TextBoxMinMmr.Text));
            }
            if (TextBoxMaxMmr.Text != "")
            {
                newRanks = newRanks.Where(x => x.MaxMmr == int.Parse(TextBoxMaxMmr.Text));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = newRanks;
        }
    }
  
}
