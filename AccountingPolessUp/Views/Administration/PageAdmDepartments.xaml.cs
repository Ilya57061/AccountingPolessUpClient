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
    /// Логика взаимодействия для PageAdmDepartments.xaml
    /// </summary>
    public partial class PageAdmDepartments : Page
    {
        private readonly DepartmentService _departmentService = new DepartmentService();
        List<Department> _departments;
        Position _position;
        public PageAdmDepartments()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        public PageAdmDepartments(List<Department> departments)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _departments = departments;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedDepartments();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedDepartments();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditDepartments(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedDepartments();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _departmentService.Get(), FullName.Text, Description.Text, DateStart.Text, DateEnd.Text, BoxStatus.Text, BoxOrganizations.Text, DirectorId.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void DeleteSelectedDepartments()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Department department in dataGrid.SelectedItems)
                {
                    _departmentService.Delete(department.Id);
                }
                UpdateDataGrid();
            }
        }
        private void SelectSelectedDepartments()
        {
            foreach (Department department in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_departments.FirstOrDefault(x => x.Id == department.Id));
            }
            this.NavigationService.GoBack();
        }
        private void EditSelectedDepartments()
        {
            foreach (Department department in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditDepartments(department, this);
            }
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_departmentService.Get(), this);
        }
        private void ButtonPositions_Click(object sender, RoutedEventArgs e)
        {
            OpenPositions();
        }
        private void OpenPositions()
        {
            foreach (Department department in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmPosition(department);
            }
        }
    }
}
