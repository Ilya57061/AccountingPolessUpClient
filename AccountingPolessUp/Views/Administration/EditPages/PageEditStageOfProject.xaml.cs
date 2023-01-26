using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Interaction logic for PageEditStageOfProject.xaml
    /// </summary>
    public partial class PageEditStageOfProject : Page
    {
        StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        ProjectService _projectService = new ProjectService();
        List<Project> _project;
        StagesOfProject _stagesOfProject;
        public PageEditStageOfProject(StagesOfProject stagesOfProject)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _project = _projectService.Get();
            DataContext = stagesOfProject;
            _stagesOfProject = stagesOfProject;
            BoxProject.ItemsSource = _project;
            BoxProject.SelectedIndex = _project.IndexOf(_project.FirstOrDefault(r => r.Id == stagesOfProject.ProjectId));
        }
        public PageEditStageOfProject()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _stagesOfProject = new StagesOfProject();
            _project = _projectService.Get();
            BoxProject.ItemsSource = _project;
        }

        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _stagesOfProjectService.Update(_stagesOfProject);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WriteData();
            _stagesOfProjectService.Create(_stagesOfProject);
        }
        private void WriteData()
        {
            _stagesOfProject.Name = Name.Text;
            _stagesOfProject.Description = Description.Text;
            _stagesOfProject.DateStart = DateTime.Parse(DateStart.Text);
            _stagesOfProject.DateStart = DateTime.Parse(DateEnd.Text);
            _stagesOfProject.Status = Status.Text;
            _stagesOfProject.ProjectId = _project.FirstOrDefault(i => i == BoxProject.SelectedItem).Id;
        }
    }
}
