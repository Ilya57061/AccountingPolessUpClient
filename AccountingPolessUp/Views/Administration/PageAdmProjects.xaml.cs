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
            BoxLocalPM.ItemsSource = _participantsService.Get();
            _projects = _projectService.Get();
            UpdateDataGrid();
            FilterComboBox.SetBoxCustomers(BoxCustomer);
        }
        public PageAdmProjects(List<Project> projects)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _projects = projects;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
            FilterComboBox.SetBoxCustomers(BoxCustomer);
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
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _projects, BoxCustomer.Text, BoxStatus.Text, DateStart.Text, DateEnd.Text, Description.Text, TechnicalSpecification.Text, _participantsService.Get().FirstOrDefault(x=>x.Individuals.FIO==BoxLocalPM.Text).Id.ToString(), Fullname.Text);
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
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedProjects();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedProjects();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_projects, this);
        }
        private void DeleteSelectedProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
                EditFrame.Content = new PageEditProject(project, this);
                break;
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
    }
}
