using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        private ProjectService _projectService = new ProjectService();
        private List<Project> _project;
        private StagesOfProject _stagesOfProject;
        private Page _parent;

        public PageEditStageOfProject(StagesOfProject stagesOfProject, Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _project = _projectService.Get();
            DataContext = stagesOfProject;
            _stagesOfProject = stagesOfProject;
            BoxProject.ItemsSource = _project;
            BoxStatus.SelectedIndex = _stagesOfProject.Status == "Завершён" ? 0 : 1;
            BoxProject.SelectedIndex = _project.IndexOf(_project.FirstOrDefault(r => r.Id == stagesOfProject.ProjectId));
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        public PageEditStageOfProject(Page parent)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _stagesOfProject = new StagesOfProject();
            _project = _projectService.Get();
            BoxProject.ItemsSource = _project;
            _parent = parent;
            AccessChecker.AccessOpenButton(this);
        }
        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxProject.Name;
            _parent.NavigationService.Content = new PageAdmProjects(_project);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _stagesOfProjectService.Update(_stagesOfProject);
                DataGridUpdater.AdmStageOfProject.UpdateDataGrid();
                this.NavigationService.GoBack();
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
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _stagesOfProjectService.Create(_stagesOfProject);
                DataGridUpdater.AdmStudents.UpdateDataGrid();
                this.NavigationService.GoBack();
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
            _stagesOfProject.ProjectId = _project.FirstOrDefault(i => i == BoxProject.SelectedItem).Id;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
