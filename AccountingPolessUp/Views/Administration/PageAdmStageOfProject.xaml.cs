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
        StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        List<StagesOfProject> _stagesOfProjects;
        public PageAdmStageOfProject()
        {
            InitializeComponent();
            
            DataGridUpdater.UpdateDataGrid(_stagesOfProjectService.Get(), this);
        }
        public PageAdmStageOfProject(List<StagesOfProject> stagesOfProjects)
        {

            InitializeComponent();
            ColumSelect.Visibility = Visibility.Visible;
            DataGridUpdater.UpdateDataGrid(_stagesOfProjectService.Get(), this);
            _stagesOfProjects = stagesOfProjects;
            ButtonAdd.Visibility = Visibility.Hidden;
            ColumDelete.Visibility = Visibility.Hidden;
            ColumEdit.Visibility = Visibility.Hidden;
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
               StagesOfProject stage = dataGrid.SelectedItems[i] as StagesOfProject;
                DataNavigator.UpdateValueComboBox(_stagesOfProjects.FirstOrDefault(x => x.Id == stage.Id));
            }

            this.NavigationService.GoBack();
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            //FilterManager.ConfirmFilter(dataGrid, _finalProjectService.Get().Where(x => x.EmploymentId == _employment.Id), TextBoxName.Text,
            //    TextBoxDescription.Text, TextBoxGitHub.Text, TextBoxLink.Text, DateStart.Text, DateEnd.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    StagesOfProject stagesOfProject = dataGrid.SelectedItems[i] as StagesOfProject;
                    if (stagesOfProject != null)
                    {
                        _stagesOfProjectService.Delete(stagesOfProject.Id);
                    }
                }
            }
            DataGridUpdater.UpdateDataGrid(_stagesOfProjectService.Get(), this);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditStageOfProject(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                StagesOfProject stagesOfProject = dataGrid.SelectedItems[i] as StagesOfProject;
                if (stagesOfProject != null)
                {
                    EditFrame.Content = new PageEditStageOfProject(stagesOfProject, this);

                }
            }
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
