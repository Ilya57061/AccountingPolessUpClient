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
    /// Логика взаимодействия для PageEditPosition.xaml
    /// </summary>
    public partial class PageEditPosition : Page
    {
        private PositionService _positionService = new PositionService();
        private DepartmentService _departmentService = new DepartmentService();
        private List<Department> _departments;
        private List<Position> positions;
        private Position _position;
        private Department _department;
        private Page _parent;
        public PageEditPosition(Position position, Page parent, Department department)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _position = position;
            _department = department;
            DataContext = position;
            _departments = _departmentService.Get();
            BoxDepartment.ItemsSource = _departments;
            BoxDepartment.SelectedIndex = _departments.IndexOf(_departments.FirstOrDefault(d => d.Id == position.DepartmentId));
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditPosition(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _position = new Position();
            _departments = _departmentService.Get();
            BoxDepartment.ItemsSource = _departments;
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        private void OpenDepartments_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxDepartment.Name;
            _parent.NavigationService.Content = new PageAdmDepartments(_departments);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _positionService.Update(_position);
                UpdateDataGrid();
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
                _positionService.Create(_position);
                UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.AdmPosition.UpdateDataGrid();
        }
        private void WriteData()
        {
            _position.FullName = Fullname.Text;
            _position.Description = Description.Text;
            _position.DepartmentId = _departments.FirstOrDefault(i => i == BoxDepartment.SelectedItem).Id;
        }
    }
}
