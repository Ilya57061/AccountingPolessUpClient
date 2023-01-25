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
        RangService _rangService = new RangService();
        OrganizationService _organizationService = new OrganizationService();
        BonusService _bonusService = new BonusService();
        List<Rang> rangs;
        List<Organization> organizations;
        public PageInfoRanks()
        {
            InitializeComponent();
            rangs= _rangService.Get();
            organizations= _organizationService.Get();
            dataGrid.ItemsSource = rangs;
            ComboORG.ItemsSource = organizations;
        }
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {

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
            TextBoxMaxMMR.Text= string.Empty;
            TextBoxMinMMR.Text= string.Empty;
            TextBoxSearch.Text=string.Empty;
        }
        private void Confirm()
        {
            List<Rang> newRangs = rangs;
            if (ComboORG.SelectedItem!=null)
            {
                newRangs = (List<Rang>)newRangs.Where(x=>x.OrganizationId== organizations.FirstOrDefault(o=>o== ComboORG.SelectedItem).Id);
            }
            if (TextBoxSearch.Text!="")
            {
                newRangs = (List<Rang>)newRangs.Where(x=>x.RangName==TextBoxSearch.Text);
            }
            if (TextBoxMinMMR.Text!="")
            {
                newRangs = (List<Rang>)newRangs.Where(x => x.MinMmr == int.Parse(TextBoxMinMMR.Text));
            }
            if (TextBoxMaxMMR.Text != "")
            {
                newRangs = (List<Rang>)newRangs.Where(x => x.MaxMmr == int.Parse(TextBoxMaxMMR.Text));
            }
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = newRangs;
        }
    }
  
}
