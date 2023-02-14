using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmOrganizations.xaml
    /// </summary>
    public partial class PageAdmOrganizations : Page
    {
        private readonly OrganizationService _organizationService = new OrganizationService();
        List<Organization> _organizations;
        public PageAdmOrganizations()
        {
            InitializeComponent();
            DataGridUpdater.AdmOrganizations = this;
            UpdateDataGrid();
        }
        public PageAdmOrganizations(List<Organization> organizations)
        {
            InitializeComponent();
            DataGridUpdater.AdmOrganizations = this;
            ColumSelect.Visibility = Visibility.Visible;
            _organizations = organizations;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
            UpdateDataGrid();

        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedOrganizations();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedOrganizations();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditOrganization(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedOrganizations();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _organizations, FullName.Text, Address.Text, Contacts.Text, Website.Text, FoundationDate.Text,BSR.Text.Replace('.', ','));
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        public void UpdateDataGrid()
        {
            _organizations = _organizationService.Get();
            DataGridUpdater.UpdateDataGrid(_organizations, this);
        }
        private void DeleteSelectedOrganizations()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Organization organization in dataGrid.SelectedItems)
                {
                    _organizationService.Delete(organization.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedOrganizations()
        {
            foreach (Organization organization in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_organizations.FirstOrDefault(x => x.Id == organization.Id));
            }

            this.NavigationService.GoBack();
        }
        private void EditSelectedOrganizations()
        {
            foreach (Organization organization in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditOrganization(organization, this);
                break;
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(e.Uri.AbsoluteUri);
            }
            catch (Exception)
            {

            }
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
