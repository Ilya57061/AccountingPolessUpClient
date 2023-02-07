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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditEducationalPortals.xaml
    /// </summary>
    public partial class PageEditEducationalPortals : Page
    {

        Page _parent;
        EducationalPortalsService _educationalPortalsService = new EducationalPortalsService();
        List<Department> _department;
        DepartmentService _departmentService = new DepartmentService();
        EducationalPortals _educationalPortals;
        public PageEditEducationalPortals(EducationalPortals educationalPortals, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _department = _departmentService.Get();
            DataContext = educationalPortals;
            _educationalPortals = educationalPortals;
            BoxDepartment.ItemsSource = _department;
            BoxDepartment.SelectedIndex = _department.IndexOf(_department.FirstOrDefault(r => r.Id == educationalPortals.DepartmentId));
            _parent = parent;
        }
        public PageEditEducationalPortals(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _educationalPortals = new EducationalPortals();
            _department = _departmentService.Get();
            BoxDepartment.ItemsSource = _department;
            _parent= parent;
        }
        private void OpenDepartments_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxDepartment.Name;
            _parent.NavigationService.Content = new PageAdmDepartments(_department);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _educationalPortalsService.Update(_educationalPortals);
                DataGridUpdater.UpdateDataGrid(_educationalPortalsService.Get(),_parent);
                this.NavigationService.GoBack();
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
                _educationalPortalsService.Create(_educationalPortals);
                DataGridUpdater.UpdateDataGrid(_educationalPortalsService.Get(), _parent);
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _educationalPortals.DepartmentId = _department.FirstOrDefault(i => i == BoxDepartment.SelectedItem).Id;
            _educationalPortals.Name = Name.Text;
            _educationalPortals.Description = Description.Text;
            _educationalPortals.Link = Link.Text;
        }
    }
}
