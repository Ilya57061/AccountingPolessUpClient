using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.Views.Administration.EditPages;
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

        public PageAdmAppInTheProject()
        {
            InitializeComponent();
            DataGridUpdater.UpdateDataGrid(_appService.Get(), this);
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
            FilterManager.ConfirmFilter(dataGrid, _appService.Get(), BoxWorkStatus.Text, DateEntry.Text, BoxParticipant.Text, ComboBoxVacancy.Text);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(panel);
            DataGridUpdater.UpdateDataGrid(_appService.Get(), this);
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }

        private void DeleteSelectedApplications()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (ApplicationsInTheProject app in dataGrid.SelectedItems)
                {
                    _appService.Delete(app.Id);
                }
                DataGridUpdater.UpdateDataGrid(_appService.Get(), this);
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
    }
}
