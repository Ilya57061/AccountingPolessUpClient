using AccountingPolessUp.Helpers;
using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AccountingPolessUp.Views.Administration.EditPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditVacancy.xaml
    /// </summary>
    public partial class PageEditVacancy : Page
    {

        
        VacancyService _vacancyService = new VacancyService();
        StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        List<StagesOfProject> _stagesOfProjects;
        Vacancy _vacancy;
        public PageEditVacancy(Vacancy vacancy)
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Visible;
            ButtonAdd.Visibility = Visibility.Hidden;
            _vacancy = vacancy;
            DataContext = vacancy;
            IsOpened.SelectedIndex = true ? 0 : 1;
            _stagesOfProjects = _stagesOfProjectService.Get();
            BoxStagesOfProject.ItemsSource= _stagesOfProjects;
            BoxStagesOfProject.SelectedIndex = _stagesOfProjects.IndexOf(_stagesOfProjects.FirstOrDefault(s=>s.Id==vacancy.StagesOfProjectId));
        }
        public PageEditVacancy()
        {
            InitializeComponent();
            ButtonSaveEdit.Visibility = Visibility.Hidden;
            ButtonAdd.Visibility = Visibility.Visible;
            _vacancy=new Vacancy();
            _stagesOfProjects = _stagesOfProjectService.Get();
            BoxStagesOfProject.ItemsSource = _stagesOfProjects;
        }
        private void OpenStages_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WriteData();
                if (FormValidator.AreAllElementsFilled(this))
                    throw new Exception();
                _vacancyService.Update(_vacancy);
                DataGridUpdater.UpdateDataGrid(_vacancyService.Get());
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
                _vacancyService.Create(_vacancy);
                DataGridUpdater.UpdateDataGrid(_vacancyService.Get());
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля корректно!");
            }

        }
        private void WriteData()
        {
            _vacancy.Name = Name.Text;
            _vacancy.Descriptions=Descriptions.Text;
            _vacancy.Responsibilities=Responsibilities.Text;
            _vacancy.DateStart = DateTime.Parse(DateStart.Text);
            _vacancy.DateEnd = DateEnd.Text == "" ? DateTime.Parse("1970/01/01") : DateTime.Parse(DateEnd.Text);
            _vacancy.Budjet = int.Parse(Budjet.Text);
            _vacancy.StagesOfProjectId = _stagesOfProjects.FirstOrDefault(i=>i==BoxStagesOfProject.SelectedItem).Id;
            _vacancy.isOpened = bool.Parse(IsOpened.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumberValidator.Validator(e);
        }
    }
}
