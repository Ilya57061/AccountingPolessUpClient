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
    /// Логика взаимодействия для PageEditCustomer.xaml
    /// </summary>
    public partial class PageEditCustomer : Page
    {

        Page _parent;
        CustomerService _customerService = new CustomerService();
        Customer _customer;
        public PageEditCustomer(Customer customer, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _customer = customer;
            DataContext = customer;
            _parent = parent;
        }
        public PageEditCustomer(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _customer = new Customer();
            _parent= parent;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _customerService.Update(_customer);
                DataGridUpdater.UpdateDataGrid(_customerService.Get(),_parent);
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
                _customerService.Create(_customer);
                DataGridUpdater.UpdateDataGrid(_customerService.Get(), _parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _customer.FullName = Fullname.Text;
            _customer.Address = Address.Text;
            _customer.Contacts = Contacts.Text;
            _customer.WebSite = WebSite.Text;
            _customer.Description = Description.Text;
        }
    }
}
