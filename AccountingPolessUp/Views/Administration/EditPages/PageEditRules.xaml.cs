using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditRules.xaml
    /// </summary>
    public partial class PageEditRules : Page
    {
        RegulationService _regulationService = new RegulationService();
        OrganizationService _organizationService = new OrganizationService();

        Page _parent;
        List<Organization> _organizations;
        Regulation _regulation;

        public PageEditRules(Regulation regulation, Page parent)
        {
            InitializeComponent();

            _organizations = _organizationService.Get();
            _parent = parent;
            _regulation = regulation;
            DataContext = regulation;
          
            BoxOrganization.ItemsSource = _organizations;
            BoxOrganization.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o => o.Id == regulation.OrganizationId));
            
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
        }
        public PageEditRules(Page parent)
        {
            InitializeComponent();
           
            _regulation = new Regulation();
            _organizations = _organizationService.Get();
            _parent = parent;

            BoxOrganization.ItemsSource = _organizations;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _regulation);
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
                DataAccess.Create(this, _regulation);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void OpenRegulation_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxOrganization.Name;

            _parent.NavigationService.Content = new PageAdmOrganizations(_organizations);
        }
        private void WriteData()
        {
            _regulation.Text = Text.Text;
            _regulation.Name = Name.Text;
            _regulation.Description = Description.Text;

            _regulation.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganization.SelectedItem).Id;
        }
    }
}
