using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditRank.xaml
    /// </summary>
    public partial class PageEditRank : Page
    {
        RangService _rangService = new RangService();
        OrganizationService _organizationService=new OrganizationService();
        List<Organization> _organizations;
        Rang _rang;
        public PageEditRank(Rang rang)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _rang = rang;
            _organizations = _organizationService.Get();
            DataContext = rang;
            BoxOrganization.ItemsSource= _organizations;
            BoxOrganization.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o=>o.Id==rang.OrganizationId));
        }
        public PageEditRank()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _rang = new Rang();
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _rangService.Update(_rang);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _rangService.Create(_rang);
        }
        private void OpenRank_Click(object sender, RoutedEventArgs e)
        {

        }
        private void WriteData()
        {
            _rang.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganization.SelectedItem).Id;
            _rang.RangName = RangName.Text;
            _rang.Description=Description.Text;
            _rang.MaxMmr = int.Parse(MaxMmr.Text);
            _rang.MinMmr=int.Parse(MinMmr.Text);
        }
    }
}
