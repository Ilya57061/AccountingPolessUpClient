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
    /// Interaction logic for PageAdmAppInTheProject.xaml
    /// </summary>
    public partial class PageAdmAppInTheProject : Page
    {
        private ApplicationsInTheProjectService _appService = new ApplicationsInTheProjectService();
        private ParticipantsService _participantsService = new ParticipantsService();
        private VacancyService _vacancyService = new VacancyService();
        private List<ApplicationsInTheProject> _applicationsInTheProject;
        private Vacancy _vacancy;

        public PageAdmAppInTheProject()
        {
            InitializeComponent();
            DataGridUpdater.AdmAppInTheProject = this;
            BoxVacancy.ItemsSource = _vacancyService.Get();
            BoxParticipant.ItemsSource = _participantsService.Get();
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            ButtonEdit.Visibility = AccessChecker.AccessEditButton(this) ? Visibility.Hidden : Visibility.Visible;
            ButtonAdd.Visibility = AccessChecker.AccessAddButton(this) ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmAppInTheProject(Vacancy vacancy)
        {
            _vacancy = vacancy;
            InitializeComponent();
            DataGridUpdater.AdmAppInTheProject = this;
            BoxVacancy.IsEnabled = false;
            BoxParticipant.ItemsSource = _participantsService.Get();
            UpdateDataGrid();
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            ButtonEdit.Visibility = AccessChecker.AccessEditButton(this) ? Visibility.Hidden : Visibility.Visible;
        }
        public void UpdateDataGrid()
        {
            try
            {
                if (_vacancy == null) _applicationsInTheProject = _appService.Get();
                else _applicationsInTheProject = _appService.Get(_vacancy.Id);
                if (RoleValidator.User.Role.Name != "Admin")
                    _applicationsInTheProject = _applicationsInTheProject.Where(x => RoleValidator.RoleChecker(AccessChecker.ApplicationsInTheProjectCheck(x.ParticipantsId)) != true).ToList();
                DataGridUpdater.UpdateDataGrid(_applicationsInTheProject, this);
            }
            catch (System.Exception)
            {
               
            }        
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
            DeleteSelectedApplications();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditApplicationsInTheProject(this);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedApplications();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _applicationsInTheProject, DateEntry.Text, BoxParticipant.Text, BoxVacancy.Text, BoxIsAccepted.Text, Status.Text, StatusDescription.Text);
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

        private void DeleteSelectedApplications()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (ApplicationsInTheProject app in dataGrid.SelectedItems)
                {
                        _appService.Delete(app.Id);
                }
                UpdateDataGrid();
            }
        }

        private void EditSelectedApplications()
        {
            if (dataGrid.SelectedItems.Count == 1)
            {
                ApplicationsInTheProject app = dataGrid.SelectedItem as ApplicationsInTheProject;
                if (app != null)
                {
                        EditFrame.Content = new PageEditApplicationsInTheProject(app, this);
                }
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}