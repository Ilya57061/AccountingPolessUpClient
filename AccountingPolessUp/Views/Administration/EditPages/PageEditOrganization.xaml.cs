using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditOrganization.xaml
    /// </summary>
    public partial class PageEditOrganization : Page
    {
        OrganizationService _organizationService = new OrganizationService();

        Page _parent; 
        Organization _organization;

        public PageEditOrganization(Organization organization, Page parent)
        {
            InitializeComponent();

            _organization = organization;
            DataContext = organization;
            _parent = parent;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;   
        }
        public PageEditOrganization(Page parent)
        {
            InitializeComponent();

            _organization = new Organization();
            _parent = parent;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;    
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _organization);
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
                DataAccess.Create(this, _organization);

            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _organization.Fullname = FullName.Text;
            _organization.Address = Address.Text;
            _organization.Contacts = Contacts.Text;
            _organization.WebSite = Website.Text;

            _organization.FoundationDate = DateTime.TryParse(FoundationDate.Text, out var dateFoundation) ? dateFoundation : (DateTime?)null;
            _organization.BSR = double.TryParse(BSR.Text.Replace('.', ','), out var bSR) ? bSR : (double?)null;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        private void Number_PreviewTextDoubleInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DoubleValidator(e);
        }
    }
}
