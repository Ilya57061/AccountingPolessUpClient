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
    /// Interaction logic for PageAdmAppInTheProject.xaml
    /// </summary>
    public partial class PageAdmAppInTheProject : Page
    {
        private readonly ApplicationsInTheProjectService _appService = new ApplicationsInTheProjectService();
        List<ApplicationsInTheProject> _applicationsInTheProject;
        Vacancy _vacancy;
        ParticipantsService _participantsService = new ParticipantsService();
        VacancyService _vacancyService = new VacancyService();

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
            AccessChecker.AccessEditButton(this);
        }
        public PageAdmAppInTheProject(Vacancy vacancy)
        {
            InitializeComponent();
            DataGridUpdater.AdmAppInTheProject = this;
            BoxVacancy.IsEnabled = false;
            BoxParticipant.ItemsSource = _participantsService.Get();
            _vacancy = vacancy;
            UpdateDataGrid();
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            AccessChecker.AccessEditButton(this);
        }
        public void UpdateDataGrid()
        {
            if (_vacancy == null) _applicationsInTheProject = _appService.Get();
            else _applicationsInTheProject = _appService.Get(_vacancy.Id);
            DataGridUpdater.UpdateDataGrid(_applicationsInTheProject, this);
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
                    if (RoleValidator.RoleChecker((int)app.Vacancy.StagesOfProject.Project.idLocalPM))
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
                    if (RoleValidator.RoleChecker((int)app.Vacancy.StagesOfProject.Project.idLocalPM))
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
