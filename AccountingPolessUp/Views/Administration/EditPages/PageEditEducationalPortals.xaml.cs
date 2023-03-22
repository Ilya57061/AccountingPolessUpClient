using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditEducationalPortals.xaml
    /// </summary>
    public partial class PageEditEducationalPortals : Page
    {
        private DepartmentService _departmentService = new DepartmentService();

        private List<Department> _department;
        private EducationalPortals _educationalPortals;
        private Page _parent;
        public PageEditEducationalPortals(EducationalPortals educationalPortals, Page parent)
        {
            InitializeComponent();
            
            _department = _departmentService.Get();
            DataContext = educationalPortals;
            _educationalPortals = educationalPortals;
            _parent = parent;

            BoxDepartment.ItemsSource = _department;
            BoxDepartment.SelectedIndex = _department.IndexOf(_department.FirstOrDefault(r => r.Id == educationalPortals.DepartmentId));

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditEducationalPortals(Page parent)
        {
            InitializeComponent();
           
            _educationalPortals = new EducationalPortals();
            _department = _departmentService.Get();
            _parent = parent;

            BoxDepartment.ItemsSource = _department;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
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
                DataAccess.Update(this, _educationalPortals);

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
                DataAccess.Create(this, _educationalPortals);

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
