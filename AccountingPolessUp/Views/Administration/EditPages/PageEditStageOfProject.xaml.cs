using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Interaction logic for PageEditStageOfProject.xaml
    /// </summary>
    public partial class PageEditStageOfProject : Page
    {
        private StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        private ProjectService _projectService = new ProjectService();

        private List<Project> _projects;
        private StagesOfProject _stagesOfProject;
        private Page _parent;
        public PageEditStageOfProject(StagesOfProject stagesOfProject, Page parent)
        {
            InitializeComponent();
            SetProjects();
          
            DataContext = stagesOfProject;
            _stagesOfProject = stagesOfProject;
            _parent = parent;

            BoxStatus.SelectedIndex = _stagesOfProject.Status == "Завершён" ? 0 : 1;
            BoxProject.SelectedIndex = _projects.IndexOf(_projects.FirstOrDefault(r => r.Id == stagesOfProject.ProjectId));

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }

        public PageEditStageOfProject(Page parent)
        {
            InitializeComponent();
            SetProjects();
            
            _stagesOfProject = new StagesOfProject();
            _parent = parent;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void SetProjects()
        {
            _projects = _projectService.Get();

            if (RoleValidator.User.Role.Name == "LocalPm")
                _projects = _projects.Where(x => RoleValidator.RoleChecker((int)x.idLocalPM) == true).ToList();

            BoxProject.ItemsSource = _projects;
        }
        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxProject.Name;

            _parent.NavigationService.Content = new PageAdmProjects(_projects);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _stagesOfProject);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Create(this, _stagesOfProject);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _stagesOfProject.Name = Name.Text;
            _stagesOfProject.Description = Description.Text;

            _stagesOfProject.DateStart = DateTime.Parse(DateStart.Text);
            _stagesOfProject.DateEnd = DateTime.Parse(DateEnd.Text);

            _stagesOfProject.Status = ((ComboBoxItem)BoxStatus.SelectedItem).Content.ToString();

            _stagesOfProject.ProjectId = _projects.FirstOrDefault(i => i == BoxProject.SelectedItem).Id;
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
