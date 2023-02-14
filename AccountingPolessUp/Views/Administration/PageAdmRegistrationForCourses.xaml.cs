using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Interaction logic for PageAdmRegistrationForCourses.xaml
    /// </summary>
    public partial class PageAdmRegistrationForCourses : Page
    {
        RegistrationForCoursesService _registrationForCoursesService = new RegistrationForCoursesService();
        List<RegistrationForCourses> _registrationForCourses;
        public PageAdmRegistrationForCourses()
        {
            InitializeComponent();
            _registrationForCourses = _registrationForCoursesService.Get();
            UpdateDataGrid();
            FilterComboBox.SetBoxCourses(BoxTrainingCourses);
            FilterComboBox.SetBoxParticipants(BoxParticipant);
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedRegistrationForCourses();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _registrationForCourses, DateEntry.Text, BoxParticipant.Text, BoxTrainingCourses.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditRegistrationForCourses(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedRegistrationForCourses();
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        public void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_registrationForCourses, this);
        }
        private void DeleteSelectedRegistrationForCourses()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (RegistrationForCourses RegistrationForCourses in dataGrid.SelectedItems)
                {
                    _registrationForCoursesService.Delete(RegistrationForCourses.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedRegistrationForCourses()
        {
            foreach (RegistrationForCourses RegistrationForCourses in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditRegistrationForCourses(RegistrationForCourses, this);
                break;
            }
        }
    }
}
