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
    /// Логика взаимодействия для PageAdmPosition.xaml
    /// </summary>
    public partial class PageAdmPosition : Page
    {
        private readonly PositionService _positionService = new PositionService();
        Department _department;
        public PageAdmPosition()
        {
            InitializeComponent();
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
        }
        public PageAdmPosition(Department department)
        {
            InitializeComponent();
            _department = department;
            UpdateDataGrid();
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
            FilterManager.ConfirmFilter(dataGrid, _positionService.Get(), Fullname.Text, Description.Text, BoxDepartment.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            if (_department == null)
                DataGridUpdater.UpdateDataGrid(_positionService.Get(), this);
            else
                DataGridUpdater.UpdateDataGrid(_positionService.Get(_department.Id), this);
        }
        private void DeleteSelectedPositions()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Position position in dataGrid.SelectedItems)
                {
                    _positionService.Delete(position.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedPositions()
        {
            foreach (Position position in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditPosition(position, this);
                break;
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
