using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Windows;
using System.Windows.Controls;

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
            _parent = parent;
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _customer);

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
                DataAccess.Create(this, _customer);
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
