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
    /// Логика взаимодействия для PageEditVacancy.xaml
    /// </summary>
    public partial class PageEditVacancy : Page
    {
        private VacancyService _vacancyService = new VacancyService();
        private StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();

        private List<StagesOfProject> _stagesOfProjects;
        private Vacancy _vacancy;
        private Page _parent;
        public PageEditVacancy(Vacancy vacancy, Page parent)
        {
            InitializeComponent();

            _stagesOfProjects = _stagesOfProjectService.Get();
            _vacancy = vacancy;
            DataContext = vacancy;
            _parent = parent;
           
            BoxStagesOfProject.ItemsSource = _stagesOfProjects;
            BoxStagesOfProject.SelectedIndex = _stagesOfProjects.IndexOf(_stagesOfProjects.FirstOrDefault(s => s.Id == vacancy.StagesOfProjectId));

            IsOpened.SelectedIndex = _vacancy.isOpened ? 0 : 1;

            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;

            AccessChecker.AccessOpenButton(this);
        }
        public PageEditVacancy(Page parent)
        {
            InitializeComponent();

            _vacancy = new Vacancy();
            _stagesOfProjects = _stagesOfProjectService.Get();   
            _parent = parent;
                
            BoxStagesOfProject.ItemsSource = _stagesOfProjects;

            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;

            AccessChecker.AccessOpenButton(this);
        }
        private void OpenStages_Click(object sender, RoutedEventArgs e)
        {
            DataNavigator.ChangePage = this;
            DataNavigator.NameBox = BoxStagesOfProject.Name;

            _parent.NavigationService.Content = new PageAdmStageOfProject(_stagesOfProjects);
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                DataAccess.Update(this, _vacancy);
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
                DataAccess.Create(this, _vacancy);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }
        }
        private void WriteData()
        {
            _vacancy.Name = Name.Text;
            _vacancy.Descriptions = Descriptions.Text;
            _vacancy.Responsibilities = Responsibilities.Text;

            _vacancy.DateStart = DateTime.Parse(DateStart.Text);
            _vacancy.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);

            _vacancy.StagesOfProjectId = _stagesOfProjects.FirstOrDefault(i => i == BoxStagesOfProject.SelectedItem).Id;

            _vacancy.isOpened = bool.Parse(IsOpened.Text);

            _vacancy.Budget = double.TryParse(Budget.Text.Replace('.', ','), out var pr) ? pr : (double?)null;
            _vacancy.RatingCoefficient = double.TryParse(RatingCoefficient.Text.Replace('.', ','), out var rc) ? rc : (double?)null;
        }
        private void Number_PreviewTextDoubleInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DoubleValidator(e);
        }
        private void Number_PreviewDateInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.DateValidator(e);
        }
    }
}
