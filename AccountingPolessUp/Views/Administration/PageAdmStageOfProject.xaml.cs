﻿using AccountingPolessUp.Helpers;
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
    /// Interaction logic for PageAdmStageOfProject.xaml
    /// </summary>
    public partial class PageAdmStageOfProject : Page
    {
        private readonly StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        List<StagesOfProject> _stagesOfProjects;
        Project _project;
        public PageAdmStageOfProject()
        {
            InitializeComponent();
            DataGridUpdater.AdmStageOfProject = this;
            ButtonBack.Visibility = Visibility.Hidden;
            UpdateDataGrid();
            FilterComboBox.SetBoxProjects(BoxProject);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmStageOfProject(Project project)
        {
            InitializeComponent();
            DataGridUpdater.AdmStageOfProject = this;
            BoxProject.IsEnabled = false;
            _project = project;
            UpdateDataGrid();
            FilterComboBox.SetBoxProjects(BoxProject);
            ButtonDelete.Visibility = AccessChecker.AccessDeleteButton() ? Visibility.Hidden : Visibility.Visible;
        }
        public PageAdmStageOfProject(List<StagesOfProject> stagesOfProjects)
        {
            InitializeComponent();
            DataGridUpdater.AdmStageOfProject = this;
            ColumSelect.Visibility = Visibility.Visible;
            _stagesOfProjects = stagesOfProjects;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonDelete.Visibility = Visibility.Hidden;
            ButtonEdit.Visibility = Visibility.Hidden;
            DataGridUpdater.UpdateDataGrid(_stagesOfProjects, this);
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
            DeleteSelectedStagesOfProjects();
        }
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectSelectedStagesOfProjects();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditFrame.Content = new PageEditStageOfProject(this);
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelFrameChecker.Cancel(this);
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedStagesOfProjects();
            ButtonCancel.Visibility = Visibility.Visible;
        }
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            FilterManager.ConfirmFilter(dataGrid, _stagesOfProjects, Name.Text, Description.Text, DateStart.Text, DateEnd.Text, BoxStatus.Text, BoxProject.Text);
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            FilterManager.ClearControls(Panel);
            UpdateDataGrid();
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
        public void UpdateDataGrid()
        {
            try
            {
                if (_project == null) _stagesOfProjects = _stagesOfProjectService.Get();
                else _stagesOfProjects = _stagesOfProjectService.Get(_project.Id);
                if (RoleValidator.User.Role.Name == "LocalPm")
                    _stagesOfProjects = _stagesOfProjects.Where(x => RoleValidator.RoleChecker((int)x.Project.idLocalPM) == true).ToList();
                DataGridUpdater.UpdateDataGrid(_stagesOfProjects, this);
            }
            catch (System.Exception)
            {
            }
        }
        private void DeleteSelectedStagesOfProjects()
        {
            if (dataGrid.SelectedItems.Count > 0 && MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void ButtonVacancy_Click(object sender, RoutedEventArgs e)
        {
            OpenVacancy();
        }
        private void OpenVacancy()
        {
            foreach (StagesOfProject stagesOfProject in dataGrid.SelectedItems)
            {
                this.NavigationService.Content = new PageAdmVacancy(stagesOfProject);
            }
        }
    }
}
