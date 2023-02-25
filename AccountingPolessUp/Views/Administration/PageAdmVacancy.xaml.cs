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
    /// Логика взаимодействия для PageAdmVacancy.xaml
    /// </summary>
    public partial class PageAdmVacancy : Page
    {
        private readonly VacancyService _vacancyService = new VacancyService();
        List<Vacancy> _vacancies;
        StagesOfProject _stagesOfProject;
        StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        public PageAdmVacancy()
        {
            InitializeComponent();
            DataGridUpdater.AdmVacancy = this;
            ButtonBack.Visibility = Visibility.Hidden;
            BoxStagesOfProject.ItemsSource = _stagesOfProjectService.Get();
            FilterComboBox.SetBoxStagesProjects(BoxStagesOfProject);
            UpdateDataGrid();
        }
        public PageAdmVacancy(List<Vacancy> vacancies)
        {
            InitializeComponent();
            DataGridUpdater.AdmVacancy = this;
            ButtonBack.Visibility = Visibility.Hidden;
            BoxStagesOfProject.ItemsSource = _stagesOfProjectService.Get();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _vacancies = vacancies;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
            DataGridUpdater.UpdateDataGrid(_vacancies, this);
        }
        public PageAdmVacancy(StagesOfProject stagesOfProject)
        {
            InitializeComponent();
            BoxStagesOfProject.IsEnabled = false;
            BoxStagesOfProject.ItemsSource = _stagesOfProjectService.Get();
            _stagesOfProject = stagesOfProject;
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            ButtonAdd.Visibility = AccessChecker.AccessAddButton(this) ? Visibility.Hidden : Visibility.Visible;
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
            DeleteSelectedVacancies();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedVacancies();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditVacancy(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedVacancies();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _vacancies, Name.Text, Descriptions.Text, Responsibilities.Text, DateStart.Text, DateEnd.Text, BoxStagesOfProject.Text, IsOpened.Text, Budget.Text.Replace('.', ','), RatingCoefficient.Text.Replace('.', ','));
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextDoubleInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DoubleValidator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        public void UpdateDataGrid()
        {
            if (_stagesOfProject == null) _vacancies = _vacancyService.Get();
            else _vacancies = _vacancyService.Get(_stagesOfProject.Id);
            DataGridUpdater.UpdateDataGrid(_vacancies, this);
        }
        private void DeleteSelectedVacancies()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Vacancy vacancy in dataGrid.SelectedItems)
                {
                    if (RoleValidator.RoleChecker((int)vacancy.StagesOfProject.Project.idLocalPM))
                        _vacancyService.Delete(vacancy.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedVacancies()
        {
            foreach (Vacancy vacancy in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_vacancies.FirstOrDefault(x => x.Id == vacancy.Id));
            }
            this.NavigationService.GoBack();
        }
        private void EditSelectedVacancies()
        {
            foreach (Vacancy vacancy in dataGrid.SelectedItems)
            {
                if (RoleValidator.RoleChecker((int)vacancy.StagesOfProject.Project.idLocalPM))
                {
                    EditFrame.Content = new PageEditVacancy(vacancy, this);
                    break;
                }
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void ButtonAppInTheProject_Click(object sender, RoutedEventArgs e)
        {
            OpenAppInTheProject();
        }
        private void OpenAppInTheProject()
        {
            foreach (Vacancy vacancy in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmAppInTheProject(vacancy);
            }
        }
    }
}
