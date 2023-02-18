using AccountingPolessUp.Helpers;
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
        private RankService _RankService = new RankService();
        private OrganizationService _organizationService = new OrganizationService();
        private List<Organization> _organizations;
        private Rank _Rank;
        private Page _parent;

        public PageEditRank(Rank Rank, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _Rank = Rank;
            _organizations = _organizationService.Get();
            DataContext = Rank;
            BoxOrganization.ItemsSource = _organizations;
            BoxOrganization.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o => o.Id == Rank.OrganizationId));
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditRank(Page parent)
        {
            InitializeComponent();
            _organizations = _organizationService.Get();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _Rank = new Rank();
            DataGridUpdater.AdmRanks.UpdateDataGrid();
            BoxOrganization.ItemsSource = _organizations;
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _RankService.Update(_Rank);
                DataGridUpdater.AdmRanks.UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _RankService.Create(_Rank);
                DataGridUpdater.UpdateDataGrid(_RankService.Get(), _parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void OpenOrganizations_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxOrganization.Name;
            _parent.NavigationService.Content = new PageAdmOrganizations(_organizations);
        }
        private void WriteData()
        {
            _Rank.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganization.SelectedItem).Id;
            _Rank.RankName = RankName.Text;
            _Rank.Description = Description.Text;
            _Rank.MaxMmr = int.Parse(MaxMmr.Text);
            _Rank.MinMmr = int.Parse(MinMmr.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
