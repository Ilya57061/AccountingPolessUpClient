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
        ProjectService _projectService = new ProjectService();
        List<Project> _projects;
        public PageAdmProjects()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_projectService.Get(), this);
        }
        public PageAdmProjects(List<Project> projects)
        {
            InitializeComponent();
            _projects = projects;
            DataGridUpdater.UpdateDataGrid(_projectService.Get(), this);
            ColumSelect.Visibility= Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ConfirmFilter(dataGrid, _finalProjectService.Get().Where(x => x.EmploymentId == _employment.Id), TextBoxName.Text,
            //    TextBoxDescription.Text, TextBoxGitHub.Text, TextBoxLink.Text, DateStart.Text, DateEnd.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Project project = dataGrid.SelectedItems[i] as Project;
                DataNavigator.UpdateValueComboBox(_projects.FirstOrDefault(x => x.Id == project.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    Project project = dataGrid.SelectedItems[i] as Project;
                    if (project != null)
                    {

                        _projectService.Delete(project.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_projectService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditProject(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Project project = dataGrid.SelectedItems[i] as Project;
                if (project != null)
                {
                    EditFrame.Content = new PageEditProject(project, this);

                }
            }
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
