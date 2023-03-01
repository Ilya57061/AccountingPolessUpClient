using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmCustomer(List<Customer> customers)
        {
            InitializeComponent();
            DataGridUpdater.AdmCustomer = this;
            ColumSelect.Visibility = Visibility.Visible;
            _customers = customers;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
            DataGridUpdater.UpdateDataGrid(_customers, this);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
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
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedCustomers();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditCustomer(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedCustomers();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _customers, Fullname.Text, Address.Text, Contacts.Text, WebSite.Text, Description.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
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
                MessageBox.Show("Ресурс не найден");
            }
        }
    }
}
