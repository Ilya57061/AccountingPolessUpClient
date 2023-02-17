using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration
{
    /// <summary>
    /// Логика взаимодействия для PageAdmFinalProject.xaml
    /// </summary>
    public partial class PageAdmFinalProject : Page
    {
        private readonly FinalProjectService _finalProjectService = new FinalProjectService();
        List<FinalProject> _finalProjects;
        Employment _employment;
        EmploymentService _employmentService = new EmploymentService();
        public PageAdmFinalProject(Employment employment)
        {
            InitializeComponent();
            _employment = employment;
            BoxEmployment.IsEnabled = false;
            BoxEmployment.ItemsSource = _employmentService.Get();
            DataGridUpdater.AdmFinalProject = this;
            UpdateDataGrid();
        }
        public PageAdmFinalProject()
        {
            InitializeComponent();
            BoxEmployment.ItemsSource = _employmentService.Get();
            ButtonBack.Visibility = Visibility.Hidden;
            DataGridUpdater.AdmFinalProject = this;
            UpdateDataGrid();
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
            DeleteSelectedFinalProjects();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditFinalProject(_employment, this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedFinalProjects();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _finalProjects, Name.Text, Description.Text, GitHub.Text, Links.Text, DateStart.Text, DateEnd.Text, BoxEmployment.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            UpdateDataGrid();
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        public void UpdateDataGrid()
        {
            try
            {
                if (_employment == null)
                    _finalProjects = _finalProjectService.Get();
                else
                    _finalProjects = _finalProjectService.GetByEmployment(_employment.Id);
                if (RoleValidator.User.Role.Name != "Admin")
                    _finalProjects = _finalProjects.Where(x => RoleValidator.RoleChecker(AccessChecker.ApplicationsInTheProjectCheck(x.Employment.ParticipantsId)) == true).ToList();
                DataGridUpdater.UpdateDataGrid(_finalProjects, this);
            }
            catch (System.Exception)
            {

                throw;
            }
           

        }
        private void DeleteSelectedFinalProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (FinalProject finalProject in dataGrid.SelectedItems)
                {
                   _finalProjectService.Delete(finalProject.Id);
                }
            }
            UpdateDataGrid();
        }
        private void EditSelectedFinalProjects()
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                FinalProject finalProject = dataGrid.SelectedItem as FinalProject;
                if (finalProject != null)
                {
                    EditFrame.Content = new PageEditFinalProject(finalProject, _employment, this);
                }
            }
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
