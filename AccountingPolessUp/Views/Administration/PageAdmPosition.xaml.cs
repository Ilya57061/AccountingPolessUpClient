using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmPosition.xaml
    /// </summary>
    public partial class PageAdmPosition : Page
    {
        public PositionService _positionService = new PositionService();
        List<Position> positions;
        Department _department;

        public PageAdmPosition()
        {
            InitializeComponent();
            DataGridUpdater.AdmPosition = this;
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            FilterComboBox.SetBoxDepartments(BoxDepartment);
        }
        public PageAdmPosition(List<Position> _positions)
        {
            InitializeComponent();
            DataGridUpdater.AdmPosition = this;
            ColumSelect.Visibility = Visibility.Visible;
            ButtonBack.Visibility = Visibility.Hidden;
            positions = _positions;
            ButtonAdd.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxDepartments(BoxDepartment);
            DataGridUpdater.UpdateDataGrid(positions, this);
        }
        public PageAdmPosition(Department department)
        {
            InitializeComponent();
            DataGridUpdater.AdmPosition = this;
            _department = department;
            BoxDepartment.IsEnabled = false;
            UpdateDataGrid();
            FilterComboBox.SetBoxDepartments(BoxDepartment);
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Position position = dataGrid.SelectedItems[i] as Position;
                DataNavigator.UpdateValueComboBox(positions.FirstOrDefault(x => x.Id == position.Id));
            }

            this.NavigationService.GoBack();
        }
        public void CreateRefresh()
        {
            positions = _positionService.Get();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedPositions();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditPosition(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedPositions();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, positions, Fullname.Text, Description.Text, BoxDepartment.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            if (_department == null)
                positions = _positionService.Get();
            else positions = _positionService.Get(_department.Id);

            DataGridUpdater.UpdateDataGrid(positions, this);
        }
        private void DeleteSelectedPositions()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Position position in dataGrid.SelectedItems)
                {
                    if (RoleValidator.RoleChecker((int)position.Department.DirectorId))
                    {
                        _positionService.Delete(position.Id);
                    }
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedPositions()
        {
            foreach (Position position in dataGrid.SelectedItems)
            {
                if (RoleValidator.RoleChecker((int)position.Department.DirectorId))
                {
                    EditFrame.Content = new PageEditPosition(position, this, _department);
                    break;
                }
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
