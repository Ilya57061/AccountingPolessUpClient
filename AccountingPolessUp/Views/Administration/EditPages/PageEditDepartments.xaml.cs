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

        Page _parent;
        DepartmentService _departmentService = new DepartmentService();
        OrganizationService _organizationService = new OrganizationService();
        Department _department;
        List<Organization> _organizations;
        public PageEditDepartments(Department department, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _organizations = _organizationService.Get();
            _department = department;
            DataContext = department;
            BoxOrganizations.ItemsSource = _organizations;
            BoxStatus.SelectedIndex = _department.Status == "Работает" ? 0 : 1;
            BoxOrganizations.SelectedItem = _organizations.FirstOrDefault(i => i.Id == department.OrganizationId);
            _parent = parent;
        }
        public PageEditDepartments(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _department = new Department();
            _organizations = _organizationService.Get();
            BoxOrganizations.ItemsSource = _organizations;
            _parent = parent;
        }
        private void OpenOrganization_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxOrganizations.Name;
            _parent.NavigationService.Content = new PageAdmOrganizations(_organizations);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _departmentService.Update(_department);
                DataGridUpdater.UpdateDataGrid(_departmentService.Get(), _parent);
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
                _departmentService.Create(_department);
                DataGridUpdater.UpdateDataGrid(_departmentService.Get(), _parent);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _department.FullName = FullName.Text;
            _department.Description = Description.Text;
            _department.DateStart = DateTime.Parse(DateStart.Text);
            _department.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            _department.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();
            _department.OrganizationId = _organizations.FirstOrDefault(i => i == BoxOrganizations.SelectedItem).Id;
            _department.DirectorId = int.Parse(DirectorId.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
