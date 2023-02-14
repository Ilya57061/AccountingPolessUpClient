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
    /// Логика взаимодействия для PageAddCustomer.xaml
    /// </summary>
    public partial class PageAdmCustomer : Page
    {
        private readonly CustomerService _customerService = new CustomerService();
        List<Customer> _customers;
        public PageAdmCustomer()
        {
            InitializeComponent();
            DataGridUpdater.AdmCustomer = this;
            UpdateDataGrid();
        }
        public PageAdmCustomer(List<Customer> customers)
        {
            InitializeComponent();
            DataGridUpdater.AdmCustomer = this;
            ColumSelect.Visibility = Visibility.Visible;
            _customers = customers;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
            UpdateDataGrid();
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectCustomers();
            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedCustomers();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditCustomer(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedCustomers();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _customers, Fullname.Text, Address.Text, Contacts.Text, WebSite.Text, Description.Text);
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
            _customers = _customerService.Get();
            DataGridUpdater.UpdateDataGrid(_customers, this);
        }
        private void DeleteSelectedCustomers()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Customer customer in dataGrid.SelectedItems)
                {
                    
                    _customerService.Delete(customer.Id);
                }
             
                UpdateDataGrid();
            }
        }
        private void EditSelectedCustomers()
        {
            foreach (Customer customer in dataGrid.SelectedItems)
            {
                if (customer != null)
                {
                    EditFrame.Content = new PageEditCustomer(customer, this);
                }
            }
        }
        private void SelectCustomers()
        {
            foreach (Customer customer in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_customers.FirstOrDefault(x => x.Id == customer.Id));
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
    }
}
