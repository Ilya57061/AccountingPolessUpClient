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
    /// Логика взаимодействия для PageAdmEducationalPortals.xaml
    /// </summary>
    public partial class PageAdmEducationalPortals : Page
    {
        private readonly EducationalPortalsService _educationalPortalsService = new EducationalPortalsService();
        public PageAdmEducationalPortals()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedEducationalPortals();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditEducationalPortals(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedEducationalPortals();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _educationalPortalsService.Get(), BoxDepartment.Text, Name.Text, Description.Text, Link.Text);
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
        private void DeleteSelectedEducationalPortals()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (EducationalPortals educationalPortal in dataGrid.SelectedItems)
                {
                    _educationalPortalsService.Delete(educationalPortal.Id);
                }
                UpdateDataGrid();
            }
        }
        private void EditSelectedEducationalPortals()
        {
            foreach (EducationalPortals educationalPortal in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditEducationalPortals(educationalPortal, this);
            }
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_educationalPortalsService.Get(), this);
        }
    }
}
