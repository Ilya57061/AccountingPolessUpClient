using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditRank.xaml
    /// </summary>
    public partial class PageEditRank : Page
    {
        private RankService _rankService = new RankService();
        private OrganizationService _organizationService = new OrganizationService();

        private List<Organization> _organizations;
        private Rank _rank;
        private Page _parent;

        public PageEditRank(Rank rank, Page parent)
        {
            InitializeComponent();

            _organizations = _organizationService.Get();
            _rank = rank;
            DataContext = rank;
            _parent = parent;

            BoxOrganization.ItemsSource = _organizations;
            BoxOrganization.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o => o.Id == rank.OrganizationId));

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditRank(Page parent)
        {
            InitializeComponent();

            _organizations = _organizationService.Get();    
            _rank = new Rank();
            _parent = parent;

            DataGridUpdater.AdmRanks.UpdateDataGrid();
            BoxOrganization.ItemsSource = _organizations;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _rank);

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
                DataAccess.Create(this, _rank);

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
            _rank.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganization.SelectedItem).Id;

            _rank.RankName = RankName.Text;
            _rank.Description = Description.Text;

            _rank.MaxMmr = int.Parse(MaxMmr.Text);
            _rank.MinMmr = int.Parse(MinMmr.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
