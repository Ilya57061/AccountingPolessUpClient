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
        PositionService _positionService = new PositionService();
        DepartmentService _departmentService = new DepartmentService();
        List<Department> _departments;
        Position _position;
        public PageEditPosition(Position position)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _position = position;
            DataContext = position;
            _departments = _departmentService.Get();
            BoxDepartment.ItemsSource = _departments;
            BoxDepartment.SelectedIndex = _departments.IndexOf(_departments.FirstOrDefault(d=>d.Id==position.DepartmentId));
        }
        public PageEditPosition()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _position = new Position();
            _departments = _departmentService.Get();
            BoxDepartment.ItemsSource = _departments;
        }
        private void OpenDepartments_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _positionService.Update(_position);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _positionService.Create(_position);
        }
        private void WriteData()
        {
            _position.FullName = Fullname.Text;
            _position.Description= Description.Text;
            _position.DepartmentId=_departments.FirstOrDefault(i=>i==BoxDepartment.SelectedItem).Id;
        }
    }
}
