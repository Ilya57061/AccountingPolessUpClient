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
    /// Логика взаимодействия для PageEditDepartments.xaml
    /// </summary>
    public partial class PageEditDepartments : Page
    {

        FormValidator validator = new FormValidator();
        DepartmentService _departmentService = new DepartmentService();
        OrganizationService _organizationService = new OrganizationService();
        Department _department;
        List<Organization> _organizations;
        public PageEditDepartments(Department department)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _department = department;
            _organizations = _organizationService.Get();
            DataContext = department;
            BoxOrganizations.ItemsSource = _organizations;
            BoxOrganizations.SelectedIndex = _organizations.IndexOf(_organizations.FirstOrDefault(o => o.Id == department.OrganizationId));
        }
        public PageEditDepartments()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _department = new Department();
            _organizations = _organizationService.Get();
            BoxOrganizations.ItemsSource = _organizations;
        }
        private void OpenOrganization_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (validator.AreAllElementsFilled(this))
                    throw new Exception();
                _departmentService.Update(_department);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (validator.AreAllElementsFilled(this))
                    throw new Exception();
                _departmentService.Create(_department);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void WriteData()
        {
            _department.FullName = FullName.Text;
            _department.Description = Description.Text;
            _department.DateStart = DateTime.Parse(DateStart.Text);
            _department.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            _department.Status = Status.Text;
            _department.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganizations.SelectedItem).Id;
        }
    }
}
