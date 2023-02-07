using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
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
            UpdateDataGrid();
        }
        public PageAdmOrganizations(List<Organization> organizations)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _organizations = organizations;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
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
            FilterManager.ConfirmFilter(dataGrid, _organizationService.Get(), FullName.Text, Address.Text, Contacts.Text, Website.Text, FoundationDate.Text);
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
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_organizationService.Get(), this);
        }
        private void DeleteSelectedOrganizations()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
    }
}
