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
    /// Interaction logic for PageAdmStageOfProject.xaml
    /// </summary>
    public partial class PageAdmStageOfProject : Page
    {
        private readonly StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        List<StagesOfProject> _stagesOfProjects;
        public PageAdmStageOfProject()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        public PageAdmStageOfProject(List<StagesOfProject> stagesOfProjects)
        {
            InitializeComponent();
            UpdateDataGrid();
            ColumSelect.Visibility = Visibility.Visible;
            _stagesOfProjects = stagesOfProjects;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedStagesOfProjects();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedStagesOfProjects();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditStageOfProject(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedStagesOfProjects();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ConfirmFilter(dataGrid, _stagesOfProjectService.Get(), Name.Text, Description.Text, DateStart.Text, DateEnd.Text, BoxStatus.Text, BoxProject.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void UpdateDataGrid()
        {
            DataGridUpdater.UpdateDataGrid(_stagesOfProjectService.Get(), this);
        }
        private void DeleteSelectedStagesOfProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Confirm deletion", "Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (StagesOfProject stagesOfProject in dataGrid.SelectedItems)
                {
                    _stagesOfProjectService.Delete(stagesOfProject.Id);
                }
            }
            UpdateDataGrid();
        }
        private void SelectSelectedStagesOfProjects()
        {
            foreach (StagesOfProject stagesOfProject in dataGrid.SelectedItems)
            {
                DataNavigator.UpdateValueComboBox(_stagesOfProjects.FirstOrDefault(x => x.Id == stagesOfProject.Id));
            }

            this.NavigationService.GoBack();
        }
        private void EditSelectedStagesOfProjects()
        {
            foreach (StagesOfProject stagesOfProject in dataGrid.SelectedItems)
            {
                EditFrame.Content = new PageEditStageOfProject(stagesOfProject, this);
                break;
            }
        }
    }
}
