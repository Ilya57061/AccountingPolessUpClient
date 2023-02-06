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
    /// Логика взаимодействия для PageAddCustomer.xaml
    /// </summary>
    public partial class PageAdmCustomer : Page
    {
        CustomerService _customerService = new CustomerService();
        List<Customer> _customers;
        public PageAdmCustomer()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_customerService.Get(), this);
        }
        public PageAdmCustomer(List<Customer> customers)
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_customerService.Get(), this);
            ColumSelect.Visibility = Visibility.Visible;
            _customers=customers;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Customer customer = dataGrid.SelectedItems[i] as Customer;
                DataNavigator.UpdateValueComboBox(_customers.FirstOrDefault(x => x.Id == customer.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Customer Customer = dataGrid.SelectedItems[i] as Customer;
                    if (Customer != null)
                    {

                        _customerService.Delete(Customer.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_customerService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditCustomer(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Customer Customer = dataGrid.SelectedItems[i] as Customer;
                if (Customer != null)
                {
                    EditFrame.Content = new PageEditCustomer(Customer, this);
                }
            }
        }
    }
}
