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
        OrganizationService _organizationService=new OrganizationService();
        List<Organization> _organizations;
        public PageAdmOrganizations()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_organizationService.Get(), this);
        }
        public PageAdmOrganizations(List<Organization> organizations)
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_organizationService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            _organizations = organizations;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Organization organization = dataGrid.SelectedItems[i] as Organization;
                DataNavigator.UpdateValueComboBox(_organizations.FirstOrDefault(x => x.Id == organization.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Organization Organization = dataGrid.SelectedItems[i] as Organization;
                    if (Organization != null)
                    {


                        _organizationService.Delete(Organization.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_organizationService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditOrganization(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Organization Organization = dataGrid.SelectedItems[i] as Organization;
                if (Organization != null)
                {

                    EditFrame.Content = new PageEditOrganization(Organization, this);

                }
            }
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
         
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
