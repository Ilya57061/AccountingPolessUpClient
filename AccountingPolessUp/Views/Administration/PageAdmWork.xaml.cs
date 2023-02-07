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
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmWork.xaml
    /// </summary>
    public partial class PageAdmWork : Page
    {
        private readonly EmploymentService _employmentService = new EmploymentService();
        public PageAdmWork()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedEmployments();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditWork(this);
        }
        private void ButtonFinalProject_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedEmployment();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedEmployment();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _employmentService.Get(),DateStart.Text,DateEnd.Text,BoxPosition.Text,BoxStatus.Text, StatusDescription.Text,BoxMentors.Text, BoxParticipants.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_employmentService.Get(), this);
        }
        private void DeleteSelectedEmployments()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Employment employment in dataGrid.SelectedItems)
                {
                    _employmentService.Delete(employment.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedEmployment()
        {
            foreach (Employment employment in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmFinalProject(employment);
            }
        }
        private void EditSelectedEmployment()
        {
            foreach (Employment employment in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditWork(employment, this);
                break;
            }
        }
    }
}
