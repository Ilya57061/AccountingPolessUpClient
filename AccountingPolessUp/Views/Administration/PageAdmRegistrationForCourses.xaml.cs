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
    /// Interaction logic for PageAdmRegistrationForCourses.xaml
    /// </summary>
    public partial class PageAdmRegistrationForCourses : Page
    {
        RegistrationForCoursesService _registrationForCoursesService = new RegistrationForCoursesService();
        public PageAdmRegistrationForCourses()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedRegistrationForCourses();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _registrationForCoursesService.Get(), DateEntry.Text, BoxParticipant.Text, BoxTrainingCourses.Text);
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
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_registrationForCoursesService.Get(), this);
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
