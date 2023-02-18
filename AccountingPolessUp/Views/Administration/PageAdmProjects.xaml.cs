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
    /// Логика взаимодействия для PageAdmProjects.xaml
    /// </summary>
    public partial class PageAdmProjects : Page
    {
        private readonly ProjectService _projectService = new ProjectService();
        ParticipantsService _participantsService = new ParticipantsService();
        List<Project> _projects;
        public PageAdmProjects()
        {
            InitializeComponent();
            DataGridUpdater.AdmProjects = this;
            BoxLocalPM.ItemsSource = _participantsService.Get();
            UpdateDataGrid();
            FilterComboBox.SetBoxCustomers(BoxCustomer);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            ButtonAdd.Visibility = AccessChecker.AccessAddButton(this) ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmProjects(List<Project> projects)
        {
            InitializeComponent();
            DataGridUpdater.AdmProjects = this;
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _projects = projects;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxCustomers(BoxCustomer);
            DataGridUpdater.UpdateDataGrid(_projects, this);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
            ButtonAdd.Visibility = AccessChecker.AccessAddButton(this) ? Visibility.Hidden : Visibility.Visible;
        }
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineRight(scroll);
        }
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.LineLeft(scroll);
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            string localPMId = string.IsNullOrEmpty(BoxLocalPM.Text) ? "" : _participantsService.GetByParticipantName(BoxLocalPM.Text).Id.ToString();
            FilterManager.ConfirmFilter(dataGrid, _projects, BoxCustomer.Text, BoxStatus.Text, DateStart.Text, DateEnd.Text, Description.Text, TechnicalSpecification.Text, localPMId, Fullname.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedProjects();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditProject(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
            ButtonCancel.Visibility = Visibility.Hidden;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedProjects();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

            DeleteSelectedProjects();
        }
        public void UpdateDataGrid()
        {
            try
            {
                _projects = _projectService.Get();
                if (RoleValidator.User.Role.Name == "LocalPm")
                    _projects = _projects.Where(x => RoleValidator.RoleChecker((int)x.idLocalPM) == true).ToList();
                DataGridUpdater.UpdateDataGrid(_projects, this);
            }
            catch (Exception)
            {
            }
        }
        private void DeleteSelectedProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Project project in dataGrid.SelectedItems)
                {
                    _projectService.Delete(project.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedProjects()
        {
            foreach (Project project in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_projects.FirstOrDefault(x => x.Id == project.Id));
            }
            this.NavigationService.GoBack();
        }
        private void EditSelectedProjects()
        {
            foreach (Project project in dataGrid.SelectedItems)
            {
                if (RoleValidator.RoleChecker((int)project.idLocalPM))
                {
                    EditFrame.Content = new PageEditProject(project, this);
                    break;
                }
            }
        }
        private void ButtonStages_Click(object sender, RoutedEventArgs e)
        {
            OpenStagesOfProject();
        }
        private void OpenStagesOfProject()
        {
            foreach (Project project in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmStageOfProject(project);
            }
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
